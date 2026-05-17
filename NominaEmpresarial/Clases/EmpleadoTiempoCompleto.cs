namespace NominaEmpresarial;

public class EmpleadoTiempoCompleto : Empleado
{
    protected double bonificacion;

    private const double PorcentajeBonificacion = 0.10;
    private const double PorcentajeSalud = 0.04;
    private const double PorcentajePension = 0.04;

  
    public EmpleadoTiempoCompleto(string nombre, string id, double salario)
        : base(nombre, id, salario)
    {
        bonificacion = CalcularBonificacion();
    }

    public double CalcularBonificacion()
    {
        return salarioBase * PorcentajeBonificacion;
    }

    public override double CalcularSalario()
    {
        return salarioBase + bonificacion;
    }

    public override double CalcularDescuentos()
    {
        double salarioBruto = CalcularSalario();
        return salarioBruto * (PorcentajeSalud + PorcentajePension);
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"Empleado      : {nombre}");
        Console.WriteLine($"ID            : {id}");
        Console.WriteLine($"Tipo          : Empleado Tiempo Completo");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Salario base  : ${salarioBase:N0}");
        Console.WriteLine($"Bonificación  : ${CalcularBonificacion():N0}  (10%)");
        Console.WriteLine($"Salario bruto : ${CalcularSalario():N0}");
        Console.WriteLine($"Descuentos    : ${CalcularDescuentos():N0}  (salud 4% + pensión 4%)");
        Console.WriteLine($"Salario neto  : ${CalcularSalarioNeto():N0}");
        Console.WriteLine("========================================\n");
    }
}

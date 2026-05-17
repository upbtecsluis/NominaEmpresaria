namespace NominaEmpresarial;

public class EmpleadoComision : Empleado
{
    protected double ventas;
    protected double porcentajeComision;

    private const double PorcentajeComisionDefault = 0.08;
    private const double PorcentajeSalud = 0.04;
    private const double PorcentajePension = 0.04;

  
    public EmpleadoComision(string nombre, string id, double salario, double ventas)
        : base(nombre, id, salario)
    {
        if (ventas < 0)
            throw new ArgumentException("Las ventas no pueden ser negativas.");

        this.ventas = ventas;
        this.porcentajeComision = PorcentajeComisionDefault;
    }

    public double CalcularComision()
    {
        return ventas * porcentajeComision;
    }

   
    public override double CalcularSalario()
    {
        return salarioBase + CalcularComision();
    }

  
    public override double CalcularDescuentos()
    {
        return CalcularSalario() * (PorcentajeSalud + PorcentajePension);
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"Empleado           : {nombre}");
        Console.WriteLine($"ID                 : {id}");
        Console.WriteLine($"Tipo               : Empleado por Comisión");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Salario base       : ${salarioBase:N0}");
        Console.WriteLine($"Ventas realizadas  : ${ventas:N0}");
        Console.WriteLine($"Comisión           : ${CalcularComision():N0}  (8%)");
        Console.WriteLine($"Salario bruto      : ${CalcularSalario():N0}");
        Console.WriteLine($"Descuentos         : ${CalcularDescuentos():N0}  (salud 4% + pensión 4%)");
        Console.WriteLine($"Salario neto       : ${CalcularSalarioNeto():N0}");
        Console.WriteLine("========================================\n");
    }
}


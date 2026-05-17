namespace NominaEmpresarial;

public class EmpleadoPorHoras : Empleado
{
    protected int horasTrabajadas;
    protected double valorHora;

    private const int LimiteHorasNormales = 160;
    private const double RecargoPorcentajeExtra = 0.15;   
    private const double PorcentajeSalud = 0.04;
    private const double PorcentajePension = 0.04;

    public EmpleadoPorHoras(string nombre, string id, int horas, double valorH)
        : base(nombre, id, 0)
    {
        if (horas <= 0)
            throw new ArgumentException("Las horas trabajadas deben ser mayores a 0.");
        if (valorH < 0)
            throw new ArgumentException("El valor por hora no puede ser negativo.");

        horasTrabajadas = horas;
        valorHora = valorH;
    }

    public double CalcularHorasExtras()
    {
        if (horasTrabajadas <= LimiteHorasNormales)
            return 0;

        int horasExtra = horasTrabajadas - LimiteHorasNormales;
        double valorHoraExtra = valorHora * (1 + RecargoPorcentajeExtra);
        return horasExtra * valorHoraExtra;
    }

    public override double CalcularSalario()
    {
        int horasNormales = Math.Min(horasTrabajadas, LimiteHorasNormales);
        double pagoNormal = horasNormales * valorHora;
        return pagoNormal + CalcularHorasExtras();
    }

    public override double CalcularDescuentos()
    {
        return CalcularSalario() * (PorcentajeSalud + PorcentajePension);
    }

    public override void MostrarInformacion()
    {
        int horasNormales = Math.Min(horasTrabajadas, LimiteHorasNormales);
        int horasExtra = Math.Max(0, horasTrabajadas - LimiteHorasNormales);

        Console.WriteLine("========================================");
        Console.WriteLine($"Empleado        : {nombre}");
        Console.WriteLine($"ID              : {id}");
        Console.WriteLine($"Tipo            : Empleado Por Horas");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Horas trabajadas: {horasTrabajadas}");
        Console.WriteLine($"  - Horas normales : {horasNormales}");
        Console.WriteLine($"  - Horas extras   : {horasExtra}");
        Console.WriteLine($"Valor por hora  : ${valorHora:N0}");
        Console.WriteLine($"Pago horas extra : ${CalcularHorasExtras():N0}  (recargo 15%)");
        Console.WriteLine($"Salario bruto   : ${CalcularSalario():N0}");
        Console.WriteLine($"Descuentos      : ${CalcularDescuentos():N0}  (salud 4% + pensión 4%)");
        Console.WriteLine($"Salario neto    : ${CalcularSalarioNeto():N0}");
        Console.WriteLine("========================================\n");
    }
}


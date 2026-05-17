using NominaEmpresarial;

IEmpleado emp1 = new EmpleadoTiempoCompleto(
    nombre: "Luis silva",
    id: "EMP-001",
    salario: 3_500_000
);


IEmpleado emp2 = new EmpleadoPorHoras(
    nombre: "lilian Uribe",
    id: "EMP-002",
    horas: 185,
    valorH: 15_000
);


IEmpleado emp3 = new EmpleadoComision(
    nombre: "Leslie Silva Uribe",
    id: "EMP-003",
    salario: 2_000_000,
    ventas: 5_000_000
);


IEmpleado emp4 = new EmpleadoPorHoras(
    nombre: "Loren Silva",
    id: "EMP-004",
    horas: 160,
    valorH: 12_500
);



List<IEmpleado> nomina = new List<IEmpleado> { emp1, emp2, emp3, emp4 };

Console.WriteLine(">>> REPORTE COMPLETO DE NÓMINA <<<\n");

foreach (IEmpleado empleado in nomina)
{
    empleado.MostrarInformacion();  
}



double totalNomina = 0;
foreach (IEmpleado empleado in nomina)
    totalNomina += empleado.CalcularSalarioNeto();

Console.WriteLine("╔══════════════════════════════════════════╗");
Console.WriteLine($"║  Total nómina a pagar : ${totalNomina,14:N0}  ║");
Console.WriteLine("╚══════════════════════════════════════════╝");


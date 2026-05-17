namespace NominaEmpresarial;

public interface IEmpleado
{
    double CalcularSalario();
    double CalcularDescuentos();
    double CalcularSalarioNeto();
    void MostrarInformacion();
}

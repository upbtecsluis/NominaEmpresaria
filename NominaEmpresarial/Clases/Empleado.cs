using NominaEmpresarial;

namespace NominaEmpresarial
{
    public abstract class Empleado : IEmpleado
    {
        // Atributos protegidos: accesibles por las subclases pero no desde afuera
        protected string nombre;
        protected string id;
        protected double salarioBase;

        
        public Empleado(string nombre, string id, double salarioBase)
        {
            if (salarioBase < 0)
                throw new ArgumentException("El salario base no puede ser negativo.");

            this.nombre = nombre;
            this.id = id;
            this.salarioBase = salarioBase;
        }

        public abstract double CalcularSalario();

  
        public abstract double CalcularDescuentos();

       
        public virtual double CalcularSalarioNeto()
        {
            return CalcularSalario() - CalcularDescuentos();
        }

       
        public abstract void MostrarInformacion();
    }
}

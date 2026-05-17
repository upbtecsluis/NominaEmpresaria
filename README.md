# 📋 Sistema de Nómina Empresarial

> **Taller II — Abstracción y Polimorfismo**  
> Programación Orientada a Objetos · C#

---

## 📌 Descripción

Sistema de cálculo de nómina empresarial desarrollado en C# aplicando los principios de **abstracción**, **polimorfismo** y **encapsulamiento**. El sistema permite calcular el salario mensual de tres tipos de empleados con reglas de negocio distintas, y está diseñado para escalar fácilmente con nuevos tipos sin modificar la lógica principal.

---

## 🏗️ Estructura del Proyecto

```
NominaEmpresarial/
│
├── IEmpleado.cs                  # Interfaz principal (contrato)
├── Empleado.cs                   # Clase abstracta base
├── EmpleadoTiempoCompleto.cs     # Clase concreta — tiempo completo
├── EmpleadoPorHoras.cs           # Clase concreta — por horas
├── EmpleadoComision.cs           # Clase concreta — por comisión
├── Program.cs                    # Punto de entrada del programa
└── README.md
```

---

## 🧱 Diagrama de Clases

```
          «interface»
          IEmpleado
  ┌─────────────────────────┐
  │ + calcularSalario()     │
  │ + calcularDescuentos()  │
  │ + calcularSalarioNeto() │
  │ + mostrarInformacion()  │
  └────────────┬────────────┘
               │ «implements»
               ▽
          «abstract»
          Empleado
  ┌─────────────────────────┐
  │ # nombre : string       │
  │ # id : string           │
  │ # salarioBase : double  │
  ├─────────────────────────┤
  │ + Empleado(...)         │
  │ + calcularDescuentos()  │
  │ + calcularSalarioNeto() │
  └──────────┬──────────────┘
             │ «extends»
    ┌─────────┼──────────┐
    ▽         ▽          ▽
EmpleadoTC  EmpleadoPH  EmpleadoCom
```

---

## 📂 Descripción de Archivos

### `IEmpleado.cs` — Interfaz
Define el **contrato** que deben cumplir todos los empleados del sistema.

```csharp
public interface IEmpleado
{
    double CalcularSalario();
    double CalcularDescuentos();
    double CalcularSalarioNeto();
    void   MostrarInformacion();
}
```

---

### `Empleado.cs` — Clase Abstracta
Implementa `IEmpleado`. Contiene los atributos comunes y define los métodos abstractos que cada subclase debe implementar obligatoriamente.

| Atributo | Tipo | Visibilidad |
|---|---|---|
| `nombre` | `string` | `protected` |
| `id` | `string` | `protected` |
| `salarioBase` | `double` | `protected` |

> ⚠️ Valida que el salario base no sea negativo en el constructor.

---

### `EmpleadoTiempoCompleto.cs` — Clase Concreta

| Concepto | Valor |
|---|---|
| Bonificación | 10% del salario base |
| Descuento salud | 4% del salario bruto |
| Descuento pensión | 4% del salario bruto |

**Fórmulas:**
```
Salario bruto = salarioBase + (salarioBase × 10%)
Descuentos    = salario bruto × 8%
Salario neto  = salario bruto - descuentos
```

---

### `EmpleadoPorHoras.cs` — Clase Concreta

| Concepto | Valor |
|---|---|
| Horas normales | Hasta 160 h/mes |
| Recargo horas extra | 15% adicional sobre valor hora |
| Descuento salud | 4% del salario bruto |
| Descuento pensión | 4% del salario bruto |

**Fórmulas:**
```
Pago normal      = horas normales × valorHora
Pago extra       = horas extra × (valorHora × 1.15)
Salario bruto    = pago normal + pago extra
Descuentos       = salario bruto × 8%
Salario neto     = salario bruto - descuentos
```

> ⚠️ Valida que las horas trabajadas sean mayores a 0.

---

### `EmpleadoComision.cs` — Clase Concreta

| Concepto | Valor |
|---|---|
| Comisión | 8% sobre ventas totales |
| Descuento salud | 4% del salario bruto |
| Descuento pensión | 4% del salario bruto |

**Fórmulas:**
```
Comisión      = ventas × 8%
Salario bruto = salarioBase + comisión
Descuentos    = salario bruto × 8%
Salario neto  = salario bruto - descuentos
```

> ⚠️ Valida que las ventas no sean negativas.

---

### `Program.cs` — Punto de Entrada
Crea instancias de los tres tipos de empleados usando la interfaz `IEmpleado`, y aplica **polimorfismo** recorriendo una lista para mostrar la información de cada uno.

```csharp
List<IEmpleado> nomina = new List<IEmpleado> { emp1, emp2, emp3, emp4 };

foreach (IEmpleado empleado in nomina)
{
    empleado.MostrarInformacion(); // polimorfismo en acción
}
```

---



## 💡 Ejemplo de Salida

```
╔══════════════════════════════════════════╗
║      SISTEMA DE NÓMINA EMPRESARIAL       ║
╚══════════════════════════════════════════╝

========================================
Empleado      : Laura Martínez
ID            : EMP-001
Tipo          : Empleado Tiempo Completo
----------------------------------------
Salario base  : $3,500,000
Bonificación  : $350,000  (10%)
Salario bruto : $3,850,000
Descuentos    : $308,000  (salud 4% + pensión 4%)
Salario neto  : $3,542,000
========================================

========================================
Empleado        : Juan Pérez
ID              : EMP-003
Tipo            : Empleado por Comisión
----------------------------------------
Salario base       : $2,000,000
Ventas realizadas  : $5,000,000
Comisión           : $400,000  (8%)
Salario bruto      : $2,400,000
Descuentos         : $192,000  (salud 4% + pensión 4%)
Salario neto       : $2,208,000
========================================
```

---

## 🎓 Conceptos Aplicados

| Concepto | Dónde se aplica |
|---|---|
| **Abstracción** | `IEmpleado` define qué debe hacer cada empleado sin importar cómo |
| **Polimorfismo** | `List<IEmpleado>` llama a `MostrarInformacion()` de cada tipo correctamente |
| **Encapsulamiento** | Todos los atributos son `protected`; acceso solo por métodos públicos |
| **Herencia** | Las 3 subclases extienden `Empleado` y heredan atributos y `CalcularSalarioNeto()` |
| **Interfaz** | `IEmpleado` garantiza que cualquier nuevo tipo cumpla el mismo contrato |

---



---

## 👨‍💻 Autor : Luis silva fuentes

> Taller desarrollado para la asignatura de **Programación Orientada a Objetos**

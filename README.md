# Best Practices Workshop - ASP.NET Core MVC

## Descripción del Proyecto

Este proyecto corresponde a la resolución del Taller de Mejores Prácticas y Patrones de Diseño en ASP.NET Core MVC. El objetivo principal fue analizar una aplicación existente para identificar problemas de diseño, aplicar principios SOLID y utilizar patrones de diseño que permitan mejorar la mantenibilidad, escalabilidad y flexibilidad del sistema.

La aplicación permite administrar vehículos y realizar operaciones como:

* Agregar vehículos.
* Encender motor.
* Apagar motor.
* Agregar combustible.
* Visualizar el estado de los vehículos.

---

# Objetivos del Taller

* Analizar el código proporcionado.
* Identificar problemas de diseño y arquitectura.
* Aplicar principios SOLID.
* Implementar patrones de diseño.
* Crear un nuevo modelo de vehículo utilizando Factory Method.
* Mantener la funcionalidad operativa sin depender de una base de datos real.

---

# Tecnologías Utilizadas

* ASP.NET Core MVC
* C#
* .NET 8
* Visual Studio Code
* Git
* GitHub

---

# Principios SOLID Aplicados

## 1. Single Responsibility Principle (SRP)

Cada clase posee una única responsabilidad:

| Clase                | Responsabilidad                         |
| -------------------- | --------------------------------------- |
| HomeController       | Gestionar solicitudes HTTP              |
| MyVehiclesRepository | Administrar almacenamiento de vehículos |
| FordMustangCreator   | Crear vehículos Mustang                 |
| FordExplorerCreator  | Crear vehículos Explorer                |
| FordEscapeCreator    | Crear vehículos Escape                  |
| CarBuilder           | Construir objetos Vehicle               |

---

## 2. Dependency Inversion Principle (DIP)

El controlador depende de una abstracción y no de una implementación concreta.

```csharp
private readonly IVehicleRepository _vehicleRepository;
```

La implementación se inyecta mediante Dependency Injection:

```csharp
services.AddTransient<IVehicleRepository, MyVehiclesRepository>();
```

Esto permite cambiar fácilmente entre almacenamiento en memoria o base de datos.

---

# Patrones de Diseño Implementados

## Repository Pattern

Permite abstraer el acceso a los datos mediante una interfaz común.

### Componentes

```text
IVehicleRepository
│
├── MyVehiclesRepository
└── DBVehicleRepository
```

### Beneficios

* Bajo acoplamiento.
* Facilidad para cambiar la fuente de datos.
* Mayor mantenibilidad.

---

## Factory Method

Utilizado para la creación de vehículos específicos.

### Componentes

```text
Creator
│
├── FordMustangCreator
├── FordExplorerCreator
└── FordEscapeCreator
```

### Beneficios

* Permite agregar nuevos modelos sin modificar el controlador.
* Cumple el principio Open/Closed.
* Facilita la extensión del sistema.

---

## Builder Pattern

Implementado mediante la clase:

```text
CarBuilder
```

Permite construir objetos de manera flexible.

Ejemplo:

```csharp
var builder = new CarBuilder();

return builder
    .SetBrand("Ford")
    .SetModel("Escape")
    .SetColor("Red")
    .Build();
```

### Beneficios

* Facilita la incorporación de nuevas propiedades.
* Reduce modificaciones futuras.
* Mejora la legibilidad del código.

---

## Singleton Pattern

Implementado mediante:

```text
VehicleCollection
```

Permite mantener una única colección de vehículos en memoria durante toda la ejecución de la aplicación.

---

# Nuevo Requerimiento Implementado

Se implementó un nuevo modelo utilizando Factory Method.

## Ford Escape

Características:

| Propiedad | Valor  |
| --------- | ------ |
| Marca     | Ford   |
| Modelo    | Escape |
| Color     | Red    |

### Clase Implementada

```text
FordEscapeCreator.cs
```

---

# Estructura del Proyecto

```text
BestPractices
│
├── Controllers
│   └── HomeController.cs
│
├── Models
│   ├── Vehicle.cs
│   ├── Car.cs
│   └── HomeViewModel.cs
│
├── Repositories
│   ├── IVehicleRepository.cs
│   ├── MyVehiclesRepository.cs
│   └── DBVehicleRepository.cs
│
├── ModelBuilders
│   └── CarBuilder.cs
│
├── Infraestructure
│   ├── Factories
│   │   ├── Creator.cs
│   │   ├── FordMustangCreator.cs
│   │   ├── FordExplorerCreator.cs
│   │   └── FordEscapeCreator.cs
│   │
│   ├── DependencyInjection
│   │   └── ServicesConfiguration.cs
│   │
│   └── Singletons
│       └── VehicleCollection.cs
│
└── Views
    └── Home
        └── Index.cshtml
```

---

# Ejecución del Proyecto

## Restaurar dependencias

```bash
dotnet restore
```

## Compilar

```bash
dotnet build
```

## Ejecutar

```bash
dotnet run
```

La aplicación se ejecutará en:

```text
https://localhost:5001
```

o

```text
http://localhost:5000
```

---

# Evidencia de Funcionamiento

La aplicación permite:

* Agregar Mustang.
* Agregar Explorer.
* Agregar Escape.
* Encender vehículos.
* Apagar vehículos.
* Agregar combustible.
* Visualizar el estado actual de cada vehículo.

---

# Conclusiones

La solución implementada permite aplicar buenas prácticas de desarrollo mediante la utilización de principios SOLID y patrones de diseño. La arquitectura obtenida facilita el mantenimiento del sistema, reduce el acoplamiento entre componentes y permite incorporar nuevos modelos de vehículos sin modificar la lógica existente.

Además, la utilización de Repository Pattern, Factory Method, Builder Pattern y Singleton Pattern proporciona una solución escalable y preparada para futuras ampliaciones del sistema.

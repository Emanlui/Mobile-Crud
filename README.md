# Proyecto de Registro y control de extintores

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)


Sistema de manejo de inventario de extintores móvil, este contiene únicamente funcionalidades para CRUD de extintores.

## Primeros pasos

Aquí encontrará las instrucciones que le permitirán tener una copia del proyecto y correrla en su máquiana local para el futuro desarrollo e implementación. Le recomendamos tener a mano los distintos manuales que brindarán información a profundidad del sistema.

### Prerequisitos

```
Visual Studio 2019
```

### Instalación

Aquí encontrará los pasos para configurar el ambiente de desarrollo y ponerlo a funcionar

- Instalar Visual Studio

```
Primero, deberá descargar Visual Studio: https://visualstudio.microsoft.com/es/downloads/
Recomendamos la versión "Community" que es de uso gratuito. 
```

- Seguidamente, deberá clonar este repositorio a una carpeta local

```
git clone https://github.com/Emanlui/Registro-y-control-de-extintores-Movil.git
```
- Abrir el archivo .sln en visual studio, este se reconocerá por el programa.

- Para ejecutar el proyecto, necesitará instalar varios nuggets, tales como:
```
MySqlConnector
Xamarin.Forms
Xamarin.esentials
System.componentModel.Annotations
Xam.plugins.settings
Android emulator
SDK para android, del 5.1 hasta el actual (encontrado en Tools/Android/Android SDK manager)
El $(TargetFrameworkVersion) debe de cambiar, este se lo puede pedir visual o no
```
Finalmente en el .csproj se debe de cambiar la siguiente línea, esto se ocupa para que el ambiente de trabajo reconozca el path del proyecto
```
<IntermediateOutputPath>C:\Users\path\del\proyecto\Registro-y-control-de-extintores-Movil\Registro-y-control-de-extintores-Movil</IntermediateOutputPath>
<UseShortFileNames>True</UseShortFileNames>
```

Ahora el proyecto está listo para correrse

## Creado con

* [Xamarin](https://docs.microsoft.com/en-us/xamarin/android/) - El framework utilizado
* [Visual Studio 2019](https://visualstudio.microsoft.com/es/downloads/) - Manejo de dependencias

## FAQ
* En caso de encontrar errores en la ejecución del programa, este puede ser causa del problemas a la hora de realizar los pasos especificados arriba

## Autores

* **Emanuelle Jiménez Sancho** - *Desarrollador de Software* - [Emanlui](https://github.com/Emanlui)

* **Kevin Ledezma Jiménez** - *Desarrollador de Software* - [Elesvan20](https://github.com/Elesvan20)

* **Fabrizio Alvarado Barquero** - *Desarrollador de Software* - [faoalvarado5](https://github.com/faoalvarado5)

## Agradecimientos

* A los empleados Mónica Quesada Bermúdez, Ana María Morera Castro y Yourks Arroyo Guzmán del departamento de Salud Ocupacional del Ministerio de Seguridad Pública de Costa Rica, por permitirnos colaborar con la elaboración de este proyecto y su atento seguimiento durante cada reunión.
* Al empleado Joaquín Soto Rojas de la Dirección de Tecnologías de Información, Departamento de Sistemas por el cercano seguimiento técnico durante el desarrollo del proyecto.
* A la profesora María Estrada Sánchez y Aurelio Sanabria Rodríguez de la facultad de Ingeniería en Computación del Instituto Tecnológico de Costa Rica por brindarnos la oportunidad de trabajar en un proyecto con los estándares que nos brindaron.
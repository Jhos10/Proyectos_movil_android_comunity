# 📱 .NET MAUI Masterclass: De XAML a Arquitectura MVVM con SQLite

![.NET 8.0](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)
![MVVM](https://img.shields.io/badge/Pattern-MVVM-008080?style=for-the-badge)

> **Taller Práctico y Proyecto Integrador** desarrollado para la materia de Programación Móvil en la Facultad de Ingeniería de la Universidad Libre.

Este repositorio documenta un viaje técnico progresivo a través del framework **.NET MAUI**. Contiene 5 aplicaciones completas que evolucionan desde el manejo básico de eventos e interfaces responsivas, hasta la implementación de patrones de diseño empresariales y persistencia de datos relacionales en dispositivos móviles.

---

## 📑 Tabla de Contenidos
1. [Arquitectura y Decisiones de Diseño](#-arquitectura-y-decisiones-de-diseño)
2. [Catálogo de Aplicaciones](#-catálogo-de-aplicaciones)
3. [Alineación Académica (Rúbrica)](#-alineación-académica-rúbrica-de-evaluación)
4. [Guía de Despliegue Local](#-guía-de-despliegue-local)
5. [Autor y Portafolio](#-autor-y-portafolio)

---

## 🏗 Arquitectura y Decisiones de Diseño

A lo largo del taller, la base de código transiciona de un enfoque monolítico (*Code-Behind*) a una arquitectura limpia y desacoplada utilizando **MVVM (Model-View-ViewModel)**.

* **Capa de Presentación (View):** Construida 100% en `XAML`, utilizando `Grid` y `StackLayouts` para garantizar la responsividad. Se implementaron `DataTriggers` y `Bindings` para reaccionar a los cambios de estado sin tocar la lógica.
* **Capa Lógica (ViewModel):** Potenciada por `CommunityToolkit.Mvvm`. El uso de Source Generators (`[ObservableProperty]`, `[RelayCommand]`) redujo drásticamente el código repetitivo (*boilerplate*), mejorando la legibilidad y el mantenimiento.
* **Capa de Datos (Model & Services):** Implementación del patrón de Repositorio (Repository Pattern) a través de `DatabaseService`, inyectado como un Singleton en `MauiProgram.cs` para garantizar una única conexión asíncrona a la base de datos **SQLite**.

---

## 📦 Catálogo de Aplicaciones

### 1️⃣ Mi Primera App (Hello World Extendido)
Fundamentos del ciclo de vida de MAUI. Se enfoca en la interacción directa entre el XAML y el Code-Behind, validación de cadenas de texto y manipulación dinámica de propiedades visuales.
* **Stack:** `VerticalStackLayout`, `Entry`, Eventos `Clicked`.

### 2️⃣ Mini Calculadora (Layouts Avanzados)
Diseño de una interfaz estructurada y control de excepciones lógicas. Se implementaron validaciones estrictas (como el bloqueo de división entre cero) y teclados optimizados para móviles.
* **Stack:** `Grid` (Proporciones relativas), `Picker`, `Keyboard="Numeric"`, Bloques `Try-Catch`.

### 3️⃣ Clima App (Introducción al Data Binding)
El punto de inflexión arquitectónico. Se elimina la manipulación directa de la UI en favor de la interfaz `INotifyPropertyChanged`, demostrando cómo la vista reacciona automáticamente a la mutación de los datos subyacentes.
* **Stack:** `BindingContext`, `StringFormat`, Modelos Reactivos.

### 4️⃣ To-Do List (Colecciones y Estado Local)
Gestión de listas dinámicas y persistencia en la memoria del dispositivo. Introduce disparadores visuales para alterar el diseño (ej. texto tachado) basados en el estado de una propiedad booleana.
* **Stack:** `CollectionView`, `CommunityToolkit.Mvvm`, `DataTrigger`, `Microsoft.Maui.Storage.Preferences` (Serialización JSON).

### 5️⃣ Agenda de Contactos (CRUD Completo con SQLite)
Proyecto integrador. Una aplicación lista para producción con almacenamiento en disco duro del móvil, inyección de dependencias, y experiencia de usuario avanzada nativa.
* **Stack:** `sqlite-net-pcl`, `SwipeView` (Gestos de borrado), `SearchBar` (Filtrado asíncrono LINQ), `DisplayAlert` (Confirmaciones modales).



## 🚀 Guía de Despliegue Local

### Requisitos Previos
* **Visual Studio 2022** (v17.8+ recomendada) o Rider.
* Carga de trabajo instalada: *Desarrollo de la IU de aplicaciones multiplataforma de .NET*.
* Emulador Android (API 33+) o dispositivo físico con Depuración USB activa.

### Instalación
1. Clona el repositorio:
   ```bash
   git clone [https://github.com/tu-usuario/Taller-MAUI-Net.git](https://github.com/tu-usuario/Taller-MAUI-Net.git)

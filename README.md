 # Entregable Final - Aplicaciones Móviles (.NET MAUI)

    Este repositorio contiene un conjunto de aplicaciones móviles desarrolladas utilizando **.NET MAUI** como parte
  del proyecto de entregable final. Cada carpeta representa una aplicación independiente diseñada para demostrar
  conceptos específicos del desarrollo móvil, como la arquitectura MVVM, persistencia de datos (SQLite, Preferences),
  validación de formularios, consumo de datos y maquetación de interfaces responsivas.

    ---

    ## 📂 Estructura del Repositorio

    A continuación se detalla el propósito y las características principales de cada una de las aplicaciones
  incluidas:

    ### 1. 📔 [AgendaMAUI](./AgendaMAUI)
    Una aplicación completa de agenda de contactos con almacenamiento persistente local.
    *   **Descripción:** Permite a los usuarios gestionar su lista de contactos personales mediante operaciones CRUD
  (Crear, Leer, Actualizar y Eliminar).
    *   **Características Clave:**
        *   **Persistencia de datos:** Utiliza una base de datos local SQLite asíncrona para guardar contactos
  permanentemente.
        *   **Búsqueda en tiempo real:** Barra de búsqueda (`SearchBar`) para filtrar la lista por nombre o número
  telefónico.
        *   **Gestos interactivos:** Implementa `SwipeView` en la lista para permitir la edición o eliminación de
  contactos al deslizar el dedo.
        *   **Mapeo de datos:** El modelo de contacto registra el nombre, teléfono, correo electrónico y fecha de
  creación.
    *   **Archivos Importantes:**
        *   [Contact.cs](./AgendaMAUI/AgendaMAUI/Models/Contact.cs): Define la estructura y atributos de la tabla de
  contactos en SQLite.
        *   [DatabaseService.cs](./AgendaMAUI/AgendaMAUI/Services/DatabaseService.cs): Maneja la lógica de conexión y
  operaciones de base de datos.
        *   [MainPage.xaml](./AgendaMAUI/AgendaMAUI/MainPage.xaml): Interfaz visual de la lista y la barra de
  búsqueda.
        *   [ContactFormPage.xaml](./AgendaMAUI/AgendaMAUI/Views/ContactFormPage.xaml): Formulario para crear y
  actualizar contactos.

    ---

    ### 2. ☀️ [ClimaAppMAUI](./ClimaAppMAUI)
    Una aplicación interactiva para visualizar y simular las condiciones climáticas.
    *   **Descripción:** Muestra datos sobre el clima (temperatura, humedad y condiciones actuales) simulando
  actualizaciones de red dinámicas.
    *   **Características Clave:**
        *   **Enlace de datos (Data Binding):** Enlaza la interfaz con una clase modelo que implementa la interfaz
  `INotifyPropertyChanged` para refrescar la vista en tiempo real cuando cambian los datos.
        *   **Simulación Dinámica:** Al presionar "Actualizar Clima", se generan de manera segura valores aleatorios
  para temperatura, humedad y condiciones atmosféricas (Soleado, Nublado, Lluvioso, etc.).
        *   **Control de errores:** Manejo estructurado de excepciones al actualizar el estado de la aplicación.
    *   **Archivos Importantes:**
        *   [WeatherData.cs](./ClimaAppMAUI/ClimaAppMAUI/WeatherData.cs): Modelo de datos del clima con soporte de
  notificaciones de propiedad cambiada.
        *   [MainPage.xaml](./ClimaAppMAUI/ClimaAppMAUI/MainPage.xaml): Interfaz de usuario estructurada con
  indicadores de temperatura y humedad en dos columnas.
        *   [MainPage.xaml.cs](./ClimaAppMAUI/ClimaAppMAUI/MainPage.xaml.cs): Lógica detrás de la actualización
  simulada.

    ---

    ### 3. 📝 [ListaTareaMAUI](./ListaTareaMAUI)
    Un gestor de tareas pendientes (To-Do List) con arquitectura MVVM moderna.
    *   **Descripción:** Permite a los usuarios llevar un registro de sus tareas diarias, permitiendo agregarlas,
  marcarlas como completadas y eliminarlas.
    *   **Características Clave:**
        *   **MVVM Avanzado:** Implementado con el paquete oficial `CommunityToolkit.Mvvm`, utilizando atributos
  modernos como `[ObservableProperty]` y `[RelayCommand]` para generar código limpio y desacoplado.
        *   **Persistencia Ligera:** Guarda la lista de tareas en las preferencias del dispositivo (`Preferences`)
  serializándolas en formato JSON.
        *   **Inicialización:** Precarga tareas por defecto la primera vez que se abre la aplicación.
    *   **Archivos Importantes:**
        *   [TaskItem.cs](./ListaTareaMAUI/ListaTareaMAUI/Models/TaskItem.cs): Estructura de cada tarea (ID, Nombre,
  Estado de finalización y Fecha).
        *   [MainViewModel.cs](./ListaTareaMAUI/ListaTareaMAUI/ViewModels/MainViewModel.cs): Modelo de vista
  encargado de la lógica de negocio (cargar, agregar y eliminar tareas).
        *   [MainPage.xaml](./ListaTareaMAUI/ListaTareaMAUI/MainPage.xaml): Vista en XAML que enlaza la colección de
  tareas y las acciones.

    ---

    ### 4. 🚀 [Mi_primera_app](./Mi_primera_app)
    Aplicación introductoria para el aprendizaje de las bases de .NET MAUI.
    *   **Descripción:** Un proyecto introductorio simple que interactúa con el usuario solicitando su nombre y
  mostrando un saludo en pantalla.
    *   **Características Clave:**
        *   **Validación básica:** Comprueba que el campo de texto no esté vacío antes de generar el saludo.
        *   **Retroalimentación visual dinámica:** Cambia el color del texto a verde si el saludo es exitoso, o a
  rojo para mostrar mensajes de advertencia si la entrada es inválida.
    *   **Archivos Importantes:**
        *   [MainPage.xaml](./Mi_primera_app/Mi_primera_app/MainPage.xaml): Diseño del campo de entrada (`Entry`), el
  botón de saludo y la etiqueta de resultado.
        *   [MainPage.xaml.cs](./Mi_primera_app/Mi_primera_app/MainPage.xaml.cs): Lógica del evento del botón y
  validaciones de texto.

    ---

    ### 5. 🧮 [MiniCalculadora](./MiniCalculadora)
    Una calculadora matemática rápida y segura.
    *   **Descripción:** Permite realizar operaciones aritméticas básicas entre dos números seleccionando la
  operación correspondiente desde un selector (`Picker`).
    *   **Características Clave:**
        *   **Operaciones soportadas:** Suma, Resta, Multiplicación y División.
        *   **Robustez y Seguridad:**
            *   Previene errores de ejecución al validar que ambos campos contengan números válidos.
            *   Implementa una validación crucial para **evitar la división por cero**, mostrando un mensaje de error
  claro en su lugar.
            *   Maneja bloques try-catch globales para evitar cierres inesperados de la aplicación.
        *   **Formateo Numérico:** Muestra el resultado final redondeado a 2 cifras decimales.
    *   **Archivos Importantes:**
        *   [MainPage.xaml](./MiniCalculadora/MiniCalculadora/MainPage.xaml): Disposición de los controles usando un
  `Grid` con teclado configurado únicamente como numérico.
        *   [MainPage.xaml.cs](./MiniCalculadora/MiniCalculadora/MainPage.xaml.cs): Lógica de cálculo y validaciones
  de errores.

    ---

    ## 🛠️ Tecnologías y Librerías Utilizadas

    *   **.NET 8.0 y .NET MAUI:** Plataforma principal para el desarrollo de aplicaciones multiplataforma.
    *   **SQLite-net-pcl:** Para la base de datos local ligera y asíncrona en *AgendaMAUI*.
    *   **CommunityToolkit.Mvvm:** Herramientas para la implementación eficiente del patrón MVVM en *ListaTareaMAUI*.
    *   **System.Text.Json:** Para serializar y deserializar colecciones de objetos en almacenamiento local.

    ---

    ## 🚀 Cómo Ejecutar los Proyectos

    1.  Asegúrate de tener instalado **Visual Studio 2022** con la carga de trabajo de **Desarrollo de la interfaz de
  usuario multiplataforma de .NET (.NET MAUI)**.
    2.  Clona este repositorio o descarga los archivos en tu máquina local.
    3.  Abre el archivo de solución de cualquiera de las aplicaciones (`.slnx` o `.sln` en sus respectivas carpetas)
  con Visual Studio.
    4.  Restaura los paquetes NuGet si es necesario.
    5.  Selecciona el dispositivo de destino (Windows Machine, Emulador de Android o Simulador de iOS) y presiona
  **F5** o el botón de ejecutar.


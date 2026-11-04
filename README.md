# Estructuras de información

Repositorio de ejercicios de consola en C# para practicar estructuras de datos y algoritmos básicos. Cada ejercicio es un proyecto independiente; los datos de prueba están definidos dentro de los programas, salvo el ejercicio de búsqueda del arreglo, que solicita un valor por consola.

## Contenido

### `ParteArreglos`

- **Ej1A:** búsqueda lineal de un valor en un arreglo; muestra su índice o `-1` si no está.
- **Ej2A:** suma los elementos de un arreglo.
- **Ej3A:** invierte el orden de los elementos de un arreglo e imprime el antes y el después.
- **Ej4A:** mueve los ceros al final del arreglo, conservando el orden de los valores distintos de cero.
- **Ej5A:** encuentra el número faltante en la secuencia de enteros del 1 al tamaño del arreglo mediante la diferencia de sumas.

### `ParteListas`

- **Ej1L:** implementa una lista enlazada simple con inserción al final e impresión.
- **Ej2_3_4L:** agrupa operaciones de lista enlazada: agregar al final, invertir, obtener el nodo N desde el final y quitar duplicados consecutivos de una lista ordenada.
- **Ej5L:** detecta si una lista enlazada contiene un ciclo usando dos referencias que avanzan a distinta velocidad.

### `PilasColas`

- **1Rocket:** pila enlazada con capacidad máxima; muestra el comportamiento al apilar y desapilar elementos.
- **2Canciones:** cola que simula una lista de reproducción circular, reproduciendo canciones en orden.
- **3Groot:** invierte una cola usando una pila auxiliar.
- **4Drax:** busca y retira un elemento de una pila, usando otra pila para conservar los elementos restantes.
- **5Nebula:** implementa una cola usando dos pilas.
- **6Coleccionista:** ordena los elementos de una pila con ayuda de una pila auxiliar.
- **Nave7:** cola genérica de nodos para distribuir energía por turnos entre los sectores de una nave hasta completar sus escudos.

## Requisitos

- .NET SDK compatible con el `TargetFramework` indicado en el archivo `.csproj` del ejercicio que se quiera ejecutar. El proyecto `Nave7` apunta a .NET 8; los proyectos revisados de las otras carpetas apuntan a .NET 10.

## Ejecución

Desde la raíz del repositorio, ejecuta el proyecto deseado con `dotnet run --project` y la ruta a su archivo `.csproj`. Por ejemplo:

```bash
dotnet run --project ParteArreglos/Ej1A/Ej1A.csproj
dotnet run --project ParteListas/Ej2_3_4L/Ej2_3_4L.csproj
dotnet run --project PilasColas/1Rocket/1Rocket.csproj
```

Reemplaza la ruta por la del ejercicio que quieras probar. `PilasColas` también incluye su propia solución, `PilasColas/PilasYColas.slnx`.

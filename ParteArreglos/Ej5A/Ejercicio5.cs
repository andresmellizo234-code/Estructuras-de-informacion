using System;

namespace Ej5A
{
    class Program 
    {
        static void Main(string[] args)
        {
            int[] arreglo = {1,2,3,4,5}; //arreglo de enteros
            int N = 5; // tamaño del arreglo
            int sumaideal = N * (N + 1) / 2; // suma ideal de los primeros N enteros
            int sumareal = 0; // variable para almacenar la suma real de los elementos del arreglo
            for (int i = 0; i < N; i++) // recorrer el arreglo
            {
                sumareal += arreglo[i]; // se suma cada elemento del arreglo a sumareal
            }

            int faltante = sumaideal - sumareal; // se calcula el número faltante
            Console.WriteLine("El número faltante es: " + faltante); // se imprime
        }
    }
}

//dotnet run --project ParteArreglos/Ej5A
using System;

namespace Ej2A
{
    class Program 
    {
        static void Main(string[] args)
        {
            const int N = 5;
            int suma = 0;
            int [] arreglo2 = {7,5,4,1,3};
            Console.Write("La suma es: ");
            
            // Bucle que suma todos los elementos del arreglo
            for(int i = 0; i<N; i++)
            {
                suma += arreglo2[i];
            }
            Console.Write(suma);
        }
    }
}


//dotnet run --project ParteArreglos/Ej2A

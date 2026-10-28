using System;

namespace Ej3A
{
    class Program 
    {
         static void Main(string[] args)
        {
            
            const int N = 5;
            int [] arreglo2 = {7,5,4,1,3};
            int inicio = 0;
            int final = arreglo2.Length-1;
            Console.Write("Antes de intercambiar: ");
            Imprimir(arreglo2); // Funcion para imprimir los elementos del arreglo
            // Bucle que invierte los arreglos
            for (int i = 0; i < N; i++)
            {
                if(inicio>=final) // Si se cumple la condición ya se han invertido todos los elementos
                {
                    break;
                }
                // Intercambio de los elementos en el arreglo
                int temp1 = arreglo2[inicio];
                arreglo2[inicio]=arreglo2[final];
                arreglo2[final]=temp1;
                inicio++;
                final--;
            }
            Console.Write("Después de intercambiar: ");
            Imprimir(arreglo2);// Funcion para imprimir los elementos del arreglo
        }
        // Imprimir los elementos de los arreglos
        static void Imprimir(int [] a)
        {
            int N=a.Length;
            for(int i=0;i<N;i++)
            {
                Console.Write(a[i]+" ");
            }
            Console.WriteLine("");
        }
    }
}


//dotnet run --project ParteArreglos/Ej3A

using System;

namespace Ej1A
{
    class Program 
    {
        static void Main(string[] args)
        {
            const int N = 5;
            int [] arreglo1 = {7,5,4,1,3};
            Console.Write("Escribe el valor: ");
            int valor = int.Parse(Console.ReadLine()); // Pedir el valor que se quiere buscar en la lista
            for(int i = 0; i<N; i++)
            {
                if (valor==arreglo1[i])
                {
                    Console.Write(i);
                    break;
                }
                if(i==4)
                {
                    Console.Write("-1");   
                }
            }
        }
    }
}


//dotnet run --project ParteArreglos/Ej1A

using System;

namespace Ej4A
{
    class Program 
    {
        static void Main(string[] args)
        {
            int[] miArreglo = { 1, 0, 3, 0, 12, 5, 0 };
            Console.WriteLine(string.Join(", ", miArreglo));
            MoverCerosAlFinal(miArreglo);
            Console.WriteLine(string.Join(", ", miArreglo));
        } 
        // Tu función abajo
        static int[] MoverCerosAlFinal(int[] arreglo)
        {
            int idxNoCero = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] != 0)
                {
                    arreglo[idxNoCero] = arreglo[i];
                    idxNoCero++;
                }
            }
            for (int i = idxNoCero; i < arreglo.Length; i++)
            {
                arreglo[i] = 0;
            }
            return arreglo;
        }

    }
}


//dotnet run --project ParteArreglos/Ej4A
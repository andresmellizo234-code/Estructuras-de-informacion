using System;
using System.Security.Cryptography.X509Certificates;

namespace Nebula
{    
    class Nodo { // Clase para crear Nodo
    public int valor; // Guarda el valor del Nodo
    public Nodo? siguiente; //Guarda el siguiente nodo

    // Constructor
        public Nodo(int val)
        {
            this.valor = val;
            this.siguiente = null;
        }    
    }

    class Program 
    {
        
        static void Main(string[] args)
        {
            // Crear Cola
            ColaNebula cola = new ColaNebula();
            
            cola.Enfilar(10);
            cola.Enfilar(20);
            cola.Sacar();
            cola.Enfilar(30);
            cola.Enfilar(40);
            cola.Sacar();
            cola.Sacar();
            cola.Sacar();
        }

        public class ColaNebula // Clase Cola
        {
            // Se crean dos Pilas con las que funciona la cola
            Pila pilaEntrada = new Pila();
            Pila pilaSalida = new Pila();
            
            // Metodo para enfilar
            public void Enfilar(int dato)
            {
                pilaEntrada.Apilar(dato); // Usa la pila de entrada
            }

            // Metodo para Sacar
            public void Sacar() 
            {
                if (pilaSalida.Vacia()) // Revisa si la pila de Salida está vacía
                {
                    if(pilaEntrada.Vacia()) // Revisa si la pila de Entrada está vacía
                    {
                        return; // Si ambas estan vacías no hay nada que sacar
                    }
                    while(true) // Ya que la pila de salida está vacía, pasa todos los elementos de la pila de entrada a la de salida
                    {
                        int? dato = pilaEntrada.Sacar();
                        if(dato==null)
                        {
                            break; //Se detiene cuando ya se pasaron todos los elementos a la segunda pila
                        }
                        pilaSalida.Apilar(dato.Value);
                    }
                }
                Console.WriteLine($"- {pilaSalida.Sacar()}");// Imprime el elemento que se sacó               
            }
        }

        public class Pila // Clase para crear una pila
        {
            Nodo? PrimerNodoPila;

            // Método para apilar
            public void Apilar(int dato)
            {
                Nodo nuevoNodo = new Nodo(dato);
                nuevoNodo.siguiente = PrimerNodoPila;
                PrimerNodoPila = nuevoNodo;                
            }

            // Método para Sacar de la pila
            public int? Sacar() 
            {
                if (PrimerNodoPila == null) return null;
                int dato = PrimerNodoPila.valor;

                PrimerNodoPila = PrimerNodoPila.siguiente;
                return dato;
            }

            // Método para verificar si está vacía o no una pila
            public Boolean Vacia()
            {
                return PrimerNodoPila==null;
            }
            // Método para imprimir en la pila
        }
    }
}

// dotnet new sln -n TareaSemana1
// dotnet new console -n Ejercicio1
// dotnet sln add Ejercicio1/Ejercicio1.csproj
// dotnet run --project 5Nebula


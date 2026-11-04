using System;
using System.Globalization;

namespace Drax
{
    class Nodo { // Clase para crear Nodo
    public String arma; //Guarda el nombre del arma
    public Nodo? siguiente; //Guarda el siguiente nodo

    // Constructor
        public Nodo(String nombreArma)
        {
            this.arma = nombreArma;
            this.siguiente = null;
        }
    
    }
    class Program 
    {
        static void Main(string[] args)
        {
            // Crea la pila de las armas de Drax y la pila auxiliar
            Pila miPila = new Pila();
            Pila pilaAuxiliar = new Pila();
            // Se apilan las armas
            miPila.Apilar("Pistola de Fuego");
            miPila.Apilar("Espada de hielo");
            miPila.Apilar("Dagas de Vibranium");     
            miPila.Apilar("Gema del espacio");            
            miPila.Apilar("Bomba de humo");
            Console.WriteLine("Orden inicial: ");
            miPila.Imprimir(); // Se imprime el orden inicial

            while (true) //Bucle que busca las "Dagas de vibranium"
            {
                string? item = miPila.Sacar(); // Saca las armas una por una
                if(item == "Dagas de Vibranium") // Si encuentra el arma lo saca del bucle
                {
                    Console.WriteLine("Dagas de Vibranium encontradas.");
                    break;
                }
                if(item == null)// Si llega al final de la pila y no encuentra nada lo saca del bucle
                {
                    Console.WriteLine("No se encontró el arma");
                    break;
                }
                pilaAuxiliar.Apilar(item); // Se van apilando las armas en la pila auxiliar
            }
            while (true) //Se reorganizan las armas, regresando a la pila inicial
            {
                string? item = pilaAuxiliar.Sacar();
                if(item == null)
                {
                    break;
                }
                miPila.Apilar(item);
            }
            Console.WriteLine("Orden final: ");
            miPila.Imprimir(); // Se imprime el orden despues de sacar el arma

        }
        public class Pila // Clase para crear una pila
        {
            Nodo? primeroDeLaPila;

            // Método para apilar (Push)
            public void Apilar(String arma) 
            {
                Nodo nuevoNodo = new Nodo(arma);

                nuevoNodo.siguiente = primeroDeLaPila;

                primeroDeLaPila = nuevoNodo;

            }

            // Método combinado para sacar y ver primero (Pop)
            public String? Sacar() 
            {
                if (primeroDeLaPila == null) return null;

                String dato = primeroDeLaPila.arma;

                primeroDeLaPila = primeroDeLaPila.siguiente;
                return dato;

            }
            // Método para imprimir la pila
            public void Imprimir()
            {
                // Empezamos apuntando al primer nodo de la pila
                Nodo? actual = primeroDeLaPila;

                // Mientras el nodo actual exista (no sea null), imprimimos y avanzamos
                while (actual != null)
                {
                    Console.WriteLine($"- {actual.arma}");
                    actual = actual.siguiente; // Avanzamos a la siguiente arma
                }
            }
        }
    }
}
// dotnet run --project 4Drax
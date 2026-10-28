using System;


    // 1. Clase que representa cada nodo de la lista
    public class Nodo
    {
        public int Valor;
        public Nodo Siguiente; // Referencia al próximo nodo

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null; // Al crearse, nace desconectado
        }
    }

    //  Clase que administra la estructura de la Lista Enlazada
    public class ListaEnlazada
    {
        public Nodo Cabeza; // Guarda la referencia al primer nodo

        public ListaEnlazada()
        {
            Cabeza = null; // La lista inicia vacía
        }

        // Método InsertAtEnd
        public void InsertAtEnd(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            // Si la lista está vacía, el nuevo nodo se convierte en la Cabeza
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                //Si no está vacía, recorremos hasta encontrar el último nodo
                Nodo actual = Cabeza;

                // Avanzamos mientras exista un nodo siguiente
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }

                // Al salir del ciclo actual es el último nodo. Le conectamos el nuevoNodo.
                actual.Siguiente = nuevoNodo;
            }
        }

        // Método auxiliar para visualizar la lista en la consola
        public void Imprimir()
        {
            Nodo actual = Cabeza;
            while (actual != null)
            {
                Console.Write(actual.Valor + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }
    }

    // Programa Principal para probar la lista
    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            // Insertamos elementos al final
            lista.InsertAtEnd(10);
            lista.InsertAtEnd(20);
            lista.InsertAtEnd(30);

            // Imprimimos la lista resultante
            Console.WriteLine("Estado final de la lista enlazada:");
            lista.Imprimir();
        }
    }

//dotnet run --project ParteListas/Ej1L
//5.

using System;

// Creamos la clase Nodo.
// Cada nodo guarda un número y una referencia al siguiente nodo.
class Nodo
{
    public int dato;
    public Nodo siguiente;

    public Nodo(int dato)
    {
        this.dato = dato;
        siguiente = null;
    }
}

class Program
{
    // Método que detecta si existe un bucle.
    static bool DetectarBucle(Nodo inicio)
    {
        // Ambos comienzan en el primer nodo.
        Nodo lento = inicio;
        Nodo rapido = inicio;

        // Mientras rápido y su siguiente nodo existan...
        while (rapido != null && rapido.siguiente != null)
        {
            // La tortuga avanza un paso.
            lento = lento.siguiente;

            // La liebre avanza dos pasos.
            rapido = rapido.siguiente.siguiente;

            // Si coinciden, existe un bucle.
            if (lento == rapido)
            {
                return true;
            }
        }

        // Si la liebre llega al final, no hay bucle.
        return false;
    }

    static void Main(string[] args)
    {
        // Creamos cuatro nodos.
        Nodo n1 = new Nodo(1);
        Nodo n2 = new Nodo(2);
        Nodo n3 = new Nodo(3);
        Nodo n4 = new Nodo(4);

        // Conectamos los nodos.
        n1.siguiente = n2;
        n2.siguiente = n3;
        n3.siguiente = n4;

        // Creamos un bucle:
        // el nodo 4 vuelve al nodo 2.
        n4.siguiente = n2;

        // Comprobamos si existe un bucle.
        bool resultado = DetectarBucle(n1);

        if (resultado)
        {
            Console.WriteLine("La lista tiene un bucle.");
        }
        else
        {
            Console.WriteLine("La lista no tiene un bucle.");
        }
    }
}

// dotnet run --project ParteListas/Ej5L
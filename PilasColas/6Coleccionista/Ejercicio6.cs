
using System;

public class Nodo
{
    public int Valor;
    public Nodo? Siguiente;

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}


public class Pila
{
    private Nodo? cima;

    public Pila()
    {
        cima = null;
    }

    public void Apilar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        nuevoNodo.Siguiente = cima;
        cima = nuevoNodo;
    }

    public int Desapilar()
    {
        if (cima == null)
        {
            throw new System.InvalidOperationException("La bóveda está vacía.");
        }

        int valorExtraido = cima.Valor;
        cima = cima.Siguiente;

        return valorExtraido;
    }

    public int VerCima()
    {
        if (cima == null) throw new System.InvalidOperationException("La bóveda está vacía.");
        return cima.Valor;
    }

    public bool EstaVacia()
    {
        return cima == null;
    }
}

public class Program
{
    public static void OrdenarPila(Pila gemas)
    {
        Pila auxiliar = new Pila();

        while (!gemas.EstaVacia())
        {
            int temp = gemas.Desapilar();


            while (!auxiliar.EstaVacia() && auxiliar.VerCima() < temp)
            {
                gemas.Apilar(auxiliar.Desapilar());
            }

            auxiliar.Apilar(temp);
        }

        while (!auxiliar.EstaVacia())
        {
            gemas.Apilar(auxiliar.Desapilar());
        }
    }


    public static void Main()
    {

        Pila bovedaOriginal = new Pila();


        bovedaOriginal.Apilar(45);
        bovedaOriginal.Apilar(12);
        bovedaOriginal.Apilar(99);
        bovedaOriginal.Apilar(34);
        bovedaOriginal.Apilar(78);
        OrdenarPila(bovedaOriginal);

        System.Console.WriteLine("Gemas ordenadas (Desde la cima hacia el fondo):");

        while (!bovedaOriginal.EstaVacia())
        {
            System.Console.WriteLine(bovedaOriginal.Desapilar());
        }
    }
}
// dotnet run --project 6Coleccionista
using System;

// Ejercicio 7: El Multiverso (Contar Nodos) - Nivel 2
// Objetivo: contarLineas() que retorne la cantidad total de nodos.

class Nodo
{
    public int Valor;
    public Nodo? Izquierdo;
    public Nodo? Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinarioBusqueda
{
    public Nodo? Raiz;

    public void Insertar(int valor)
    {
        Raiz = InsertarRecursivo(Raiz!, valor);
    }

    private Nodo InsertarRecursivo(Nodo actual, int valor)
    {
        if (actual == null) return new Nodo(valor);

        if (valor < actual.Valor)
            actual.Izquierdo = InsertarRecursivo(actual.Izquierdo!, valor);
        else if (valor > actual.Valor)
            actual.Derecho = InsertarRecursivo(actual.Derecho!, valor);

        return actual;
    }

    // Cuenta todos los nodos del árbol.
    public int ContarLineas()
    {
        return ContarRecursivo(Raiz!);
    }

    private int ContarRecursivo(Nodo actual)
    {
        // Caso base: un subárbol vacío tiene 0 nodos
        if (actual == null)
            return 0;

        // 1 (este nodo) + nodos del subárbol izquierdo + nodos del subárbol derecho
        int izquierda = ContarRecursivo(actual.Izquierdo!);
        int derecha = ContarRecursivo(actual.Derecho!);
        return 1 + izquierda + derecha;
    }
}

class Programa
{
    static void Main()
    {
        var arbol = new ArbolBinarioBusqueda();
        int[] valores = { 50, 30, 70, 20, 40, 60, 80 };

        foreach (int v in valores)
            arbol.Insertar(v);

        Console.WriteLine("Multiverso - Total de líneas temporales (nodos):");
        Console.WriteLine(arbol.ContarLineas()); // 7
    }
}
//dotnet run --project eje7
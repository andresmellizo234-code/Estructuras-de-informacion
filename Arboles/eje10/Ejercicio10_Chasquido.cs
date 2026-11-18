using System;

// Ejercicio 10: El Chasquido (Eliminar Nodo) - Nivel 3
// Objetivo: eliminar(int valor) cubriendo los 3 casos:
// 1) Nodo hoja (sin hijos)
// 2) Nodo con un solo hijo
// 3) Nodo con dos hijos (usar sucesor inorden: menor del subárbol derecho)

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

    public void Eliminar(int valor)
    {
        Raiz = EliminarRecursivo(Raiz!, valor);
    }

    private Nodo EliminarRecursivo(Nodo actual, int valor)
    {
        if (actual == null)
            return null!; // valor no encontrado

        // 1) Buscar el nodo a eliminar
        if (valor < actual.Valor)
        {
            actual.Izquierdo = EliminarRecursivo(actual.Izquierdo!, valor);
        }
        else if (valor > actual.Valor)
        {
            actual.Derecho = EliminarRecursivo(actual.Derecho!, valor);
        }
        else
        {
            // Encontramos el nodo a eliminar (actual.Valor == valor)

            // Caso 1: sin hijos (hoja)
            if (actual.Izquierdo == null && actual.Derecho == null)
                return null!;

            // Caso 2: un solo hijo
            if (actual.Izquierdo == null)
                return actual.Derecho!; // se reemplaza por su hijo derecho
            if (actual.Derecho == null)
                return actual.Izquierdo; // se reemplaza por su hijo izquierdo

            // Caso 3: dos hijos
            // Buscamos el sucesor inorden: el valor más pequeño del subárbol derecho
            int sucesor = EncontrarMenorValor(actual.Derecho);
            actual.Valor = sucesor; // copiamos el valor del sucesor aquí
            // Eliminamos el sucesor de su posición original en el subárbol derecho
            actual.Derecho = EliminarRecursivo(actual.Derecho, sucesor);
        }

        return actual;
    }

    private int EncontrarMenorValor(Nodo nodo)
    {
        int menor = nodo.Valor;
        while (nodo.Izquierdo != null)
        {
            menor = nodo.Izquierdo.Valor;
            nodo = nodo.Izquierdo;
        }
        return menor;
    }

    // InOrden para verificar el árbol (debe salir ordenado en un BST)
    public void InOrden()
    {
        InOrdenRecursivo(Raiz!);
        Console.WriteLine();
    }

    private void InOrdenRecursivo(Nodo actual)
    {
        if (actual == null) return;
        InOrdenRecursivo(actual.Izquierdo!);
        Console.Write(actual.Valor + " ");
        InOrdenRecursivo(actual.Derecho!);
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

        Console.WriteLine("Antes del chasquido (InOrden):");
        arbol.InOrden();

        arbol.Eliminar(20); // caso 1: hoja
        Console.WriteLine("Tras eliminar 20 (hoja):");
        arbol.InOrden();

        arbol.Eliminar(30); // caso 2: un hijo
        Console.WriteLine("Tras eliminar 30 (un hijo):");
        arbol.InOrden();

        arbol.Eliminar(50); // caso 3: dos hijos (raíz)
        Console.WriteLine("Tras eliminar 50 (dos hijos):");
        arbol.InOrden();
    }
}
//dotnet run --project eje10

using System;

// Ejercicio 6: Explosión de Sokovia (PostOrden) - Nivel 2
// Objetivo: Implementar recorrido PostOrden (Izquierda -> Derecha -> Raíz)

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

    // Recorrido PostOrden: primero hijos, luego la raíz.
    // Útil para "eliminar/destruir" porque procesas nodos hoja antes que sus padres.
    public void RecorridoPostOrden()
    {
        PostOrdenRecursivo(Raiz!);
        Console.WriteLine();
    }

    private void PostOrdenRecursivo(Nodo actual)
    {
        if (actual == null)
            return; // caso base: no hay nada que procesar

        // 1) Izquierda
        PostOrdenRecursivo(actual.Izquierdo!);
        // 2) Derecha
        PostOrdenRecursivo(actual.Derecho!);
        // 3) Raíz (procesar el nodo actual)
        Console.Write(actual.Valor + " ");
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

        Console.WriteLine("Explosión de Sokovia - Recorrido PostOrden:");
        arbol.RecorridoPostOrden();
        // Salida esperada: 20 40 30 60 80 70 50
    }
}
//dotnet run --project eje6
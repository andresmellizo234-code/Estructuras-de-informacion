using System;

// Ejercicio 3: El Radar de Heimdall (Nivel 1)
// Objetivo: Implementar buscar(int amenaza) que retorne true si existe, false si no.

class Nodo
{
    public int Valor;       // dato almacenado (nivel/amenaza)
    public Nodo? Izquierdo;  // referencia al hijo izquierdo
    public Nodo? Derecho;    // referencia al hijo derecho

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

    // Inserción BST (necesaria para poder probar la búsqueda)
    public void Insertar(int valor)
    {
        Raiz = InsertarRecursivo(Raiz!, valor);
    }

    private Nodo InsertarRecursivo(Nodo actual, int valor)
    {
        if (actual == null)
            return new Nodo(valor);

        if (valor < actual.Valor)
            actual.Izquierdo = InsertarRecursivo(actual.Izquierdo!, valor);
        else if (valor > actual.Valor)
            actual.Derecho = InsertarRecursivo(actual.Derecho!, valor);
        // si es igual, no insertamos duplicados (opción simple)

        return actual;
    }

    // Búsqueda en un Árbol Binario de Búsqueda (BST)
    public bool Buscar(int amenaza)
    {
        return BuscarRecursivo(Raiz!, amenaza);
    }

    private bool BuscarRecursivo(Nodo actual, int amenaza)
    {
        // Caso base 1: llegamos a una referencia nula -> no está
        if (actual == null)
            return false;

        // Caso base 2: encontramos el valor
        if (amenaza == actual.Valor)
            return true;

        // Si la amenaza es menor, solo puede estar en el subárbol izquierdo
        if (amenaza < actual.Valor)
            return BuscarRecursivo(actual.Izquierdo!, amenaza);

        // Si es mayor, solo puede estar en el subárbol derecho
        return BuscarRecursivo(actual.Derecho!, amenaza);
    }
}

class Programa
{
    static void Main()
    {
        var radar = new ArbolBinarioBusqueda();
        int[] amenazasRegistradas = { 50, 30, 70, 20, 40, 60, 80 };

        foreach (int a in amenazasRegistradas)
            radar.Insertar(a);

        Console.WriteLine("Radar de Heimdall - Pruebas de búsqueda");
        Console.WriteLine(radar.Buscar(60)); // True
        Console.WriteLine(radar.Buscar(25)); // False
        Console.WriteLine(radar.Buscar(80)); // True
    }
}
//dotnet run --project eje3
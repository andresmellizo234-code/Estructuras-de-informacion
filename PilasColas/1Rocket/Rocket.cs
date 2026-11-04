using System;


class Nodo
{
    public object contenido;
    public Nodo? siguiente;

    public Nodo(object contenido)
    {
        this.contenido = contenido;
        this.siguiente = null;
    }
}

class PilaLimitada
{
    public Nodo? primeroDeLaPila;
    private int capacidadMaxima;
    private int cantidadActual;

    public PilaLimitada(int max)
    {
        this.capacidadMaxima = max;
        this.cantidadActual = 0;
        this.primeroDeLaPila = null;
    }

    public void apilar(object nuevoObjeto)
    {
        if (cantidadActual >= capacidadMaxima)
        {
            Console.WriteLine("¡Cargador lleno! No se puede apilar: " + nuevoObjeto);
            return;
        }

        Nodo nuevoNodo = new Nodo(nuevoObjeto);
        nuevoNodo.siguiente = primeroDeLaPila;
        primeroDeLaPila = nuevoNodo;
        cantidadActual++;
    }

    public object? sacar()
    {
        if (primeroDeLaPila == null)
        {
            return null;
        }

        object dato = primeroDeLaPila.contenido;
        primeroDeLaPila = primeroDeLaPila.siguiente;
        cantidadActual--;
        return dato;
    }
}

class Program
{
    static void Main()
    {
        PilaLimitada cargador = new PilaLimitada(3);

        cargador.apilar("Bateria 1");
        cargador.apilar("Bateria 2");
        cargador.apilar("Bateria 3");
        cargador.apilar("Bateria 4");               // debe rechazar

        Console.WriteLine(cargador.sacar());        // Bateria 3
        cargador.apilar("Bateria 4");               // ahora sí cabe
        Console.WriteLine(cargador.sacar());        // Bateria 4
        Console.WriteLine(cargador.sacar());        // Bateria 2
        Console.WriteLine(cargador.sacar());        // Bateria 1
        Console.WriteLine(cargador.sacar());        // null (línea vacía)
    }
}
// dotnet new sln -n TareaSemana1
// dotnet new console -n Ejercicio1
// dotnet sln add Ejercicio1/Ejercicio1.csproj
// dotnet run --project 1Rocket
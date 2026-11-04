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

class Pila
{
    public Nodo? primeroDeLaPila;

    public bool estaVacia()
    {
        return primeroDeLaPila == null;
    }

    public void apilar(object nuevoObjeto)
    {
        Nodo nuevoNodo = new Nodo(nuevoObjeto);
        nuevoNodo.siguiente = primeroDeLaPila;
        primeroDeLaPila = nuevoNodo;
    }

    public object? sacar()
    {
        if (primeroDeLaPila == null)
        {
            return null;
        }

        object dato = primeroDeLaPila.contenido;
        primeroDeLaPila = primeroDeLaPila.siguiente;
        return dato;
    }
}

class Cola
{
    public Nodo? primeroEnLaCola;
    public Nodo? ultimoEnLaCola;

    public bool estaVacia()
    {
        return primeroEnLaCola == null;
    }

    public void enfilar(object nuevoObjeto)
    {
        Nodo nuevoNodo = new Nodo(nuevoObjeto);

        if (primeroEnLaCola == null)
        {
            primeroEnLaCola = nuevoNodo;
        }
        else
        {
            ultimoEnLaCola?.siguiente = nuevoNodo;
        }
        ultimoEnLaCola = nuevoNodo;
    }

    public object? sacar()
    {
        if (primeroEnLaCola == null)
        {
            return null;
        }

        object dato = primeroEnLaCola.contenido;
        primeroEnLaCola = primeroEnLaCola.siguiente;

        if (primeroEnLaCola == null)
        {
            ultimoEnLaCola = null;
        }
        return dato;
    }
}

class Program
{
    static void invertirCola(Cola cola)
    {
        Pila temp = new Pila();

        while (!cola.estaVacia())
        {
            temp.apilar(cola.sacar());
        }

        while (!temp.estaVacia())
        {
            cola.enfilar(temp.sacar());
        }
    }

    static void Main()
    {
        Cola coordenadas = new Cola();
        coordenadas.enfilar("X=10");
        coordenadas.enfilar("Y=20");
        coordenadas.enfilar("Z=30");

        invertirCola(coordenadas);

        while (!coordenadas.estaVacia())
        {
            Console.WriteLine(coordenadas.sacar());
        }
    }
}
// dotnet new sln -n TareaSemana1
// dotnet new console -n Ejercicio1
// dotnet sln add Ejercicio1/Ejercicio1.csproj
// dotnet run --project 3Groot


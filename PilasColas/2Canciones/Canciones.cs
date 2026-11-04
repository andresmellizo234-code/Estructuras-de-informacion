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

class Cola
{
    public Nodo? primeroEnLaCola;
    public Nodo? ultimoEnLaCola;

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
    static void reproducirSiguiente(Cola playlist)
    {
        object? cancion = playlist.sacar();

        if (cancion == null)
        {
            Console.WriteLine("La playlist está vacía");
            return;
        }

        Console.WriteLine("Reproduciendo: " + cancion);
        playlist.enfilar(cancion);
    }

    static void Main()
    {
        Cola playlist = new Cola();
        playlist.enfilar("Cancion 1");
        playlist.enfilar("Cancion 2");
        playlist.enfilar("Cancion 3");

        for (int i = 0; i < 5; i++)
        {
            reproducirSiguiente(playlist);
        }
    }
}
// dotnet new sln -n TareaSemana1
// dotnet new console -n Ejercicio1
// dotnet sln add Ejercicio1/Ejercicio1.csproj
// dotnet run --project 2Canciones

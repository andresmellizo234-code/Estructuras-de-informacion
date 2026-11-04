
using System;

public class ColaNodos<T>
{
    private class Nodo
    {
        public T Valor { get; set; }
        public Nodo? Siguiente { get; set; }
        public Nodo (T valor) { Valor = valor; }
    }

    private Nodo? _frente;
    private Nodo? _final;


    public void Enfilar(T elemento)
    {
        Nodo nuevoNodo = new Nodo(elemento);

        if (EstaVacia())
        {
            _frente = _final = nuevoNodo;
        }
        else
        {
            _final!.Siguiente = nuevoNodo;
            _final = nuevoNodo;
        }
    }

    public T Sacar()
    {
        if (EstaVacia()) throw new InvalidOperationException("La cola está vacía.");

        T valor = _frente!.Valor;
        _frente = _frente.Siguiente;

        if (_frente == null)
        {
            _final = null;
        }

        return valor;
    }

    public bool EstaVacia() => _frente == null;
}

public class Sector
{
    public string Nombre { get; set; }
    public int EnergiaFaltante { get; set; }

    public Sector(string nombre, int energia)
    {
        Nombre = nombre;
        EnergiaFaltante = energia;
    }
}

class Program
{
    static void Main()
    {

        ColaNodos<Sector> colaEscudos = new ColaNodos<Sector>();

        colaEscudos.Enfilar(new Sector("Frontal", 25));
        colaEscudos.Enfilar(new Sector("Trasero", 10));
        colaEscudos.Enfilar(new Sector("Izquierdo", 35));
        colaEscudos.Enfilar(new Sector("Derecho", 15));

        int energiaPorCiclo = 10;
        int numeroCiclo = 1;

        Console.WriteLine("--- INICIANDO PROTOCOLO DE DEFENSA MILANO ---\n");


        while (!colaEscudos.EstaVacia())
        {
            Sector sectorActual = colaEscudos.Sacar();

            int energiaInyectada = Math.Min(energiaPorCiclo, sectorActual.EnergiaFaltante);
            sectorActual.EnergiaFaltante -= energiaInyectada;

            Console.WriteLine($"[Ciclo {numeroCiclo}] Cargando {sectorActual.Nombre}... (Inyectando {energiaInyectada}u)");


            if (sectorActual.EnergiaFaltante > 0)
            {
                Console.WriteLine($"   -> Restan {sectorActual.EnergiaFaltante} para el 100%. Vuelve a la cola.");
                colaEscudos.Enfilar(sectorActual);
            }
            else
            {
                Console.WriteLine($"   -> [!] Sector {sectorActual.Nombre} al 100%. Descartado de la cola.");
            }

            Console.WriteLine(new string('-', 40));
            numeroCiclo++;
        }

        Console.WriteLine("\n*** NÚCLEO ESTABLE: TODOS LOS ESCUDOS AL 100% ***");
    }
}

// dotnet run --project Nave7
using System;


// CLASE NODO

public class NodoVengador
{
    public int? Valor;
    public NodoVengador? Izquierdo;// Nodo hijo izquierdo
    public NodoVengador? Derecho;// Nodo hijo derecho

    public NodoVengador(int valor)// Constructor
    {
        Valor = valor;// Nivel de seguridad del Vengador
        Izquierdo = null;// Inicialmente no tiene hijos
        Derecho = null;// Inicialmente no tiene hijos
    }
}


// CLASE ARBOL BINARIO (retos 2, 5 y 8)

public class ArbolBinario
{
    private NodoVengador? raiz;// Nodo raíz del árbol

    public ArbolBinario()// Constructor
    {
        raiz = null;
    }

    
    // RETO 2 - Insertar (Árbol Binario de Búsqueda, de forma recursiva)
    

    // Método público: lo que usa quien llama
    public void Insertar(int nivelSeguridad) 
    {
        raiz = InsertarRecursivo(raiz!, nivelSeguridad);
    }

    // Método privado recursivo: hace el trabajo real
    private NodoVengador InsertarRecursivo(NodoVengador actual, int valor)
    {
        // Caso base: encontramos un hueco, aquí va el nodo nuevo
        if (actual == null)
        {
            return new NodoVengador(valor);
        }

        // Caso recursivo: decidir por qué lado bajar
        if (valor < actual.Valor)
        {
            actual.Izquierdo = InsertarRecursivo(actual.Izquierdo!, valor);
        }
        else if (valor > actual.Valor)
        {
            actual.Derecho = InsertarRecursivo(actual.Derecho!, valor);
        }
        // Si es igual, es un duplicado y no se hace nada

        return actual;
    }

   
    // EXTRA Mostrar niveles con recorrido InOrden
    // Sirve para comprobar que la inserción quedó bien (sale ordenado)

    public void MostrarNiveles()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol está vacío.");
            return;
        }

        MostrarRecursivo(raiz);
        Console.WriteLine();
    }

    // InOrden: Izquierda -> Raíz -> Derecha
    private void MostrarRecursivo(NodoVengador actual)
    {
        if (actual == null)
        {
            return;
        }

        MostrarRecursivo(actual.Izquierdo!);
        Console.Write(actual.Valor + " ");
        MostrarRecursivo(actual.Derecho!);
    }

    
    // RETO 5 - Recorrido PreOrden (Raíz -> Izquierda -> Derecha)
    

    // Método público
    public void PreOrden()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol está vacío.");
            return;
        }

        PreOrdenRecursivo(raiz);
        Console.WriteLine();
    }

    // Método privado recursivo
    private void PreOrdenRecursivo(NodoVengador actual)
    {
        // Caso base: no hay nodo, no hay nada que visitar
        if (actual == null)
        {
            return;
        }

        Console.Write(actual.Valor + " ");      // 1. Raíz
        PreOrdenRecursivo(actual.Izquierdo!);    // 2. Izquierda
        PreOrdenRecursivo(actual.Derecho!);      // 3. Derecha
    }

    
    // RETO 8 - Encontrar menor y mayor 
        

    // El menor está en el extremo izquierdo del árbol.
    // Devuelve null si el árbol está vacío (int? = entero que puede ser null).
    public int? EncontrarMenor()
    {
        if (raiz == null)
        {
            return null;
        }

        NodoVengador actual = raiz;
        while (actual.Izquierdo != null)
        {
            actual = actual.Izquierdo;
        }

        return actual.Valor;
    }

    // El mayor está en el extremo derecho del árbol.
    public int? EncontrarMayor()
    {
        if (raiz == null)
        {
            return null;
        }

        NodoVengador actual = raiz;
        while (actual.Derecho != null)
        {
            actual = actual.Derecho;
        }

        return actual.Valor;
    }
}


// PROGRAMA PRINCIPAL (pruebas de los retos)

public class Program
{
    public static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();

        // ----- RETO 2: Insertar -----
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);
        arbol.Insertar(20);
        arbol.Insertar(40);

        Console.WriteLine("Niveles de seguridad registrados (menor a mayor):");
        arbol.MostrarNiveles();
        // Salida esperada: 20 30 40 50 70

        // ----- RETO 5: PreOrden -----
        Console.WriteLine("Recorrido PreOrden:");
        arbol.PreOrden();
        // Salida esperada: 50 30 20 40 70

        // ----- RETO 8: Menor y mayor -----
        Console.WriteLine("Gema de menor poder: " + arbol.EncontrarMenor());   // 20
        Console.WriteLine("Gema de mayor poder: " + arbol.EncontrarMayor());    // 70
    }
}
//dotnet run --project eje2_5_8
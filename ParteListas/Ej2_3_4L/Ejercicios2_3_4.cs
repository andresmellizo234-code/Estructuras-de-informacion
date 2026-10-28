using System;

// ==========================================
// 1. LA CLASE NODO (Tu definición, intacta)
// ==========================================
public class Nodo
{
    public int Datos;
    public Nodo Siguiente;

    public Nodo(int d) 
    {
        Datos = d; 
        Siguiente = null;
    }
}

// ==========================================
// 2. LA CLASE LISTA ENLAZADA
// ==========================================
public class ListaEnlazada
{    
    public Nodo Cabeza; 

    // --- RETO 1: AGREGAR AL FINAL ---
    public void Agregar(int d)
    {
        Nodo nuevoNodo = new Nodo(d);

        if (Cabeza == null)
        {
            Cabeza = nuevoNodo; // Caso vacío
            return;
        }

        Nodo actual = Cabeza;
        while (actual.Siguiente != null) 
        {
            actual = actual.Siguiente;
        }
        
        actual.Siguiente = nuevoNodo;
    }



    public void Imprimir()
    {
        Nodo temp = Cabeza;
        while (temp != null)
        {
            Console.Write(temp.Datos + " -> ");
            temp = temp.Siguiente;
        }
        Console.WriteLine("null");
    }

    // --- RETO 2: INVERTIR LISTA ---
    public void Invertir()
    {
        Nodo prev = null;
        Nodo actual = Cabeza;
        Nodo sig;

        while (actual != null)
        {
            sig = actual.Siguiente;       // 1. Guardar futuro (Salvavidas)
            actual.Siguiente = prev;      // 2. Voltear flecha (Regla 3)
            prev = actual;                // 3. Avanzar ventana (prev sube)
            actual = sig;                 // 4. Avanzar ventana (actual salta)
        }

        Cabeza = prev; // Actualizar cabeza maestra
    }

    // --- RETO 3: DEVOLVER EL NODOS N DESDE EL FINAL ---
    // Ejemplo: Si lista es 1->2->3->4->5 y n=2, devuelve nodo '4' (penultimo)
    public Nodo ObtenerNDelFinal(int n)
    {
        if (Cabeza == null) return null;

        Nodo rapido = Cabeza;
        Nodo lento = Cabeza;

        // Fase 1: Abrir brecha de distancia 'n'
        for (int i = 0; i < n; i++)
        {
            if (rapido == null) return null; // Lista más corta que n
            rapido = rapido.Siguiente;
        }

        // Fase 2: Mover ambos hasta que rapido llegue al final
        while (rapido != null)
        {
            rapido = rapido.Siguiente;
            lento = lento.Siguiente;
        }

        return lento; 

    }
    public void QuitarDuplicadosOrdenada()
    {
        Nodo actual = Cabeza;


        while (actual != null && actual.Siguiente != null)
        {
            if (actual.Datos == actual.Siguiente.Datos)
            {
        
                actual.Siguiente = actual.Siguiente.Siguiente;
           
            }
            else
            {
                // Solo avanzamos si NO había duplicado
                actual = actual.Siguiente;
            }
        }
    }
    }


class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada miLista = new ListaEnlazada();

        Console.WriteLine("--- PRUEBA RETO 1: AGREGAR ---");
        miLista.Agregar(1);
        miLista.Agregar(2);
        miLista.Agregar(3);
        miLista.Agregar(4);
        miLista.Agregar(5);
        miLista.Imprimir(); // Esperado: 1 -> 2 -> 3 -> 4 -> 5 -> null

        Console.WriteLine("\n--- PRUEBA RETO 2: INVERTIR ---");
        miLista.Invertir();
        miLista.Imprimir();
        

        miLista.Invertir(); 

        Console.WriteLine("\n--- PRUEBA RETO 3: N-ÉSIMO DESDE EL FINAL ---");
  
        Nodo resultado = miLista.ObtenerNDelFinal(2);
        if (resultado != null)
            Console.WriteLine($"El nodo 2 desde el final es: {resultado.Datos}"); 
        else
            Console.WriteLine("No existe.");

        Console.WriteLine("\n--- PRUEBA RETO 4: ELIMINAR DUPLICADOS ---");
        ListaEnlazada listaDup = new ListaEnlazada();
     
        int[] vals = {1, 1, 2, 3, 3, 3, 4};
        foreach(var v in vals) listaDup.Agregar(v);
        
        Console.WriteLine("Antes de limpiar:");
        listaDup.Imprimir();
        
        listaDup.QuitarDuplicadosOrdenada();
        
        Console.WriteLine("Después de limpiar:");
        listaDup.Imprimir(); 
}
}

// //dotnet run --project ParteListas/Ej2L

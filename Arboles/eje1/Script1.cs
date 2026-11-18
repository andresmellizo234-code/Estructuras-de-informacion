using System;
/*Este programa implementa la estructura más básica de un árbol binario
para registrar los reinos de Yggdrasil. Se definen dos clases: Nodo,
que guarda el nombre de un mundo junto con dos referencias (izquierdo y derecho)
que apuntan a otros nodos o quedan en null si no hay hijo, y ArbolBinario,
que mantiene la referencia a la raíz. El método InsertarManual crea el nodo
raíz “Asgard” y luego enlaza a sus lados, de forma estática, a “Midgard”
como hijo izquierdo y a “Vanaheim” como hijo derecho. Así se ve cómo funcionan
los punteros: cada nodo solo conoce a sus hijos directos, y para llegar
a cualquier reino hay que partir de la raíz y seguir las referencias
izquierda o derecha. Finalmente, Main crea el árbol, ejecuta la inserción
e imprime los tres nombres accediendo a ellos a través de la raíz.*/

class Program
{
    class Nodo
    {
        public String mundo; //Guarda el nombre de los mundos
        public Nodo? izquierdo; //Guarda el nodo de la izquierda del arbol
        public Nodo? derecho; //Guarda el nodo de la derecha del arbol

    // Constructor
        public Nodo(String nameWord)
        {
            this.mundo = nameWord;
            this.izquierdo = null;
            this.derecho = null;

        }
    }
    class Arbol
    {
        public Nodo? raiz; //Crea la raiz

        public void InsertarMundos() //Crea los mundos
        {
            raiz = new Nodo("Asgard");
            raiz.izquierdo = new Nodo("Midgard");
            raiz.derecho = new Nodo("Vanaheim");
        }
    }
    static void Main(string[] args)
    {
        Arbol arbol = new Arbol();
        arbol.InsertarMundos(); // Llama al método que crea los mundos

        //Imprime el árbol
        Console.WriteLine("Raíz: " + arbol.raiz!.mundo);
        Console.WriteLine("Hijo izquierdo: " + arbol.raiz.izquierdo!.mundo);
        Console.WriteLine("Hijo derecho: " + arbol.raiz.derecho!.mundo);
        
    }
    
}
//dotnet run --project eje1

/*Este programa construye un árbol binario de búsqueda
para guardar el inventario de armaduras de Iron Man y
lo imprime de la más antigua a la más nueva.
Cada Nodo almacena un número y dos referencias a sus hijos.
El método insertar compara cada valor nuevo con los nodos
existentes, si es menor baja por la izquierda y
si es mayor o igual baja por la derecha, hasta encontrar
un espacio libre donde colocarlo. Así, los valores menores
siempre quedan a la izquierda y los mayores a la derecha.
El método InOrder usa recursividad para recorrer el árbol
en el orden Izquierda → Raíz → Derecha. Baja primero hasta
el valor más pequeño, lo imprime, y luego sube visitando
cada nodo y su lado derecho. Como el árbol ya está organizado,
este recorrido muestra los datos ordenados de menor a mayor
sin necesidad de ordenarlos aparte.*/

using System;

class Program
{
    // Nodo, guarda un dato y apunta a sus dos hijos
    class Nodo
    {
        public int dato;        // Valor guardado (año de la armadura)
        public Nodo? izquierdo; // Hijo con valor menor
        public Nodo? derecho;   // Hijo con valor mayor

        // Constructor: crea el nodo sin hijos
        public Nodo(int valor)
        {
            this.dato = valor;
            this.izquierdo = null;
            this.derecho = null;
        }
    }

    // Árbol, guarda la raíz y las operaciones
    class Arbol
    {
        Nodo? raiz; // Primer nodo del árbol

        // Inserta un número en la posición correcta
        public void insertar(int num)
        {
            // Si el árbol está vacío, el nuevo nodo es la raíz
            if (raiz == null)
            {
                raiz = new Nodo(num);
                return;
            }

            Nodo actual = raiz; // Empezamos a bajar desde la raíz

            while (true)
            {
                // Si es menor, va por la izquierda
                if (num < actual.dato)
                {
                    // Si no hay hijo izquierdo, lo ponemos aquí
                    if (actual.izquierdo == null)
                    {
                        actual.izquierdo = new Nodo(num);
                        return;
                    }
                    actual = actual.izquierdo; // Si hay, seguimos bajando
                }
                // Si es mayor o igual, va por la derecha
                else
                {
                    // Si no hay hijo derecho, lo ponemos aquí
                    if (actual.derecho == null)
                    {
                        actual.derecho = new Nodo(num);
                        return;
                    }
                    actual = actual.derecho; // Si hay, seguimos bajando
                }
            }
        }

        // Método que inicia el recorrido desde la raíz
        public void InOrder()
        {
            InOrder(raiz);
        }

        // Método recursivo Izquierda -> Raíz -> Derecha
        private void InOrder(Nodo? nodo)
        {
            // Caso base: si no hay nodo, se detiene
            if (nodo == null)
                return;

            InOrder(nodo.izquierdo);        // 1. Visita el subárbol izquierdo
            Console.WriteLine(nodo.dato);   // 2. Imprime el nodo actual
            InOrder(nodo.derecho);          // 3. Visita el subárbol derecho
        }
    }

    static void Main(string[] args)
    {
        Arbol inventario = new Arbol();

        // Insertamos años de armaduras sin ningún orden
        inventario.insertar(2008);
        inventario.insertar(1990);
        inventario.insertar(2015);
        inventario.insertar(1985);
        inventario.insertar(2000);
        inventario.insertar(2020);

        // Imprime de menor a mayor
        Console.WriteLine("Inventario de armaduras (de la más antigua a la más nueva):");
        inventario.InOrder();
    }
}
//dotnet run --project eje4

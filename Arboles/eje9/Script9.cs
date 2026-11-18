/*Este programa calcula qué tan profundo es un árbol binario,
es decir, la distancia más larga desde la raíz hasta una hoja.
El método calcularAltura es recursivo y se apoya en una idea simple:
la altura de un nodo es 1 (él mismo) más la altura de su rama más alta.
Para cada nodo se calcula la altura del lado izquierdo y la del derecho,
y Math.Max elige la mayor de las dos, porque solo importa el camino
más largo. El caso base es un nodo vacío (null), que devuelve 0 y es
lo que detiene la recursión. Las llamadas bajan hasta las hojas y luego
van sumando 1 al regresar, hasta que la raíz devuelve la altura total
del árbol.*/

using System;

class Program
{
    // Nodo, guarda un dato y apunta a sus dos hijos
    class Nodo
    {
        public int dato;        // Valor guardado
        public Nodo? izquierdo; // Hijo con valor menor
        public Nodo? derecho;   // Hijo con valor mayor

        // Constructor, crea el nodo sin hijos
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
                    if (actual.izquierdo == null)
                    {
                        actual.izquierdo = new Nodo(num);
                        return;
                    }
                    actual = actual.izquierdo; // Seguimos bajando
                }
                // Si es mayor o igual, va por la derecha
                else
                {
                    if (actual.derecho == null)
                    {
                        actual.derecho = new Nodo(num);
                        return;
                    }
                    actual = actual.derecho; // Seguimos bajando
                }
            }
        }

        // Método público: inicia el cálculo desde la raíz
        public int calcularAltura()
        {
            return calcularAltura(raiz);
        }

        // Método recursivo: calcula la altura de un nodo
        private int calcularAltura(Nodo? nodo)
        {
            // Caso base: un nodo vacío no suma niveles
            if (nodo == null)
                return 0;

            int alturaIzq = calcularAltura(nodo.izquierdo); // Altura del lado izquierdo
            int alturaDer = calcularAltura(nodo.derecho);   // Altura del lado derecho

            // Nos quedamos con el lado más profundo y sumamos 1 por el nodo actual
            return Math.Max(alturaIzq, alturaDer) + 1;
        }
    }

    static void Main(string[] args)
    {
        Arbol torre = new Arbol();

        // Probamos con un árbol vacío
        Console.WriteLine("Altura con el árbol vacío: " + torre.calcularAltura());

        // Insertamos valores para formar el árbol
        torre.insertar(50);
        torre.insertar(30);
        torre.insertar(70);
        torre.insertar(20);
        torre.insertar(40);
        torre.insertar(60);
        torre.insertar(80);
        torre.insertar(10); // Este hace más profundo el lado izquierdo

        // Mostramos la altura máxima
        Console.WriteLine("Altura de la Torre Stark: " + torre.calcularAltura());
    }
}
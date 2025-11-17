using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace InnovatecEstructuras
{
    
    public class ArbolJerarquia
    {
        public NodoJerarquia Raiz { get; private set; }

        public ArbolJerarquia(NodoJerarquia raiz)
        {
            Raiz = raiz;
        }

        
        public void RecorridoPreorden()
        {
            Console.WriteLine("Recorrido preorden de la jerarquía:\n");
            RecorridoPreorden(Raiz, 0);
        }

        private void RecorridoPreorden(NodoJerarquia nodo, int nivel)
        {
            if (nodo == null) return;

            Console.WriteLine(new string(' ', nivel * 2) + "- " + nodo.Nombre);

            foreach (var hijo in nodo.Hijos)
            {
                RecorridoPreorden(hijo, nivel + 1);
            }
        }

        
        public NodoJerarquia Buscar(string nombre)
        {
            return Buscar(Raiz, nombre);
        }

        private NodoJerarquia Buscar(NodoJerarquia nodo, string nombre)
        {
            if (nodo == null) return null;

            if (string.Equals(nodo.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                return nodo;

            foreach (var hijo in nodo.Hijos)
            {
                var encontrado = Buscar(hijo, nombre);
                if (encontrado != null)
                    return encontrado;
            }

            return null;
        }

        
        public int ContarNodos()
        {
            return ContarNodos(Raiz);
        }

        private int ContarNodos(NodoJerarquia nodo)
        {
            if (nodo == null) return 0;

            int total = 1;
            foreach (var hijo in nodo.Hijos)
            {
                total += ContarNodos(hijo);
            }
            return total;
        }

        
        public int ObtenerAltura()
        {
            return ObtenerAltura(Raiz);
        }

        private int ObtenerAltura(NodoJerarquia nodo)
        {
            if (nodo == null) return 0;
            if (nodo.Hijos.Count == 0) return 1;

            int maxHijo = 0;
            foreach (var hijo in nodo.Hijos)
            {
                int alturaHijo = ObtenerAltura(hijo);
                if (alturaHijo > maxHijo)
                    maxHijo = alturaHijo;
            }

            return 1 + maxHijo;
        }

       
        public void ImprimirPorNiveles()
        {
            if (Raiz == null) return;

            Console.WriteLine("Jerarquía por niveles:\n");

            Queue<(NodoJerarquia nodo, int nivel)> cola =
                new Queue<(NodoJerarquia nodo, int nivel)>();

            cola.Enqueue((Raiz, 0));
            int nivelActual = 0;

            Console.Write("Nivel 0: ");

            while (cola.Count > 0)
            {
                var item = cola.Dequeue();
                var nodo = item.nodo;
                var nivel = item.nivel;

                if (nivel != nivelActual)
                {
                    nivelActual = nivel;
                    Console.WriteLine();
                    Console.Write("Nivel " + nivel + ": ");
                }

                Console.Write("[" + nodo.Nombre + "] ");

                foreach (var hijo in nodo.Hijos)
                {
                    cola.Enqueue((hijo, nivel + 1));
                }
            }

            Console.WriteLine();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InnovatecEstructuras
{
    
    public class GrafoRutas
    {
        
        private Dictionary<string, List<Arista>> _adyacencia;

        public GrafoRutas()
        {
            _adyacencia = new Dictionary<string, List<Arista>>();
        }

        public void AgregarVertice(string nombre)
        {
            if (!_adyacencia.ContainsKey(nombre))
            {
                _adyacencia[nombre] = new List<Arista>();
            }
        }

        
        public void AgregarConexion(string origen, string destino, double peso)
        {
            AgregarVertice(origen);
            AgregarVertice(destino);

            _adyacencia[origen].Add(new Arista(destino, peso));
            _adyacencia[destino].Add(new Arista(origen, peso));
        }

        
        public void MostrarConexiones()
        {
            Console.WriteLine("Conexiones del grafo de rutas:\n");

            foreach (var par in _adyacencia)
            {
                string edificio = par.Key;
                List<Arista> conexiones = par.Value;

                Console.Write(edificio + " -> ");
                foreach (var arista in conexiones)
                {
                    Console.Write("[" + arista.Destino + " (" + arista.Peso + ")] ");
                }
                Console.WriteLine();
            }
        }

        
        public bool EsConexo()
        {
            if (_adyacencia.Count == 0) return true;

            HashSet<string> visitados = new HashSet<string>();
            Queue<string> cola = new Queue<string>();

            string inicio = null;
            foreach (var v in _adyacencia.Keys)
            {
                inicio = v;
                break;
            }

            cola.Enqueue(inicio);
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();

                foreach (var arista in _adyacencia[actual])
                {
                    string vecino = arista.Destino;
                    if (!visitados.Contains(vecino))
                    {
                        visitados.Add(vecino);
                        cola.Enqueue(vecino);
                    }
                }
            }

            return visitados.Count == _adyacencia.Count;
        }

       
        public ResultadoRuta RutaMasCorta(string origen, string destino)
        {
            ResultadoRuta resultado = new ResultadoRuta();

            if (!_adyacencia.ContainsKey(origen) || !_adyacencia.ContainsKey(destino))
            {
                resultado.Existe = false;
                return resultado;
            }

            Dictionary<string, double> dist = new Dictionary<string, double>();
            Dictionary<string, string> previo = new Dictionary<string, string>();
            HashSet<string> visitados = new HashSet<string>();

            
            foreach (var v in _adyacencia.Keys)
            {
                dist[v] = double.PositiveInfinity;
                previo[v] = null;
            }

            dist[origen] = 0;

            while (visitados.Count < _adyacencia.Count)
            {
                string u = null;
                double menorDistancia = double.PositiveInfinity;

                
                foreach (var v in _adyacencia.Keys)
                {
                    if (!visitados.Contains(v) && dist[v] < menorDistancia)
                    {
                        menorDistancia = dist[v];
                        u = v;
                    }
                }

                if (u == null) break;
                if (u == destino) break;

                visitados.Add(u);

                
                foreach (var arista in _adyacencia[u])
                {
                    string vecino = arista.Destino;
                    double peso = arista.Peso;

                    if (visitados.Contains(vecino))
                        continue;

                    double nuevaDist = dist[u] + peso;
                    if (nuevaDist < dist[vecino])
                    {
                        dist[vecino] = nuevaDist;
                        previo[vecino] = u;
                    }
                }
            }

            if (double.IsPositiveInfinity(dist[destino]))
            {
                resultado.Existe = false;
                return resultado;
            }

            List<string> caminoReverso = new List<string>();
            string actualNodo = destino;

            while (actualNodo != null)
            {
                caminoReverso.Add(actualNodo);
                actualNodo = previo[actualNodo];
            }

            caminoReverso.Reverse();

            resultado.Existe = true;
            resultado.DistanciaTotal = dist[destino];
            resultado.Camino = caminoReverso;

            return resultado;
        }
    }
}

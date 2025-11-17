using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InnovatecEstructuras
{
    // Resultado de la ruta más corta
    public class ResultadoRuta
    {
        public bool Existe { get; set; }
        public double DistanciaTotal { get; set; }
        public List<string> Camino { get; set; }

        public ResultadoRuta()
        {
            Camino = new List<string>();
        }
    }
}


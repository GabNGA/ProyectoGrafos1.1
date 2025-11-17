using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovatecEstructuras
{
    
    public class Arista
    {
        public string Destino { get; set; }
        public double Peso { get; set; } .

        public Arista(string destino, double peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }
}


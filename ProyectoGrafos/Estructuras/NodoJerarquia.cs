using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InnovatecEstructuras
{
   
    public class NodoJerarquia
    {
        public string Nombre { get; set; }
        public List<NodoJerarquia> Hijos { get; private set; }

        public NodoJerarquia(string nombre)
        {
            Nombre = nombre;
            Hijos = new List<NodoJerarquia>();
        }

        public void AgregarHijo(NodoJerarquia hijo)
        {
            Hijos.Add(hijo);
        }
    }
}


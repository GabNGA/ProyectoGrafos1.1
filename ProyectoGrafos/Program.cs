using InnovatecEstructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using InnovatecEstructuras;



namespace InnovatecEstructuras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ArbolJerarquia arbol = CrearArbolJerarquiaEjemplo();

            Console.WriteLine("===== PARTE A: ÁRBOL - Jerarquía Organizativa =====\n");

            arbol.RecorridoPreorden();
            Console.WriteLine();

            Console.WriteLine("Cantidad total de nodos en la jerarquía: " + arbol.ContarNodos());
            Console.WriteLine("Altura (cantidad de niveles) del árbol: " + arbol.ObtenerAltura());
            Console.WriteLine();

            arbol.ImprimirPorNiveles();
            Console.WriteLine();

            Console.Write("Ingresa el nombre de un área o puesto para buscar en la jerarquía: ");
            string nombreBusqueda = Console.ReadLine();

            var nodoEncontrado = arbol.Buscar(nombreBusqueda);
            if (nodoEncontrado != null)
            {
                Console.WriteLine("Se encontró el nodo: " + nodoEncontrado.Nombre);
            }
            else
            {
                Console.WriteLine("No se encontró el nodo con ese nombre.");
            }

            Console.WriteLine("\nPresiona una tecla para continuar con el grafo...");
            Console.ReadKey();
            Console.Clear();

            // ============================
            // PARTE B: GRAFO DE RUTAS
            // ============================
            GrafoRutas grafo = CrearGrafoRutasEjemplo();

            Console.WriteLine("===== PARTE B: GRAFO - Sistema de Rutas del Parque =====\n");

            grafo.MostrarConexiones();
            Console.WriteLine();

            bool esConexo = grafo.EsConexo();
            Console.WriteLine("¿El grafo de rutas es conexo? " + (esConexo ? "Sí" : "No"));
            Console.WriteLine();

            Console.WriteLine("Edificios disponibles:");
            Console.WriteLine("- Edificio A");
            Console.WriteLine("- Edificio B");
            Console.WriteLine("- Edificio C");
            Console.WriteLine("- Edificio D");
            Console.WriteLine("- Edificio E");
            Console.WriteLine();

            Console.Write("Ingresa el edificio de origen (ej: Edificio A): ");
            string origen = Console.ReadLine();

            Console.Write("Ingresa el edificio de destino (ej: Edificio E): ");
            string destino = Console.ReadLine();

            var ruta = grafo.RutaMasCorta(origen, destino);

            Console.WriteLine();

            if (ruta.Existe)
            {
                Console.WriteLine("Ruta más corta encontrada:");
                Console.WriteLine("Camino: " + string.Join(" -> ", ruta.Camino));
                Console.WriteLine("Distancia total: " + ruta.DistanciaTotal);
            }
            else
            {
                Console.WriteLine("No existe una ruta entre esos dos edificios.");
            }

            Console.WriteLine("\nPrograma finalizado. Presiona una tecla para salir...");
            Console.ReadKey();
        }

        // =====================
        // Crear árbol de ejemplo
        // =====================
        static ArbolJerarquia CrearArbolJerarquiaEjemplo()
        {
            // Nodo raíz
            var direccion = new NodoJerarquia("Direccion General");

            // Primer nivel
            var areaAdmin = new NodoJerarquia("Area Administrativa");
            var areaTecno = new NodoJerarquia("Area Tecnologica");
            var areaInnov = new NodoJerarquia("Area de Innovacion");

            direccion.AgregarHijo(areaAdmin);
            direccion.AgregarHijo(areaTecno);
            direccion.AgregarHijo(areaInnov);

            // Segundo nivel - Área Administrativa
            var rrhh = new NodoJerarquia("Recursos Humanos");
            var finanzas = new NodoJerarquia("Finanzas");
            areaAdmin.AgregarHijo(rrhh);
            areaAdmin.AgregarHijo(finanzas);

            // Segundo nivel - Área Tecnológica
            var infraTI = new NodoJerarquia("Infraestructura TI");
            var desarrollo = new NodoJerarquia("Desarrollo de Software");
            var soporte = new NodoJerarquia("Soporte Tecnico");
            areaTecno.AgregarHijo(infraTI);
            areaTecno.AgregarHijo(desarrollo);
            areaTecno.AgregarHijo(soporte);

            // Segundo nivel - Área de Innovación
            var gestionProyectos = new NodoJerarquia("Gestion de Proyectos");
            var laboratorio = new NodoJerarquia("Laboratorio de Prototipos");
            areaInnov.AgregarHijo(gestionProyectos);
            areaInnov.AgregarHijo(laboratorio);

            return new ArbolJerarquia(direccion);
        }

        // =====================
        // Crear grafo de ejemplo
        // =====================
        static GrafoRutas CrearGrafoRutasEjemplo()
        {
            var grafo = new GrafoRutas();

            // Cada peso puede interpretarse como distancia (por ejemplo, en metros)
            grafo.AgregarConexion("Edificio A", "Edificio B", 5);
            grafo.AgregarConexion("Edificio A", "Edificio C", 7);
            grafo.AgregarConexion("Edificio B", "Edificio D", 3);
            grafo.AgregarConexion("Edificio C", "Edificio D", 2);
            grafo.AgregarConexion("Edificio C", "Edificio E", 4);
            grafo.AgregarConexion("Edificio D", "Edificio E", 6);

            return grafo;
        }
    }
}

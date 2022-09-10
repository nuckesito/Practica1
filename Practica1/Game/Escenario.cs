using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Game
{
    public class Escenario
    {
        public List<Figura> ListaFigura { get; set; }

        Escenario()
        { 
            ListaFigura= new List<Figura>();
        }
        public int CantidadFiguras()
        { 
            return ListaFigura.Count;
        }
        public bool EstaVacia()
        {
            return ListaFigura.Count == 0;
        }
        
        public void InsertarFigura(Figura a)
        {
            ListaFigura.Add(a);
        }
        

    }
}

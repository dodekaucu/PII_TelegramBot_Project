using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que representa los materiales
    /// </summary>
    public class Materiales
    {
        public Materiales(Clasificacion clasificacion, int cantidad,string unidad, int valor)
        {
            this.clasificacion = clasificacion;
            this.cantidad = cantidad;
            this.unidad = unidad;
            this.valor = valor;
        }
        private Clasificacion clasificacion;
        private int cantidad;
        private string unidad;
        private int valor;

        public Clasificacion Clasificacion {
            get
            {
                return this.clasificacion;
            }
            
        }
        public int Cantidad {
            get
            {
                return this.cantidad;
            }
        }
        public string Unidad {
            get
            {
                return this.unidad;
            }
        }
        public int Valor {
            get
            {
                return this.valor;
            }
        }
    }
}
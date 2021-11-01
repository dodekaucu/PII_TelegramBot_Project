using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que representa los materiales
    /// </summary>
    public class Material
    {
        public Material(string nombre,Clasificacion clasificacion, int cantidad,string unidad, double valor)
        {
            this.nombre = nombre;
            this.clasificacion = clasificacion;
            this.cantidad = cantidad;
            this.unidad = unidad;
            this.valor = valor;
        }
        private Clasificacion clasificacion;
        private int cantidad;
        private string unidad;
        private double valor;

        private string nombre;


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
        public double Valor {
            get
            {
                return this.valor;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
    }
}
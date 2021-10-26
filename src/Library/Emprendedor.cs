using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa un Emprendedor
    /// </summary>
    public class Emprendedor : Usuario
    {
        /// <summary>
        /// Variable del tipo string que representa la Especializacion del emprendedor
        /// </summary>
        /// <value></value>
        public string Especializacion {get; set;}

        private List<Habilitacion> habilitaciones = new List<Habilitacion>();
        /// <summary>
        /// Coleccion generica del tipo Habilitacion
        /// </summary>
        /// <value></value>
        public List<Habilitacion> Habilitaciones 
        {
            get{
                return this.habilitaciones;
            }
            set{
                this.habilitaciones=value;
            }
        }
        /// <summary>
        /// Metodo constructor que toma como base el nombre, rubro, ciudad y calle de la SuperClase y se le añiade
        /// el parametro especializacion (parametro propio del emprendedor)
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="rubro"></param>
        /// <param name="ciudad"></param>
        /// <param name="calle"></param>
        /// <param name="especializacion"></param>
        /// <returns></returns>
        public Emprendedor(string nombre, string rubro, string ciudad, string calle,string especializacion) :
        base(nombre,rubro,ciudad,calle)
        {
            this.Especializacion = especializacion;
        }

        /// <summary>
        /// Añade habilitacion a la lista de habilitaciones de habilitaciones del emprendedor, recibe de parametro
        /// string nombre string  descripcion. El metodo inicializa a habilitacion cumpliendo el patron creator
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        public void AddHabilitacion(string nombre, string descripcion)
        {
            Habilitacion habilitacion = new Habilitacion(nombre, descripcion);
            this.Habilitaciones.Add(habilitacion);
        }
        /// <summary>
        /// Remueve la Habilitacion
        /// </summary>
        /// <param name="habilitacion"></param>
        public void RemoveHabilitacion(Habilitacion habilitacion)
        {
            this.Habilitaciones.Remove(habilitacion);
        }

    }
}
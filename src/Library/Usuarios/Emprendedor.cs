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
        /// Obtiene un valor que indica la especializacion del emprendedor
        /// </summary>
        /// <value></value>

        public string Especializacion {get; set;}

        private List<Habilitacion> habilitaciones = new List<Habilitacion>();

        /// <summary>
        /// Obtiene el valor de las habilitaciones del emprendedor
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
        /// Inicializa una nueva instancia de la clase Emprendedor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="rubro"></param>
        /// <param name="ciudad"></param>
        /// <param name="calle"></param>
        /// <param name="especializacion"></param>
        /// <returns></returns>

        public Emprendedor(string nombre, Rubro rubro, string ciudad, string calle,string especializacion) :
        base(nombre,rubro,ciudad,calle)
        {
            this.Especializacion = especializacion;
        }

        /// <summary>
        /// Agrega una habilitacion al emprendedor
        /// </summary>
        /// <param name="habilitacion"></param>

        public void AddHabilitacion(Habilitacion habilitacion)
        {
            this.Habilitaciones.Add(habilitacion);
        }
        /// <summary>
        /// Remueve una habilitacion al emprendedor
        /// </summary>
        /// <param name="habilitacion"></param>
        public void RemoveHabilitacion(Habilitacion habilitacion)
        {
            this.Habilitaciones.Remove(habilitacion);
        }

    }
}
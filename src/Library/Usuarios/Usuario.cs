using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa un usuario de la aplicación.
    /// </summary>
    
    public abstract class Usuario   
    {

        /// <summary>
        /// Obtiene un valor que indica el nombre del usuario
        /// </summary>
        /// <value></value>

        public string Nombre {get; set;}

        /// <summary>
        /// Obtiene un valor que indica el rubro del usuario
        /// </summary>
        /// <value></value>

        public Rubro Rubro {get; set;}

        /// <summary>
        /// Obtiene un valor que indica la ubicacion del usuario
        /// </summary>
        /// <value></value>

        public Ubicacion Ubicacion {get;set;}
        

        /// <summary>
        /// Inicializa una instancia de la clase Usuario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="rubro"></param>
        /// <param name="ciudad"></param>
        /// <param name="calle"></param>
        protected Usuario (string nombre, Rubro rubro, string ciudad, string calle)
        {
            if (nombre == null)
            {
                throw new ArgumentNullException("name");
            }
            if (nombre =="")
            {
                throw new ArgumentException("El nombre no puede estar vacio");
            }
            Ubicacion ubicacion = new Ubicacion(ciudad,calle);
            this.Ubicacion=ubicacion;
            this.Nombre=nombre;
            this.Rubro=rubro;
        }
    }
}
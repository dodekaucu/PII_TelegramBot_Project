//--------------------------------------------------------------------------------
// <copyright file="Usuario.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa un usuario de la aplicación.
    /// </summary>
    public abstract class Usuario
    {
        private List<Oferta> registroUsuario = new List<Oferta>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/>.
        /// </summary>
        /// <param name="nombre">parametro nombre recibido por el constructor del usuario.</param>
        /// <param name="rubro">parametro rubro recibido por el constructor del usuario.</param>
        /// <param name="ciudad">parametro ciudad recibido por el constructor del usuario.</param>
        /// <param name="calle">parametro calle recibido por el constructor del usuario.</param>
        protected Usuario(string nombre, Rubro rubro, string ciudad, string calle)
        {
            if (nombre == null)
            {
                throw new ArgumentNullException("name");
            }
            if (nombre.Length == 0)
            {
                throw new ArgumentException("El nombre no puede estar vacio");
            }

            Ubicacion ubicacion = new Ubicacion(ciudad, calle);
            this.Ubicacion = ubicacion;
            this.Nombre = nombre;
            this.Rubro = rubro;
        }

        /// <summary>
        /// Obtiene o establece un valor el nombre del usuario.
        /// </summary>
        /// <value>this.nombre.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que es el rubro del usuario.
        /// </summary>
        /// <value>this.rubro.</value>
        public Rubro Rubro { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica la ubicacion del usuario.
        /// </summary>
        /// <value>this.ubicacion.</value>
        public Ubicacion Ubicacion { get; set; }

        /// <summary>
        /// Obtiene un valor que indica el registro del usuario.
        /// </summary>
        /// <value>this.registroUsuario.</value>
        public List<Oferta> RegistroUsuario
        {
            get
            {
                return this.registroUsuario;
            }
        }
    }
}
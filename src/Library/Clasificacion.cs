//--------------------------------------------------------------------------------
// <copyright file="Clasificacion.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Esta clase representa una clasificación de un material.
    /// </summary>
    public class Clasificacion
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Clasificacion"/>.
        /// </summary>
        /// <param name="nombre"> parametro nombre recibido por el constructor.</param>
        /// <param name="descripcion">parametro descripcion recibido por el constructor.</param>
        public Clasificacion(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        /// <summary>
        /// Obtiene un valor que indica el nombre de la clasificación.
        /// </summary>
        /// <value>this.nombre.</value>
        public string Nombre { get; }

        /// <summary>
        /// Obtiene un valor que indica la descripcion de la clasificación.
        /// </summary>
        /// <value>this.descripcion.</value>
        public string Descripcion { get; }
    }
}
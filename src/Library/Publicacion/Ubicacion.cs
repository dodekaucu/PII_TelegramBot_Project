//--------------------------------------------------------------------------------
// <copyright file="Ubicacion.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Esta clase representa una ubicacion.
    /// </summary>
    public class Ubicacion
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Ubicacion"/>.
        /// </summary>
        /// <param name="ciudad">parametro ciudad que recibe el constructor.</param>
        /// <param name="calle">parametro calle que recibe el constructor.</param>
        public Ubicacion(string ciudad, string calle)
        {
            this.Ciudad = ciudad;
            this.Calle = calle;
        }

        /// <summary>
        ///  Obtiene o establece la ciudad.
        /// </summary>
        /// <value>this.ciudad.</value>
        public string Ciudad { get; set; }

        /// <summary>
        /// Obtiene o establece la calle.
        /// </summary>
        /// <value>this.calle.</value>
        public string Calle { get; set; }
    }
}
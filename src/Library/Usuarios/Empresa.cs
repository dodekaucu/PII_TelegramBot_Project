//--------------------------------------------------------------------------------
// <copyright file="Empresa.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Clase que representa una Empresa.
    /// Patrones y principios utilizados:
    /// EXPERT, porque conoce toda la informacion que debe conocer una empresa.
    /// </summary>
    public class Empresa : Usuario
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Empresa"/>.
        /// </summary>
        /// <param name="nombre">parametro nombre recibido por el constructor de empresa.</param>
        /// <param name="rubro">parametro rubro recibido por el constructor de la empresa.</param>
        /// <param name="ciudad">parametro ciudad recibido por el constructor de la emrpesa.</param>
        /// <param name="calle">parametro calle recibido por el constructor de la empresa.</param>
        public Empresa(string nombre, Rubro rubro, string ciudad, string calle,string telefono)
        : base(nombre, rubro, ciudad, calle)
        {
            this.Telefono = telefono;
        }

        public string Telefono { get; set; }
    }
}
//--------------------------------------------------------------------------------
// <copyright file="Oferta.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa una oferta. Es una subclase de OfertaBase
    /// Esto se debe a porque al ser una oferta recurrente necesita una property que es fechaDeGeneracion.
    /// </summary>
    public class Oferta : OfertaBase
    {
        private FechaCompraOferta fechaCompra;
        private bool disponible;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Oferta"/>.
        /// </summary>
        /// <param name="nombreoferta">parametro nombre de la oferta.</param>
        /// <param name="empresa">parametro empresa que oferta.</param>
        /// <param name="ciudad">ciuadad donde se encuentra la oferta.</param>
        /// <param name="calle">callle donde se encuentra la oferta.</param>
        /// <param name="nombreMaterial">nombre del material donde se encuentra la oferta.</param>
        /// <param name="clasificacion">clasificacion del material.</param>
        /// <param name="cantidad">cantidad del material.</param>
        /// <param name="unidad">unidad del material.</param>
        /// <param name="valor">valor del material.</param>
        /// <param name="fechaDeGeneracion">cuando se genera la oferta.</param>
        public Oferta(string nombreoferta, Empresa empresa, string ciudad, string calle, string nombreMaterial, Clasificacion clasificacion, int cantidad, string unidad, double valor, DateTime fechaDeGeneracion)
        : base(nombreoferta, empresa, ciudad, calle, nombreMaterial, clasificacion, cantidad, unidad, valor)
        {
            this.FechadeGeneracion = fechaDeGeneracion;
        }

        /// <summary>
        /// Obtiene o establece cuando la oferta va a ser generada.
        /// </summary>
        /// <value>La fecha de la generacion.</value>
        public DateTime FechadeGeneracion { get; set; }

        public bool Disponible
        {
            get
            {
                if(fechaCompra == null)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddComprador(string id,DateTime fechaventa)
        {
            FechaCompraOferta fechaCompra = new FechaCompraOferta(id,fechaventa);
        }
    }
}
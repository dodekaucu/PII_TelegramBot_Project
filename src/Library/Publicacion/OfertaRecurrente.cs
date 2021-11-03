using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa una oferta recurrente.
    /// </summary>
    public class OfertaRecurrente : OfertaBase
    {
        /// <summary>
        /// Obtiene o establece el número de veces que se repite la oferta en un mes.
        /// </summary>
        /// <value>this.RecurrenciaMensual.</value>
        public int RecurrenciaMensual { get; set; }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="OfertaRecurrente"/>.
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
        /// <param name="recurrenciaMensual">cuantas veces se repite en un mes.</param>
        public OfertaRecurrente(string nombreoferta, Empresa empresa, string ciudad, string calle, 
        string nombreMaterial ,Clasificacion clasificacion,
        int cantidad, string unidad, double valor,int recurrenciaMensual) 
        : base(nombreoferta, empresa, ciudad, calle, nombreMaterial, clasificacion, cantidad, unidad, valor)
        {
            this.RecurrenciaMensual = recurrenciaMensual;
        }
    }
}
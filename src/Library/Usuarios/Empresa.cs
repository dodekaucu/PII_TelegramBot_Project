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
        public Empresa(string nombre, Rubro rubro, string ciudad, string calle)
        : base(nombre, rubro, ciudad, calle)
        {
        }

        public void CrearOfertaUnica(
            string nombre,string ciudad,string calle,string nombreMaterial,Clasificacion clasificacion,
            int cantidad,string unidad, double valor, DateTime fechaDeGeneracion
        )
        {
            Oferta oferta = new Oferta
            (nombre, this, ciudad, calle, nombreMaterial,clasificacion,cantidad,unidad,valor,fechaDeGeneracion);
            Contenedor.Instancia.AddOferta(oferta);
        }

        public void CrearOfertaRecurrente(
            string nombre,string ciudad,string calle,string nombreMaterial,Clasificacion clasificacion,
            int cantidad,string unidad, double valor, int recurrencia
        )
        {
            OfertaRecurrente oferta = new OfertaRecurrente
            (nombre, this, ciudad, calle, nombreMaterial,clasificacion,cantidad,unidad,valor,recurrencia);
            Contenedor.Instancia.AddOferta(oferta);
        }
    }
}
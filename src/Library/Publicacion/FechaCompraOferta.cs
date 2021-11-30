//--------------------------------------------------------------------------------
// <copyright file="Admin.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;

namespace Library
{
    /// <summary>
    /// Clase que guarda la fecha de compra de una oferta y el usuario.
    /// </summary>
    public class FechaCompraOferta
    {
        private DateTime fechaCompra;
        private string idComprador;

        /// <summary>
        /// Constructor de Fecha compra oferta.
        /// </summary>
        /// <param name="idComprador">ID del comprador.</param>
        /// <param name="fechaCompra">Fecha de compra.</param>
        public FechaCompraOferta(string idComprador, DateTime fechaCompra)
        {
            this.IdComprador = idComprador;
            this.FechaCompra = fechaCompra;
        }

        /// <summary>
        /// Obtiene o establece el id del comprador.
        /// </summary>
        /// <value></value>
        public string IdComprador { get; }

        /// <summary>
        /// Obtiene o establece la fecha de compra.
        /// </summary>
        /// <value></value>
        public DateTime FechaCompra { get; }
    }
}
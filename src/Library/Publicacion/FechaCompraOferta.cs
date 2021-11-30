//--------------------------------------------------------------------------------
// <copyright file="Admin.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;

namespace Library
{
    public class FechaCompraOferta
    {
        private DateTime fechaCompra;
        private string idComprador;

        public FechaCompraOferta(string idComprador, DateTime fechaCompra)
        {
            this.IdComprador = idComprador;
            this.FechaCompra = fechaCompra;
        }

        public string IdComprador { get; }
        public DateTime FechaCompra { get; }
    }
}
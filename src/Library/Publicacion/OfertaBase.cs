//--------------------------------------------------------------------------------
// <copyright file="OfertaBase.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase abstracta que representa la base de oferta.
    /// </summary>
    public abstract class OfertaBase
    {
        /// <summary>
        /// Obtiene o establece el nombre de la oferta.
        /// </summary>
        /// <value>Nombre de la oferta.</value>
        public string Nombreoferta { get; set; }

        /// <summary>
        /// Obtiene o establece fecha en la cual se realizo la venta.
        /// </summary>
        /// <value>Fecha de la venta.</value>
        public DateTime FechaVenta { get; set; }

        /// <summary>
        /// Obtiene o establece material ofertado en la oferta.
        /// </summary>
        /// <value>Material ofrecido.</value>
        public Material Material { get; set; }

        /// <summary>
        /// Obtiene empresa que realiza la oferta.
        /// </summary>
        /// <value>Empresa que oferta.</value>
        public Empresa Empresa { get; }

        /// <summary>
        /// Obtiene o establece ubicación de la oferta.
        /// </summary>
        /// <value>Ubicacion de la oferta.</value>
        public Ubicacion Ubicacion { get; set; }
        private List<string> palabrasClaves = new List<string>();

        /// <summary>
        /// Obtiene palabras clave de la oferta, estas sirven para su futura busqueda.
        /// </summary>
        /// <value></value>
        public List<string> PalabrasClaves
        {
            get { return palabrasClaves; }
        }

        private List<Habilitacion> habilitaciones = new List<Habilitacion>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OfertaBase"/>.
        /// </summary>
        /// <param name="nombreoferta">Nombre de la oferta a crear.</param>
        /// <param name="empresa">Empresa que crea la oferta.</param>
        /// <param name="ciudad">Ciudad donde se encuentra la oferta.</param>
        /// <param name="calle">Calle donde esta la oferta.</param>
        /// <param name="nombreMaterial">Nombre del material a ofertar.</param>
        /// <param name="clasificacion">Clasificación del material.</param>
        /// <param name="cantidad">Cantidad a ofertar.</param>
        /// <param name="unidad">Unidad del material.</param>
        /// <param name="valor">Valor de la oferta.</param>
        protected OfertaBase(string nombreoferta, Empresa empresa, string ciudad, string calle, string nombreMaterial, Clasificacion clasificacion, int cantidad, string unidad, double valor)
        {
            Material material = new Material(nombreMaterial, clasificacion, cantidad, unidad, valor);
            this.Material = material;
            this.Nombreoferta = nombreoferta;
            this.Empresa = empresa;
            Ubicacion ubicacion = new Ubicacion(ciudad, calle);
            this.Ubicacion = ubicacion;

            this.PalabrasClaves.Add(this.Nombreoferta);
            this.PalabrasClaves.Add(this.Empresa.Nombre);
            this.PalabrasClaves.Add(this.Material.Nombre);
        }

        /// <summary>
        /// Obtiene lista de habilitaciones nesesarias para poder adquirir la oferta.
        /// </summary>
        /// <value></value>
        public List<Habilitacion> Habilitaciones
        {
            get { return this.habilitaciones; }
        }

        /// <summary>
        /// Añade habilitaciones a la lista.
        /// </summary>
        /// <param name="habilitacion">Habilitaciones necesarias para adquirir la oferta.</param>
        public void AddHabilitacion(Habilitacion habilitacion)
        {
            this.habilitaciones.Add(habilitacion);
        }

        /// <summary>
        /// Añade palabras clave a la lista.
        /// </summary>
        /// <param name="palabraClave">Palabras clave para buscar la oferta.</param>
        public void AddPalabraClave(string palabraClave)
        {
            this.PalabrasClaves.Add(palabraClave);
        }
    }
}
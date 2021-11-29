//--------------------------------------------------------------------------------
// <copyright file="Emprendedor.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Esta clase representa un Emprendedor.
    /// Patrones y principios utilizados:
    /// EXPERT, porque el emprendedor es una clase experta en la inficación que debe poseer un emprendedor.
    /// </summary>
    public class Emprendedor : Usuario
    {
        private Collection<Habilitacion> habilitaciones = new Collection<Habilitacion>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Emprendedor"/>.
        /// </summary>
        /// <param name="nombre">parametro nombre recibido por el constructor del emprendedor.</param>
        /// <param name="rubro">parametro rubro recibido por el constructor del emprendedor.</param>
        /// <param name="ciudad">parametro ciudad recibido por el constructor del emprendedor.</param>
        /// <param name="calle">parametro calle recibido por el constructor del emprendedor.</param>
        /// <param name="especializacion">parametro especializacion recibidio por el constructor del emprendedor.</param>
        public Emprendedor(string nombre, Rubro rubro, string ciudad, string calle, string especializacion)
        : base(nombre, rubro, ciudad, calle)
        {
            this.Especializacion = especializacion;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica la especializacion del emprendedor.
        /// </summary>
        /// <value>this.especializacon.</value>
        public string Especializacion { get; set; }

        /// <summary>
        /// Obtiene el valor de las habilitaciones del emprendedor.
        /// </summary>
        /// <value>this.habilitaciones.</value>
        public Collection<Habilitacion> Habilitaciones
        {
            get
            {
                return this.habilitaciones;
            }
        }

        /// <summary>
        /// Agrega una habilitacion al emprendedor.
        /// </summary>
        /// <param name="habilitacion">parametro habilitaciones que recibe el metodo AddHabilitacion.</param>
        public void AddHabilitacion(Habilitacion habilitacion)
        {
            this.Habilitaciones.Add(habilitacion);
        }

        /// <summary>
        /// Remueve una habilitacion al emprendedor.
        /// </summary>
        /// <param name="habilitacion">parametro habilitaciones que recibe el metodo RemoveHabilitacion.</param>
        public void RemoveHabilitacion(Habilitacion habilitacion)
        {
            this.Habilitaciones.Remove(habilitacion);
        }
    }
}
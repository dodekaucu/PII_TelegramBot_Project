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
    public class Emprendedor : IJsonSerialize
    {
        private Collection<Habilitacion> habilitaciones = new Collection<Habilitacion>();
        private Collection<Oferta> registroUsuario = new Collection<Oferta>();

        public Emprendedor()
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Emprendedor"/>.
        /// </summary>
        /// <param name="nombre">parametro nombre recibido por el constructor del emprendedor.</param>
        /// <param name="rubro">parametro rubro recibido por el constructor del emprendedor.</param>
        /// <param name="ciudad">parametro ciudad recibido por el constructor del emprendedor.</param>
        /// <param name="calle">parametro calle recibido por el constructor del emprendedor.</param>
        /// <param name="especializacion">parametro especializacion recibidio por el constructor del emprendedor.</param>

        public Emprendedor(string nombre, Rubro rubro, string ciudad, string calle, string especializacion, string id)
        {
            this.Nombre = nombre;
            this.Rubro = rubro;
            //this.Ciudad = ciudad;
            //this.Calle = calle;

            if (nombre == null)
            {
                throw new ArgumentNullException("name");
            }
            if (nombre.Length == 0)
            {
                throw new ArgumentException("El nombre no puede estar vacio");
            }

            Ubicacion ubicacion = new Ubicacion(ciudad, calle);
            this.Ubicacion = ubicacion;
            
            
            this.Especializacion = especializacion;
        }

        /// <summary>
        /// Obtiene o establece un valor el nombre del usuario.
        /// </summary>
        /// <value>this.nombre.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el id del usuario.
        /// </summary>
        /// <value></value>
        public string ID { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que es el rubro del usuario.
        /// </summary>
        /// <value>this.rubro.</value>
        public Rubro Rubro { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica la ubicacion del usuario.
        /// </summary>
        /// <value>this.ubicacion.</value>
        public Ubicacion Ubicacion { get; set; }

        /// <summary>
        /// Obtiene un valor que indica el registro del usuario.
        /// </summary>
        /// <value>this.registroUsuario.</value>
        [JsonInclude]
        public Collection<Oferta> RegistroUsuario
        {
            get
            {
                return this.registroUsuario;
            }
        }

        /// <summary>
        /// Añiade al registro del usuario la oferta.
        /// </summary>
        /// <param name="oferta">Parametro.</param>
        public void AddToRegister(Oferta oferta)
        {
            this.registroUsuario.Add(oferta);
        }

        /// <summary>
        /// Busca en el registro del usuario.
        /// </summary>
        /// <param name="fechaDesde">Parametro que indica la fechaDesde donde se desea buscar.</param>
        /// <returns>una lista de ofertas llamada resultado.</returns>
        public Collection<Oferta> BuscarEnHistorial(DateTime fechaDesde)
        {
            Collection<Oferta> resultado = new Collection<Oferta>();
            foreach (Oferta oferta in this.registroUsuario)
            {
                /*Oferta o;
                if (oferta as Oferta != null)
                {
                    o = oferta as Oferta;

                }*/
                if (oferta.RecurrenciaMensual == 0)
                    {
                        if (!oferta.Disponible && oferta.FechaCompra.FechaCompra >= fechaDesde)
                        {
                            resultado.Add(oferta);
                        }
                    }
                else if (oferta.RecurrenciaMensual > 0)
                {
                    
                    foreach (FechaCompraOferta fecha in oferta.RegistroVentas)
                    {
                        if (fecha.FechaCompra >= fechaDesde && fecha.IdComprador == this.ID)
                        {
                            resultado.Add(oferta);
                        }
                    }
                }
            }

            return resultado;
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
        [JsonInclude]
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
        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance, 
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(this, options);
            return json;
        }
    }
}
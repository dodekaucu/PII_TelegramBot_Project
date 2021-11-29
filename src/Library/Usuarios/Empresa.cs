//--------------------------------------------------------------------------------
// <copyright file="Empresa.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;

namespace Library
{
    /// <summary>
    /// Clase que representa una Empresa.
    /// Patrones y principios utilizados:
    /// EXPERT, porque conoce toda la informacion que debe conocer una empresa.
    /// </summary>
    public class Empresa : IJsonSerialize
    {
        
        private Collection<Oferta> registroUsuario = new Collection<Oferta>();

        /// <summary>
        /// Constructor de empresa vacío para deserialización.
        /// </summary>
        public Empresa()
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Empresa"/>.
        /// </summary>
        /// <param name="nombre">parametro nombre recibido por el constructor de empresa.</param>
        /// <param name="rubro">parametro rubro recibido por el constructor de la empresa.</param>
        /// <param name="ciudad">parametro ciudad recibido por el constructor de la emrpesa.</param>
        /// <param name="calle">parametro calle recibido por el constructor de la empresa.</param>
        /// <param name="id">parametro id recibido por el constructor de la empresa.</param>
        
        [JsonConstructor]
        public Empresa(string nombre, Rubro rubro, string ciudad, string calle, string id, string telefono)
        {
            this.Nombre = nombre;
            this.Rubro = rubro;
            this.Ciudad = ciudad;
            this.Calle = calle;
            this.ID = id;
            this.Telefono = telefono;
            
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
            
            
        }

        /// <summary>
        /// Obtiene o establece el id del usuario.
        /// </summary>
        /// <value></value>
        public string ID { get; set; }

        /// <summary>
        /// Obtiene o establece un valor el nombre del usuario.
        /// </summary>
        /// <value>this.nombre.</value>
        public string Nombre { get; set; }
        /// <summary>
        /// Obtiene o establece la calle donde se ubica la empresa.
        /// </summary>
        public string Calle {get;set;}
        /// <summary>
        /// Obtiene o establece la ciudad donde se ubica la empresa.
        /// </summary>
        public string Ciudad {get;set;}

        public string Telefono { get; set; }

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
                Oferta o;
                if (oferta as Oferta != null)
                {
                    o = oferta as Oferta;

                }
                if (oferta.RecurrenciaSemanal == 0)
                    {
                        if (!oferta.Disponible && oferta.FechaCompra.FechaCompra >= fechaDesde)
                        {
                            resultado.Add(oferta);
                        }
                    }
                else if (oferta.RecurrenciaSemanal > 0)
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
        /// Convert to json.
        /// </summary>
        /// <returns></returns>
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
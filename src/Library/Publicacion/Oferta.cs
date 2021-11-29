//--------------------------------------------------------------------------------
// <copyright file="Oferta.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Esta clase representa una oferta. Es una subclase de OfertaBase
    /// Esto se debe a porque al ser una oferta recurrente necesita una property que es fechaDeGeneracion.
    /// </summary>
    public class Oferta : IJsonSerialize
    {
        Contenedor db = Contenedor.Instancia;
        private FechaCompraOferta fechaCompra;
        private Collection<FechaCompraOferta> registroVentas = new Collection<FechaCompraOferta> ();
        private bool disponible;
        private int identificador;
        private Collection<string> palabrasClaves = new Collection<string>();
        private Collection<Habilitacion> habilitaciones = new Collection<Habilitacion>();

        /// <summary>
        /// Constructor de oferta vacío para la deserialización.
        /// </summary>
        public Oferta()
        {

        }

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
        /// <param name="recurrenciaSemanal">Cada cuantas semanas se renueva la oferta.</param>
        /// <param name="fechaDeGeneracion">cuando se genera la oferta.</param>
        [JsonConstructor]
        public Oferta(string nombreoferta, Empresa empresa, string ciudad, string calle, string nombreMaterial, Clasificacion clasificacion, int cantidad, string unidad, double valor, int recurrenciaSemanal, DateTime fechaDeGeneracion)
        {
            
            this.Empresa = empresa;
            this.Ciudad = ciudad;
            this.Calle = calle;
            this.Nombrematerial = nombreMaterial;
            this.Clasificacion = clasificacion;
            this.Cantidad = cantidad;
            this.Unidad = unidad;
            this.Valor = valor;
            this.RecurrenciaSemanal = recurrenciaSemanal;
            this.FechadeGeneracion = fechaDeGeneracion;
            this.Nombreoferta = nombreoferta;

            Material material = new Material(nombreMaterial, clasificacion, cantidad, unidad, valor);
            this.Material = material;
            Ubicacion ubicacion = new Ubicacion(ciudad, calle);
            this.Ubicacion = ubicacion;
            this.AddPalabraClave(this.Nombreoferta);
            this.AddPalabraClave(this.Empresa.Nombre);
            this.AddPalabraClave(this.Material.Nombre);
            Contenedor db = Contenedor.Instancia;
            this.identificador = db.Ofertas.Count;
        }

        /// <summary>
        /// Recurrencia semanal. Esto es un int de cada cuantas semanas se repite la oferta.
        /// </summary>
        /// <value></value>
        public int RecurrenciaSemanal { get; set; }

        /// <summary>
        /// Obtiene o establece cuando la oferta va a ser generada.
        /// </summary>
        /// <value>La fecha de la generacion.</value>
        public DateTime FechadeGeneracion { get; set; }

        /// <summary>
        /// ID de la oferta.
        /// </summary>
        /// <value></value>

        public int Identificador { get => this.identificador; }

        /// <summary>
        /// Obtiene o establece el nombre de la oferta.
        /// </summary>
        /// <value>Nombre de la oferta.</value>
        public string Nombreoferta { get; set; }

        /// <summary>
        /// Obtiene o establece la calles donde se encuentra la oferta.
        /// </summary>
        /// <value></value>
        public string Calle {get;set;}

        /// <summary>
        /// Obtiene o establece la ciudad donde se encuentra la oferta.
        /// </summary>
        /// <value></value>
        public string Ciudad {get;set;}

        /// <summary>
        /// Obtiene o establece el nombre del materia de la oferta.
        /// </summary>
        /// <value></value>
        public string Nombrematerial {get;set;}

        /// <summary>
        /// Obtiene o establece la clasificacion del material.
        /// </summary>
        /// <value></value>
        public Clasificacion Clasificacion {get;set;}

        /// <summary>
        /// Obtiene o establece la cantidad de material.
        /// </summary>
        /// <value></value>

        public int Cantidad {get;set;}

        /// <summary>
        /// Obtiene o establece la unidad del material.
        /// </summary>
        /// <value></value>

        public string Unidad {get;set;}

        /// <summary>
        /// Obtiene o establece el precio de la oferta.
        /// </summary>
        /// <value></value>

        public double Valor {get;set;}

        /// <summary>
        /// Obtiene o establece fecha en la cual se realizo la venta.
        /// </summary>
        /// <value>Fecha de la venta.</value>
        public DateTime FechaVenta { get; set; } //BORRARLA --> NO SIRVE MAS

        /// <summary>
        /// Obtiene o establece material ofertado en la oferta.
        /// </summary>
        /// <value>Material ofrecido.</value>
        public Material Material { get; set; }

        /// <summary>
        /// Obtiene empresa que realiza la oferta.
        /// </summary>
        /// <value>Empresa que oferta.</value>
        public Empresa Empresa { get; set;}

        /// <summary>
        /// Obtiene o establece ubicación de la oferta.
        /// </summary>
        /// <value>Ubicacion de la oferta.</value>
        public Ubicacion Ubicacion { get; set; }

        /// <summary>
        /// Obtiene palabras clave de la oferta, estas sirven para su futura busqueda.
        /// </summary>
        /// <value>Palabras clave de la oferta.</value>
        [JsonInclude]
        public Collection<string> PalabrasClaves
        {
            get
            {
                return this.palabrasClaves;
            }
        }

        /// <summary>
        /// Obtiene lista de habilitaciones nesesarias para poder adquirir la oferta.
        /// </summary>
        /// <value>retorna this.habilitaciones.</value>
        [JsonInclude]
        public Collection<Habilitacion> Habilitaciones
        {
            get
            {
                return this.habilitaciones;
            }
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
            string[] palabras = palabraClave.Split(" ");
            foreach (string palabra in palabras)
            {
                this.PalabrasClaves.Add(palabra.ToLower());
            }
                
        }
        
        
        /// <summary>
        /// Obtiene si la oferta esta disponible o no PARA OFERTAS ÚNICAS.
        /// </summary>
        /// <value></value>
        public bool Disponible
        {
            get
            {
                return fechaCompra == null;
            }
        }
        /// <summary>
        /// Obtiene la fecha de compra PARA OFERTAS ÚNICAS.
        /// </summary>
        /// <value></value>
        public FechaCompraOferta FechaCompra 
        {
            get
            {
                return this.fechaCompra;
            }
        }
        
        /// <summary>
        /// Añade un comprador al oferta, distingue entre ofertas únicas y recurrentes.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <param name="fechaventa">Fecha de venta.</param>
        public void AddComprador(string id,DateTime fechaventa)
        {
            if (this.RecurrenciaSemanal == 0)
            {
            FechaCompraOferta fechaCompra = new FechaCompraOferta(id,fechaventa);
            this.fechaCompra = fechaCompra;
            }
            if (this.RecurrenciaSemanal > 0)
            {
            FechaCompraOferta venta = new FechaCompraOferta(id,fechaventa);
            this.registroVentas.Add(venta);
            }
        }

        //Recurrente
        /// <summary>
        /// Obtiene el registro de ventas PARA OFERTAS RECURRENTES.
        /// </summary>
        /// <value></value>
        [JsonInclude]
        public Collection<FechaCompraOferta> RegistroVentas
        {
            get
            {
                return this.registroVentas;
            }
        }

        /// <summary>
        /// Convert to Json.
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
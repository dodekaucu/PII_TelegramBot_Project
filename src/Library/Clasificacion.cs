//--------------------------------------------------------------------------------
// <copyright file="Clasificacion.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Esta clase representa una clasificación de un material.
    /// </summary>
    public class Clasificacion : IJsonSerialize
    {   
        /// <summary>
        /// Constructor vacío para la serialización.
        /// </summary>
        public Clasificacion()
        {
            
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Clasificacion"/>.
        /// </summary>
        /// <param name="nombre"> parametro nombre recibido por el constructor.</param>
        /// <param name="descripcion">parametro descripcion recibido por el constructor.</param>
        [JsonConstructor]
        public Clasificacion(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        /// <summary>
        /// Obtiene un valor que indica el nombre de la clasificación.
        /// </summary>
        /// <value>this.nombre.</value>
        public string Nombre { get; }

        /// <summary>
        /// Obtiene un valor que indica la descripcion de la clasificación.
        /// </summary>
        /// <value>this.descripcion.</value>
        public string Descripcion { get; }

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
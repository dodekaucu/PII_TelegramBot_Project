//--------------------------------------------------------------------------------
// <copyright file="Habilitacion.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Esta clase representa una Habilitacion basica.
    /// </summary>
    public class Habilitacion: IJsonSerialize
    {
        public string Name { get; }
        public string Descripcion { get; }
        public Habilitacion()
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Habilitacion"/>.
        /// </summary>
        /// <param name="name">Parametro name que recibe el constructor de la habilitacion.</param>
        /// <param name="descripcion">Parametro descripcion que recibe el constructor de la habilitacion.</param>
        [JsonConstructor]
        public Habilitacion(string name, string descripcion)
        {
            this.Name = name;
            this.Descripcion = descripcion;
        }

        /// <summary>
        /// Obtiene un valor que indica el nombre de la habilitacion.
        /// </summary>
        /// <value>this.name.</value>
        //public string Name { get; }

        /// <summary>
        /// Obtiene un valor que indica la descripcion de la habilitacion.
        /// </summary>
        /// <value>this.descripcion.</value>
        //public string Descripcion { get; }
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
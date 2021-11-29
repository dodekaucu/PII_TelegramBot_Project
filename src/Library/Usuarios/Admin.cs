//--------------------------------------------------------------------------------
// <copyright file="Admin.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Esta clase representa un Administrador de la aplicacion.
    /// </summary>
    public class Admin: IJsonSerialize
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Admin"/>.
        /// </summary>
        /// <param name="nombre">parametro que recibe el nombre del admin.</param>
        public Admin(string nombre)
        {
            this.Nombre = nombre;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el nombre del admin.
        /// </summary>
        /// <value>this.nombre.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Invita a una Empresa.
        /// </summary>
        /// <param name="userEmpresa">parametro userEmpresa que represneta el usuario de la empresa a inviatr.</param>
        public void InvitarEmpresa(string userEmpresa)
        {
            throw new System.NotImplementedException();
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
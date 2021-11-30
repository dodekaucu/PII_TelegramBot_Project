//--------------------------------------------------------------------------------
// <copyright file="IJsonSerialize.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Library
{
    /// <summary>
    /// Interface con la firma de los métodos que debe tener un manejador de datos.
    /// </summary>
    public interface IJsonSerialize
    {
        /// <summary>
        /// Método que serializa un objeto en formato Json.
        /// </summary>
        /// <returns>String con el objeto serializado en formato Json.</returns>
        string ConvertToJson();
        /*
        /// <summary>
        /// Asigna las propiedades de un objeto a partir de un string en formato Json.
        /// </summary>
        /// <param name="json">El texto del cual asignamos las propiedades</param>
        void LoadFromJson(string json);*/
    }
}
//--------------------------------------------------------------------------------
// <copyright file="IManejoDeDatos.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Library
{
    /// <summary>
    /// Interface con la firma de los métodos que debe tener un manejador de datos.
    /// </summary>
    public interface IManejoDeDatos
    {
        /// <summary>
        /// Guarda los datos en un archivo.
        /// </summary>
        /// <param name="dondeGuardar">parametro que indica donde se va a guardar el archivo.</param>
        /// <param name="nombreArchivo">parametro que indica el nombre del archivo a guardar.</param>
        void GuardarInfo(string dondeGuardar, string nombreArchivo);

        /// <summary>
        /// Devuelve los datos de un archivo.
        /// </summary>
        /// <param name="dondeBuscar">parametro que indica donde va a buscar el archivo.</param>
        void DevolverInfo(string dondeBuscar);
    }
}
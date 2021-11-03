//--------------------------------------------------------------------------------
// <copyright file="IChat.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Interface que representa la firma de los metodos de IChat.
    /// </summary>
    public interface IChat
    {
        /// <summary>
        /// Envia un mensaje al usuario.
        /// </summary>
        /// <param name="mensaje">parametro mensaje que envia al usuario.</param>
        void EnviarMensaje(string mensaje);

        /// <summary>
        /// Recibe el mensaje del usuario.
        /// </summary>
        void RecibirMensaje();
    }
}
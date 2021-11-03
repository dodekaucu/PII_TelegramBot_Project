//--------------------------------------------------------------------------------
// <copyright file="Chat.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;

namespace Library
{
    /// <summary>
    /// Clase que representa un chat.
    /// </summary>
    public class Chat : IChat
    {
        /// <summary>
        /// Envia un mensaje al usuario.
        /// </summary>
        /// <param name="mensaje">parametro mensaje que envia al usuario.</param>
        public void EnviarMensaje(string mensaje)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recibe el mensaje del usuario.
        /// </summary>
        public void RecibirMensaje()
        {
            throw new NotImplementedException();
        }
    }
}
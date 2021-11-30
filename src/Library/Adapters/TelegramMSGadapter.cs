//--------------------------------------------------------------------------------
// <copyright file="IManejoDeDatos.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Telegram.Bot.Types;

namespace Handlers
{
    /// <summary>
    /// Adaptador de mensajes de Telegram a mensajes de la interfaz de usuario.
    /// </summary>
    public class TelegramMSGadapter : IMessage
    {
        private Message message;
        private int id;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TelegramMSGadapter"/>.
        /// </summary>
        /// <param name="message">mensaje recibido.</param>
        public TelegramMSGadapter(Message message)
        {
            this.message = message;
            this.id = message.From.Id;
        }

        /// <summary>
        /// Mensaje recibido.
        /// </summary>
        public string Text
        {
            get
            {
                return this.message.Text;
            }
        }

        /// <summary>
        /// Identificador del usuario que envió el mensaje.
        /// </summary>
        public string ID
        {
            get
            {
                return this.id.ToString();
            }
        }
    }
}
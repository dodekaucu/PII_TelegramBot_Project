using Telegram.Bot.Types;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Adaptador de mensajes de Telegram a mensajes de la interfaz de usuario.
    /// </summary>
    public class TelegramMSGadapter : IMessage
    {
        private Message message;
        private string id;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TelegramMSGadapter"/>.
        /// </summary>
        /// <param name="message">mensaje recibido.</param>
        public TelegramMSGadapter(Message message)
        {
            this.message = message;
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
                return this.message.Chat.Id.ToString();
            }
        }
        
    }
}
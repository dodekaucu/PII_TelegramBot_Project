using System;
using Telegram.Bot.Types;
using System.Linq;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/start".
    /// </summary>
    public class StartHandler : BaseHandler //funka bien
    {

        private Contenedor contenedor;

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "/start".
        /// </summary>
        /// <param name="next">el proximo handler.</param>
        /// <returns></returns>
        public StartHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/start" };
        }

        /// <summary>
        /// Procesa el mensaje "/start" y evalua si el usuario que envia el mensaje esta  
        /// retorna true; retorna false en caso de que no se pueda procesar el mensaje.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            if (this.CanHandle(message))
            {
                if (db.Invitados.Contains(message.ID.ToString()))  // ver como referenciar a la clase contenedor
                {
                    response = "Usted se encuentra en la lista de empresas invitadas, se procedera con el registro";
                    return true;
                }
                else if (db.Administradores.Contains(message.ID.ToString()))
                {
                    response = "sos admin";
                    return true;
                }
                else
                {
                    response ="Usted no se encuentra en la lista de empresas invitadas, si usted es una empresa y desea registrarse como tal, por favor comuniqueselo a un Administrador. De lo contrario ignore el mensaje";
                    return true;
                }
                
            }

            response = string.Empty;
            return false;
        }

        protected override bool CanHandle(IMessage message)
        {
            if (this.Keywords == null || this.Keywords.Length == 0)
            {
                throw new InvalidOperationException("No hay palabras clave que puedan ser procesadas");
            }

            return this.Keywords.Any(s => message.Text.StartsWith(s, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
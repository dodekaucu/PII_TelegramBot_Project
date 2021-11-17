using System;
using System.Linq;
using Telegram.Bot.Types;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class AdminInvitationHandler : BaseHandler
    {
        private Contenedor contenedor;
        public AdminInvitationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Invitar" };
        }

        /// <summary>
        /// Procesa el mensaje "chau" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)  
        {
            Contenedor db = Contenedor.Instancia;
            if (this.CanHandle(message))
            {
                if (db.Administradores.Contains(message.ID.ToString()))
                {
                    string invitado = message.Text.Replace("/Invitar ","").Trim();
                    db.AddInvitado(invitado); 
                    response = "La empresa con el usuario:  " + invitado + " ha sido agregado a la lista de empresas invitadas";
                    return true;
                }
                else
                {
                    response = "Este comando solo puede ser ejecutado por un administrador";
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


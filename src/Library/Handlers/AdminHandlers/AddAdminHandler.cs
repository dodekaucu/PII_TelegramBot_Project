using System;
using System.Linq;
using Telegram.Bot.Types;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/AddAdmin".
    /// </summary>
    public class AddAdminHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddAdminHandler"/>. Esta clase procesa el mensaje "/AddAdmin".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AddAdminHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/AddAdmin" };
        }

        /// <summary>
        /// Procesa el comando "/AddAdmin", Si es ejecutado por un Administrador entonces se procede a añadir como administrador
        /// al usuario ingresado. El valor que se ingresa debe ser el ID del usuario, en este caso es el ID de Telegram.
        /// El ID del usuario se debe preguntar a la persona que se agrega, hay un bot que te lo dice (@userinfobot).
        /// En el caso de que el usuario que ejecute el comando no sea Admin se le informa que no tiene permisos para hacerlo.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        protected override bool InternalHandle(IMessage message, out string response)  
        {
            Contenedor db = Contenedor.Instancia;
            if (this.CanHandle(message))
            {
                if (db.Administradores.Contains(message.ID.ToString()))
                {
                    string newAdmin = message.Text.Replace("/AddAdmin ","").Trim();
                    db.AddAdministrador(newAdmin); 
                    response = "Se ha asignado como admin al usuario con ID: " + newAdmin;
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
    }
}
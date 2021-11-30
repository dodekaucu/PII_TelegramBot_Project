//--------------------------------------------------------------------------------
// <copyright file="IManejoDeDatos.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Telegram.Bot.Types;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/Invitar".
    /// </summary>
    public class AdminInvitationHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AdminInvitationHandler"/>. Esta clase procesa el mensaje "/Invitar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AdminInvitationHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Invitar" };
        }

        /// <summary>
        /// Procesa el comando "/Invitar", Si es ejecutado por un Administrador entonces se procede a invitar
        /// al usuario ingresado. El valor que se ingresa debe ser el ID del usuario, en este caso es el ID de Telegram.
        /// El ID del usuario se debe preguntar a la persona que se invita, hay un bot que te lo dice (@userinfobot).
        /// En el caso de que el que ejecute el comando no sea Admin se le informa que no tiene permisos para hacerlo.
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
                    string invitado = message.Text.ToLower().Replace("/invitar ","").Trim();
                    db.AddInvitado(invitado); 
                    response = "La empresa con el usuario: " + invitado + " ha sido agregado a la lista de empresas invitadas";
                    return true;
                }
                else
                {
                    response = "Este comando sólo puede ser ejecutado por un administrador";
                    return true;
                }
                
            }

            response = string.Empty;
            return false;
        }
    }
}


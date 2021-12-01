//--------------------------------------------------------------------------------
// <copyright file="CancelHandler.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/cacnelar".
    /// </summary>
    public class CancelHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CancelHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CancelHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/cancel"};
        }

        /// <summary>
        /// Procesa el mensaje "/cancel" elimina el ChatStatus del usuario asi como eliminar todo dato temporal que este posea y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            StatusManager sm = StatusManager.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            if (this.CanHandle(message))
            {
                if(sm.UserStatusChat.ContainsKey(message.ID))
                {
                    sm.UserStatusChat.Remove(message.ID);
                    dt.DataTemporal.Remove(message.ID);
                    response = "proceso cancelado";
                    return true;
                }
                else
                {
                    response = "no hay ningun proceso activo para cancelar";
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}
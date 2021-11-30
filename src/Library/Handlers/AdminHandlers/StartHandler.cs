//--------------------------------------------------------------------------------
// <copyright file="StartHandler.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
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
                if (db.Invitados.Contains(message.ID) && !db.Empresas.ContainsKey(message.ID))  // ver como referenciar a la clase contenedor
                {
                    response = "Usted se encuentra en la lista de empresas invitadas, Utilize el comando /registro para proceder con el registro";
                    return true;
                }
                else if (db.Administradores.Contains(message.ID.ToString()))
                {
                    response = "Eres admin";
                    return true;
                }
                else if (db.Empresas.ContainsKey(message.ID) || db.Emprendedores.ContainsKey(message.ID))
                {
                    if (db.Empresas.ContainsKey(message.ID))
                    {
                        response = "Bienvenido de vuelta"+ db.Empresas[message.ID].Nombre+"Recuerde que para publicar una oferta utilize el comando /PublicarOferta, para consultar sus publicaciones /MisPublicaciones, para añadir un comprador (en caso de haber vendido) /AñadirComprador, por ultimo /HistorialDesde para ver las ofertas vendidas en un periodo de tiempo" ;
                        return true;
                    }
                    else
                    {
                        response = "Bienvenido de vuelta "+db.Emprendedores[message.ID].Nombre+"Recuerde que que si necesita ayuda puede usar /ayuda para tener una guia detallada de los comandos";
                        return true;
                    }

                }
                else
                {
                    response ="Usted no se encuentra en la lista de empresas invitadas, si usted es una empresa y desea registrarse como tal, por favor comuniqueselo a un Administrador. De lo contrario ignore el mensaje. Para registrarse utilize el comando /registro";
                    return true;
                }
                
            }

            response = string.Empty;
            return false;
        }
    }
}
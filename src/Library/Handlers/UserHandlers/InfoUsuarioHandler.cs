using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/Info".
    /// </summary>
    public class InfoUsuarioHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InfoUsuarioHandler"/>. Esta clase procesa el comando "/Info".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public InfoUsuarioHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Info"};
        }

        /// <summary>
        /// Procesa el comando "/Info" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            if (this.CanHandle(message))
            {
                if(db.Empresas.ContainsKey(message.ID))
                {
                    string name = "Nombre: " + db.Empresas[message.ID].Nombre+"\n";
                    string rubro="Rubro: "+db.Empresas[message.ID].Rubro.Nombre+" "+db.Empresas[message.ID].Rubro.Area+"\n";
                    string ubicacion = "Ubicacion: "+db.Empresas[message.ID].Ubicacion.Ciudad+","+db.Empresas[message.ID].Ubicacion.Calle+"\n\n";
                    string idUser = "ID USUARIO: "+message.ID;
                    response= "EMPRESA:\n\n"+name+rubro+ubicacion+idUser;
                    return true;
                }
                else if (db.Emprendedores.ContainsKey(message.ID))
                {
                    string name = "Nombre: " + db.Emprendedores[message.ID].Nombre+"\n";
                    string rubro="Rubro: "+db.Emprendedores[message.ID].Rubro.Nombre+" "+db.Emprendedores[message.ID].Rubro.Area+"\n";
                    string ubicacion = "Ubicacion: "+db.Emprendedores[message.ID].Ubicacion.Ciudad+","+db.Emprendedores[message.ID].Ubicacion.Calle+"\n\n";
                    string idUser = "ID USUARIO: "+message.ID;
                    response= "EMPRENDEDOR:\n\n"+name+rubro+ubicacion+idUser;
                    return true;
                }
                else
                {
                    response = "Usted no se encuentra registrado";
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}
using System.Collections.ObjectModel;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/AddHabilitacion".
    /// </summary>
    public class AddPalabraClaveHandler : BaseHandler
    {

        public AddPalabraClaveHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/AddPalabraClave"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            StatusManager sm = StatusManager.Instancia;
            if(!sm.UserStatusChat.ContainsKey(message.ID))
            {
                sm.AddKeyUser(message.ID);
            }
            if (this.CanHandle(message))
            {
                if(sm.UserStatusChat[message.ID]=="AddPalabrasClave")
                {
                    response= "Actualmente se encuentra el proceso " + sm.UserStatusChat[message.ID]+" activo, porfavor, si desea activar otro comando cancele el actual con /cancel";
                    return true;
                }
                if(db.Emprendedores.ContainsKey(message.ID))
                {
                    response = "Este comando solo puede ser ejecutado por una empresa";
                }
                if(db.Empresas.ContainsKey(message.ID))
                {
                    //imprimir lista de oferta --> IDEM a habilitaciones.
                }
            }


            response = string.Empty;
            return false;
        }
    }
}
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/AddHabilitacion".
    /// </summary>
    public class AddHabilitacionHandler : BaseHandler
    {

        public AddHabilitacionHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/AddHabilitacion"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            StatusManager statusManager = StatusManager.Instancia;
            if (this.CanHandle(message))
            {
                if (db.Empresas.ContainsKey(message.ID))
                {
                    foreach (OfertaBase oferta in db.Ofertas)
                    {
                        if(oferta.Empresa.ID == message.ID) //VER COMO MEJORAR ESTO!!!!! 
                        {
                            
                        }
                    }
                }
                else
                {
                    response = "Usted no se encuentra registrado como empresa, para registrarse comuniquese con un Administrador";
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}
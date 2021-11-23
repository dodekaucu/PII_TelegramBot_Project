using Library;

namespace Handlers
{

    public class RegistroEmprendedorHandler : BaseHandler
    {

        public RegistroEmprendedorHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registro"};
        }

        protected override bool InternalHandle(IMessage message, IMessage ID, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            if (this.CanHandle(message, ID))
            {
                if (db.Invitados.Contains(message.ID))
                {
                    response = "Su ID se encuentra registrada como una empresa invitada";
                    return true;
                }
                else
                {
                    response = "se procedera con su registro como Emprendedor";
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}
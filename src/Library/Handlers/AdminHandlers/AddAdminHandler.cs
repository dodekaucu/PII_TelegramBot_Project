using System;
using System.Linq;
using Telegram.Bot.Types;
using Library;

namespace Handlers
{
    public class AddAdminHandler : BaseHandler
    {
        private Contenedor contenedor;
        public AddAdminHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/AñadirAdmin" };
        }

        protected override bool InternalHandle(IMessage message, IMessage ID, out string response)  
        {
            Contenedor db = Contenedor.Instancia;
            if (this.CanHandle(message, ID))
            {
                if (db.Administradores.Contains(message.ID.ToString()))
                {
                    string newAdmin = message.Text.Replace("/AñadirAdmin ","").Trim();
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

        protected override bool CanHandle(IMessage message, IMessage ID)
        {
            if (this.Keywords == null || this.Keywords.Length == 0)
            {
                throw new InvalidOperationException("No hay palabras clave que puedan ser procesadas");
            }

            return this.Keywords.Any(s => message.Text.StartsWith(s, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
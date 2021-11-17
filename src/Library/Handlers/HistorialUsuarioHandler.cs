using System;
using Telegram.Bot.Types;
using System.Linq;
using Library;

namespace Handlers
{
    public class HistorialUsuarioHandler : BaseHandler   // cambiar nombre a historial
    {
        public HistorialUsuarioHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/historialDesde" };
        }
        protected override bool InternalHandle(IMessage message, IMessage ID, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            Impresora impresora = Impresora.Instancia;
            if (this.CanHandle(message, ID))
            {
                string fecha = message.Text.Replace("/historialDesde ","").Trim();
                DateTime fechaDesde = DateTime.Parse(fecha);
                    
                if(db.Emprendedores.ContainsKey(message.ID))
                {
                    string RegistrosValidos = impresora.Imprimir(db.Emprendedores[message.ID].BuscarEnRegistro(fechaDesde)); 
                    response = $"{RegistrosValidos}";

                    return true;
                }

                else if (db.Empresas.ContainsKey(message.ID))
                {
                    string RegistrosValidos = impresora.Imprimir(db.Empresas[message.ID].BuscarEnRegistro(fechaDesde)); 
                    response = $"{RegistrosValidos}";

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
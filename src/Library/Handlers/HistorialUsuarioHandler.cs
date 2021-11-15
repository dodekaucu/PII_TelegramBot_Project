using System;
using Telegram.Bot.Types;
using System.Linq;
using Library;

namespace Handlers
{
    public class HistorialUsuarioHandler : BaseHandler   // cambiar nombre a historial
    {
        private Impresora impresora;
        private Contenedor contenedor;
        public HistorialUsuarioHandler(BaseHandler next, Contenedor contenedor) : base(next)
        {
            this.Keywords = new string[] { "/historialDesde" };
            this.contenedor = contenedor;
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (this.CanHandle(message))
            {
                string fecha = message.Text.Replace("/historialDesde ","").Trim();
                DateTime fechaDesde = DateTime.Parse(fecha);
                this.impresora= Impresora.Instancia;

                foreach (Emprendedor emprendedor in this.contenedor.Emprendedores)
                {
                    if(emprendedor.ID == message.ID)
                    {
                        string coso = impresora.Imprimir(emprendedor.BuscarEnRegistro(fechaDesde)); //modifique impresora para que me apareciera oferta base
                        response = $"{coso}";
                        return true;
                    }
                }

                foreach (Empresa empresa in this.contenedor.Empresas)
                {
                    if(empresa.ID == message.ID)
                    {
                        string coso = impresora.Imprimir(empresa.BuscarEnRegistro(fechaDesde)); //modifique impresora para que me apareciera oferta base
                        response = $"{coso}";
                        return true;
                    }
                }
            }

            response = string.Empty;
            return false;
        }

        protected override bool CanHandle(IMessage message)
        {
            if (this.Keywords == null || this.Keywords.Length == 0)
            {
                throw new InvalidOperationException("No hay palabras clave que puedan ser procesadas");
            }

            return this.Keywords.Any(s => message.Text.StartsWith(s, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
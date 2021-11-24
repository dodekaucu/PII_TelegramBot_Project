using System;
using Telegram.Bot.Types;
using System.Linq;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/historialDesde".
    /// </summary>
    public class HistorialUsuarioHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HistorialUsuarioHandler"/>. Esta clase procesa el comando "/historialDesde".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public HistorialUsuarioHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/historialDesde" };
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            StatusManager sm = StatusManager.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            if (this.CanHandle(message))
            {
                /*if(sm.UserStatusChat.ContainsKey(message.ID))
                {
                    response = "Actualmente ya se encuentra el proceso " + sm.UserStatusChat[message.ID] + " activo, recuerde que existe el comando /cancel en caso de que desee cancelarlo. De lo contrario, termine el proceso actual";
                    return true;
                }*/
                if (!db.Emprendedores.ContainsKey(message.ID) && !db.Empresas.ContainsKey(message.ID))
                {
                    response= "Usted no se encuentra registrado";
                    return true;
                }
                else
                {
                    response = "Ingrese la fecha desde donde desee consultar el registro.\nRecuerde que la fecha debe tener la forma xx/xx/xxxx";
                    //sm.AddKeyUser(message.ID);
                    sm.AddUserStatus(message.ID,"/HistorialDesde");
                    dt.AddKeyUser(message.ID);
                    return true;
                }
            }
            if (sm.UserStatusChat[message.ID]=="/HistorialDesde" && dt.DataTemporal[message.ID].Count==0)
            {
                DateTime fecha;
                if (!DateTime.TryParse(message.Text,out fecha))
                {
                    response = "La fecha no es valida, recuerda que debe tener el formato xx/xx/xxxx";
                    return true;
                }
                else    // podria hacerse un switch pero ni idea
                {
                    if(db.Emprendedores.ContainsKey(message.ID))
                    {
                        DateTime fechaDesde = DateTime.Parse(message.Text);
                        string opciones = "";
                        
                        foreach (OfertaBase oferta in db.Emprendedores[message.ID].BuscarEnRegistro(fechaDesde))
                        {
                            opciones = opciones + $"NOMBRE: {oferta.Nombreoferta}\nNOMBRE MATERIAL: {oferta.Material.Nombre} {oferta.Material.Cantidad} {oferta.Material.Unidad}\n";
                        }
                        response = "Ofertas Consumidas Desde: " +message.Text+"\n" + opciones;
                        return true;
                    }
                    else
                    {
                        DateTime fechaDesde = DateTime.Parse(message.Text);
                        string opciones = "";
                        
                        foreach (OfertaBase oferta in db.Empresas[message.ID].BuscarEnRegistro(fechaDesde))
                        {
                            opciones = opciones + $"NOMBRE: {oferta.Nombreoferta}\nNOMBRE MATERIAL: {oferta.Material.Nombre} {oferta.Material.Cantidad} {oferta.Material.Unidad}\n";
                        }
                        response = "Ofertas Consumidas Desde: " +message.Text+"\n" + opciones;
                        return true;
                    }
                }
            }


            response = string.Empty;
            return false;
        }
    }
}
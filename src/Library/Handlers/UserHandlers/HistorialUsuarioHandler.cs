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
        /// <summary>
        /// Procesa el mensaje "/historialDesde" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">Mensaje a procesar.</param>
        /// <param name="response">>La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
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
                    return true;
                }
            }
            if (sm.UserStatusChat[message.ID]=="/HistorialDesde")
            {
                DateTime fecha;
                if (!DateTime.TryParse(message.Text,out fecha))
                {
                    response = "La fecha no es valida, recuerda que debe tener el formato xx/xx/xxxx";
                    return true;
                }
                if(DateTime.Parse(message.Text)>DateTime.Now)
                {
                    response = "Usted no es el Doc Brown para viajar en el tiempo, por favor, ingrese una fecha valida";
                    return true;
                }
                else // ver como imprimir las fechas de compra !!!!!
                {
                    if(db.Emprendedores.ContainsKey(message.ID))
                    {
                        DateTime fechaDesde = DateTime.Parse(message.Text); 
                        string opciones = "";
                        string linea="----------------------------------";
                        if(db.Emprendedores[message.ID].BuscarEnHistorial(fechaDesde).Count==0)
                        {
                            response = "No hay ninguna oferta comprada desde el "+message.Text;
                            return true;
                        }
                        foreach (OfertaBase oferta in db.Emprendedores[message.ID].BuscarEnHistorial(fechaDesde))
                        {
                            Oferta o;
                            OfertaRecurrente o1;
                            if (oferta as Oferta != null)
                            {
                                o = oferta as Oferta;
                                opciones = opciones + $"NOMBRE: {oferta.Nombreoferta}\nNOMBRE MATERIAL: {oferta.Material.Nombre} {oferta.Material.Cantidad} {oferta.Material.Unidad}\n\nFECHA COMPRA: {o.FechaCompra.FechaCompra}\n\n"+linea+"\n";
                            }
                            if(oferta as OfertaRecurrente != null)
                            {
                                o1= oferta as OfertaRecurrente;
                                foreach (FechaCompraOferta item in o1.RegistroVentas)
                                {
                                    if(item.IdComprador == message.ID)
                                    {
                                        opciones = opciones + $"NOMBRE: {oferta.Nombreoferta}\nNOMBRE MATERIAL: {oferta.Material.Nombre} {oferta.Material.Cantidad} {oferta.Material.Unidad}\n\nFECHA COMPRA: {item.FechaCompra}\n\n"+linea+"\n";
                                    }
                                }
                            }
                        }
                        response = "Ofertas Consumidas Desde: " +message.Text+"\n\n" + opciones;
                        return true;
                    }
                    else
                    {
                        DateTime fechaDesde = DateTime.Parse(message.Text);
                        string opciones = "";
                        string linea="------------------------------------------------------";
                        if(db.Empresas[message.ID].BuscarEnHistorial(fechaDesde).Count==0)
                        {
                            response = "No hay ninguna oferta vendida desde el "+message.Text;
                            return true;
                        }
                        foreach (OfertaBase oferta in db.Empresas[message.ID].BuscarEnHistorial(fechaDesde)) 
                        {
                            Oferta o;
                            OfertaRecurrente o1;
                            if (oferta as Oferta != null)
                            {
                                o = oferta as Oferta;
                                opciones = opciones + $"NOMBRE: {oferta.Nombreoferta}\nNOMBRE MATERIAL: {oferta.Material.Nombre} {oferta.Material.Cantidad} {oferta.Material.Unidad}\n\nFECHA COMPRA: {o.FechaCompra.FechaCompra.Date}\n\n"+linea+"\n";
                            }
                            if(oferta as OfertaRecurrente != null)
                            {
                                o1= oferta as OfertaRecurrente;
                                foreach (FechaCompraOferta item in o1.RegistroVentas)
                                {
                                    if(item.IdComprador == message.ID)
                                    {
                                        opciones = opciones + $"NOMBRE: {oferta.Nombreoferta}\nNOMBRE MATERIAL: {oferta.Material.Nombre} {oferta.Material.Cantidad} {oferta.Material.Unidad}\n\nFECHA COMPRA: {item.FechaCompra}\n\n"+linea+"\n";
                                    }
                                }
                            }
                        }
                        response = "Ofertas Consumidas Desde: " +message.Text+"\n\n" + opciones;
                        sm.UserStatusChat.Remove(message.ID);
                        return true;
                    }
                }
            }

            response = string.Empty;
            return false;
        }
    }
}
using Library;
using System;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/MisPublicaciones".
    /// </summary>
    public class MisPublicacionesHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MisPublicacionesHandler"/>. Esta clase procesa el comando "/MisPublicaciones".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public MisPublicacionesHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/MisPublicaciones"};
        }

        /// <summary>
        /// Procesa el comando "/MisPublicaciones" y retorna true; retorna false en caso contrario.
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
                    string opciones = "";
                    string linea = "\n-------------------------\n";
                    foreach(Oferta oferta in db.Ofertas)
                    {
                        if (db.Empresas[message.ID].Nombre==oferta.Empresa.Nombre)
                        {
                            if (oferta.RecurrenciaMensual == 0)
                            {
                                Oferta o = oferta;
                                if (oferta as Oferta != null)
                                {
                                    o = oferta as Oferta;
                                    opciones = opciones + oferta.Nombreoferta +"\n"+ oferta.Material.Nombre+" "+oferta.Material.Cantidad+" "+oferta.Material.Unidad+"\n$"+oferta.Material.Valor+"\n\nFECHA DE GENERACION: "+o.FechadeGeneracion+"\n"+"Estado de la oferta: "+o.Disponible.ToString()+linea;
                                }
                            }
                            else if (oferta.RecurrenciaMensual > 0)
                            {
                                Oferta o1 = oferta;
                                if(oferta as Oferta != null)
                                {
                                    o1 = oferta as Oferta;
                                    opciones = opciones + oferta.Nombreoferta +"\n"+ oferta.Material.Nombre+" "+oferta.Material.Cantidad+" "+oferta.Material.Unidad+"\n$"+oferta.Material.Valor+"\n\nRecurrencia: "+ o1.RecurrenciaMensual+"\n"+linea;
                                }
                            }
                        }
                    }
                    response = "Sus publicaciones:\n\n\n"+ opciones;
                    return true;
                }
                else
                {
                    response = "Usted no se encuentra registrado como empresa";
                    return true;
                }
            }


            response = string.Empty;
            return false;
        }
    }
}
using System;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/Info".
    /// </summary>
    public class AñadirCompradorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AñadirCompradorHandler"/>. Esta clase procesa el comando "/AñadirComprador".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AñadirCompradorHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/AñadirComprador"};
        }

        /// <summary>
        /// Procesa el comando "/AñadirCompradorOferta" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            StatusManager sm = StatusManager.Instancia;
            if (this.CanHandle(message))
            {
                if (db.Empresas.ContainsKey(message.ID))
                {
                    string opciones ="";
                    foreach (OfertaBase oferta in db.Ofertas)
                    {
                        if(db.Empresas[message.ID]==oferta.Empresa)
                        {
                            //aca van a estar las ofertas que posee la empresa, identificadas por ID.
                            opciones = opciones + "ID " + oferta.Identificador.ToString() + " - " + oferta.Nombreoferta +"\n";
                        }
                    }

                    response = "las ofertas que usted posee son:\n"+ opciones +"seleccione una oferta para añiadir un comprador";
                    sm.AddUserStatus(message.ID,"AñadirComprador"); 
                    dt.AddKeyUser(message.ID);
                    return true;
                }
                else
                {
                    response = "usted no se encuentra registrado como empresa";
                    return true;
                }
            }
            if (sm.UserStatusChat[message.ID]=="AñadirComprador" && dt.DataTemporal[message.ID].Count==0)
            {
                int num;
                if(!Int32.TryParse(message.Text,out num))
                {
                    response = "No se ha ingresado un número, ingrese un numero válido.";
                    return true;
                }
                else if(Int32.Parse(message.Text) >=  db.Ofertas.Count)     
                {
                    response = "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo";
                    return true;
                }
                if(db.Empresas[message.ID]==db.Ofertas[Int32.Parse(message.Text)].Empresa)
                {
                    dt.AddDato(message.ID,message.Text);
                    int numoferta = Int32.Parse(message.Text);
                    response = $"Ingrese el ID del comprador de {db.Ofertas[numoferta].Nombreoferta}:\n(recuerde que con /Info el comprador puede ver su Id)";
                    return true;
                }
                else
                {
                    response="El numero ingresado no corresponde a una oferta suya, por favor digite de nuevo";
                    return true;
                }
            }
            if (sm.UserStatusChat[message.ID]=="AñadirComprador" && dt.DataTemporal[message.ID].Count==1) 
            {
                if (db.Emprendedores.ContainsKey(message.Text))
                {
                    dt.AddDato(message.ID,message.Text);
                    response = "Ahora ingrese la fecha de compra, recuerde que debe tener la forma dd/mm/aaaa";
                    return true;
                }
                else
                {
                    response = "la id no se encuentra registrada como emprendedor";
                    return true;
                }
            }
            if (sm.UserStatusChat[message.ID]=="AñadirComprador" && dt.DataTemporal[message.ID].Count==2) 
            {
                DateTime fecha;
                if(!DateTime.TryParse(message.Text,out fecha))
                {
                    response = "no ha ingresado una fecha valida, recuerde que debe tener la forma de dd/mm/aaaa";
                    return true;
                }
                else
                {
                    int numoferta = Int32.Parse(dt.DataTemporal[message.ID][0]);
                    string idComprador = dt.DataTemporal[message.ID][1];
                    DateTime fechaCompra = DateTime.Parse(message.Text);
                    switch(db.Ofertas[numoferta])
                    {
                    case Oferta o:
                        if(!o.Disponible)
                        {
                            response = "La oferta ya ha sido comprada";
                            return true;
                        }
                        o.AddComprador(idComprador,fechaCompra);
                        db.Empresas[message.ID].AddToRegister(o);
                        db.Emprendedores[idComprador].AddToRegister(o);
                        response = $"{o.Nombreoferta} ha sido comprada por {db.Emprendedores[idComprador].Nombre} el dia {o.FechaCompra.FechaCompra}";
                        sm.UserStatusChat.Remove(message.ID);
                        dt.DataTemporal.Remove(message.ID);
                        return true;
                    
                    case OfertaRecurrente o:
                        o.AddFechaVenta(idComprador,fechaCompra);
                        db.Empresas[message.ID].AddToRegister(o);
                        db.Emprendedores[idComprador].AddToRegister(o);
                        response = $"{o.Nombreoferta} ha sido comprada por {db.Emprendedores[idComprador].Nombre} el dia "+fechaCompra;
                        sm.UserStatusChat.Remove(message.ID);
                        dt.DataTemporal.Remove(message.ID);
                        return true;
                    }
                    response = "";
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}
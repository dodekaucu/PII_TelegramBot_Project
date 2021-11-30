//--------------------------------------------------------------------------------
// <copyright file="AddPalabraClaveHandler.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using Library;
using System;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/AddHabilitacion".
    /// </summary>
    public class AddPalabraClaveHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddPalabraClaveHandler"/>. Esta clase procesa el mensaje "/addHabilitacion".
        /// </summary>
        /// <param name="next">Próximo handler.</param>
        /// <returns></returns>

        public AddPalabraClaveHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/AddPalabraClave"};
        }
        /// <summary>
        /// Este handler añade palabras clave a las ofertas de una empresa.
        /// Cuando se ejecuta por una empresa se le muestra una lista de las ofertas que tiene publicadas.
        /// Ahí se le da la opción de elegir una y luego ingresa la palabra clave a añadir.
        /// 
        /// En el caso de que el comando sea ejecutado por un emprendedor, se informa que el comando es inválido.
        /// </summary>
        /// <param name="message">Mensaje a procesar.</param>
        /// <param name="response">Respuesta al usaurio.</param>
        /// <returns></returns>
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
                    sm.UserStatusChat.Remove(message.ID);
                    dt.DataTemporal.Remove(message.ID);
                    dt.AddKeyUser(message.ID);
                    string opciones ="";
                    foreach (Oferta oferta in db.Ofertas)
                    {
                        if(message.ID==oferta.Empresa.ID)
                        {
                            //aca van a estar las ofertas que posee la empresa, identificadas por ID.
                            opciones = opciones + "ID " + db.Ofertas.IndexOf(oferta).ToString() + " - " + oferta.Nombreoferta +"\n";
                        }
                    }
                    response = "Seleccione la oferta a añadir una palabra clave: \n" + opciones;
                    sm.AddUserStatus(message.ID,"AddPalabrasClave");
                    return true;
                }
            }
            else if(sm.UserStatusChat[message.ID]=="AddPalabrasClave" && dt.DataTemporal[message.ID].Count==0)
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
                else
                {
                dt.AddDato(message.ID,message.Text);
                int numoferta = Int32.Parse(message.Text);
                response = $"Ingrese palabra clave para añadir a la oferta {db.Ofertas[numoferta].Nombreoferta}:";
                return true;
                }
            }
            else if(sm.UserStatusChat[message.ID]=="AddPalabrasClave" && dt.DataTemporal[message.ID].Count==1)
            {
                int numoferta = Int32.Parse(dt.DataTemporal[message.ID][0]);
                db.Ofertas[numoferta].AddPalabraClave(message.Text);
                response = $"Palabra clave \"{message.Text}\" añadida a {db.Ofertas[numoferta].Nombreoferta}";
                sm.UserStatusChat.Remove(message.ID);
                dt.DataTemporal.Remove(message.ID);
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}
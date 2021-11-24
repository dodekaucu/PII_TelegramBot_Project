using System.Collections.ObjectModel;
using System;
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
            this.Keywords = new string[] {"/addhabilitacion"};
        }
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
                if ((db.Emprendedores.ContainsKey(message.ID)) && (sm.UserStatusChat[message.ID]!="AddHabilitacion")) 
                {
                    sm.UserStatusChat.Remove(message.ID);
                    dt.DataTemporal.Remove(message.ID);
                    sm.AddUserStatus(message.ID,"AddHabilitacion");
                    dt.AddKeyUser(message.ID);
                    string opciones ="";
                    int i=0;
                    foreach (Habilitacion habilitacion in db.Habilitaciones)
                    {
                        opciones = opciones + i.ToString() + " - " + habilitacion.Name +"\n";
                        i++;
                    }
                    response = "Seleccione su habilitacion (escriba el número correspondiente)\n"+ opciones;
                    return true;
                }
                
                else if((db.Empresas.ContainsKey(message.ID)) && (sm.UserStatusChat[message.ID]!="AddHabilitacion"))
                {
                    //AÑADIR UNA HABILITACION A LA OFERTA
                    sm.UserStatusChat.Remove(message.ID);
                    dt.DataTemporal.Remove(message.ID);
                    string opciones ="";
                    int i=0;
                    foreach (OfertaBase oferta in db.Ofertas)
                    {
                        if(message.ID==oferta.Empresa.ID)
                        {
                            //aca van a estar las ofertas que posee la empresa
                            opciones = i.ToString() + " - " + opciones + oferta.Nombreoferta +"\n";
                            i++;
                        }
                    }
                    response = "Seleccione la oferta ha añadir una habilitacion";
                    sm.AddUserStatus(message.ID,"AddHabilitacion");
                    return true;
                }
                else if(sm.UserStatusChat[message.ID]=="AddHabilitacion")
                {
                    response = "Actualmente se encuentra el proceso " + sm.UserStatusChat[message.ID]+" activo, porfavor, si desea activar otro comando cancele el actual con /cancel";
                    return true;
                }
                else
                {
                    response = "Usted no se encuentra registrado en la plataforma";
                    return true;
                }
            }
            else if((sm.UserStatusChat[message.ID]=="AddHabilitacion") && (db.Emprendedores.ContainsKey(message.ID)))
            {
                int num;
                if(!Int32.TryParse(message.Text,out num))
                {
                    response = "No se ha ingresado un número, ingrese un numero válido.";
                    return true;
                }
                else if(Int32.Parse(message.Text) >=  db.Habilitaciones.Count)     
                {
                    response = "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo";
                    return true;
                }
                else
                {
                    dt.AddDato(message.ID,message.Text);
                    if (db.Emprendedores[message.ID].Habilitaciones.Contains(db.Habilitaciones[Int32.Parse(dt.DataTemporal[message.ID][0])]))
                    {
                        response = "Usted ya posee esta habilitacion."+"\n"+"\n"+"Ingrese /addhabilitacion para añadir otra.";
                        sm.UserStatusChat.Remove(message.ID);
                        return true;
                    }
                    else if (!db.Emprendedores[message.ID].Habilitaciones.Contains(db.Habilitaciones[Int32.Parse(dt.DataTemporal[message.ID][0])]))
                    {
                        response = "La habilitacion añadida es: "+ db.Habilitaciones[Int32.Parse(dt.DataTemporal[message.ID][0])].Name + "\n"+"\n" + "Ingrese /addhabilitacion para añadir otra.";
                        db.Emprendedores[message.ID].Habilitaciones.Add(db.Habilitaciones[Int32.Parse(dt.DataTemporal[message.ID][0])]);
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
using System.Linq;
using System;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/AddHabilitacion".
    /// </summary>
    public class AddHabilitacionHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddHabilitacionHandler"/>. Esta clase procesa el mensaje "/addHabilitacion".
        /// </summary>
        /// <param name="next">El próximo handler.</param>
        /// <returns></returns>
        public AddHabilitacionHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/addhabilitacion"};
        }
        /// <summary>
        /// Este handler se ocupa de añadir una habilitación a una oferta o a un emprendedor.
        /// Si es ejecutado por un emprendedor la habilitación se la agrega a si mismo, además checkea.
        /// si actualmente tiene esa habilitación, en ese caso informa que ya esta añadida.
        /// 
        /// Si es ejecutado por una empresa se le da una lista de sus ofertas y cuando elige una se le muestran.
        /// las habilitaciones que se pueden añadir. Si la habilitacion ya existe en esa oferta se informa que ya esta añadida.
        /// en el caso contrario esta se añade a la misma.
        /// </summary>
        /// <param name="message">Mensaje a procesar.</param>
        /// <param name="response">Respuesta que se envia al usuario.</param>
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
                    response = "Seleccione su habilitación (escriba el número correspondiente)\n"+ opciones;
                    return true;
                }
                
                else if(db.Empresas.ContainsKey(message.ID))
                {
                    //AÑADIR UNA HABILITACION A LA OFERTA
                    sm.UserStatusChat.Remove(message.ID);
                    dt.DataTemporal.Remove(message.ID);
                    dt.AddKeyUser(message.ID);
                    string opciones ="";
                    foreach (OfertaBase oferta in db.Ofertas)
                    {
                        if(db.Empresas[message.ID]==oferta.Empresa)
                        {
                            //aca van a estar las ofertas que posee la empresa, identificadas por ID.
                            opciones = opciones + "ID " + oferta.Identificador.ToString() + " - " + oferta.Nombreoferta +"\n";
                        }
                    }
                    response = "Seleccione la oferta a añadir una habilitación: \n" + opciones;
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
            else if(sm.UserStatusChat[message.ID]=="AddHabilitacion" && db.Empresas.ContainsKey(message.ID) && dt.DataTemporal[message.ID].Count==0)
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
                    Console.WriteLine(dt.DataTemporal.Count);
                    string opciones = "";
                    int i = 0;
                    foreach (Habilitacion habilitacion in db.Habilitaciones)
                    {
                        opciones = opciones + i.ToString() + " - " + habilitacion.Name +"\n";
                        i++;
                    }
                    response = $"Ingrese una habilitacion para agregar a {db.Ofertas[Int32.Parse(message.Text)].Nombreoferta}" + "\n \n" + "Habilitaciones disponibles: \n" + opciones;
                    return true;
                }
            }
            //
            else if(sm.UserStatusChat[message.ID]=="AddHabilitacion" && db.Empresas.ContainsKey(message.ID) && dt.DataTemporal[message.ID].Count==1)
            {
                int num;
                if(!Int32.TryParse(message.Text,out num))
                {
                    response = "No se ha ingresado un número, ingrese un numero válido.";
                    return true;
                }
                else if(Int32.Parse(message.Text) >=  db.Ofertas.Count)     
                {
                    response = "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo.";
                    return true;
                }
                else
                {
                    Console.WriteLine(dt.DataTemporal[message.ID][0]);
                    int numeroferta = Int32.Parse(dt.DataTemporal[message.ID][0]);
                    int numerohab = Int32.Parse(message.Text);
                    if (db.Ofertas[numeroferta].Habilitaciones.Contains(db.Habilitaciones[numerohab]))
                    {
                        response = "Esta oferta ya posee esta habilitación."+"\n"+"\n"+"Ingrese un número válido o /cancelar para salir del menú.";
                        dt.RemoveDato(message.ID,message.Text);
                        return true;
                    }
                    else
                    {
                        db.Ofertas[Int32.Parse(dt.DataTemporal[message.ID][0])].AddHabilitacion(db.Habilitaciones[Int32.Parse(message.Text)]);
                        response = $"Se agregó la habilitación {db.Habilitaciones[Int32.Parse(message.Text)].Name} a la oferta {db.Ofertas[Int32.Parse(dt.DataTemporal[message.ID][0])].Nombreoferta}";
                        sm.UserStatusChat.Remove(message.ID);
                        dt.DataTemporal.Remove(message.ID);
                        return true;
                    }
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
                    response = "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo.";
                    return true;
                }
                else
                {
                    dt.AddDato(message.ID,message.Text);
                    if (db.Emprendedores[message.ID].Habilitaciones.Contains(db.Habilitaciones[Int32.Parse(dt.DataTemporal[message.ID][0])]))
                    {
                        response = "Usted ya posee esta habilitacion."+"\n"+"\n"+"Ingrese un número válido para añadir otra o /cancelar para salir del menú.";
                        dt.RemoveDato(message.ID,message.Text);
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
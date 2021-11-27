using System;
using Library;

namespace Handlers
{

    public class PublicarOfertaHandler : BaseHandler
    {

        public PublicarOfertaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/PublicarOferta"};
        }

        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            StatusManager sm = StatusManager.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            if (this.CanHandle(message))
            {
                if (!db.Empresas.ContainsKey(message.ID))
                {
                    response = "No se encuentra registrado como empresa, para registrarse por favor contactese con un administrador";
                    return true;
                }
                else  
                {
                    if(sm.UserStatusChat.ContainsKey(message.ID))
                    {
                        response = "Ya hay un proceso activo, por favor termine el proceso actual o cancelelo con /cancel";
                        return true;
                    }
                    response = "se procedera con la publicacion, primero indique el tipo de oferta que desea crear:\n1-Oferta normal\n2-OfertaRecurrente";
                    sm.AddKeyUser(message.ID);
                    sm.AddUserStatus(message.ID,"/PublicarOferta");
                    dt.AddKeyUser(message.ID);
                    return true;           
                }
                
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count==0)
            {
                switch(message.Text)
                {
                    case "1":
                    response ="Usted eliguio crear una Oferta normal, ahora ingrese el nombre de la oferta";
                    dt.AddDato(message.ID,message.Text);
                    return true;

                    case "2":
                    response="Usted eliguio crear una Oferta Recurrente, ahora ingrese el nombre de la oferta";
                    dt.AddDato(message.ID,message.Text);
                    return true;

                    default:
                    response ="No ha ingresado una opcion correcta, por favor digite (1 o 2) nuevamente";
                    return true;
                }
            }

            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count ==1)
            {
                dt.AddDato(message.ID,message.Text);
                response= "el nombre de la oferta es: "+message.Text+", Ahora ingrese la ciudad donde se encuentra la oferta: ";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count ==2)
            {
                dt.AddDato(message.ID,message.Text);
                response= "la ciudad de la oferta es: "+message.Text+", Ahora ingrese la calle donde se encuentra la oferta: ";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count ==3)
            {
                dt.AddDato(message.ID,message.Text);
                response= "la calle de la oferta es: "+message.Text+", Ahora ingrese el nombre del material del que esta compuesto la oferta";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count ==4)
            {
                dt.AddDato(message.ID,message.Text);
                string opciones = "";
                int i =0;
                foreach (Clasificacion clasificacion in db.Clasificaciones)
                {
                    opciones = i.ToString() + " - " + opciones + clasificacion.Nombre +"\n";
                    i++;
                }
                response = "el nombre del material es: "+ message.Text + "Ahora seleccione (marcando con el numero correspondiente)\n"+opciones;
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count ==5)
            {
                int num;
                if(!Int32.TryParse(message.Text,out num))
                {
                    response = "no se ha ingresado un numero, ingrese un numero correspondiente.";
                    return true;
                }
                if(Int32.Parse(message.Text) >=  db.Clasificaciones.Count)     
                {
                    response = "usted ha ingresado un numero incorrecto, por favor vuelva a intentarlo";
                    return true;
                }
                dt.AddDato(message.ID,message.Text);
                Console.WriteLine(dt.DataTemporal[message.ID].Count);
                response= "Ahora agrege la cantidad del material";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count ==6) //se muere aca XD?
            {
                int num;
                if(!Int32.TryParse(message.Text,out num))
                {
                    response = "no se ha ingresado un numero, ingrese un numero correspondiente.";
                    return true;
                }
                dt.AddDato(message.ID,message.Text);
                response = "Ahora ingrese la unidad";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count ==7)
            {
                dt.AddDato(message.ID,message.Text);
                response=message.Text+"es la unidad seleccionada, ahora ingrese el valor que desea darle a la oferta";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count ==8)
            {
                double num;
                if(!Double.TryParse(message.Text,out num))
                {
                    response = "no se ha ingresado un numero, ingrese un numero correspondiente.";
                    return true;
                }
                dt.AddDato(message.ID,message.Text);
                switch(dt.DataTemporal[message.ID][0])
                {
                    case "1":
                    response ="Como usted selecciono una oferta Normal, ingrese la fecha puntual en la que la oferta es generada (recuerde que debe tener la forma xx/xx/xxxx)";
                    return true;

                    case "2":
                    response="Como usted selecciono una oferta Recurrente, ingrese la periocidad mensual con la que se genera la misma";
                    return true;
                }
            }
            if(sm.UserStatusChat[message.ID]=="/PublicarOferta" && dt.DataTemporal[message.ID].Count==9)
            {
                switch(dt.DataTemporal[message.ID][0])
                {
                    case "1":
                    DateTime fecha;
                    if (!DateTime.TryParse(message.Text,out fecha))
                    {
                        response = "La fecha no es valida, recuerda que debe tener el formato xx/xx/xxxx";
                        return true;
                    }
                    dt.AddDato(message.ID,message.Text);
                    string name = dt.DataTemporal[message.ID][1];
                    string ciudad = dt.DataTemporal[message.ID][2];
                    string calle = dt.DataTemporal[message.ID][3];
                    string nombreMaterial = dt.DataTemporal[message.ID][4];
                    Clasificacion clasificacion = db.Clasificaciones[Int32.Parse(dt.DataTemporal[message.ID][5])];
                    int cantidad = Int32.Parse(dt.DataTemporal[message.ID][6]);
                    string unidad = dt.DataTemporal[message.ID][7];
                    double valor = double.Parse(dt.DataTemporal[message.ID][8]);
                    DateTime fechageneracion = DateTime.Parse(dt.DataTemporal[message.ID][9]);
                    Oferta oferta = new Oferta(name,db.Empresas[message.ID],ciudad,calle,nombreMaterial,clasificacion,cantidad,unidad,valor,fechageneracion);
                    /*if(!db.Ofertas.ContainsKey(message.ID))
                    {
                        db.AddOfertaKey(message.ID);
                    }*/
                    db.AddOferta(oferta);
                    dt.DataTemporal.Remove(message.ID);
                    sm.UserStatusChat.Remove(message.ID);
                    response = $"Se a creado la oferta {oferta.Nombreoferta} a nombre de la empresa {oferta.Empresa.Nombre}.\nCARACTERISTICAS:\n{oferta.Material.Nombre}\n{oferta.Material.Cantidad} {oferta.Material.Unidad}\nFECHA DE GENERACION: {oferta.FechadeGeneracion}";
                    return true;

                    case "2":
                    int num;
                    if(!Int32.TryParse(message.Text,out num))
                    {
                        response = "La periocidad no es valida, recuerda que debe ser un numero";
                        return true;
                    }
                    dt.AddDato(message.ID,message.Text);
                    string name2 = dt.DataTemporal[message.ID][1];
                    string ciudad2 = dt.DataTemporal[message.ID][2];
                    string calle2 = dt.DataTemporal[message.ID][3];
                    string nombreMaterial2 = dt.DataTemporal[message.ID][4];
                    Clasificacion clasificacion2 = db.Clasificaciones[Int32.Parse(dt.DataTemporal[message.ID][5])];
                    int cantidad2 = Int32.Parse(dt.DataTemporal[message.ID][6]);
                    string unidad2 = dt.DataTemporal[message.ID][7];
                    double valor2 = double.Parse(dt.DataTemporal[message.ID][8]);
                    int periocidad = Int32.Parse(dt.DataTemporal[message.ID][9]);
                    OfertaRecurrente oferta2 = new OfertaRecurrente(name2,db.Empresas[message.ID],ciudad2,calle2,nombreMaterial2,clasificacion2,cantidad2,unidad2,valor2,periocidad);
                    db.AddOferta(oferta2);
                    dt.DataTemporal.Remove(message.ID);
                    sm.UserStatusChat.Remove(message.ID);
                    response = $"Se a creado la oferta {oferta2.Nombreoferta} a nombre de la empresa {oferta2.Empresa.Nombre}.\nCARACTERISTICAS:\n{oferta2.Material.Nombre}\n{oferta2.Material.Cantidad} {oferta2.Material.Unidad}\nPERIOCIDAD MENSUAL: {oferta2.RecurrenciaMensual}";
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}
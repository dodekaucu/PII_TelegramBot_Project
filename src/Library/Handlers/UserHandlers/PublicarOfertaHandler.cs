using System;
using Library;

namespace Handlers
{
    /// <summary>
    /// /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/PublicarOferta".
    /// </summary>
    public class PublicarOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PublicarOfertaHandler"/>. Esta clase procesa el comando "/PublicarOferta".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PublicarOfertaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/PublicarOferta"};
        }

        /// <summary>
        /// Procesa el mensaje "/PublicarOferta" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">Mensaje a procesar.</param>
        /// <param name="response">>La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            StatusManager sm = StatusManager.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            if(!sm.UserStatusChat.ContainsKey(message.ID))
            {
                sm.AddKeyUser(message.ID);
            }
            if (this.CanHandle(message))
            {
                if (!db.Empresas.ContainsKey(message.ID))
                {
                    response = "No se encuentra registrado como empresa, para registrarse por favor contactese con un administrador";
                    return true;
                }
                else  
                {
                    if(sm.UserStatusChat[message.ID]=="PublicarOferta")
                    {
                        response = "Ya hay un proceso activo, por favor termine el proceso actual o cancelelo con /cancel";
                        return true;
                    }
                    response = "Se procedera con la publicacion, primero indique el tipo de oferta que desea crear:\n1 - Oferta Única \n2 - Oferta Recurrente";
                    sm.AddUserStatus(message.ID,"PublicarOferta");
                    dt.AddKeyUser(message.ID);
                    return true;           
                }
                
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count==0)
            {
                switch(message.Text)
                {
                    case "1":
                    response ="Usted eligió crear una Oferta Única"+"\n \n"+"Ingrese el nombre de la oferta:";
                    dt.AddDato(message.ID,message.Text);
                    return true;

                    case "2":
                    response="Usted eligió crear una Oferta Recurrente"+"\n \n"+"Ingrese el nombre de la oferta";
                    dt.AddDato(message.ID,message.Text);
                    return true;

                    default:
                    response ="No ha ingresado una opcion correcta, por favor ingrese 1 o 2";
                    return true;
                }
            }

            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count ==1)
            {
                dt.AddDato(message.ID,message.Text);
                response= "El nombre de la oferta es: "+message.Text+"\n \n" +"Ingrese la ciudad donde se encuentra la oferta:";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count ==2)
            {
                dt.AddDato(message.ID,message.Text);
                response= "La ciudad de la oferta es: "+message.Text+"\n \n"+"Ingrese la calle donde se encuentra la oferta:";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count ==3)
            {
                dt.AddDato(message.ID,message.Text);
                response= "La calle de la oferta es: "+message.Text+"\n \n"+"Ahora ingrese el nombre del material que quiere ofertar:";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count ==4)
            {
                dt.AddDato(message.ID,message.Text);
                string opciones = "";
                int i =0;
                foreach (Clasificacion clasificacion in db.Clasificaciones)
                {
                    opciones = opciones + i.ToString() + " - " + clasificacion.Nombre +"\n";
                    i++;
                }
                response = "El nombre del material es: "+ message.Text +"\n \n" +"Ahora seleccione la clasificación del mismo. (Ingresando el numero correspondiente)\n"+opciones;
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count ==5)
            {
                int num;
                if(!Int32.TryParse(message.Text,out num))
                {
                    response = "No se ha ingresado un numero, ingrese un numero válido.";
                    return true;
                }
                if(Int32.Parse(message.Text) >=  db.Clasificaciones.Count)     
                {
                    response = "Usted ha ingresado un numero incorrecto, por favor vuelva a intentarlo.";
                    return true;
                }
                dt.AddDato(message.ID,message.Text);
                Console.WriteLine(dt.DataTemporal[message.ID].Count);
                response= "Ahora indique la cantidad de material: \n (A continuación le pediremos la unidad)";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count ==6) //se muere aca XD?
            {
                int num;
                if(!Int32.TryParse(message.Text,out num))
                {
                    response = "No se ha ingresado un número, ingrese un número correspondiente.";
                    return true;
                }
                dt.AddDato(message.ID,message.Text);
                response = "Ahora ingrese la unidad de medida correspondiente:";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count ==7)
            {
                dt.AddDato(message.ID,message.Text);
                response=message.Text+" Es la unidad seleccionada, ahora ingrese el valor ($U) que desea darle a la oferta:";
                return true;
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count ==8)
            {
                double num;
                if(!Double.TryParse(message.Text,out num))
                {
                    response = "No se ha ingresado un número. Ingrese un número válido.";
                    return true;
                }
                dt.AddDato(message.ID,message.Text);
                switch(dt.DataTemporal[message.ID][0])
                {
                    case "1":
                    response ="Como usted selecciono una Oferta Única, ingrese la fecha puntual en la que la oferta es (o fue) generada \n (Debe tener la forma dd/mm/aaaa)";
                    return true;

                    case "2":
                    response="Como usted selecciono una Oferta Recurrente, ingrese la periocidad mensual con la que se genera la misma";
                    return true;
                }
            }
            if(sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count==9)
            {
                switch(dt.DataTemporal[message.ID][0])
                {
                    case "1":
                    DateTime fecha;
                    if (!DateTime.TryParse(message.Text,out fecha))
                    {
                        response = "La fecha no es valida, recuerda que debe tener el formato dd/mmm/aaaa";
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
                    response = $"Se a creado la oferta \"{oferta.Nombreoferta}\" a nombre de la empresa {oferta.Empresa.Nombre}.\nCaracterísticas:\n-{oferta.Material.Nombre}\n-{oferta.Material.Cantidad} {oferta.Material.Unidad}\n"+"-$"+$"{oferta.Material.Valor}\nFecha de generación: {oferta.FechadeGeneracion}\nPalabras claves: {oferta.PalabrasClaves[0]} , {oferta.PalabrasClaves[1]} , {oferta.PalabrasClaves[2]}";
                    return true;

                    case "2":
                    int num;
                    if(!Int32.TryParse(message.Text,out num))
                    {
                        response = "La periocidad no es válida, recuerda que debe ser un número";
                        return true;
                    }
                    response= "Desea agregar una descripcion para especificar la recurrencia de  (Y/N)";
                    dt.AddDato(message.ID,message.Text);
                    return true;

                }
            }
            if (sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count==10)
            {
                if(message.Text.ToUpper() == "N")
                {
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
                    response = $"Se a creado la oferta {oferta2.Nombreoferta} a nombre de la empresa {oferta2.Empresa.Nombre}.\n Características:\n{oferta2.Material.Nombre}\n{oferta2.Material.Cantidad} {oferta2.Material.Unidad}\n Periocidad mensual: {oferta2.RecurrenciaMensual}\nPalabras claves: {oferta2.PalabrasClaves[0]},{oferta2.PalabrasClaves[1]},{oferta2.PalabrasClaves[2]}";
                    return true;
                }
                if (message.Text.ToUpper() == "Y")
                {
                    response = "Ingrese su descripcion";
                    dt.AddDato(message.ID,message.Text);
                    return true;
                }
                else
                {
                    response = "no ha ingresado Y/N, intentelo de nuevo";
                    return true;
                }
            }
            if (sm.UserStatusChat[message.ID]=="PublicarOferta" && dt.DataTemporal[message.ID].Count==11)
            {
                string name2 = dt.DataTemporal[message.ID][1];
                string ciudad2 = dt.DataTemporal[message.ID][2];
                string calle2 = dt.DataTemporal[message.ID][3];
                string nombreMaterial2 = dt.DataTemporal[message.ID][4];
                Clasificacion clasificacion2 = db.Clasificaciones[Int32.Parse(dt.DataTemporal[message.ID][5])];
                int cantidad2 = Int32.Parse(dt.DataTemporal[message.ID][6]);
                string unidad2 = dt.DataTemporal[message.ID][7];
                double valor2 = double.Parse(dt.DataTemporal[message.ID][8]);
                int periocidad = Int32.Parse(dt.DataTemporal[message.ID][9]);
                string descripcion = message.Text;
                OfertaRecurrente oferta2 = new OfertaRecurrente(name2,db.Empresas[message.ID],ciudad2,calle2,nombreMaterial2,clasificacion2,cantidad2,unidad2,valor2,periocidad);
                oferta2.DescripcionRecurrencia = descripcion;
                db.AddOferta(oferta2);
                dt.DataTemporal.Remove(message.ID);
                sm.UserStatusChat.Remove(message.ID);
                response = $"Se a creado la oferta {oferta2.Nombreoferta} a nombre de la empresa {oferta2.Empresa.Nombre}.\n Características:\n{oferta2.Material.Nombre}\n{oferta2.Material.Cantidad} {oferta2.Material.Unidad}\n Periocidad mensual: {oferta2.RecurrenciaMensual}\nPalabras claves: {oferta2.PalabrasClaves[0]},{oferta2.PalabrasClaves[1]},{oferta2.PalabrasClaves[2]}";
                return true;
            }
            

            response = string.Empty;
            return false;
        }
    }
}
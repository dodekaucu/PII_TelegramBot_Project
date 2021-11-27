using System;
using Library;

namespace Handlers
{
    public class Registro : BaseHandler
    {

        public Registro(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registro"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            StatusManager sm = StatusManager.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            Contenedor db = Contenedor.Instancia;
            if (this.CanHandle(message))
            {
                if (db.Invitados.Contains(message.ID) && !sm.UserStatusChat.ContainsKey(message.ID))
                {
                    response = "Su ID se encuentra en la lista de invitados para registrarse como Empresa"+"\n"+"Ingrese el nombre de la empresa:";
                    sm.AddKeyUser(message.ID);
                    sm.AddUserStatus(message.ID,"NombreStatus");
                    return true;
                }
                else if (db.Emprendedores.ContainsKey(message.ID))
                {
                    response = "Usted ya se encuentra registrado.";
                    return true;
                }
                else if (db.Empresas.ContainsKey(message.ID))
                {
                    response = "La empresa ya se encuentra registrada.";
                    return true;
                }
                else    
                {
                    if(sm.UserStatusChat.ContainsKey(message.ID))
                    {
                        response = "Ya hay un proceso activo, por favor termine el proceso actual o cancelelo con /cancel";
                        return true;
                    }
                    response = "Se procedera con su registro como emprendedor."+"\n"+"\n"+"Ingrese su nombre:";
                    sm.AddKeyUser(message.ID);
                    sm.AddUserStatus(message.ID,"NombreStatus");
                    return true;           
                }
            }
            else if (sm.UserStatusChat.ContainsKey(message.ID))
            {
                if(sm.UserStatusChat[message.ID]=="NombreStatus")
                    {
                        sm.AddUserStatus(message.ID,"RubroStatus");
                        dt.AddKeyUser(message.ID);
                        dt.AddDato(message.ID,message.Text);
                        string opciones = "";
                        int i =0;
                        foreach (Rubro rubro in db.Rubros)
                        {
                            opciones = i.ToString() + " - " + opciones + rubro.Nombre +"\n";
                            i++;
                        }
                        response = "Su nombre es: "+ message.Text+"\n"+"\n"+"Seleccione su rubro:\n" + opciones;
                        return true;
                    }
                else if(sm.UserStatusChat[message.ID]=="RubroStatus")  
                {
                    int num;
                    if(!Int32.TryParse(message.Text,out num))
                    {
                        response = "No se ha ingresado un número, ingrese un numero válido.";
                        return true;
                    }
                    else if(Int32.Parse(message.Text) >=  db.Rubros.Count)     
                    {
                        response = "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo";
                        return true;
                    }
                    sm.AddUserStatus(message.ID,"CiudadStatus");
                    dt.AddDato(message.ID,message.Text);
                    response = "Su rubro es: "+ db.Rubros[Int32.Parse(dt.DataTemporal[message.ID][1])].Nombre +"\n"+"\n"+"Ahora ingrese su ciudad:";
                    return true;
                }
                else if(sm.UserStatusChat[message.ID]=="CiudadStatus")
                {
                    sm.AddUserStatus(message.ID,"CalleStatus");
                    dt.AddDato(message.ID,message.Text);
                    response = "Su ciudad es: "+message.Text+"\n"+"\n"+"Ahora ingrese su calle:";
                    return true;
                }
                else if(sm.UserStatusChat[message.ID]=="CalleStatus")
                {
                    sm.AddUserStatus(message.ID,"EspecializacionStatus");
                    dt.AddDato(message.ID,message.Text);
                    if(db.Invitados.Contains(message.ID))   //aca termina el registro para la empresa
                    {
                        sm.UserStatusChat.Remove(message.ID);
                        string name = dt.DataTemporal[message.ID][0];
                        Rubro rubro = db.Rubros[Int32.Parse(dt.DataTemporal[message.ID][1])];
                        string ciudad = dt.DataTemporal[message.ID][2];
                        string calle = dt.DataTemporal[message.ID][3];
                        Empresa empresa = new Empresa(name,rubro,ciudad,calle);
                        empresa.ID=message.ID;
                        db.AddEmpresa(message.ID,empresa);
                        dt.DataTemporal.Remove(message.ID);
                        response = $"{db.Empresas[message.ID].Nombre} has sido registrado correctamente!"+"\n"+$"su domicilio a sido fijado a {db.Empresas[message.ID].Ubicacion.Calle}, {db.Empresas[message.ID].Ubicacion.Ciudad}";
                        return true;
                    }
                    response = "Su calle es: " + message.Text + "\n"+"\n"+"Ahora ingrese su especialización:";
                    return true;
                }
                else if(sm.UserStatusChat[message.ID]=="EspecializacionStatus")
                {
                        sm.UserStatusChat.Remove(message.ID);
                        dt.AddDato(message.ID,message.Text);
                        string name = dt.DataTemporal[message.ID][0];
                        Rubro rubro = db.Rubros[Int32.Parse(dt.DataTemporal[message.ID][1])];
                        string ciudad = dt.DataTemporal[message.ID][2];
                        string calle = dt.DataTemporal[message.ID][3];
                        string especializacion = dt.DataTemporal[message.ID][4];
                        Emprendedor emprendedor = new Emprendedor(name, rubro,ciudad,calle,especializacion);
                        db.AddEmprendedor(message.ID,emprendedor);
                        dt.DataTemporal.Remove(message.ID);
                        response = $"Emprendedor {db.Emprendedores[message.ID].Nombre} del rubro {db.Emprendedores[message.ID].Rubro.Nombre} ha sido registrado correctamente!"+"\n"+$"Su domicilio a sido fijado a {db.Emprendedores[message.ID].Ubicacion.Calle}, {db.Emprendedores[message.ID].Ubicacion.Ciudad}" + "\n" + "\n" + "Recuerda que si desea agregar una habilitacion, debera utilizar el comando /habilitacion";
                        return true;
                }
                else if(sm.UserStatusChat[message.ID]=="HabilitacionStatus")
                {
                    int num;
                    if(!Int32.TryParse(message.Text,out num))
                    {
                        response = "No se ha ingresado un numero, ingrese un numero correspondiente.";
                        return true;
                    }
                    else if(Int32.Parse(message.Text) >=  db.Habilitaciones.Count)     
                    {
                        response = "Usted ha ingresado un numero incorrecto, por favor vuelva a intentarlo";
                        return true;
                    }
                    else
                    {
                        int opcion = Int32.Parse(message.Text);
                        db.Emprendedores[message.ID].AddHabilitacion(db.Habilitaciones[opcion]);
                        sm.UserStatusChat.Remove(message.ID);
                        response= "Se ha agreagado la habilitacion "+ db.Habilitaciones[opcion].Name;
                        return true;
                    }
                }
                else if(!sm.UserStatusChat.ContainsKey(message.ID))
                {
                    response = "No hay ningún proceso activo";
                    return true;
                }
            }
            else if(message.Text.ToLower()=="/habilitación")
            {
                sm.AddUserStatus(message.ID,"HabilitacionStatus");
                string opciones = "";
                int i =0;
                foreach (Habilitacion habilitacion in db.Habilitaciones)
                {
                    opciones = i.ToString() + " - " + opciones + habilitacion.Name +"\n";
                    i++;
                }
                response = "Seleccione una habilitación:\n" + opciones;
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}



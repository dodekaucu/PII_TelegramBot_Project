//--------------------------------------------------------------------------------
// <copyright file="RegistroHandler.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/registro".
    /// </summary>
    public class Registro : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Registro"/>. Esta clase procesa el mensaje "/registro".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public Registro(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registro"};
        }

        /// <summary>
        /// Procesa el comando "/registro", en el caso de que el usuario se encuentre en la lista de invitados.
        /// se procede a registrarlo como empresa (se le asigna el UserStatus "RegistroStatus").
        /// Y en el caso de que no esta en la lista de invitados comienza el registro como emprendedor.
        /// Se asigna el mismo status pero en el caso de la Empresa termina antes ya que el Emprendedor contiene.
        /// un dato que las Empresas no necesitan.
        /// Y en los casos que se ejecute el comando pero la empresa/emprendedor ya esten registrados se les informa esto mismo.
        /// </summary>
        /// <param name="message">Mensaje a procesar.</param>
        /// <param name="response">Respuesta al usuario.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            StatusManager sm = StatusManager.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            Contenedor db = Contenedor.Instancia;
            if(!sm.UserStatusChat.ContainsKey(message.ID))
            {
                sm.AddKeyUser(message.ID);
            }
            if (this.CanHandle(message))
            {
                if (db.Invitados.Contains(message.ID) && sm.UserStatusChat[message.ID]!="RegistroStatus")
                {
                    response = "Su ID se encuentra en la lista de invitados para registrarse como Empresa"+"\n"+"Ingrese el nombre de la empresa:";
                    sm.AddUserStatus(message.ID,"RegistroStatus");
                    dt.AddKeyUser(message.ID);
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
                    if(sm.UserStatusChat[message.ID]=="RegistroStatus")
                    {
                        response = "Ya hay un proceso activo, por favor termine el proceso actual o cancelelo con /cancel";
                        return true;
                    }
                    response = "Se procedera con su registro como emprendedor."+"\n"+"\n"+"Ingrese su nombre:";
                    sm.AddUserStatus(message.ID,"RegistroStatus");
                    dt.AddKeyUser(message.ID);
                    return true;           
                }
            }
            else if(sm.UserStatusChat[message.ID]=="RegistroStatus" && dt.DataTemporal[message.ID].Count==0)
                {
                    dt.AddDato(message.ID,message.Text);
                    string opciones = "";
                    int i =0;
                    foreach (Rubro rubro in db.Rubros)
                    {
                        opciones = opciones + i.ToString() + " - " + rubro.Nombre +"\n";
                        i++;
                    }
                    response = "Su nombre es: "+ message.Text+"\n"+"\n"+"Seleccione su rubro:\n" + opciones;
                    return true;
                }
            else if(sm.UserStatusChat[message.ID]=="RegistroStatus" && dt.DataTemporal[message.ID].Count==1)  
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
                    dt.AddDato(message.ID,message.Text);
                    response = "Su rubro es: "+ db.Rubros[Int32.Parse(dt.DataTemporal[message.ID][1])].Nombre +"\n"+"\n"+"Ahora ingrese su ciudad:";
                    return true;
                }
            else if(sm.UserStatusChat[message.ID]=="RegistroStatus" && dt.DataTemporal[message.ID].Count==2)
                {
                    dt.AddDato(message.ID,message.Text);
                    response = "Su ciudad es: "+message.Text+"\n"+"\n"+"Ahora ingrese su calle:";
                    return true;
                }
            else if(sm.UserStatusChat[message.ID]=="RegistroStatus" && dt.DataTemporal[message.ID].Count==3)
                {
                    dt.AddDato(message.ID,message.Text);
                    if(db.Invitados.Contains(message.ID)) 
                    {
                        response = "Su calle es: " + message.Text + "\n"+"\n"+"Ahora ingrese un teléfono de contacto:";
                        return true;
                    }
                    else
                    {
                    response = "Su calle es: " + message.Text + "\n"+"\n"+"Ahora ingrese su especialización:";
                    return true;
                    }
                }
            else if(sm.UserStatusChat[message.ID] == "RegistroStatus" && dt.DataTemporal[message.ID].Count==4)
                {
                    switch (db.Invitados.Contains(message.ID))
                    {
                        case true:
                        dt.AddDato(message.ID,message.Text);
                        string name = dt.DataTemporal[message.ID][0];
                        Rubro rubro = db.Rubros[Int32.Parse(dt.DataTemporal[message.ID][1])];
                        string ciudad = dt.DataTemporal[message.ID][2];
                        string calle = dt.DataTemporal[message.ID][3];
                        string telefono = dt.DataTemporal[message.ID][4];
                        db.AddEmpresa(name, rubro, ciudad, calle, message.ID, telefono);
                        dt.DataTemporal.Remove(message.ID);
                        sm.UserStatusChat.Remove(message.ID);
                        System.Console.WriteLine(db.Empresas[message.ID].Nombre);
                        response = $"{db.Empresas[message.ID].Nombre} has sido registrado correctamente!"+"\n"+$"su domicilio a sido fijado a {db.Empresas[message.ID].Ubicacion.Calle}, {db.Empresas[message.ID].Ubicacion.Ciudad}\nTEL: {db.Empresas[message.ID].Telefono}\n\nRecuerde que como empresa puede utilizar /PublicarOferta.";
                        return true;

                        case false:
                        dt.AddDato(message.ID, message.Text);
                        string name2 = dt.DataTemporal[message.ID][0];
                        Rubro rubro2 = db.Rubros[Int32.Parse(dt.DataTemporal[message.ID][1])];
                        string ciudad2 = dt.DataTemporal[message.ID][2];
                        string calle2 = dt.DataTemporal[message.ID][3];
                        string especializacion = dt.DataTemporal[message.ID][4];
                        db.AddEmprendedor(name2, rubro2, ciudad2, calle2, especializacion,message.ID);
                        dt.DataTemporal.Remove(message.ID);
                        sm.UserStatusChat.Remove(message.ID);
                        System.Console.WriteLine(db.Emprendedores[message.ID].Nombre);
                        response = $"Emprendedor {db.Emprendedores[message.ID].Nombre} del rubro {db.Emprendedores[message.ID].Rubro.Nombre} ha sido registrado correctamente!"+"\n"+$"Su domicilio a sido fijado a {db.Emprendedores[message.ID].Ubicacion.Ciudad}, {db.Emprendedores[message.ID].Ubicacion.Calle}" + "\n" + "\n" + "Recuerda que si desea agregar una habilitacion, debera utilizar el comando /AddHabilitacion";
                        return true;
                    }

                }
            else if(!sm.UserStatusChat.ContainsKey(message.ID))
            {
                response = "No hay ningún proceso activo";
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}


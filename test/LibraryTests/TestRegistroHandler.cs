using NUnit.Framework;
using Handlers;
using Library;
using Telegram.Bot.Types;

namespace ProgramTests
{
    public class RegistroHandlerTests
    {
        Registro handler;
        Message message;

        TelegramMSGadapter msj;
        Contenedor db;
        Rubro rubroTest;
        StatusManager sm;

        [SetUp]
        public void Setup() //Deberiamos hacer uno por mensage o uno por proceso????
        {
            sm = StatusManager.Instancia;
            Rubro rubroTest = new Rubro("Prueba","Prueba","Prueba");
            db = Contenedor.Instancia;
            db.AddRubro(rubroTest);
            handler = new Registro(null);
            message = new Message();
            message.From = new User();
            message.From.Id = 1454175798;
            msj = new TelegramMSGadapter(message);
        }

        [Test]
        public void TestRegistroEmprendedorHandle()
        {
            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(msj, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Se procedera con su registro como emprendedor."+"\n"+"\n"+"Ingrese su nombre:"
                ));
            
            message.Text = "NombreEmprendedor";
            handler.Handle(msj, out response);
            string opciones = "";
            int i =0;
            foreach (Rubro rubro in db.Rubros)
            {
                opciones = opciones + i.ToString() + " - " + rubro.Nombre +"\n";
                i++;
            }
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su nombre es: "+"NombreEmprendedor"+"\n"+"\n"+"Seleccione su rubro:\n" + opciones
                ));
            
            message.Text = "rubro"; 
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "No se ha ingresado un número, ingrese un numero válido."
                ));

            message.Text = "80";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo"
                ));
            
            message.Text = "0";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su rubro es: "+ db.Rubros[0].Nombre +"\n"+"\n"+"Ahora ingrese su ciudad:"
                ));

            message.Text = "montevideo";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su ciudad es: "+"montevideo"+"\n"+"\n"+"Ahora ingrese su calle:"
                ));
            
            message.Text = "calle 8";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su calle es: " + "calle 8" + "\n"+"\n"+"Ahora ingrese su especialización:"
                ));

            message.Text="madera";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Emprendedor NombreEmprendedor del rubro Prueba ha sido registrado correctamente!"+"\n"+$"Su domicilio a sido fijado a montevideo, calle 8" + "\n" + "\n" + "Recuerda que si desea agregar una habilitacion, debera utilizar el comando /AddHabilitacion"
                ));
        }

        [Test]
        public void TestRegistroEmpresaHandle()
        {
            db.Invitados.Add("1454175798");
            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(msj, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su ID se encuentra en la lista de invitados para registrarse como Empresa"+"\n"+"Ingrese el nombre de la empresa:"
                ));
            
                        message.Text = "NombreEmpresa";
            handler.Handle(msj, out response);
            string opciones = "";
            int i =0;
            foreach (Rubro rubro in db.Rubros)
            {
                opciones = opciones + i.ToString() + " - " + rubro.Nombre +"\n";
                i++;
            }
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su nombre es: "+"NombreEmpresa"+"\n"+"\n"+"Seleccione su rubro:\n" + opciones
                ));
            
            message.Text = "0";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su rubro es: "+ db.Rubros[0].Nombre +"\n"+"\n"+"Ahora ingrese su ciudad:"
                ));

            message.Text = "montevideo";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su ciudad es: "+"montevideo"+"\n"+"\n"+"Ahora ingrese su calle:"
                ));
            
            message.Text = "calle 8";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "NombreEmpresa has sido registrado correctamente!"+"\n"+$"su domicilio a sido fijado a calle 8, montevideo"
                ));
        }

        [Test]

        public void TestRegistroUsuarioRegistrado()
        {
            message.Text=handler.Keywords[0];
            db.Invitados.Remove("1454175798");
            string response;

            IHandler result = handler.Handle(msj, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Usted ya se encuentra registrado."
                ));
        }

        /*[Test]

        public void TestProcesoActivo() REVISAR!!!!
        {
            message.Text=handler.Keywords[0];
            sm.UserStatusChat["1454175798"] ="RegistroStatus";
            string response;

            IHandler result = handler.Handle(msj, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Ya hay un proceso activo, por favor termine el proceso actual o cancelelo con /cancel"
                ));
        }*/

        /*[Test]

        public void TestNOProcesoActivo()
        {
            sm.UserStatusChat.Remove("1454175798");
            string response;

            IHandler result = handler.Handle(msj, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "No hay ningún proceso activo"
                ));
        }*/

    }
}

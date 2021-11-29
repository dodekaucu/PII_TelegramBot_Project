using NUnit.Framework;
using Handlers;
using Library;
using Telegram.Bot.Types;

namespace ProgramTests
{
    /// <summary>
    /// Esta clase prueba el Handler AdminInvitarHandler.
    /// </summary>
    public class InvitarHandlerTests
    {
        AdminInvitationHandler handler;
        Message message;

        TelegramMSGadapter msj;
        Contenedor db;

        /// <summary>
        /// Crea una instancia de contenedor, el handler a probar, el message asi como asignarle una ID. Y ademas
        /// crea una instancia de TelegramMSG adapter.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            db = Contenedor.Instancia;
            handler = new AdminInvitationHandler(null);
            message = new Message();
            message.From = new User();
            message.From.Id = 150;
            
            msj = new TelegramMSGadapter(message);
        }

        /// <summary>
        /// Este test prueba como se procesa el mensaje cuando el usuario no es administrador.
        /// </summary>
        [Test]
        public void TestInvitaraEmpresaNOvalido()
        {
            message.Text=handler.Keywords[0]+" 007";
            string response;

            IHandler result = handler.Handle(msj, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Este comando sólo puede ser ejecutado por un administrador"
                ));
        }

        /// <summary>
        /// Este test prueba como se procesa el mensaje cuando el usuario es administrador.
        /// </summary>
        [Test]
        public void TestInvitaraEmpresaValido()
        {
            db.AddAdministrador("150");
            message.Text=handler.Keywords[0]+" 007";
            string response;

            IHandler result = handler.Handle(msj, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "La empresa con el usuario: " +"007"+ " ha sido agregado a la lista de empresas invitadas"
                ));
        }
    }

}
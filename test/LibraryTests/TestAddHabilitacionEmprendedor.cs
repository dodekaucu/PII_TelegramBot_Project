using NUnit.Framework;
using Handlers;
using Library;
using Telegram.Bot.Types;
using System;
using System.Collections.ObjectModel;

namespace ProgramTests
{
    /// <summary>
    /// Esta clase prueba el handler de PublicarOferta. Concretamente cuando se toma la ruta de oferta única.
    /// </summary>
    public class TestAddHabilitacionEmprendedor
    {
        AddHabilitacionHandler handler;
        Message message;

        TelegramMSGadapter msj;
        Contenedor db = Contenedor.Instancia;
        Clasificacion clasificacionTest;

        Emprendedor emprendedor;

        Busqueda buscador = Busqueda.Instancia;

        /// <summary>
        /// Crea una instancia de rubro, emprendedor, dos empresas, clasificación y dos ofertas para la búsqueda.
        /// estas se utilizan para el test de búsqueda a continuación.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Rubro rubroMadera = new Rubro("Madera", "Forestal", "Madera de todo tipo");
            emprendedor = new Emprendedor("Gaston Pereira", rubroMadera, "San Ramon", "Ruta 12", "Emprendimiento","1555");
            Habilitacion msp = new Habilitacion("MSP", "Habilitación del Ministerio de salud publica");
            Habilitacion unit = new Habilitacion("UNIT", "Habilitación Instituto Uruguayo de Normas Técnicas");
            Habilitacion iso = new Habilitacion("ISO 9000", "Habilitación ISO 9000");
            db.AddHabilitacion(msp);
            db.AddHabilitacion(unit);
            db.AddHabilitacion(iso);
            handler = new AddHabilitacionHandler(null);
            message = new Message();
            message.From = new User();
            message.From.Id = 1555;
            msj = new TelegramMSGadapter(message);
            db.AddEmprendedor("1555",emprendedor);
            db.Emprendedores["1555"].Habilitaciones.Add(msp);
        }

        /// <summary>
        /// Este test prueba la busqueda por palabras clave.
        /// </summary>
        [Test]
        public void TestAddPalabras()
        {
            message.Text = handler.Keywords[0];
            string response;
            
            IHandler result = handler.Handle(msj, out response);

            string opciones ="";
                    int i=0;
                    foreach (Habilitacion habilitacion in db.Habilitaciones)
                    {
                        opciones = opciones + i.ToString() + " - " + habilitacion.Name +"\n";
                        i++;
                    }
                    string respuesta = "Seleccione su habilitación (escriba el número correspondiente)\n"+ opciones;

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(respuesta));

            message.Text = "asdasd"; //el usuario no un número.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "No se ha ingresado un número, ingrese un numero válido."
                ));
            
            message.Text = "34553"; //el usuario no ingresa un numero válido.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo."
                ));
            
            message.Text = "0"; //el usuario no ingresa un numero válido.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Usted ya posee esta habilitacion."+"\n"+"\n"+"Ingrese un número válido para añadir otra o /cancelar para salir del menú."
                ));

            message.Text = "1"; //el usuario no ingresa un numero válido.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "La habilitacion añadida es: "+ db.Habilitaciones[1].Name + "\n"+"\n" + "Ingrese /addhabilitacion para añadir otra."
                ));
        }
        

    }

}

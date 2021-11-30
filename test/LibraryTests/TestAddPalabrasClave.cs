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
    public class TestAddPalabrasClave
    {
        AddPalabraClaveHandler handler;
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
            Rubro rubroMadera = new Rubro("Forestal", "Leñeria", "Recursos");
            Empresa barracaFernandez = new Empresa("Madera SRL", rubroMadera, "San Bautista", "Ruta 6","24","099222333");
            Clasificacion madera = new Clasificacion("Madera", "Madera natural");
            Oferta uno = new Oferta("Madera tratada", barracaFernandez, "San Ramon", "Tala", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("13/09/2021"));
            db.AddOferta(uno);
            db.AddClasificacion(madera);
            db.AddRubro(rubroMadera);
            handler = new AddPalabraClaveHandler(null);
            message = new Message();
            message.From = new User();
            message.From.Id = 24;
            msj = new TelegramMSGadapter(message);
            db.AddEmpresa("24",barracaFernandez);
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
                    foreach (Oferta oferta in db.Ofertas)
                    {
                        if(db.Empresas[msj.ID]==oferta.Empresa)
                        {
                            //aca van a estar las ofertas que posee la empresa, identificadas por ID.
                            opciones = opciones + "ID " + oferta.Identificador.ToString() + " - " + oferta.Nombreoferta +"\n";
                        }
                    }
                    string response1 = "Seleccione la oferta a añadir una palabra clave: \n" + opciones;

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(response1));

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
                "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo"
                ));

            message.Text = "1"; //el usuario no ingresa un numero válido.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                $"Ingrese palabra clave para añadir a la oferta {db.Ofertas[Int32.Parse(message.Text)].Nombreoferta}:"
                ));

            message.Text = "palabra";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                $"Palabra clave \"{message.Text}\" añadida a {db.Ofertas[1].Nombreoferta}"
                ));
        }

    }

}

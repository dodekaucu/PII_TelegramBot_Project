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
    public class TestAddHabilitacionEmpresa
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
            Empresa empresa = new Empresa("Barraca Fernandez", rubroMadera, "San Bautista", "Ruta 6","2555","099222333");
            Clasificacion madera = new Clasificacion("Madera", "Madera natural");
            Oferta uno = new Oferta("Madera tratada", empresa, "San Ramon", "Tala", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("13/09/2021"));
            db.AddOferta(uno);
            Habilitacion msp = new Habilitacion("MSP", "Habilitación del Ministerio de salud publica");
            Habilitacion unit = new Habilitacion("UNIT", "Habilitación Instituto Uruguayo de Normas Técnicas");
            Habilitacion iso = new Habilitacion("ISO 9000", "Habilitación ISO 9000");
            db.AddHabilitacion(msp);
            db.AddHabilitacion(unit);
            db.AddHabilitacion(iso);
            handler = new AddHabilitacionHandler(null);
            message = new Message();
            message.From = new User();
            message.From.Id = 2555;
            msj = new TelegramMSGadapter(message);
            db.AddEmpresa("2555",empresa);
            db.Ofertas[0].Habilitaciones.Add(msp);
        }

        /// <summary>
        /// Este test prueba la busqueda por palabras clave.
        /// </summary>
        [Test]
        public void TestAddHabilitacion()
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
                    string respuesta = "Seleccione la oferta a añadir una habilitación: \n" + opciones;

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(respuesta));

            message.Text = "asdasd"; //el usuario no ingresa un número.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "No se ha ingresado un número, ingrese un numero válido."
                ));
            
            message.Text = "4553"; //el usuario ingresa un numero no válido.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo"
                ));
            
            message.Text = "1"; //el usuario ingresa un numero válido.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            string opciones2 = "";
                    int i = 0;
                    foreach (Habilitacion habilitacion in db.Habilitaciones)
                    {
                        opciones2 = opciones2 + i.ToString() + " - " + habilitacion.Name +"\n";
                        i++;
                    }
                    string respuesta2 = $"Ingrese una habilitacion para agregar a {db.Ofertas[1].Nombreoferta}" + "\n \n" + "Habilitaciones disponibles: \n" + opciones2;
            Assert.That(response, Is.EqualTo(respuesta2));

            message.Text = "dsdsff"; //el usuario no ingresa un numero.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "No se ha ingresado un número, ingrese un numero válido."
                ));

            message.Text = "67"; //el usuario no ingresa un numero.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo."
                ));

            message.Text = "0"; //el usuario no ingresa un numero.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Esta oferta ya posee esta habilitación."+"\n"+"\n"+"Ingrese un número válido o /cancelar para salir del menú."
                ));

            message.Text = "1"; //el usuario no ingresa un numero.
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                $"Se agregó la habilitación {db.Habilitaciones[1].Name} a la oferta {db.Ofertas[1].Nombreoferta}"
                ));
            
        }
        

    }

}

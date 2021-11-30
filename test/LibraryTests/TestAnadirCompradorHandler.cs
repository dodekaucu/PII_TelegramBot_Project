//--------------------------------------------------------------------------------
// <copyright file="TestAnadirCompradorHandler.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using NUnit.Framework;
using Handlers;
using Library;
using Telegram.Bot.Types;
using System;
using System.Collections.ObjectModel;

namespace ProgramTests
{
    /// <summary>
    /// Esta clase prueba el handler de 
    /// </summary>
    public class TestAnadirCompradorHandler
    {
        AnadirCompradorHandler handler;
        Message message;

        TelegramMSGadapter msj;
        Contenedor db = Contenedor.Instancia;
        Clasificacion clasificacionTest;

        Emprendedor emprendedor;


        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Rubro rubroMadera = new Rubro("Forestal", "Leñeria", "Recursos");
            db.AddEmpresa("Madera SRL", rubroMadera, "San Bautista", "Ruta 6","8001","099222333");
            db.AddEmprendedor("Emprendedor Prueba", rubroMadera,"San Bautista", "Ruta 6","madera","9001");
            Clasificacion madera = new Clasificacion("Madera", "Madera natural");
            Oferta uno = new Oferta("Madera tratada", db.Empresas["8001"] , "San Ramon", "Tala", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("13/09/2021"));
            handler = new AnadirCompradorHandler(null);
            message = new Message();
            message.From = new User();
            message.From.Id = 8001;
            msj = new TelegramMSGadapter(message);
        }

        /// <summary>
        /// Test que simula una interaccion desde un usuario (Emprendedor) que consulta las ofertas compradas desde
        /// una fecha anterior.
        /// </summary>
        [Test]
        public void AnadirComprador()
        {
            message.Text = handler.Keywords[0];
            string response;
            IHandler result = handler.Handle(msj, out response);
            string opciones ="";
            foreach (Oferta oferta in db.Ofertas)
            {
                if(msj.ID==oferta.Empresa.ID)
                {
                    opciones = opciones + "ID " + db.Ofertas.IndexOf(oferta) + " - " + oferta.Nombreoferta +"\n";
                }
            }
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "las ofertas que usted posee son:\n"+ opciones +"seleccione una oferta para añiadir un comprador"
                ));

            message.Text = "012036548465466";   //Ingresa una ID no registrada como emprendedor     
            string fecha = DateTime.Now.ToString();
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "la id no se encuentra registrada como emprendedor"
                ));
        }

    }
}
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
    public class TestBusquedaUbi
    {
        BuscarUbiHandler handler;
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
            emprendedor = new Emprendedor("Gaston Pereira", rubroMadera, "San Ramon", "Ruta 12", "Emprendimiento");
            Empresa barracaFernandez = new Empresa("Madera SRL", rubroMadera, "San Bautista", "Ruta 6");
            Empresa carpinteriaRodriguez = new Empresa("Madera SRL", rubroMadera, "San Bautista", "Ruta 6");
            Clasificacion madera = new Clasificacion("Madera", "Madera natural");
            Oferta uno = new Oferta("Madera tratada", barracaFernandez, "San Ramon", "Tala", "madera", madera, 1, "Tonelada", 5000, 0, DateTime.Parse("13/09/2021"));
            db.AddOferta(uno);
            Oferta dos = new Oferta("Madera encofrado", carpinteriaRodriguez, "Montevideo", "Bulevar Artigas", "madera", madera, 100, "Kilos", 4000, 0, DateTime.Parse("11/11/2021"));
            db.AddOferta(dos);
            db.AddClasificacion(madera);
            db.AddRubro(rubroMadera);
            handler = new BuscarUbiHandler(null);
            message = new Message();
            message.From = new User();
            message.From.Id = 1333;
            msj = new TelegramMSGadapter(message);
            db.AddEmprendedor("1333",emprendedor);
        }

        /// <summary>
        /// Este test prueba la busqueda por ubicación.
        /// </summary>
        [Test]
        public void TestBusquedaUbicacion()
        {
            message.Text = "/bubicacion San Ramon, Tala";
            string response;
            string respuestaesperada;

            string mensaje = message.Text.Remove(0,12);
            string[] ubicacion = mensaje.Split(',');
            Ubicacion ubicacionbuscada = new Ubicacion(ubicacion[0].Trim(), ubicacion[1].Trim());

            Collection<Oferta> ofertasvalidas = buscador.BuscarOferta(emprendedor, ubicacionbuscada, db);
            if (ofertasvalidas.Count == 0)
            {
                respuestaesperada = "No hay ofertas disponibles";
            }
            else
            {
                respuestaesperada = "OFERTAS DISPONIBLES: \n";
                foreach (Oferta oferta in ofertasvalidas)
                {
                respuestaesperada += "\n";
                respuestaesperada += "Nombre: " + oferta.Nombreoferta + "\n";
                respuestaesperada += "Material: " + oferta.Material.Nombre + "\n";
                respuestaesperada += "Cantidad: " + oferta.Material.Cantidad +" "+oferta.Material.Unidad + "\n";
                respuestaesperada += "Precio: $" + oferta.Material.Valor + "\n";
                respuestaesperada += "Identificador: " + oferta.Identificador + "\n";
                respuestaesperada += "\n";
                respuestaesperada += "---------------------------------------" + "\n";
                }   
            }

            IHandler result = handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(respuestaesperada));
        }
    }
}
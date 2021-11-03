//--------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace Test
{
    /// <summary>
    /// Pruebas de las diferentes Users story.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Rubro para pruebas.
        /// </summary>
        private Rubro testRubro;

        /// <summary>
        /// Habilitacion para prueba.
        /// </summary>
        private Habilitacion testHabilitacion;

        /// <summary>
        /// Clasificacion para prueba.
        /// </summary>
        private Clasificacion testClasifciacion;

        private Contenedor db;

        private Busqueda buscador;

        /// <summary>
        /// Crea un Rubro, una habilitacion y una clasificacion para pruebas.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.testRubro = new Rubro("Tecnologia", "Software", "Programacion");
            this.testHabilitacion = new Habilitacion("UNIT", "9001");
            this.testClasifciacion = new Clasificacion("Reciclable", "se puede reciclar");
            this.db = Contenedor.Instancia;
            this.buscador = Busqueda.Instancia;
        }

        /// <summary>
        /// Prueba que se cree la empresa.
        /// </summary>
        [Test]
        public void TestCrearEmpresa()
        {
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848");
            string expectedNombre = "12 Holdings";
            Assert.AreEqual(expectedNombre, empresaTest.Nombre);
            string expectedRubro = "Tecnologia";
            Assert.AreEqual(expectedRubro, empresaTest.Rubro.Nombre);
            string expectedCiudad = "Montevideo";
            Assert.AreEqual(expectedCiudad, empresaTest.Ubicacion.Ciudad);
            string expectedCalle = "Plaza Independencia 848";
            Assert.AreEqual(expectedCalle, empresaTest.Ubicacion.Calle);
        }

        /// <summary>
        ///  Prueba que se crea materiales.
        /// </summary>
        [Test]
        public void TestCrearMateriales()
        {
            Clasificacion clasificacionTest = new Clasificacion("Escombros", "Escombros de demolicion");
            Material materialTest = new Material("Escombros de Antel", clasificacionTest, 100, "kg", 150);
            string expectedNombre = "Escombros de Antel";
            Assert.AreEqual(expectedNombre, materialTest.Nombre);
            string expectedClasificacionNombre = "Escombros";
            Assert.AreEqual(expectedClasificacionNombre, materialTest.Clasificacion.Nombre);
            string expectedClasificacionDescripcion = "Escombros de demolicion";
            Assert.AreEqual(expectedClasificacionDescripcion, materialTest.Clasificacion.Descripcion);
            int expectedCantidad = 100;
            Assert.AreEqual(expectedCantidad, materialTest.Cantidad);
            string expectedUnidad = "kg";
            Assert.AreEqual(expectedUnidad, materialTest.Unidad);
            int expectedValor = 150;
            Assert.AreEqual(expectedValor, materialTest.Valor);
        }

        /// <summary>
        /// Prueba que se cree una Oferta.
        /// </summary>
        [Test]
        public void TestCrearOferta()
        {
            Clasificacion clasificacionTest = new Clasificacion("Escombros", "Escombros de demolicion");
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, 3, "Montevideo", "Plaza Independencia 848", true, "Escombros", clasificacionTest, 150, "Kilos", 100);
            string expectedNombre = "Escombros";
            Assert.AreEqual(expectedNombre, ofertaTest.Nombreoferta);
            string expectedEmpresa = "12 Holdings";
            Assert.AreEqual(expectedEmpresa, ofertaTest.Empresa.Nombre);
            string expectedCiudad = "Montevideo";
            Assert.AreEqual(expectedCiudad, ofertaTest.Ubicacion.Ciudad);
            string expectedCalle = "Plaza Independencia 848";
            Assert.AreEqual(expectedCalle, ofertaTest.Ubicacion.Calle);
            string expectedDescripcion = "Escombros de demolicion";
            Assert.AreEqual(expectedDescripcion, ofertaTest.Material.Clasificacion.Descripcion);
            string expectedClasificacion = "Escombros";
            Assert.AreEqual(expectedClasificacion, ofertaTest.Material.Clasificacion.Nombre);
            string expectedUnidad = "Kilos";
            Assert.AreEqual(expectedUnidad, ofertaTest.Material.Unidad);
            int expectedCantidad = 150;
            Assert.AreEqual(expectedCantidad, ofertaTest.Material.Cantidad);
            int expectedPrecio = 100;
            Assert.AreEqual(expectedPrecio, ofertaTest.Material.Valor);
            bool expectedEstado = true;
            Assert.AreEqual(expectedEstado, ofertaTest.Disponible);
            int expectedRecurrencia = 3;
            Assert.AreEqual(expectedRecurrencia, ofertaTest.Recurrencia);
        }

        /// <summary>
        /// Test Disponibilidad Materiales.
        /// </summary>
        [Test]
        public void TestDisponibilidadMateriales()
        {
            Material materialTest = new Material("Escombros de Antel", this.testClasifciacion, 100, "kg", 150);
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, 3, "Montevideo", "Plaza Independencia 848", true, "Escombros", this.testClasifciacion, 150, "Kilos", 100);
            int expectedRecurrencia = 3;
            Assert.AreEqual(expectedRecurrencia, ofertaTest.Recurrencia);
        }

        /// <summary>
        /// Prueba que dada una oferta se le asigenen las habilitaciones correspondientes.
        /// </summary>
        [Test]
        public void TestHabilitacionesEmprendedor()
        {
            Clasificacion clasificacionTest = new Clasificacion("Escombros", "Escombros de demolicion");
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848");
            Habilitacion habilitacionTest = new Habilitacion("DGI", "Permisos del DGI");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, 3, "Montevideo", "Plaza Independencia 848", true, "Escombros", clasificacionTest, 150, "Kilos", 100);
            ofertaTest.AddHabilitacion(habilitacionTest);
            string expectedNombreHabilitacion = "DGI";
            Assert.AreEqual(expectedNombreHabilitacion, habilitacionTest.Name);
            string expectedDescripcionHabilitacion = "Permisos del DGI";
            Assert.AreEqual(expectedDescripcionHabilitacion, habilitacionTest.Descripcion);
        }

        /// <summary>
        /// Prueba que se agreguen las palabras claves a la oferta.
        /// </summary>
        [Test]
        public void TestPalabrasClaveOferta()
        {
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, 3, "Montevideo", "Plaza Independencia 848", true, "Escombros", this.testClasifciacion, 150, "Kilos", 100);
            ofertaTest.AddPalabraClave("madera");
            ofertaTest.AddPalabraClave("Montevideo");
            ofertaTest.AddPalabraClave("cocina");
            List<string> expectedPalabrasClaves = new List<string>() { "Escombros", "12 Holdings", "Escombros", "madera", "Montevideo", "cocina" };
            Assert.AreEqual(ofertaTest.PalabrasClaves, expectedPalabrasClaves);
        }

        /// <summary>
        /// Prueba que se cree el emprendedor.
        /// </summary>
        [Test]
        public void TestCrearEmprendedor()
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene", this.testRubro, "La perla", "Calle 13", "madera");
            string expectedNombre = "Rene";
            Assert.AreEqual(expectedNombre, emprendedorTest.Nombre);
            string expectedRubro = "Tecnologia";
            Assert.AreEqual(expectedRubro, emprendedorTest.Rubro.Nombre);
            string expectedCiudad = "La perla";
            Assert.AreEqual(expectedCiudad, emprendedorTest.Ubicacion.Ciudad);
            string expectedCalle = "Calle 13";
            Assert.AreEqual(expectedCalle, emprendedorTest.Ubicacion.Calle);
            string expectedEspezialicacion = "madera";
            Assert.AreEqual(expectedEspezialicacion, emprendedorTest.Especializacion);
        }

        /// <summary>
        /// Prueba que se agruegue una habilitacion a un emprendedor.
        /// </summary>
        [Test]
        public void HabilitacionesEmprendedor()
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene", this.testRubro, "La perla", "Calle 13", "madera");
            emprendedorTest.AddHabilitacion(this.testHabilitacion);
            Assert.AreEqual(this.testHabilitacion, emprendedorTest.Habilitaciones[0]);
        }

        /// <summary>
        /// Prueba que las excepcioens del constructor Usuario funcionen correctamente.
        /// </summary>
        [Test]
        public void ThrowNameException()
        {
            Assert.Throws<ArgumentException>(() => new Emprendedor(string.Empty, this.testRubro, "La perla", "Calle 13", "madera"));
            Assert.Throws<ArgumentNullException>(() => new Emprendedor(null, this.testRubro, "La perla", "Calle 13", "madera"));
        }

        /// <summary>
        /// Test de la clase busqueda, realiza una busqueda por palabras claves.
        /// </summary>
        [Test]
        public void TestBusquedaPalabrasClave()
        {
            Habilitacion msp = new Habilitacion("MSP", "msp");
            Rubro rubro = new Rubro("Forestal", "Leñeria", "Recursos");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro, "San Ramon", "Ruta 12", "Emprendimiento");
            Empresa maderaslr = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6");
            Clasificacion madera = new Clasificacion("Madera", "Roble Oscuro");
            Oferta uno = new Oferta("Madera", maderaslr, 1, "San Bautista", "Ruta 6", true, "Madera", madera, 1, "Tonelada", 5000);
            uno.AddHabilitacion(msp);
            emprendedor.AddHabilitacion(msp);
            this.db.AddOferta(uno);
            List<Oferta> expectedResultado = new List<Oferta>() { uno };
            Assert.AreEqual(expectedResultado, this.buscador.BuscarOferta(emprendedor, "Madera", this.db));
            int largoEsperado2 = 0;
            Assert.AreEqual(largoEsperado2, this.buscador.BuscarOferta(emprendedor, "Azucar", this.db).Count);
        }

        /// <summary>
        /// Test de la clase busqueda, realiza una busqueda por Ubicacion.
        /// </summary>
        [Test]
        public void TestBusquedaUbicacion()
        {
            Rubro rubro2 = new Rubro("Metal", "Hierro", "Herreria");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro2, "San Ramon", "Ruta 12", "Emprendimiento");
            Empresa herracor = new Empresa("Herracor", rubro2, "San Bautista", "Ruta 6");
            Clasificacion hierro = new Clasificacion("Metales", "Metales, etc");
            Oferta dos = new Oferta("Metales", herracor, 1, "Santa Rosa", "Ruta 6", true, "Metales", hierro, 1, "Kilos", 500);
            Ubicacion buscarubi = new Ubicacion("Santa Rosa", "Ruta 6");
            Ubicacion buscarubi2 = new Ubicacion("San Ramon", "Ruta 6");
            this.db.AddOferta(dos);
            List<Oferta> expectedResultadoo = new List<Oferta>() { dos };
            Assert.AreEqual(expectedResultadoo, this.buscador.BuscarOferta(emprendedor, buscarubi, this.db));
            int largoEsperado2 = 0;
            Assert.AreEqual(largoEsperado2, this.buscador.BuscarOferta(emprendedor, buscarubi2, this.db).Count);
        }

        /// <summary>
        /// Test de la clase busqeuda, realiza una busqueda por categoria de material.
        /// </summary>
        [Test]
        public void TestBusquedaCategoria()
        {
            Rubro rubro3 = new Rubro("Ropa", "Textil", "Telas");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro3, "San Ramon", "Ruta 12", "Emprendimiento");
            Empresa ropaUsada = new Empresa("Ropa Usada", rubro3, "San Bautista", "Ruta 6");
            Clasificacion textil = new Clasificacion("Textiles", "Todo tipo de textiles");
            Oferta tres = new Oferta("Textiles", ropaUsada, 1, "San Bautista", "Ruta 6", true, "Textiles", textil, 1, "Kilos", 500);
            Clasificacion buscarclasi = new Clasificacion("Textiles", "Todo tipo de textiles");
            Clasificacion buscarclasi2 = new Clasificacion("Residuos hospitalarios", "Residuoos provenientes de hospitales");
            this.db.AddOferta(tres);
            List<Oferta> expectedResultadoo = new List<Oferta>() { tres };
            Assert.AreEqual(expectedResultadoo, this.buscador.BuscarOferta(emprendedor, buscarclasi, this.db));
            int largoEsperado2 = 0;
            Assert.AreEqual(largoEsperado2, this.buscador.BuscarOferta(emprendedor, buscarclasi2, this.db).Count);
        }
    }
}
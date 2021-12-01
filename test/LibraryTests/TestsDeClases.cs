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
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848","5122","007");
            string expectedNombre = "12 Holdings";
            Assert.AreEqual(expectedNombre, empresaTest.Nombre);
            string expectedRubro = "Tecnologia";
            Assert.AreEqual(expectedRubro, empresaTest.Rubro.Nombre);
            string expectedCiudad = "Montevideo";
            Assert.AreEqual(expectedCiudad, empresaTest.Ubicacion.Ciudad);
            string expectedCalle = "Plaza Independencia 848";
            Assert.AreEqual(expectedCalle, empresaTest.Ubicacion.Calle);
            Assert.AreEqual("5122", empresaTest.ID);
            Assert.AreEqual("007", empresaTest.Telefono);
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
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848","564","666");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, "Montevideo", "Plaza Independencia 848", "Escombros", clasificacionTest, 150, "Kilos", 100, 0 ,DateTime.Parse("11/11/2021"));
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
            DateTime expectedFecha = DateTime.Parse("11/11/2021");
            Assert.AreEqual(expectedFecha, ofertaTest.FechadeGeneracion);
        }

        /// <summary>
        /// Prueba la Disponibilidad Materiales de manera semanal.
        /// </summary>
        [Test]
        public void TestDisponibilidadMateriales()
        {
            Clasificacion clasificacionTest = new Clasificacion("Escombros", "Escombros de demolicion");
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848","564","666");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, "Montevideo", "Plaza Independencia 848", "Escombros", clasificacionTest, 150, "Kilos", 100, 5 ,DateTime.Parse("11/11/2021"));
            int expectedRecurrencia = 5;
            Assert.AreEqual(expectedRecurrencia, ofertaTest.RecurrenciaSemanal);
        }

        /// <summary>
        /// Prueba que dada un oferta que se genera de manera unica, se le asigne la fecha correcta.
        /// </summary>
        [Test]
        public void TestDisponibilidadUnica()
        {
            Material materialTest = new Material("Escombros de Antel", this.testClasifciacion, 100, "kg", 150);
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848","00001","010101");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, "Montevideo", "Plaza Independencia 848", "Escombros", this.testClasifciacion, 150, "Kilos", 100, 0 ,DateTime.Parse("11/11/2021"));
            DateTime dateExpected = DateTime.Parse("11/11/2021");
            Assert.AreEqual(dateExpected, ofertaTest.FechadeGeneracion);
        }

        /// <summary>
        /// Prueba que dada una oferta se le asigenen las habilitaciones correspondientes.
        /// </summary>
        [Test]
        public void TestHabilitacionesEmprendedor()
        {
            Clasificacion clasificacionTest = new Clasificacion("Escombros", "Escombros de demolicion");
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848", "494","09002911");
            Habilitacion habilitacionTest = new Habilitacion("DGI", "Permisos del DGI");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, "Montevideo", "Plaza Independencia 848", "Escombros", this.testClasifciacion, 150, "Kilos", 100, 0, DateTime.Parse("11/11/2021"));
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
            Empresa empresaTest = new Empresa("12 Holdings", this.testRubro, "Montevideo", "Plaza Independencia 848","125","09002920");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, "Montevideo", "Plaza Independencia 848", "Escombros", this.testClasifciacion, 150, "Kilos", 100, 0 ,DateTime.Parse("11/11/2021"));
            ofertaTest.AddPalabraClave("madera");
            ofertaTest.AddPalabraClave("Montevideo");
            ofertaTest.AddPalabraClave("cocina");
            List<string> expectedPalabrasClaves = new List<string>() { "escombros", "12", "holdings", "escombros" ,"madera", "montevideo", "cocina" };
            Assert.AreEqual(ofertaTest.PalabrasClaves, expectedPalabrasClaves);
        }

        /// <summary>
        /// Prueba que se cree el emprendedor.
        /// </summary>
        [Test]
        public void TestCrearEmprendedor()
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene", this.testRubro, "La perla", "Calle 13", "madera","150");
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
            Assert.AreEqual("150",emprendedorTest.ID);
        }

        /// <summary>
        /// Prueba que se agruegue una habilitacion a un emprendedor.
        /// </summary>
        [Test]
        public void HabilitacionesEmprendedor()
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene", this.testRubro, "La perla", "Calle 13", "madera","127");
            emprendedorTest.AddHabilitacion(this.testHabilitacion);
            Assert.AreEqual(this.testHabilitacion, emprendedorTest.Habilitaciones[0]);
        }

        /// <summary>
        /// Prueba que las excepcioens del constructor Usuario funcionen correctamente.
        /// </summary>
        [Test]
        public void ThrowNameException()
        {
            Assert.Throws<ArgumentException>(() => new Emprendedor(string.Empty, this.testRubro, "La perla", "Calle 13", "madera","450"));
            Assert.Throws<ArgumentNullException>(() => new Emprendedor(null, this.testRubro, "La perla", "Calle 13", "madera","450"));
        }

        /// <summary>
        /// Test de la clase busqueda, realiza una busqueda por palabras claves.
        /// </summary>
        [Test]
        public void TestBusquedaPalabrasClave()
        {
            Habilitacion msp = new Habilitacion("MSP", "msp");
            Rubro rubro = new Rubro("Forestal", "Leñeria", "Recursos");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro, "San Ramon", "Ruta 12", "Emprendimiento","4252564");
            Empresa maderaslr = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6","582","582");
            Clasificacion madera = new Clasificacion("Madera", "Roble Oscuro");
            Oferta uno = new Oferta("Madera", maderaslr, "San Bautista", "Ruta 6", "Madera", madera, 1, "Tonelada", 5000, 0 ,DateTime.Parse("11/11/2021"));
            uno.AddHabilitacion(msp);
            uno.AddPalabraClave("barato");
            emprendedor.AddHabilitacion(msp);
            this.db.AddOferta(uno);
            List<Oferta> expectedResultado = new List<Oferta>() { uno };
            Assert.AreEqual(expectedResultado, this.buscador.BuscarOferta(emprendedor, "barato", this.db));
        }

        /// <summary>
        /// Test de la clase busqueda, realiza una busqueda por Ubicacion.
        /// </summary>
        [Test]
        public void TestBusquedaUbicacion()
        {
            Rubro rubro2 = new Rubro("Metal", "Hierro", "Herreria");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro2, "San Ramon", "Ruta 12", "Emprendimiento","7892");
            Empresa herracor = new Empresa("Herracor", rubro2, "San Bautista", "Ruta 6","79523","789798789");
            Clasificacion hierro = new Clasificacion("Metales", "Metales, etc");
            Oferta dos = new Oferta("Metales", herracor, "Santa Rosa", "Ruta 6", "Metales", hierro, 1, "Kilos", 500,0, DateTime.Parse("11/11/2021"));
            Ubicacion buscarubi = new Ubicacion("Santa Rosa", "Ruta 6");
            Ubicacion buscarubi2 = new Ubicacion("San Ramon", "Ruta 6");
            this.db.AddOferta(dos);
            List<Oferta> expectedResultadoo = new List<Oferta>() { dos };
            Assert.AreEqual(expectedResultadoo, this.buscador.BuscarOferta(emprendedor, buscarubi, this.db));
        }

        /// <summary>
        /// Test de la clase busqeuda, realiza una busqueda por categoria de material.
        /// </summary>
        [Test]
        public void TestBusquedaCategoria()
        {
            Rubro rubro3 = new Rubro("Ropa", "Textil", "Telas");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro3, "San Ramon", "Ruta 12", "Emprendimiento","6548");
            Empresa ropaUsada = new Empresa("Ropa Usada", rubro3, "San Bautista", "Ruta 6","64585","099925879");
            Clasificacion textil = new Clasificacion("Textiles", "Todo tipo de textiles");
            Oferta tres = new Oferta("Textiles", ropaUsada, "San Bautista", "Ruta 6", "Textiles", textil, 1, "Kilos", 500,0, DateTime.Parse("11/11/2021"));
            Clasificacion buscarclasi = new Clasificacion("Textiles", "Todo tipo de textiles");
            Clasificacion buscarclasi2 = new Clasificacion("Residuos hospitalarios", "Residuoos provenientes de hospitales");
            this.db.AddOferta(tres);
            List<Oferta> expectedResultadoo = new List<Oferta>() { tres };
            Assert.AreEqual(expectedResultadoo, this.buscador.BuscarOferta(emprendedor, buscarclasi, this.db));
        }

        /// <summary>
        /// Prueba que las empresas accedan a su registro de materiales entregados en un perido de tiempo determinado.
        /// </summary>
        [Test]
        public void TestRegistroEmpresa()
        {
            Rubro rubro = new Rubro("a", "a", "a");
            Clasificacion clasificacion = new Clasificacion("a", "a");
            db.AddEmprendedor("tata", rubro, "mont", "uru", "madera","410");
            db.AddEmpresa("tata", rubro, "mont", "uru","480","480");
            Oferta oferta1 = new Oferta("a", db.Empresas["480"], "10", "10", "pan", clasificacion, 5, "kg", 5.0,0,DateTime.Parse("11/11/2021"));
            oferta1.AddComprador("410",DateTime.Parse("12/11/2021"));
            db.Empresas["480"].AddToRegister(oferta1);
            List<Oferta> expectedRegister2 = new List<Oferta>() { oferta1 };
            Assert.AreEqual(expectedRegister2, db.Empresas["480"].BuscarEnHistorial(DateTime.Parse("01/10/2021")));
        }

        /// <summary>
        /// Prueba que los emprendedores accedan a su registro de materiales consumidos en un perido de tiempo determinado.
        /// </summary>
        [Test]
        public void TestRegistroEmprendedor()
        {
            Rubro rubro = new Rubro("a", "a", "a");
            Clasificacion clasificacion = new Clasificacion("a", "a");
            db.AddEmprendedor("tata", rubro, "mont", "uru", "madera","420");
            Empresa empresa = new Empresa("tata", rubro, "mont", "uru","450","450");
            Oferta oferta1 = new Oferta("a", empresa, "10", "10", "pan", clasificacion, 5, "kg", 5.0,0,DateTime.Parse("11/11/2021"));
            oferta1.AddComprador("420",DateTime.Parse("12/11/2021"));
            db.Emprendedores["420"].AddToRegister(oferta1);
            List<Oferta> expectedRegister2 = new List<Oferta>() { oferta1 };
            Assert.AreEqual(expectedRegister2, db.Emprendedores["420"].BuscarEnHistorial(DateTime.Parse("01/10/2021")));
        }
    }
}
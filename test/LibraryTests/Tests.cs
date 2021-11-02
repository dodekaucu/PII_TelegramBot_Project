using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Pruebas de las diferentes clases de la libreria
    /// </summary>

    [TestFixture]
    public class Test
    {

        Rubro TestRubro = new Rubro("Tecnologia","Software","Programacion");
        Habilitacion TestHabilitacion = new Habilitacion("UNIT","9001");

        Clasificacion TestClasificaion = new Clasificacion("Hormigon armado","una hormiga grande con un arma");



        /// <summary>
        /// Prueba que se cree la empresa
        /// </summary>
            
        [Test]
        public void TestCrearEmpresa()
        {
            Empresa empresaTest = new Empresa("12 Holdings",TestRubro,"Montevideo","Plaza Independencia 848");
            string expectedNombre = "12 Holdings";
            Assert.AreEqual(expectedNombre,empresaTest.Nombre);
            string expectedRubro = "Tecnologia";
            Assert.AreEqual(expectedRubro, empresaTest.Rubro.Nombre);
            string expectedCiudad = "Montevideo";
            Assert.AreEqual(expectedCiudad,empresaTest.Ubicacion.Ciudad);
            string expectedCalle = "Plaza Independencia 848";
            Assert.AreEqual(expectedCalle, empresaTest.Ubicacion.Calle);
        }

        /// <summary>
        /// Prueba que se cree una Oferta
        /// </summary>
        [Test]
        public void TestCrearOferta()
        {
            Clasificacion clasificacionTest = new Clasificacion("Escombros", "Escombros de demolicion");
            Empresa empresaTest = new Empresa("12 Holdings", TestRubro, "Montevideo", "Plaza Independencia 848");
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
        /// Prueba que se cree una Habiitacion
        /// </summary>
        
        [Test]
        public void TestCrearHabilitacion()
        {
            Clasificacion clasificacionTest = new Clasificacion("Escombros", "Escombros de demolicion");
            Empresa empresaTest = new Empresa("12 Holdings", TestRubro, "Montevideo", "Plaza Independencia 848");
            Habilitacion habilitacionTest = new Habilitacion("DGI", "Permisos del DGI");
            Oferta ofertaTest = new Oferta("Escombros", empresaTest, 3, "Montevideo", "Plaza Independencia 848", true, "Escombros", clasificacionTest, 150, "Kilos", 100);
            ofertaTest.AddHabilitacion(habilitacionTest.Name, habilitacionTest.Descripcion);
            string expectedNombreHabilitacion = "DGI";
            Assert.AreEqual(expectedNombreHabilitacion, habilitacionTest.Name);
            string expectedDescripcionHabilitacion = "Permisos del DGI";
            Assert.AreEqual(expectedDescripcionHabilitacion, habilitacionTest.Descripcion);
        }
        
        /// <summary>
        /// Prueba que se cree el emprendedor
        /// </summary>


        [Test]
        public void TestCrearEmprendedor()
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene",TestRubro,"La perla","Calle 13","madera");
            string expectedNombre = "Rene";
            Assert.AreEqual(expectedNombre,emprendedorTest.Nombre);
            string expectedRubro = "Tecnologia";
            Assert.AreEqual(expectedRubro, emprendedorTest.Rubro.Nombre);
            string expectedCiudad = "La perla";
            Assert.AreEqual(expectedCiudad,emprendedorTest.Ubicacion.Ciudad);
            string expectedCalle = "Calle 13";
            Assert.AreEqual(expectedCalle, emprendedorTest.Ubicacion.Calle);
            string expectedEspezialicacion = "madera";
            Assert.AreEqual(expectedEspezialicacion,emprendedorTest.Especializacion);
        }


        /* REVISAR ESTOS TEST SI SON NECESARIOS !!!!!
        [Test]
        public void TestCrearHabilitacion()
        {
            Habilitacion UNIT9001 = new Habilitacion("UNIT","9001");
            
        }
        [Test]
        public void TestCrearClasificacion()
        {
            
        }*/

        /// <summary>
        /// Prueba que se agruegue una habilitacion a un emprendedor
        /// </summary>

        [Test]

        public void HabilitacionesEmprendedor() 
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene",TestRubro,"La perla","Calle 13","madera");
            emprendedorTest.AddHabilitacion(TestHabilitacion);
            Assert.AreEqual(TestHabilitacion,emprendedorTest.Habilitaciones[0]);
        }

        /// <summary>
        /// Prueba que las excepcioens del constructor funcionen correctamente
        /// </summary>

        [Test]
        public void ThrowNameException()
        {
            Assert.Throws<ArgumentException>(() => new Emprendedor("",TestRubro,"La perla","Calle 13","madera"));
            Assert.Throws<ArgumentNullException>(() => new Emprendedor(null,TestRubro,"La perla","Calle 13","madera"));
        }
        
        /// <summary>
        /// Test de la clase busqueda
        /// </summary>
        [Test] 
        public void TestBusqueda()
        {
            Habilitacion MSP = new Habilitacion("MSP","msp");
            Rubro Rubro = new Rubro("Forestal","Leñeria","Recursos");
            Emprendedor Emprendedor = new Emprendedor("Gaston", Rubro,"San Ramon","Ruta 12", "Emprendimiento");
            Empresa Poyote = new Empresa("Poyote",Rubro,"San Bautista","Ruta 6");
            Clasificacion poyotero = new Clasificacion("Madera","Roble Oscuro");
            Oferta uno = new Oferta("Madera",Poyote,1,"San Bautista","Ruta 6", true, "Madera",poyotero,1,"Kilos",500);
            Contenedor db = Contenedor.Instancia;
            uno.AddHabilitacion(MSP);
            Emprendedor.AddHabilitacion(MSP);
            db.AddOferta(uno);
            Busqueda buscador = Busqueda.Instancia;
            var ResultadoBusqueda = buscador.BuscarOferta(Emprendedor,"Madera",db);
            int Largo = 1;
            
            var ResultadoBusqueda2 = buscador.BuscarOferta(Emprendedor,"Azucar",db);
            int Largo2 = 0;
            Assert.AreEqual(Largo2,ResultadoBusqueda2.Count);
        }
    }
}



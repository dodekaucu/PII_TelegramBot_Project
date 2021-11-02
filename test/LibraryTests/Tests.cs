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
            Busqueda buscador = new Busqueda();
            var coso = buscador.BuscarOferta(Emprendedor,"Madera",db);
            int Largo = 1;
            Assert.AreEqual(Largo,coso.Count);
        }
    }
}



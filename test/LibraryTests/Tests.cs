using NUnit.Framework;
using Library;

namespace Tests
{
    /// <summary>
    /// Pruebas de ?????
    /// </summary>

    [TestFixture]
    public class Test
    {

        /// <summary>
        /// prueba que la Empresa se cree y se le asignen los valores correctos a sus diferentes atributos
        /// </summary>

        [Test]
        public void TestCrearEmpresa()
        {
            Empresa empresaTest = new Empresa("12 Holdings","Inversiones","Montevideo","Plaza Independencia 848");
            string expectedNombre = "12 Holdings";
            Assert.AreEqual(expectedNombre,empresaTest.Nombre);
            string expectedRubro = "Inversiones";
            Assert.AreEqual(expectedRubro, empresaTest.Rubro);
            string expectedCiudad = "Montevideo";
            Assert.AreEqual(expectedCiudad,empresaTest.Ubicacion.Ciudad);
            string expectedCalle = "Plaza Independencia 848";
            Assert.AreEqual(expectedCalle, empresaTest.Ubicacion.Calle);
        }

        /// <summary>
        /// Prueba que el emprendedor se cree y que se le asignen los valores correctos a sus diferentes atributos
        /// </summary>


        [Test]
        public void TestCrearEmprendedor()
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene","Musica","La perla","Calle 13","madera");
            string expectedNombre = "Rene";
            Assert.AreEqual(expectedNombre,emprendedorTest.Nombre);
            string expectedRubro = "Musica";
            Assert.AreEqual(expectedRubro, emprendedorTest.Rubro);
            string expectedCiudad = "La perla";
            Assert.AreEqual(expectedCiudad,emprendedorTest.Ubicacion.Ciudad);
            string expectedCalle = "Calle 13";
            Assert.AreEqual(expectedCalle, emprendedorTest.Ubicacion.Calle);
            string expectedEspezialicacion = "madera";
            Assert.AreEqual(expectedEspezialicacion,emprendedorTest.Especializacion);
        }


        
        [Test]
        public void TestCrearHabilitacion()
        {
            Habilitacion UNIT9001 = new Habilitacion("UNIT","9001");
            
        }
        [Test]
        public void TestCrearClasificacion()
        {
            
        }

        /// <summary>
        /// Prueba 
        /// </summary>

        [Test]

        public void HabilitacionesEmprendedor() //REVISAR
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene","Musica","La perla","Calle 13","madera");
            Habilitacion UNIT9001 = new Habilitacion("UNIT","9001");
            emprendedorTest.AddHabilitacion(UNIT9001);
            Assert.AreEqual(UNIT9001,emprendedorTest.Habilitaciones[0]);
        }

    }

}

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

        /// <summary>
        /// Prueba los metodos AddHabilitacion del emprendedor. Chekea si es correcta la agregacion a la lista
        /// y si las habilitaciones son creadas correctamente en el metodo.
        /// </summary>

        [Test]

        public void HabilitacionesEmprendedor()
        {
            Emprendedor emprendedorTest = new Emprendedor("Rene","Musica","La perla","Calle 13","madera");
            emprendedorTest.AddHabilitacion("UNIT","ISO 9001");
            int expectedLargo = 1;
            Assert.AreEqual(emprendedorTest.Habilitaciones.Count, expectedLargo);
            string expectedHabilitacionNombre = "UNIT";
            Assert.AreEqual(emprendedorTest.Habilitaciones[0].Name, expectedHabilitacionNombre);
            string expectedHabilitacionDescripcion = "ISO 9001";
            Assert.AreEqual(emprendedorTest.Habilitaciones[0].Descripcion,expectedHabilitacionDescripcion);
        }

    }

}

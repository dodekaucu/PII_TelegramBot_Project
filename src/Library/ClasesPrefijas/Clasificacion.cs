
namespace Library
{

    /// <summary>
    /// Esta clase representa una clasificación de un material.
    /// </summary>
    public class Clasificacion
    {

        /// <summary>
        /// Obtiene un valor que indica el nombre de la clasificación.
        /// </summary>
        /// <value></value>
        
        public string Nombre {get;}

        /// <summary>
        /// Obtiene un valor que indica la descripcion de la clasificación.
        /// </summary>
        /// <value></value>
        public string Descripcion {get;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Clasificacion"/>.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>

        public Clasificacion (string nombre, string descripcion)
        {
            this.Nombre=nombre;
            this.Descripcion = descripcion;
        }
    }
}

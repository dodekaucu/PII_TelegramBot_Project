namespace Library
{

    /// <summary>
    /// Esta clase representa una Habilitacion basica
    /// </summary>
    
    public class Habilitacion
    {

        /// <summary>
        /// Obtiene un valor que indica el nombre de la habilitacion
        /// </summary>
        /// <value></value>
        
        public string Name {get;}

        /// <summary>
        /// Obtiene un valor que indica la descripcion de la habilitacion
        /// </summary>
        /// <value></value>
        
        public string Descripcion {get;}

        /// <summary>
        /// Inicializa una nueva instancia de la clase Habilitacion
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descripcion"></param>

        public Habilitacion(string name, string descripcion)
        {
            this.Name = name;
            this.Descripcion = descripcion;
        }
    }
}
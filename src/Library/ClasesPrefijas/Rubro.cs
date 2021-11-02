namespace Library
{
    /// <summary>
    /// Clase que representa los rubros
    /// </summary>
    public class Rubro
    {
        public string nombre;
        public string area;
        public string descripcion;


        /// <summary>
        /// Inicializa una instancia de la clase Rubro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="area"></param>
        /// <param name="descripcion"></param>

        public Rubro(string nombre, string area, string descripcion)
        {
            this.nombre = nombre;
            this.area = area;
            this.descripcion = descripcion;
        }

        /// <summary>
        /// Devuelve un valor que indica el nombre del rubro
        /// </summary>
        /// <value></value>

        public string Nombre {
            get
            {
                return this.nombre;
            }
        }

        /// <summary>
        /// Devuelve un valor que indica el area del rubro
        /// </summary>
        /// <value></value>
        
        public string Area {
            get
            {
                return this.area;
            }
        }

        /// <summary>
        /// Devuelve un valor que indica la descripcion del rubro
        /// </summary>
        /// <value></value>

        public string Descripcion {
            get
            {
                return this.descripcion;
            }
        }
    }
}
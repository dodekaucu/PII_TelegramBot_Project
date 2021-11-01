using System
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

        public Rubro(string nombre, string area, string descripcion)
        {
            this.nombre = nombre;
            this.area = area;
            this.descripcion = descripcion;
        }
        public string Nombre {
            get
            {
                return this.nombre;
            }
        }
        public string Area {
            get
            {
                return this.area;
            }
        }
        public string Descripcion {
            get
            {
                return this.descripcion;
            }
        }
    }
}
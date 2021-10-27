namespace Library
{

    /// <summary>
    /// Esta clase representa una Habilitacion basica
    /// </summary>
    public class Habilitacion
    {
        /// <summary>
        /// Esta variable del tipo string  representa el nombre de la Habilitacion
        /// </summary>
        /// <value></value>
        public string Name {get;}

        /// <summary>
        /// Esta variable del tipo string
        /// </summary>
        /// <value></value>
        public string Descripcion {get;}

        /// <summary>
        /// Metodo constructor de la Habilitacion
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
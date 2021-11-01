namespace Library
{
    /// <summary>
    /// Esta clase representa una ubicacion
    /// </summary>
    public class Ubicacion
    {
        /// <summary>
        /// variable del tipo string que representa la Ciudad de la Ubicacion
        /// </summary>
        /// <value></value>
        public string Ciudad {get; set;}

        /// <summary>
        /// variable del tipo string que represneta la ciudad
        /// </summary>
        /// <value></value>
        public string Calle {get; set;}

        /// <summary>
        /// Metodo constructor de Ubicacion, recibe dos string.
        /// </summary>
        /// <param name="ciudad"></param>
        /// <param name="calle"></param>
        public Ubicacion (string ciudad, string calle)
        {
            this.Ciudad= ciudad;
            this.Calle = calle;
        }
    }
}
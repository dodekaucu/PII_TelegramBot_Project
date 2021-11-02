namespace Library
{

    /// <summary>
    /// Esta clase representa un Administrador de la aplicacion
    /// </summary>
    
    public class Admin
    {
        /// <summary>
        /// Obtiene un valor que indica el nombre del usuario
        /// </summary>
        /// <value></value>
        public string Nombre { get; set; }

        /// <summary>
        /// Inicializa una instancia de la clase Admin
        /// </summary>
        /// <param name="nombre"></param>

        public Admin(string nombre)
        {
            this.Nombre = nombre;
        }

        /// <summary>
        /// 
        /// </summary>

        public void InvitarEmpresa()
        {
            // Invitar a una empresa a unirse a la plataforma
        }
    }
}
namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/ayuda".
    /// </summary>
    public class HelpHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelpHandler"/>. Esta clase procesa el comando "/ayuda".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public HelpHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/ayuda"};
        }

        /// <summary>
        /// Procesa el comando "/ayuda" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (this.CanHandle(message))
            {
                response = "Los comandos soportados por el bot son:\n/start ´Para saber que rol tienes´.\n/invitar (ID) ´Comando solo para administradores, manda una invitacion a una empresa con el ID asociado´.\n/AñadirAdmin (ID) ´Añade una ID como admin´.\n/Buscar (Palabra clave) ´Busca en la lista de ofertas las que tengan la misma palabra clave´.\n/BuscarUbicacion (Ciudad,Calle) ´Busca ofertas cerca de tu ubicacion´.\n/historialDesde (xx/xx/xxxx) ´Te muestra una lista de ofertas de una empresa desde la fecha estipulada´.\n/BClasificacion (Clasificacion) ´Busca en el registro de Ofertas las que tengan la clasificacion deseada´.\n/Registro ´Despliega los pasos a seguir para poder registrarse como emprendedor/empresa respectivamente´.\n/PublicarOferta ´Despliega los pasos a seguir para crear una Oferta´, comando solo para empresas.\n/Cancel ´Termina cualquier proceso que se este llevando acabo´.\n/AddHabilitacion ´Agrega una habilitacion a una Oferta´.\n/Invitar (ID)";
                return true;
            }

            response = string.Empty;
            return false;
        }
    }
}
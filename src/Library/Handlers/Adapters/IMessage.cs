namespace Handlers
{
    /// <summary>
    /// Interfaz de mensajes.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Id del usuario.
        /// </summary>
        string ID { get;}

        /// <summary>
        /// Mensaje.
        /// </summary>
        string Text { get;}
    }
}

//--------------------------------------------------------------------------------
// <copyright file="IChat.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Interface que representa la firma de los metodos de IChat. Se utiliza una interface, pues la idea
    /// detras es poseer una interfaz que posea todos los metodos que se necesitan para el funcionamiento 
    /// de un chat, pero a su vez que la clase que dependa de esta interfaz no este forzada a implmenetarlos 
    /// de una manera determinada impidiendo asi que sea necesario modificar cualquier clase del tipo IChat
    /// dependiendo de las necesidades del usuario.
    /// </summary>
    public interface IChat
    {
        /// <summary>
        /// Envia un mensaje al usuario.
        /// </summary>
        /// <param name="mensaje">parametro mensaje que envia al usuario.</param>
        void EnviarMensaje(string mensaje);

        /// <summary>
        /// Recibe el mensaje del usuario.
        /// </summary>
        void RecibirMensaje();
    }
}
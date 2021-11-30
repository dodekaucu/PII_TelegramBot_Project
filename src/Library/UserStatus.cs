using System.Collections.Generic;

namespace Library
{
    //LA IDEA ES QUE GUARDE EL ULTIMO STATUS QUE UTILIZO UN USUARIO
    public class StatusManager
    {
        private static StatusManager statusManager;

        private Dictionary<string,string> userStatusChat = new Dictionary<string,string> ();

        private StatusManager()
        {
        }

        public static StatusManager Instancia
        {
            get
            {
                if(statusManager == null)
                {
                    statusManager= new StatusManager();
                }
                return statusManager;
            }
        }
        /// <summary>
        /// Obtiene el diccionario de usuarios y su status.
        /// </summary>
        /// <value></value>

        public Dictionary<string,string> UserStatusChat
        {
            get{
                return this.userStatusChat;
            }
        }

        /// <summary>
        /// Añade el usuario al diccionario de status pero sin status.
        /// </summary>
        /// <param name="ID">ID del usuario.</param>
        public void AddKeyUser(string ID)
        {
            this.userStatusChat.Add(ID,"");
        }

        /// <summary>
        /// Añade el status del usuario al diccionario.
        /// </summary>
        /// <param name="ID">ID del usuario.</param>
        /// <param name="status">Status del usuario.</param>
        public void AddUserStatus(string ID, string status)
        {
            this.userStatusChat[ID]=status;
        }
    }
}
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

        public Dictionary<string,string> UserStatusChat
        {
            get{
                return this.userStatusChat;
            }
        }

        public void AddKeyUser(string ID)
        {
            this.userStatusChat.Add(ID,"");
        }

        public void AddUserStatus(string ID, string status)
        {
            this.userStatusChat[ID]=status;
        }
    }
}
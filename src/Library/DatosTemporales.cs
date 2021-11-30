//--------------------------------------------------------------------------------
// <copyright file="DatosTemporales.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Library
{
    /// <summary>
    /// Datos temporales del usuario.
    /// </summary>
    public class DatosTemporales
    {
        private static DatosTemporales estadoConversacion;

        private Dictionary<string,Collection<string>> dataTemporal = new Dictionary<string,Collection<string>> () ;

        private DatosTemporales()
        {
        }

        /// <summary>
        /// Singleton datos.
        /// </summary>
        /// <value></value>

        public static DatosTemporales Instancia
        {
            get
            {
                if (estadoConversacion == null)
                {
                    estadoConversacion = new DatosTemporales();
                }

                return estadoConversacion;
            }
        }

        /// <summary>
        /// Data temp.
        /// </summary>
        /// <value></value>

        public Dictionary <string,Collection<string>> DataTemporal{
            get{
                return this.dataTemporal;
            }
        }

        /// <summary>
        /// Add key.
        /// </summary>
        /// <param name="ID"></param>
        public void AddKeyUser(string ID)
        {
            this.dataTemporal.Add(ID, new Collection<string>());
        }

        /// <summary>
        /// Add dato.
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="dato"></param>
        public void AddDato(string chatId, string dato)
        {
            dataTemporal[chatId].Add(dato);
        }
        /// <summary>
        /// Remove dato.
        /// </summary>
        /// <param name="chatId"></param>
        /// <param name="dato"></param>

        public void RemoveDato(string chatId, string dato)
        {
            dataTemporal[chatId].Remove(dato);
        }
    }
}
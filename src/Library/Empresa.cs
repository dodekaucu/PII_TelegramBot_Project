using System;

namespace Library
{
    /// <summary>
    /// Clase que representa una Empresa, Hereda 
    /// </summary>
    public class Empresa : Usuario
    {
        /// <summary>
        /// Metodo constructor de la empresa
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="rubro"></param>
        /// <param name="ciudad"></param>
        /// <param name="calle"></param>
        /// <returns></returns>
        public Empresa(string nombre, string rubro, string ciudad, string calle) :
        base(nombre,rubro,ciudad,calle)
        {
        }

        //falta el aceptar invitacion.
    }
}
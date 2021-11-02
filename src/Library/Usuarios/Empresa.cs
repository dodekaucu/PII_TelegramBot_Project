using System;

namespace Library
{
    /// <summary>
    /// Clase que representa una Empresa
    /// </summary>
    public class Empresa : Usuario
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Empresa"/>.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="rubro"></param>
        /// <param name="ciudad"></param>
        /// <param name="calle"></param>
        /// <returns></returns>

        public Empresa(string nombre, Rubro rubro, string ciudad, string calle) :
        base(nombre,rubro,ciudad,calle)
        {
        }
        
    }
}
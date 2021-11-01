using System;
using System.Collections.Generic;

namespace Library
{
    class Busqueda
    {

        private List<Oferta> listaOfertas = new List<Oferta>();  

        public List<Oferta> ListaOfertas 
        {
            get{
                return this.listaOfertas;
            }
            set{
                this.listaOfertas=value;
            }
        }

        /// <summary>
        /// La función para buscar ofertas reciben un string con las palabras a buscar y
        /// revisa cada oferta para ver si las palabras claves coinciden.
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// 
        /// Base de datos queda así porque aun no sabemos como funciona.
        /// </summary>
        public Busqueda(string Mensaje)
        {
            foreach (Oferta Oferta in BaseDeDatos)
            {
                if (Oferta.PalabrasClaves.Contains(Mensaje))
                {
                    ListaOfertas.Add(Oferta);
                }
            } 
        }

        /// <summary>
        /// En este caso la funcion busqueda recibe la ubicación en la que se quiere buscar
        /// revisa cada oferta para ver si la ubicacion coincide con ubicación buscada 
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// 
        /// Base de datos queda así porque aun no sabemos como funciona.
        /// </summary>
        public Busqueda(Ubicacion ubicacion)
        {
            foreach (Oferta Oferta in BaseDeDatos)
            {
                if (Oferta.Ubicacion == ubicacion)
                {
                    ListaOfertas.Add(Oferta);
                }
            } 
        }

        /// <summary>
        /// En este caso la funcion busqueda recibe clasificacion del material
        /// revisa la clasificacion de los materiales de cada oferta para ver si son iguales
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// 
        /// Base de datos queda así porque aun no sabemos como funciona.
        /// </summary>
        public Busqueda(Clasificacion clasificacion)
        {
            foreach (Oferta Oferta in BaseDeDatos)
            {
                if (Oferta.Material.Clasificacion == clasificacion)
                {
                    ListaOfertas.Add(Oferta);
                }
            } 
        }
    }
}
using System;
using System.Collections.Generic;

namespace Library
{
    class Busqueda
    {

        public Busqueda()
        {
        }

        /// <summary>
        /// La función para buscar ofertas reciben un string con las palabras a buscar y
        /// revisa cada oferta para ver si las palabras claves coinciden.
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// 
        /// Contenedor basededatos se usa como una db temporal 
        /// </summary>
        public List<Oferta> BuscarOferta(string Mensaje, Contenedor basededatos)
        {
            List<Oferta> ListaOfertas = new List<Oferta>();
            foreach (Oferta Oferta in basededatos.Ofertas)
            {
                if (Oferta.PalabrasClaves.Contains(Mensaje))
                {
                    ListaOfertas.Add(Oferta);
                }
            }
            return ListaOfertas;
        }

        /// <summary>
        /// En este caso la funcion busqueda recibe la ubicación en la que se quiere buscar
        /// revisa cada oferta para ver si la ubicacion coincide con ubicación buscada 
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// 
        /// Contenedor basededatos se usa como una db temporal
        /// </summary>
        public List<Oferta> BuscarOferta(Ubicacion ubicacion, Contenedor basededatos)
        {
            List<Oferta> ListaOfertas = new List<Oferta>();
            foreach (Oferta Oferta in basededatos.Ofertas)
            {
                if (Oferta.Ubicacion == ubicacion)
                {
                    ListaOfertas.Add(Oferta);
                }
            } 
            return ListaOfertas;
        }

        /// <summary>
        /// En este caso la funcion busqueda recibe clasificacion del material
        /// revisa la clasificacion de los materiales de cada oferta para ver si son iguales
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// 
        /// Contenedor basededatos se usa como una db temporal
        /// </summary>
        public List<Oferta> BuscarOferta(Clasificacion clasificacion, Contenedor basededatos)
        {
            List<Oferta> ListaOfertas = new List<Oferta>();
            foreach (Oferta Oferta in basededatos.Ofertas)
            {
                if (Oferta.Material.Clasificacion == clasificacion)
                {
                    ListaOfertas.Add(Oferta);
                }
            }
            return ListaOfertas;
        }
    }
}
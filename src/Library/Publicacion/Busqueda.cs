using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase busqueda. 
    /// </summary>
    public class Busqueda
    {

        public Busqueda()
        {
        }

        /// <summary>
        /// La función para buscar ofertas reciben un string con las palabras a buscar y
        /// revisa cada oferta para ver si las palabras claves coinciden.
        /// Luego comprueba si el emprendedor tiene las habilitaciones necesarias para acceder a la oferta.
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// 
        /// Contenedor basededatos se usa como una db temporal 
        /// </summary>
        public List<Oferta> BuscarOferta(Emprendedor emprendedor, string Mensaje, Contenedor basededatos)
        {
            List<Oferta> ListaOfertas = new List<Oferta>();
            bool valido = true; 
            foreach (Oferta Oferta in basededatos.Ofertas)
            {
                if (Oferta.PalabrasClaves.Contains(Mensaje))
                {
                    foreach (Habilitacion habilitacion in Oferta.Habilitaciones)
                    {
                        if(emprendedor.Habilitaciones.Contains(habilitacion))
                        {
                        }
                        else{
                            valido = false;
                        }
                    }
                    if (valido == true)
                    {ListaOfertas.Add(Oferta);}
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
        public List<Oferta> BuscarOferta(Emprendedor emprendedor,Ubicacion ubicacion, Contenedor basededatos)
        {
            List<Oferta> ListaOfertas = new List<Oferta>();
            bool valido = true; 
            foreach (Oferta Oferta in basededatos.Ofertas)
            {
                if (Oferta.Ubicacion == ubicacion)
                {
                    foreach (Habilitacion habilitacion in Oferta.Habilitaciones)
                    {
                        if(emprendedor.Habilitaciones.Contains(habilitacion))
                        {
                        }
                        else{
                            valido = false;
                        }
                    }
                    if (valido == true)
                    {ListaOfertas.Add(Oferta);}
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
        public List<Oferta> BuscarOferta(Emprendedor emprendedor, Clasificacion clasificacion, Contenedor basededatos)
        {
            List<Oferta> ListaOfertas = new List<Oferta>();
            bool valido = true; 
            foreach (Oferta Oferta in basededatos.Ofertas)
            {
                if (Oferta.Material.Clasificacion == clasificacion)
                {
                    foreach (Habilitacion habilitacion in Oferta.Habilitaciones)
                    {
                        if(emprendedor.Habilitaciones.Contains(habilitacion))
                        {
                        }
                        else{
                            valido = false;
                        }
                    }
                    if (valido == true)
                    {ListaOfertas.Add(Oferta);}
                }
            }
            return ListaOfertas;
        }
    }
}

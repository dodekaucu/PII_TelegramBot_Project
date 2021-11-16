//--------------------------------------------------------------------------------
// <copyright file="Busqueda.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    /// <summary>
    /// Esta clase representa la busqueda de ofertas a partir de palabras claves, ubicacion y clasificacion.
    /// Se utilzia el principio SRP, donde la unica razon para cambiar de la clase es que se modifique la forma en que se busca la informacion.
    /// Ademas se usa el patron Singleton pues solo se debe tener una instancia de esta clase.
    /// </summary>
    public class Busqueda
    {
        private static Busqueda busqueda;

        private Busqueda()
        {
        }

        /// <summary>
        /// Obtiene una instancia de la clase Busqueda y si no existe una, crea una nueva.
        /// </summary>
        /// <value>una instancia de busqueda.</value>
        public static Busqueda Instancia
        {
            get
            {
                if (busqueda == null)
                {
                    busqueda = new Busqueda();
                }

                return busqueda;
            }
        }

        /// <summary>
        /// La función para buscar ofertas reciben un string con las palabras a buscar y
        /// revisa cada oferta para ver si las palabras claves coinciden.
        /// Luego comprueba si el emprendedor tiene las habilitaciones necesarias para acceder a la oferta.
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// Contenedor basededatos se usa como una db temporal.
        /// </summary>
        /// <param name="emprendedor">Es el usuario que busca las ofertas.</param>
        /// <param name="mensaje">Son las palabras claves que busca el emprendedor.</param>
        /// <param name="basededatos">Es la base de datos donde se buscan las ofertas disponibles.</param>
        /// <returns>Lista de ofertas que cumplen con los requisitos.</returns>
        public Collection<OfertaBase> BuscarOferta(Emprendedor emprendedor, string mensaje, Contenedor basededatos)
        {
            Collection<OfertaBase> listaOfertas = new Collection<OfertaBase>();
            bool valido = true;
            mensaje = mensaje.ToLower();
            foreach (Oferta oferta in basededatos.Ofertas)
            {
                if (oferta.PalabrasClaves.Contains(mensaje))
                {
                    if (oferta.Habilitaciones.Count >= 1)
                    {
                        foreach (Habilitacion habilitacion in oferta.Habilitaciones)
                        {
                            if (emprendedor.Habilitaciones.Contains(habilitacion))
                            {
                            }
                            else
                            {
                                valido = false;
                            }
                        }

                        if (valido == true)
                        {
                            listaOfertas.Add(oferta);
                        }
                    }
                    else
                    {
                        listaOfertas.Add(oferta);
                    }
                }
            }

            return listaOfertas;
        }

        /// <summary>
        /// En este caso la funcion busqueda recibe la ubicación en la que se quiere buscar.
        /// revisa cada oferta para ver si la ubicacion coincide con ubicación buscada.
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// Contenedor basededatos se usa como una db temporal.
        /// </summary>
        /// <param name="emprendedor">Es el usuario que busca las ofertas.</param>
        /// <param name="ubicacion">Ubicacion buscada por el emprendedor.</param>
        /// <param name="basededatos">Es la base de datos donde se buscan las ofertas disponibles.</param>
        /// <returns>Lista de ofertas que cumplen con los requisitos.</returns>
        public Collection<OfertaBase> BuscarOferta(Emprendedor emprendedor, Ubicacion ubicacion, Contenedor basededatos)
        {
            Collection<OfertaBase> listaOfertas = new Collection<OfertaBase>();
            bool valido = true;
            foreach (Oferta oferta in basededatos.Ofertas)
            {
                if (String.Equals(oferta.Ubicacion.Ciudad, ubicacion.Ciudad, StringComparison.OrdinalIgnoreCase))
                {
                    if (String.Equals(oferta.Ubicacion.Calle, ubicacion.Calle, StringComparison.OrdinalIgnoreCase))
                    {
                        if (oferta.Habilitaciones.Count >= 1)
                        {
                            foreach (Habilitacion habilitacion in oferta.Habilitaciones)
                            {
                                if (emprendedor.Habilitaciones.Contains(habilitacion))
                                {
                                }
                                else
                                {
                                    valido = false;
                                }
                            }

                            if (valido == true)
                            {
                                listaOfertas.Add(oferta);
                            }
                        }
                        else
                        {
                            listaOfertas.Add(oferta);
                        }
                    }
                    else
                    {
                        valido = false;
                    }
                }
                else
                {
                    valido = false;
                }
            }

            return listaOfertas;
        }

        /// <summary>
        /// En este caso la funcion busqueda recibe clasificacion del material.
        /// revisa la clasificacion de los materiales de cada oferta para ver si son iguales.
        /// Retornando una lista temporal para que el usuario reciba solo las ofertas que coincidan.
        /// Contenedor basededatos se usa como una db temporal.
        /// </summary>
        /// <param name="emprendedor">Es el usuario que busca las ofertas.</param>
        /// <param name="clasificacion">Clasificacion buscada por el emprendedor.</param>
        /// <param name="basededatos">Es la base de datos donde se buscan las ofertas disponibles.</param>
        /// <returns>Lista de ofertas que cumplen con los requisitos.</returns>
        public Collection<OfertaBase> BuscarOferta(Emprendedor emprendedor, Clasificacion clasificacion, Contenedor basededatos)
        {
            Collection<OfertaBase> listaOfertas = new Collection<OfertaBase>();
            bool valido = true;
            foreach (Oferta oferta in basededatos.Ofertas)
            {
                if (String.Equals(oferta.Material.Clasificacion.Nombre, clasificacion.Nombre, StringComparison.OrdinalIgnoreCase))
                {
                    if (oferta.Habilitaciones.Count >= 1)
                    {
                        foreach (Habilitacion habilitacion in oferta.Habilitaciones)
                        {
                            if (emprendedor.Habilitaciones.Contains(habilitacion))
                            {
                            }
                            else
                            {
                                valido = false;
                            }
                        }

                        if (valido == true)
                        {
                            listaOfertas.Add(oferta);
                        }
                    }
                    else
                    {
                        listaOfertas.Add(oferta);
                    }
                }
                else
                {
                    valido = false;
                }
            }

            return listaOfertas;
        }
    }
}
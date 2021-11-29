using System;
using Library;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Handlers
{
    /// <summary>
    /// Clase impresora, se encarga de hacer un string con las ofertas que cumplen con los requisitos de la busqueda.
    /// </summary>
    public class Impresora
    {
        /// <summary>
        /// Texto que se va a imprimir.
        /// </summary>
        public string texto;

        private static Impresora impresora;

        private Impresora()
        {
        }

        /// <summary>
        /// Obtiene una instancia de la clase impresora y si no existe una, crea una nueva.
        /// </summary>
        /// <value>una instancia de impresora.</value>

        public static Impresora Instancia
        {
            get
            {
                if (impresora == null)
                {
                    impresora = new Impresora();
                }

                return impresora;
            }
        }

        /// <summary>
        /// Funcion que recibe la lista de ofertas para imprimir.
        /// </summary>
        /// <param name="lista">lista buscada.</param>
        /// <returns></returns>
        public string Imprimir(Collection<OfertaBase> lista)
        {  
            if (lista.Count == 0)
            {
                texto = "No hay ofertas disponibles";
            }
            else
            {
                texto = "OFERTAS DISPONIBLES: \n";
                foreach (OfertaBase oferta in lista)
                {
                texto += "\n";
                texto += "Nombre: " + oferta.Nombreoferta + "\n";
                texto += "Material: " + oferta.Material.Nombre + "\n";
                texto += "Cantidad: " + oferta.Material.Cantidad +" "+oferta.Material.Unidad + "\n";
                texto += "Precio: $" + oferta.Material.Valor + "\n";
                texto += "Identificador: " + oferta.Identificador + "\n";
                texto += "Vendedor: " + oferta.Empresa.Nombre + "\n";
                texto += "Telefono de contacto: "+ oferta.Empresa.Telefono + "\n";
                texto += "Id de la oferta: " + oferta.Identificador + "\n";
                texto += "\n";
                texto += "---------------------------------------" + "\n";
                }   
            }
            return texto;
        }
    }
}
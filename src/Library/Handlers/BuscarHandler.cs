using System;
using Library;
using System.Collections.Generic;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class BuscarHandler : BaseHandler
    {
        /// <summary>
        /// El usuario que busca ofertas.
        /// </summary>
        public Emprendedor emprendedor;

        private Impresora impresora;

        /// <summary>
        /// base de datos.
        /// </summary>
        public Contenedor db;
        /// <summary>
        /// Buscador de ofertas.
        /// </summary>
        public Busqueda buscador;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BuscarHandler"/>. Esta clase procesa el mensaje "chau"
        /// y el mensaje "adiós" -un ejemplo de cómo un "handler" puede procesar comandos con sinónimos.
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BuscarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/buscar" };
        }

        /// <summary>
        /// Procesa el mensaje "chau" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="ID">El ID del usuario.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, IMessage ID, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            Busqueda buscador = Busqueda.Instancia;
            Impresora impresora = Impresora.Instancia;
            if (this.CanHandle(message, ID))
            {
                if (db.Emprendedores.ContainsKey(message.ID.ToString()))
                {
                    string busca = message.Text.Remove(0,7);
                    string emprend = message.ID.ToString();
                    string OfertasValidas = impresora.Imprimir(buscador.BuscarOferta(db.Emprendedores[emprend],busca.Trim(),db));
                    response = $"{OfertasValidas}";
                    return true;
                }
                else
                {
                    response = "No estas registrado como emprendedor";
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}
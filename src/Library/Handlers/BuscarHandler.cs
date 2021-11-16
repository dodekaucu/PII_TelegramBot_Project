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
        /// <param name="emprendedor">El emprendedor.</param>
        /// <param name="db">El contenedor de datos.</param>
        /// <param name="buscador">El buscador.</param>
        public BuscarHandler(BaseHandler next, Busqueda buscador, Emprendedor emprendedor, Contenedor db) : base(next)
        {
            this.Keywords = new string[] { "/buscar" };
            this.emprendedor = emprendedor;
            this.db = db;
            this.buscador = buscador;
        }

        /// <summary>
        /// Procesa el mensaje "chau" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            if (this.CanHandle(message))
            {
                string busca = message.Text.Remove(0,7);
                char[] inicio = {' '};
                this.impresora = Impresora.Instancia;
                string OfertasValidas = impresora.Imprimir(this.buscador.BuscarOferta(this.emprendedor,busca.TrimStart(inicio),this.db));
                response = $"{OfertasValidas}";
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}
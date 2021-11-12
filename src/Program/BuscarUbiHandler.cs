using System;
using Telegram.Bot.Types;
using Library;
using System.Collections.Generic;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class BuscarUbiHandler : BaseHandler
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
        public BuscarUbiHandler(BaseHandler next, Busqueda buscador, Emprendedor emprendedor, Contenedor db) : base(next)
        {
            this.Keywords = new string[] { "/buscarubicacion" };
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
                string busca = message.Text.Remove(0,16);
                char[] inicio = {' '};
                string[] ubicacion = busca.Split(',');
                this.impresora = Impresora.Instancia;
                Ubicacion ubicacionbuscar = new Ubicacion(ubicacion[0].TrimStart(inicio), ubicacion[1].TrimStart(inicio));
                string coso = impresora.Imprimir(this.buscador.BuscarOferta(this.emprendedor,ubicacionbuscar,this.db));
                response = $"{coso}";
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}
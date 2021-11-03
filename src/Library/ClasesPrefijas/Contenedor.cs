//--------------------------------------------------------------------------------
// <copyright file="Contenedor.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa un contenedor de las diferentes clases del bot.
    /// </summary>
    public class Contenedor
    {
        private static Contenedor contenedor;
        private List<Habilitacion> habilitaciones = new List<Habilitacion>();
        private List<Rubro> rubros = new List<Rubro>();
        private List<Clasificacion> clasificaciones = new List<Clasificacion>();
        private List<Oferta> ofertas = new List<Oferta>();
        private List<Emprendedor> emprendedores = new List<Emprendedor>();
        private List<Empresa> empresas = new List<Empresa>();

        private Contenedor()
        {
        }

        /// <summary>
        /// Obtiene una instancia de la clase Contenedor y si no existe la crea.
        /// </summary>
        /// <value>this.contenedor.</value>
        public static Contenedor Instancia
        {
            get
            {
                if (contenedor == null)
                {
                    contenedor = new Contenedor();
                }

                return contenedor;
            }
        }

        /// <summary>
        /// Devuelve un valor con la habilitacion correspondiente.
        /// </summary>
        /// <value>this.habilitaciones.</value>
        public List<Habilitacion> Habilitaciones
        {
            get
            {
                return this.habilitaciones;
            }
        }

        /// <summary>
        /// Devuelve un valor con la lista de rubros.
        /// </summary>
        /// <value>this.rubros.</value>
        public List<Rubro> Rubros
        {
            get
            {
                return this.rubros;
            }
        }

        /// <summary>
        /// Devuelve un valor con la lista de clasificaciones.
        /// </summary>
        /// <value>this.clasificaciones.</value>
        public List<Clasificacion> Clasificaciones
        {
            get
            {
                return this.clasificaciones;
            }
        }

        /// <summary>
        /// Devuelve un valor con la lista de las ofertas.
        /// </summary>
        /// <value>this.ofertas.</value>
        public List<Oferta> Ofertas
        {
            get
            {
                return this.ofertas;
            }
        }

        /// <summary>
        /// Devuelve un valor con la lista de los Emprendedores.
        /// </summary>
        /// <value>this.emprendedores.</value>
        public List<Emprendedor> Emprendedores
        {
            get
            {
                return this.emprendedores;
            }
        }

        /// <summary>
        /// Devuelve un valro con la lsita de las Empresas.
        /// </summary>
        /// <value>this.empresas.</value>
        public List<Empresa> Empresas
        {
            get
            {
                return this.empresas;
            }
        }

        /// <summary>
        /// Añiade una habilitacion a la lista de habilitaciones.
        /// </summary>
        /// <param name="habilitacion">parametro habilitacion que recibe AddHabilitacion.</param>
        public void AddHabilitacion(Habilitacion habilitacion)
        {
            this.habilitaciones.Add(habilitacion);
        }

        /// <summary>
        /// Remueve una habilitacion de la lista de habilitaciones.
        /// </summary>
        /// <param name="habilitacion">parametro habilitacion que recibe RemoveHabilitacion.</param>
        public void RemoveHabiltiacion(Habilitacion habilitacion)
        {
            this.habilitaciones.Remove(habilitacion);
        }

        /// <summary>
        /// Añiade un rubro a la lista de rubros.
        /// </summary>
        /// <param name="rubro">parametro rubro que recibe RemoveRubro.</param>
        public void AddRubro(Rubro rubro)
        {
            this.rubros.Add(rubro);
        }

        /// <summary>
        /// Remueve un rubro de la lista de rubros.
        /// </summary>
        /// <param name="rubro">parametro rubro que recibe RemoveRubro.</param>
        public void RemoveRubro(Rubro rubro)
        {
            this.rubros.Remove(rubro);
        }

        /// <summary>
        /// Añiade una clasificacion a la lista de clasificaciones.
        /// </summary>
        /// <param name="clasificacion">parametro clasificacion que recibe AddClasificacion.</param>
        public void AddClasificacion(Clasificacion clasificacion)
        {
            this.clasificaciones.Add(clasificacion);
        }

        /// <summary>
        /// Remueve una clasificacion de la lista de clasificaciones.
        /// </summary>
        /// <param name="clasificacion">parametro clasificacion que recibe Removelasificacion.</param>
        public void RemoveClasificacion(Clasificacion clasificacion)
        {
            this.clasificaciones.Remove(clasificacion);
        }

        /// <summary>
        /// Añiade una oferta a la lista de ofertas.
        /// </summary>
        /// <param name="oferta">parametro oferta recibido por el metodo AddOferta.</param>
        public void AddOferta(Oferta oferta)
        {
            this.ofertas.Add(oferta);
        }

        /// <summary>
        /// Remueve una oferta de la lista de ofertas.
        /// </summary>
        /// <param name="oferta">parametro oferta recibido por el metodo RemoveOferta.</param>
        public void RemoveOferta(Oferta oferta)
        {
            this.ofertas.Remove(oferta);
        }

        /// <summary>
        /// Agrega un Emprendedor a la lista de emprendedores.
        /// </summary>
        /// <param name="emprendedor">parametro oferta recibido por el metodo RemoverOferta.</param>
        public void AddEmprendedor(Emprendedor emprendedor)
        {
            this.emprendedores.Add(emprendedor);
        }

        /// <summary>
        /// Remueve un emprendedor de la lista de emprendedores.
        /// </summary>
        /// <param name="emprendedor">parametro emprendedor recibido por el metodo RemoverEmprendedor.</param>
        public void RemoveEmprendedor(Emprendedor emprendedor)
        {
            this.emprendedores.Remove(emprendedor);
        }

        /// <summary>
        /// Añiade una empresa a la lista de empresas.
        /// </summary>
        /// <param name="empresa">parametro empresa recibido por el metodo AgregarEmpresa.</param>
        public void AddEmpresa(Empresa empresa)
        {
            this.empresas.Add(empresa);
        }

        /// <summary>
        /// Remueve una empresa de la lista de empresas.
        /// </summary>
        /// <param name="empresa">parametro empresa recibido por el metodo RemoveEmpresa.</param>
        public void RemoveEmpresa(Empresa empresa)
        {
            this.empresas.Remove(empresa);
        }
    }
}
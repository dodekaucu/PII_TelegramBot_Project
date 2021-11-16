//--------------------------------------------------------------------------------
// <copyright file="Contenedor.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    /// <summary>
    /// Esta clase representa un contenedor de las diferentes clases del bot.
    /// Utilzia el patron de diseño Singleton. Pues solo se puede tener una instancia de esta clase.
    /// Es la clase EXPERTA en contener las diferentes instancias del programa.
    /// Ademas se cumple SRP pues su unica razon para cambiar es que se cambie la forma de almacenar las instancias.
    /// </summary>
    public class Contenedor
    {
        private static Contenedor contenedor;
        private Collection<Habilitacion> habilitaciones = new Collection<Habilitacion>();
        private Collection<Rubro> rubros = new Collection<Rubro>();
        private Collection<Clasificacion> clasificaciones = new Collection<Clasificacion>();
        private Collection<OfertaBase> ofertas = new Collection<OfertaBase>();
        private Dictionary<string,Emprendedor> emprendedores = new Dictionary<string, Emprendedor>();
        private Dictionary<string,Empresa> empresas = new Dictionary<string,Empresa>();

        private Collection<string> administradores = new Collection<string>() { "1454175798" };

        private Collection<string> invitados = new Collection<string> ();

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
        /// Obtiene un valor con la habilitacion correspondiente.
        /// </summary>
        /// <value>this.habilitaciones.</value>
        public Collection<Habilitacion> Habilitaciones
        {
            get
            {
                return this.habilitaciones;
            }
        }

        /// <summary>
        /// Obtiene un valor con la lista de rubros.
        /// </summary>
        /// <value>this.rubros.</value>
        public Collection<Rubro> Rubros
        {
            get
            {
                return this.rubros;
            }
        }

        /// <summary>
        /// Obtiene un valor con la lista de clasificaciones.
        /// </summary>
        /// <value>this.clasificaciones.</value>
        public Collection<Clasificacion> Clasificaciones
        {
            get
            {
                return this.clasificaciones;
            }
        }

        /// <summary>
        /// Obtiene un valor con la lista de las ofertas.
        /// </summary>
        /// <value>this.ofertas.</value>
        public Collection<OfertaBase> Ofertas
        {
            get
            {
                return this.ofertas;
            }
        }

        /// <summary>
        /// Obtiene un valor con la lista de los Emprendedores.
        /// </summary>
        /// <value>this.emprendedores.</value>
        public Dictionary<string,Emprendedor> Emprendedores
        {
            get
            {
                return this.emprendedores;
            }
        }

        /// <summary>
        /// Obtiene un valro con la lsita de las Empresas.
        /// </summary>
        /// <value>this.empresas.</value>
        public Dictionary<string,Empresa> Empresas
        {
            get
            {
                return this.empresas;
            }
        }

        public Collection<string> Invitados
        {
            get
            {
                return this.invitados;
            }
        }

        public Collection<string> Administradores
        {
            get
            {
                return this.administradores;
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
        public void AddEmprendedor(string ID, Emprendedor emprendedor)
        {
            this.emprendedores.Add(ID,emprendedor);
        }

        /// <summary>
        /// Remueve un emprendedor de la lista de emprendedores.
        /// </summary>
        /// <param name="emprendedor">parametro emprendedor recibido por el metodo RemoverEmprendedor.</param>
        public void RemoveEmprendedor(string ID)
        {
            this.emprendedores.Remove(ID);  
        }

        /// <summary>
        /// Añiade una empresa a la lista de empresas.
        /// </summary>
        /// <param name="empresa">parametro empresa recibido por el metodo AgregarEmpresa.</param>
        public void AddEmpresa(string ID, Empresa empresa)
        {
            this.empresas.Add(ID,empresa);
        }

        /// <summary>
        /// Remueve una empresa de la lista de empresas.
        /// </summary>
        /// <param name="empresa">parametro empresa recibido por el metodo RemoveEmpresa.</param>
        public void RemoveEmpresa(string ID)
        {
            this.empresas.Remove(ID);
        }

        public void AddInvitado(string ID)
        {
            this.invitados.Add(ID);
        }

        public void AddAdministrador(string ID)
        {
            this.administradores.Add(ID);
        }
    }
}
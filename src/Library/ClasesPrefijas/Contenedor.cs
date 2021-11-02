using System.Collections.Generic;

namespace Library
{

    /// <summary>
    /// Esta clase representa un contenedor de las diferentes clases del bot
    /// </summary>

    public class Contenedor
    {
        //singleton
        private static Contenedor contenedor;

        /// <summary>
        /// Devuelve una instancia de la clase Contenedor y si no existe la crea
        /// </summary>
        /// <value></value>

        public static Contenedor Instancia
        {
            get{
                if (contenedor == null)
                {
                    contenedor = new Contenedor();
                }
                return contenedor;
            }
        }

        private Contenedor()
        {
        }
        
        private List<Habilitacion> habilitaciones = new List<Habilitacion>();

        /// <summary>
        /// Devuelve un valor con la habilitacion correspondiente al nombre
        /// </summary>
        /// <value></value>

        public List<Habilitacion> Habilitaciones 
        {
            get{
                return this.habilitaciones;
            }
            set{
                this.habilitaciones=value;
            }
        }
        private List<Rubro> rubros = new List<Rubro>();

        /// <summary>
        /// Devuelve un valor con la lista de rubros
        /// </summary>
        /// <value></value>
        public List<Rubro> Rubros
        {
            get{
                return this.rubros;
            }
            set{
                this.rubros=value;
            }
        }
        private List<Clasificacion> clasificaciones = new List<Clasificacion>();

        /// <summary>
        /// Devuelve un valor con la lista de clasificaciones
        /// </summary>
        /// <value></value>

        public List<Clasificacion> Clasificaciones
        {
            get{
                return this.clasificaciones;
            }
            set{
                this.clasificaciones=value;
            }
        }

        private List<Oferta> ofertas = new List<Oferta>();

        /// <summary>
        /// Devuelve un valor con la lista de las ofertas
        /// </summary>
        /// <value></value>

        public List<Oferta> Ofertas
        {
            get{
                return this.ofertas;
            }
            set{
                this.ofertas=value;
            }
        }


        private List<Emprendedor> emprendedores = new List<Emprendedor>();

        /// <summary>
        /// Devuelve un valor con la lista de los Emprendedores
        /// </summary>
        /// <value></value>
        
        public List<Emprendedor> Emprendedores
        {
            get{
                return this.emprendedores;
            }
            set{
                this.emprendedores=value;
            }
        }

        private List<Empresa> empresas = new List<Empresa>();

        /// <summary>
        /// Devuelve un valro con la lsita de las Empresas
        /// </summary>
        /// <value></value>

        public List<Empresa> Empresas
        {
            get{
                return this.empresas;
            }
            set{
                this.empresas=value;
            }
        }
        
        /// <summary>
        /// Añiade una habilitacion a la lista de habilitaciones
        /// </summary>
        /// <param name="habilitacion"></param>

        public void AddHabilitacion(Habilitacion habilitacion)
        {
            this.Habilitaciones.Add(habilitacion);
        }

        /// <summary>
        /// Remueve una habilitacion de la lista de habilitaciones
        /// </summary>
        /// <param name="habilitacion"></param>

        public void RemoveHabiltiacion(Habilitacion habilitacion)
        {
            this.Habilitaciones.Remove(habilitacion);
        }

        /// <summary>
        /// Añiade un rubro a la lista de rubros
        /// </summary>
        /// <param name="rubro"></param>

        public void AddRubro(Rubro rubro)
        {
            this.Rubros.Add(rubro);
        }

        /// <summary>
        /// Remueve un rubro de la lista de rubros
        /// </summary>
        /// <param name="rubro"></param>

        public void RemoveRubro(Rubro rubro)
        {
            this.Rubros.Remove(rubro);
        }
        
        /// <summary>
        /// Añiade una clasificacion a la lista de clasificaciones
        /// </summary>
        /// <param name="clasificacion"></param>

        public void AddClasificacion(Clasificacion clasificacion)
        {
            this.Clasificaciones.Add(clasificacion);
        }

        /// <summary>
        /// Remueve una clasificacion de la lista de clasificaciones
        /// </summary>
        /// <param name="clasificacion"></param>

        public void RemoveClasificacion(Clasificacion clasificacion)
        {
            this.Clasificaciones.Remove(clasificacion);
        }

        /// <summary>
        /// Añiade una oferta a la lista de ofertas
        /// </summary>
        /// <param name="oferta"></param>

        public void AddOferta(Oferta oferta)
        {
            this.Ofertas.Add(oferta);
        }

        /// <summary>
        /// Remueve una oferta de la lista de ofertas
        /// </summary>
        /// <param name="oferta"></param>

        public void RemoveOferta(Oferta oferta)
        {
            this.Ofertas.Remove(oferta);
        }

        /// <summary>
        /// Añiade un Emprendedor a la lista de emprendedores
        /// </summary>
        /// <param name="emprendedor"></param>
        

        public void AddEmprendedor(Emprendedor emprendedor)
        {
            this.Emprendedores.Add(emprendedor);
        }

        /// <summary>
        /// Remueve un emprendedor de la lista de emprendedores
        /// </summary>
        /// <param name="emprendedor"></param>

        public void RemoveEmprendedor(Emprendedor emprendedor)
        {
            this.Emprendedores.Remove(emprendedor);
        }

        /// <summary>
        /// Añiade una empresa a la lista de empresas
        /// </summary>
        /// <param name="empresa"></param>

        public void AddEmpresa(Empresa empresa)
        {
            this.Empresas.Add(empresa);
        }

        /// <summary>
        /// Remueve una empresa de la lista de empresas
        /// </summary>
        /// <param name="empresa"></param>

        public void RemoveEmpresa(Empresa empresa)
        {
            this.Empresas.Remove(empresa);
        }
    }
}
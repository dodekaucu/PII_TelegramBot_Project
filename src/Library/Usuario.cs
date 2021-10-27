using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta es una  superclase Usuario porque la relacion entre la clase Usuario y Emprendedor y Empresa es una 
    /// relacion "is a".
    /// </summary>
    public abstract class Usuario   
    {
        /// <summary>
        /// Se declara una variable nombre del tipo string, nombre del usuario
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        /// <summary>
        /// se declara una variable Rubro, indica el rubro del usuario
        /// </summary>
        /// <value></value>
        public string Rubro {get; set;}

        /// <summary>
        /// Variable del tipo Ubicacion
        /// </summary>
        /// <value></value>
        public Ubicacion Ubicacion{get;set;}
        
        //protected List<string> registro = new List<string>();   //el registro (no son strings son ofertas, creo?)

        /// <summary>
        /// Constructor del Usuario, los parametros nombre y rubro son propios de la empresa, mientras
        /// que ciudad y calle es para Ubicacion. una instancia llamada ubicacion es inicializada 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="rubro"></param>
        /// <param name="ciudad"></param>
        /// <param name="calle"></param>
        protected Usuario(string nombre, string rubro,string ciudad,string calle)
        {
            Ubicacion ubicacion = new Ubicacion(ciudad,calle);
            this.Ubicacion=ubicacion;
            this.Nombre=nombre;
            this.Rubro=rubro;
        }
    }
}
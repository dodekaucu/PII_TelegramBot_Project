//--------------------------------------------------------------------------------
// <copyright file="Material.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace Library
{
    /// <summary>
    /// Clase que representa al Material.
    /// Es una clase experta en crear materiales. Y tiene la sola responsabilidad de crear materiales. (SRP).
    /// </summary>
    public class Material
    {
        private Clasificacion clasificacion;
        private int cantidad;
        private string unidad;
        private double valor;

        private string nombre;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Material"/>.
        /// </summary>
        /// <param name="nombre">El nombre del material.</param>
        /// <param name="clasificacion">La clasificacion del material.</param>
        /// <param name="cantidad">La cantidad de la unidad.</param>
        /// <param name="unidad">La unidad del material.</param>
        /// <param name="valor">El valor de la unidad.</param>
        public Material(string nombre, Clasificacion clasificacion, int cantidad, string unidad, double valor)
        {
            this.nombre = nombre;
            this.clasificacion = clasificacion;
            this.cantidad = cantidad;
            this.unidad = unidad;
            this.valor = valor;
        }

        /// <summary>
        /// Obtiene la clasificacion del material.
        /// </summary>
        /// <value>la clasificacion del material.</value>
        public Clasificacion Clasificacion
        {
            get
            {
                return this.clasificacion;
            }
        }

        /// <summary>
        /// Obtiene un valor que indica la cantidad del material.
        /// </summary>
        /// <value>la cantidad de la unidad.</value>
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
        }

        /// <summary>
        /// Obtiene un valor que indica la unidad del material.
        /// </summary>
        /// <value>la unidad en la cual se va a medir.</value>
        public string Unidad
        {
            get
            {
                return this.unidad;
            }
        }

        /// <summary>
        /// Obtiene un valor que indica el valor del material.
        /// </summary>
        /// <value>el valor de la unidad.</value>
        public double Valor
        {
            get
            {
                return this.valor;
            }
        }

        /// <summary>
        /// Obtiene un valor que indica el nombre del material.
        /// </summary>
        /// <value>el nombre del material.</value>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
    }
}
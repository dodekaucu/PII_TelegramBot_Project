//--------------------------------------------------------------------------------
// <copyright file="IUsuario.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Library
{
    /// <summary>
    /// Public Interface con la firma de los metodos que debe poseer un Usuario. Se utilizo una interface
    /// puesto que todos los usuarios deben tener almenos ciertas properties en orden de ser considerados
    /// un Usuario. Se cumple el principio OCP, puesto que al crear una interface usuario permito que las
    /// clases que dependan de IUsuario, queden abiertas a la extension pero cerradas a la modificacion.
    /// Esto se ve ejemplificado en el caso de que yo quiera modificar una clase que implementa IUsuario
    /// sencillamente la exando utilizando una interface que implemente IUsuario. Respetando asi el principio
    /// </summary>
    public interface IUsuario
    {
        /// <summary>
        /// Obtiene o establece un valor el nombre del usuario.
        /// </summary>
        /// <value>this.nombre.</value>
        string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que es el rubro del usuario.
        /// </summary>
        /// <value>this.rubro.</value>
        Rubro Rubro { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica la ubicacion del usuario.
        /// </summary>
        /// <value>ubicacion.</value>
        Ubicacion Ubicacion { get; set; }

    }
}
//--------------------------------------------------------------------------------
// <copyright file="Contenedor.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library
{
    /// <summary>
    /// Esta clase representa un contenedor de las diferentes clases del bot.
    /// Utilzia el patron de diseño Singleton. Pues solo se puede tener una instancia de esta clase.
    /// Es la clase EXPERTA en contener las diferentes instancias del programa.
    /// Ademas se cumple SRP pues su unica razon para cambiar es que se cambie la forma de almacenar las instancias.
    /// </summary>
    public class Contenedor: IJsonSerialize
    {
        public static Contenedor contenedor;

        public Collection<Habilitacion> habilitaciones = new Collection<Habilitacion>();

        public Collection<Rubro> rubros = new Collection<Rubro>();

        public Collection<Clasificacion> clasificaciones = new Collection<Clasificacion>();

        public Collection<Oferta> ofertas = new Collection<Oferta>();

        public Dictionary<string,Emprendedor> emprendedores = new Dictionary<string, Emprendedor>();

        public Dictionary<string,Empresa> empresas = new Dictionary<string, Empresa>();


        public Collection<string> administradores = new Collection<string>() { "1454175798" };


        public Collection<string> invitados = new Collection<string> ();

        public Contenedor()
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
        public Collection<Oferta> Ofertas
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
        /// Obtiene el diccionario de Empresas registradas.
        /// </summary>
        /// <value></value>
        public Dictionary<string,Empresa> Empresas
        {
            get
            {
                return this.empresas;
            }
        }

        /// <summary>
        /// Obtiene la lista de usuarios invitados.
        /// </summary>

        public Collection<string> Invitados
        {
            get
            {
                return this.invitados;
            }
        }

        /// <summary>
        /// Obtiene la lista de administradores.
        /// </summary>
        /// <value></value>
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
        /// Añade un emprendedor al diccionario de emprendedores.
        /// Se utiliza un diccionario porque es mas facil para buscarlos por ID de usuario.
        /// </summary>
        /// <param name="ID">ID del usuario.</param>
        /// <param name="emprendedor">Instancia de clase emprendedor.</param>

        public void AddEmprendedor(string ID, Emprendedor emprendedor)
        {
            this.emprendedores.Add(ID,emprendedor);
        }

        /// <summary>
        /// Remueve un emprendedor del diccionario de emprendedores.
        /// </summary>
        /// <param name="ID">ID del usuario.</param>

        public void RemoveEmprendedor(string ID)
        {
            this.emprendedores.Remove(ID);
        }

        /// <summary>
        /// Agrega una empresa al diccioanrio de empresas.
        /// </summary>
        /// <param name="ID">ID del usuario</param>
        /// <param name="empresa">Instancia de la clase empresa.</param>

        public void AddEmpresa(string ID, Empresa empresa)
        {
            this.empresas.Add(ID,empresa);
        }


        /// <summary>
        /// Remueve una empresa del diccionario de empresas.
        /// </summary>
        /// <param name="ID">ID del usuario.</param>
        public void RemoveEmmpresa(string ID)
        {
            this.empresas.Remove(ID);
        }

        /// <summary>
        /// Agrega a un usuario a la lista de invitados.
        /// </summary>
        /// <param name="ID">ID del usuario.</param>
        public void AddInvitado(string ID)
        {
            this.invitados.Add(ID);
        }

        /// <summary>
        /// Agrega a un administrador a la lista de admins.
        /// </summary>
        /// <param name="ID">ID del usuario.</param>

        public void AddAdministrador(string ID)
        {
            this.administradores.Add(ID);
        }
        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance, 
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(this, options);
            return json;
        }  
        /*
        public void LoadFromJson(string json)
        {
            Contenedor data = JsonSerializer.Deserialize<Contenedor>(json);
            this.habilitaciones = data.habilitaciones;
            this.rubros = data.rubros;
            this.clasificaciones = data.clasificaciones;
            this.ofertas = data.ofertas;
            this.emprendedores = data.emprendedores;
            this.empresas = data.empresas;
            this.administradores = data.administradores;
            this.invitados = data.invitados;
        }*/
        public string serializaremprendedor()
        {
            return JsonSerializer.Serialize(this.emprendedores);
        }
        public string serializarempresa()
        {
            return JsonSerializer.Serialize(this.empresas);
        }
        public string serializarhabilitacion()
        {
            return JsonSerializer.Serialize(this.habilitaciones);
        }
        public string serializarrubro()
        {
            return JsonSerializer.Serialize(this.rubros);
        }
        public string serializarclasificacion()
        {
            return JsonSerializer.Serialize(this.clasificaciones);
        }
        public string serializaroferta()
        {
            return JsonSerializer.Serialize(this.ofertas);
        }
        public string serializaradministrador()
        {
            return JsonSerializer.Serialize(this.administradores);
        }
        public string serializarinvitado()
        {
            return JsonSerializer.Serialize(this.invitados);
        }
        public string jsonemprendedor = "";
        public string jsonempresa = "";
        public string jsonhabilitacion = "";
        public string jsonrubro = "";
        public string jsonclasificacion = "";
        public string jsonoferta = "";
        public string jsonadmin = "";
        public string jsoninvitado = "";
        public void Serializar()
        {
            this.jsonhabilitacion = serializarhabilitacion();
            this.jsonrubro = serializarrubro();
            this.jsonclasificacion = serializarclasificacion();
            this.jsonoferta = serializaroferta();
            this.jsonemprendedor = serializaremprendedor();
            this.jsonempresa = serializarempresa();
            this.jsonadmin = serializaradministrador();
            this.jsoninvitado = serializarinvitado();
        }
        public void Deserializar(string deserializarhabilitacion, string deserializarrubro, string deserializarclasificacion, string deserializaremprendedor, string deserializarempresa, string deserializaradmin, string deserializarinvitado, string deserializaroferta)
        {
            this.habilitaciones = JsonSerializer.Deserialize<Collection<Habilitacion>>(deserializarhabilitacion);
            this.rubros = JsonSerializer.Deserialize<Collection<Rubro>>(deserializarrubro);
            this.clasificaciones = JsonSerializer.Deserialize<Collection<Clasificacion>>(deserializarclasificacion);
            this.ofertas = JsonSerializer.Deserialize<Collection<Oferta>>(deserializaroferta);
            this.emprendedores = JsonSerializer.Deserialize<Dictionary<string, Emprendedor>>(deserializaremprendedor);
            this.empresas = JsonSerializer.Deserialize<Dictionary<string, Empresa>>(deserializarempresa);
            this.administradores = JsonSerializer.Deserialize<Collection<string>>(deserializaradmin);
            this.invitados = JsonSerializer.Deserialize<Collection<string>>(deserializarinvitado);
        }
    }
}
using System.Collections.ObjectModel;
using Library;

namespace Handlers
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/AddHabilitacion".
    /// </summary>
    public class AddHabilitacionHandler : BaseHandler
    {

        public AddHabilitacionHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/AddHabilitacion"};
        }
        protected override bool InternalHandle(IMessage message, out string response)
        {
            Contenedor db = Contenedor.Instancia;
            DatosTemporales dt = DatosTemporales.Instancia;
            StatusManager sm = StatusManager.Instancia;
            if (this.CanHandle(message))
            {
                if (db.Emprendedores.ContainsKey(message.ID))
                {
                    string opciones ="";
                    int i=0;
                    // revisar como hacer esta mierda !!!
                    Collection<Habilitacion> habilitacionsDisponibles = new Collection<Habilitacion> ();
                    foreach(Habilitacion habilitacion in db.Habilitaciones)
                    {
                        if(!db.Emprendedores[message.ID].Habilitaciones.Contains(habilitacion))
                        {
                            opciones = i.ToString() + " - " + opciones + habilitacion.Name +"\n";
                            habilitacionsDisponibles.Add(habilitacion);
                            i++;
                        }
                    }
                    response = "seleccione su habilitacion (escriba el número correspondiente)\n"+opciones;
                    sm.AddKeyUser(message.ID);
                    sm.AddUserStatus(message.ID,"/AddHabilitacion");
                    dt.AddKeyUser(message.ID);
                    //dt.DataTemporal()*/
                    return true;
                }
                if(db.Empresas.ContainsKey(message.ID))
                {
                    //AÑADIR UNA HABILITACION A LA OFERTA
                    string opciones ="";
                    int i=0;
                    foreach (OfertaBase oferta in db.Ofertas)
                    {
                        if(message.ID==oferta.Empresa.ID)
                        {
                            //aca van a estar las ofertas que posee la empresa
                            opciones = i.ToString() + " - " + opciones + oferta.Nombreoferta +"\n";
                            i++;
                        }
                    }
                    response = "Seleccione la oferta ha añadir una habilitacion";
                    sm.AddKeyUser(message.ID);
                    sm.AddUserStatus(message.ID,"/AddHabilitacion");
                    return true;
                }
                if(sm.UserStatusChat.ContainsKey(message.ID))
                {
                    response = "Actualmente se encuentra el proceso " + sm.UserStatusChat[message.ID]+" activo, porfavor, si desea activar otro comando cancele el actual con /cancel";
                    return true;
                }
                else
                {
                    response = "Usted no se encuentra registrado en la plataforma";
                    return true;
                }
            }
            if(sm.UserStatusChat[message.ID]=="/AddHabilitacion" && dt.DataTemporal[message.ID].Count==0)
            {
                
            }

            response = string.Empty;
            return false;
        }
    }
}
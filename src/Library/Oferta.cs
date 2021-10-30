using System;
using System.Collections.Generic;

namespace Library
{
    public class Oferta
    {
        public string Nombreoferta {get; set;}
        public int Recurrencia {get; set;}
        public bool Disponible {get; set;}
        public string Palabraclave {get; set;}
         public Oferta(string nombreoferta, Empresa empresa, int recurrencia, Ubicacion ubicacion, bool disponible, string palabraclave)
         {
             this.Nombreoferta = nombreoferta;
             this.Empresa = empresa;
             this.Recurrencia = recurrencia;
             this.Ubicacion = ubicacion;
             this.Disponible = disponible;
             this.Palabraclave = palabraclave;
         }
         public void AddMateriales(string clasificacion, int cantidad, string unidad, int valor)
         {
             Materiales material = new Materiales(clasificacion, cantidad, unidad, valor);
             this.material.Add(material);
         }

         private List<Habilitacion> habilitaciones = new List<Habilitacion>();

         public void AddHabilitacion(string nombre, string descripcion)
         {
             Habilitacion habilitacion = new Habilitacion(nombre,descripcion);
             this.habilitaciones.Add(habilitacion);
         }
    }
}
using System;
using System.Collections.Generic;

namespace Library
{
    public class Oferta
    {
        public string Nombreoferta {get; set;}
        public int Recurrencia {get; set;}
        public bool Disponible {get; set;}

        public Material Material {get; set;}
        public Empresa Empresa {get;}

        public Ubicacion Ubicacion {get; set;}
        private List<string> palabrasClaves = new List<string>();
        public List<string> PalabrasClaves
        {
            get { return palabrasClaves; }
            set { palabrasClaves = value; }
        }
        public Oferta(string nombreoferta, Empresa empresa, int recurrencia, string ciudad, string calle, 
        bool disponible,string nombreMaterial ,Clasificacion clasificacion,
        int cantidad, string unidad, double valor)
        {
            Material material = new Material(nombreMaterial,clasificacion, cantidad, unidad, valor); 
            this.Material = material;
            this.Nombreoferta = nombreoferta;
            this.Empresa = empresa;
            this.Recurrencia = recurrencia;
            Ubicacion ubicacion = new Ubicacion(ciudad, calle);
            this.Ubicacion = ubicacion;
            this.Disponible = disponible;

            this.PalabrasClaves.Add(this.Nombreoferta);
            this.PalabrasClaves.Add(this.Empresa.Nombre);
            this.PalabrasClaves.Add(this.Material.Nombre);
        }
        private List<Habilitacion> habilitaciones = new List<Habilitacion>();

        public void AddHabilitacion(string nombre, string descripcion)
        {
            Habilitacion habilitacion = new Habilitacion(nombre,descripcion);
            this.habilitaciones.Add(habilitacion);
        }

        public void AddPalabraClave(string palabraClave)
        {
            this.PalabrasClaves.Add(palabraClave);
        }
    }
}
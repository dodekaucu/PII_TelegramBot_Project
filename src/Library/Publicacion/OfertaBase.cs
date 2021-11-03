using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class OfertaBase
    {
        public string Nombreoferta {get; set;}

        public DateTime FechaVenta {get; set;}

        public Material Material {get; set;}
        public Empresa Empresa {get;}

        public Ubicacion Ubicacion {get; set;}
        private List<string> palabrasClaves = new List<string>();
        public List<string> PalabrasClaves
        {
            get { return palabrasClaves; }
        }
        protected OfertaBase(string nombreoferta, Empresa empresa, string ciudad, string calle, 
        string nombreMaterial ,Clasificacion clasificacion,
        int cantidad, string unidad, double valor)
        {
            Material material = new Material(nombreMaterial,clasificacion, cantidad, unidad, valor); 
            this.Material = material;
            this.Nombreoferta = nombreoferta;
            this.Empresa = empresa;
            Ubicacion ubicacion = new Ubicacion(ciudad, calle);
            this.Ubicacion = ubicacion;

            this.PalabrasClaves.Add(this.Nombreoferta);
            this.PalabrasClaves.Add(this.Empresa.Nombre);
            this.PalabrasClaves.Add(this.Material.Nombre);
        }
        private List<Habilitacion> habilitaciones = new List<Habilitacion>();

        public List<Habilitacion> Habilitaciones
        {
            get {return this.habilitaciones;}
        }

        public void AddHabilitacion(Habilitacion habilitacion)
        {
            this.habilitaciones.Add(habilitacion);
        }

        public void AddPalabraClave(string palabraClave)
        {
            this.PalabrasClaves.Add(palabraClave);
        }
    }
}
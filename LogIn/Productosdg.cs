using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    class Productosdg
    {
        private string id;
        private string nombre;
        private string codebarra;
        private string preciocompra;
        private string precioventa;
        private string cantidad;
        public Productosdg() { }
        public Productosdg(string i, string n, string cb, string pc, string pv, string c)
        {
            id = i;
            nombre = n;
            codebarra = cb;
            preciocompra = pc;
            precioventa = pv;
            cantidad = c;
        }
        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public string Precioventa
        {
            get { return precioventa; }
            set { precioventa = value; }
        }
        public string Preciocompra
        {
            get { return preciocompra; }
            set { preciocompra = value; }
        }
        public string Codebarra
        {
            get { return codebarra; }
            set { codebarra = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}

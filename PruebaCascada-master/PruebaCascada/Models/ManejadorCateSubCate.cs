using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaCascada.DAL;

namespace PruebaCascada.Models
{
    public class ManejadorCateSubCate
    {

        private static PruebaCascadaEntities db = new PruebaCascadaEntities();

        public int? SelectedCategoriaId { get; set; }
        public int? SelectedSubCategoriaId { get; set; }

        public IEnumerable<Categorias> ListaCategorias { get; set; }
        public IEnumerable<Subcategorias> ListaSubCategorias { get; set; }
        public IEnumerable<Productos> ListaProductos { get; set; }

        public static IEnumerable<Categorias> GetCategorias()
        {
            return (from t in db.Categorias
                    select t).ToList();
        }

        public static IEnumerable<Subcategorias> GetSubCategorias()
        {
            return (from t in db.Subcategorias
                    select t).ToList();
        }

        public static IEnumerable<Productos> GetProductos()
        {
            return (from t in db.Productos
                    select t).ToList();
        }

        public static Categorias GetCategoria(int CategoriaId)
        {
            return (from t in db.Categorias
                    where t.id == CategoriaId
                    select t).SingleOrDefault();
        }

    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace PruebaCascada.DAL
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
public partial class Productos
{

    public int id { get; set; }
    [Display(Name="Producto")]
    public string nombre { get; set; }
    [Display(Name="Descripci�n")]
    public string descripcion { get; set; }
    
    public int idcat { get; set; }
    
    public int idsubcat { get; set; }


    [Display(Name = "Categoria")]
    public virtual Categorias Categorias { get; set; }
    [Display(Name = "Subcategoria")]
    public virtual Subcategorias Subcategorias { get; set; }

}

}
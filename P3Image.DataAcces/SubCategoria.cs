//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P3Image.DataAcces
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubCategoria
    {
        public SubCategoria()
        {
            this.Campos = new HashSet<Campo>();
        }
    
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> CategoriaId { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Campo> Campos { get; set; }
    }
}
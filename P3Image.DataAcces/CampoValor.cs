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
    
    public partial class CampoValor
    {
        public int Id { get; set; }
        public int CampoId { get; set; }
        public string Valor { get; set; }
    
        public virtual Campo Campo { get; set; }
    }
}
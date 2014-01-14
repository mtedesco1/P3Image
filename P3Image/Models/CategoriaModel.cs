using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace P3Image.Presentation.Models
{
    public class CategoriaModel
    {
        public CategoriaModel() 
        {
            this.Categorias = new List<Categoria>();
            this.SubCategorias = new List<SubCategoria>();
        }
        
        public List<Categoria> Categorias { get; set; }
        public List<SubCategoria> SubCategorias { get; set; }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<SubCategoria> SubCategorias { get; set; }
    }

    public class SubCategoria
    {
        public SubCategoria() 
        {
            this.Campos = new List<Campo>();        
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public List<Campo> Campos { get; set; }
    }

    public class Campo
    {
        public Campo() 
        {
            this.Valores = new List<CampoValor>();
        }
        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int TipoId { get; set; }
        public int SubCategoriaId { get; set; }
        public List<CampoValor> Valores { get; set; }
    }

    public class TipoCampo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    public class CampoValor
    {
        public int Id { get; set; }
        public int CampoId { get; set; }
        public string Valor { get; set; }
    }
}
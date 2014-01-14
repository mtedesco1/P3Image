using P3Image.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace P3Image.Business.Interfaces
{
    public interface ICategoriaBusiness
    {
        int SaveCategoria(string nomeCategoria);
        int SaveSubCategoria(int idCategoria);
        int SaveCampo(string descricao, int subCategoriaId, int tipoId);
        int SaveCampoValor(int campoId, string valor);
        void UpdateNomeSubCategoria(int idSubCategoria, string descricao);
        List<Categoria> GetCategorias();
        List<SubCategoria> GetSubCategoriasByIdCategoria(int idCategoria);
        SubCategoria GetSubCategoriaByNomes(string nomeCategoria, string nomeSubCategoria);
    }
}

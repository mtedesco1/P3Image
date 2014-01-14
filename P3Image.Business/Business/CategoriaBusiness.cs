using DataAcces.Interfaces;
using DataAcces.Repositories;
using P3Image.Business.Interfaces;
using P3Image.DataAcces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace P3Image.Business
{
    public class CategoriaBusiness : ICategoriaBusiness
    {
        private ModelStateDictionary _modelState;
        private ICategoriaRepository _repository;

        public CategoriaBusiness(ModelStateDictionary modelState, ICategoriaRepository repository)
        {
            _modelState = modelState;
            _repository = repository;
        }

        public int SaveCategoria(string nomeCategoria)
        {
            return _repository.SaveCategoria(nomeCategoria);
        }

        public List<Categoria> GetCategorias()
        {
            return _repository.GetCategorias();
        }

        public int SaveSubCategoria(int idCategoria) 
        {
            return _repository.SaveSubCategoria(idCategoria);
        }

        public int SaveCampoValor(int campoId, string valor) 
        {
            return _repository.SaveCampoValor(campoId, valor);
        }

        public int SaveCampo(string descricao, int subCategoriaId, int tipoId)
        {
            return _repository.SaveCampo(descricao, subCategoriaId, tipoId);
        }

        public List<SubCategoria> GetSubCategoriasByIdCategoria(int idCategoria) 
        {
            return _repository.GetSubCategoriasByIdCategoria(idCategoria);
        }

        public void UpdateNomeSubCategoria(int idSubCategoria, string descricao) 
        {
            _repository.UpdateNomeSubCategoria(idSubCategoria, descricao);
        }

        public SubCategoria GetSubCategoriaByNomes(string nomeCategoria, string nomeSubCategoria) 
        {
            return _repository.GetSubCategoriaByNomes(nomeCategoria, nomeSubCategoria);
        }
    }
}
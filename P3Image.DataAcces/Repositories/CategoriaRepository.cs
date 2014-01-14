using DataAcces.Interfaces;
using P3Image.DataAcces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private P3ImageDBEntities _entities = new P3ImageDBEntities();
         
        public int SaveCategoria(string nomeCategoria)
        {
            var categoria = new Categoria();
            categoria.Descricao = nomeCategoria;
            _entities.Categorias.Add(categoria);
            _entities.SaveChanges();
            return categoria.Id;
        }

        public int SaveSubCategoria(int idCategoria)
        {
            var subCategoria = new SubCategoria();
            subCategoria.CategoriaId = idCategoria;
            _entities.SubCategorias.Add(subCategoria);
            _entities.SaveChanges();
            return subCategoria.Id;
        }

        public int SaveCampo(string descricao, int subCategoriaId, int tipoId)
        {
            var campo = new Campo();
            campo.Descricao = descricao;
            campo.SubCategoriaId = subCategoriaId;
            campo.TipoId = tipoId;
            _entities.Campos.Add(campo);
            _entities.SaveChanges();
            return campo.Id;
        }

        public int SaveCampoValor(int campoId, string valor) 
        {
            var campo = new CampoValor();
            campo.CampoId = campoId;
            campo.Valor = valor;
            _entities.Valores.Add(campo);
            _entities.SaveChanges();
            return campo.Id;
        }

        public List<Categoria> GetCategorias()
        {
            return _entities.Categorias.ToList();
        }

        public List<SubCategoria> GetSubCategoriasByIdCategoria(int idCategoria) 
        {
            return _entities.SubCategorias.Where(x => x.CategoriaId == idCategoria).ToList();
        }

        public void UpdateNomeSubCategoria(int idSubCategoria, string descricao)
        {
            var subCategoria = _entities.SubCategorias.Where(x => x.Id == idSubCategoria).FirstOrDefault();
            subCategoria.Descricao = descricao;
            _entities.SaveChanges();
        }

        public SubCategoria GetSubCategoriaByNomes(string nomeCategoria, string nomeSubCategoria) 
        {
            var categoria = _entities.Categorias.Where(x => x.Descricao == nomeCategoria).FirstOrDefault();
            if (categoria != null)
                return _entities.SubCategorias.Where(x => x.CategoriaId == categoria.Id && x.Descricao == nomeSubCategoria).FirstOrDefault();
            else
                return null;
        }
    }
}

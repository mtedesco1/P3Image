using P3Image;
using DataAcces.Interfaces;
using DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P3Image.Business.Interfaces;
using P3Image.Business;
using P3Image.Presentation.Models;
using P3Image.Mappers;

namespace P3Image.Presentation.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaBusiness _service;

        public CategoriaController()
        {
            _service = new CategoriaBusiness(this.ModelState, new CategoriaRepository());
        }

        public CategoriaController(ICategoriaBusiness service)
        {
            _service = service;
        }

        public ActionResult Create()
        {
            var model = new CategoriaModel();
            model.Categorias = CategoriaMapper.MappEntityListToModels(_service.GetCategorias());
            return View(model);
        }

        public ActionResult Index(string categoria, string subCategoria)
        {
            var model = CategoriaMapper.MappEntityToModel(_service.GetSubCategoriaByNomes(categoria, subCategoria));
            if (model != null)
                return View(model);
            else
                return RedirectToAction("NoResults");
        }

        public ActionResult NoResults()
        {
            return View();
        }

        public JsonResult GetSubCategoriasByIdCategoria(int idCategoria)
        {
            return Json(CategoriaMapper.MappEntityListToModels(_service.GetSubCategoriasByIdCategoria(idCategoria)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCategoria(string nomeCategoria) 
        {
            return Json(_service.SaveCategoria(nomeCategoria), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddSubCategoria(int idCategoria)
        {
            return Json(_service.SaveSubCategoria(idCategoria), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCampo(string descricao, int subCategoriaId, int tipoId)
        {
            return Json(_service.SaveCampo(descricao, subCategoriaId, tipoId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCampoValor(int campoId, string valor)
        {
            if (valor != string.Empty)
                return Json(_service.SaveCampoValor(campoId, valor), JsonRequestBehavior.AllowGet);
            else
                return null;
        }

        public void UpdateNomeSubCategoria(int idSubCategoria, string descricao)
        {
            _service.UpdateNomeSubCategoria(idSubCategoria, descricao);
        }
    }
}

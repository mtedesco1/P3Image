using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using P3Image.Models;
using P3Image.Presentation.Models;

namespace P3Image.Mappers
{
	public static class CategoriaMapper
	{
        public static SubCategoria MappEntityToModel(DataAcces.SubCategoria entity)
        {
            Mapper.CreateMap<DataAcces.SubCategoria, SubCategoria>();
            Mapper.CreateMap<DataAcces.Campo, Campo>();
            Mapper.CreateMap<DataAcces.CampoValor, CampoValor>();
            return Mapper.Map<DataAcces.SubCategoria, SubCategoria>(entity);
        }

        public static List<Categoria> MappEntityListToModels(List<DataAcces.Categoria> Entities)
        {
            Mapper.CreateMap<DataAcces.Categoria, Categoria>();
            Mapper.CreateMap<DataAcces.SubCategoria, SubCategoria>();
            Mapper.CreateMap<DataAcces.Campo, Campo>();
            Mapper.CreateMap<DataAcces.CampoValor, CampoValor>();
            return Mapper.Map<List<DataAcces.Categoria>, List<Categoria>>(Entities);
        }

        public static List<SubCategoria> MappEntityListToModels(List<DataAcces.SubCategoria> Entities)
        {
            Mapper.CreateMap<DataAcces.SubCategoria, SubCategoria>();
            Mapper.CreateMap<DataAcces.Campo, Campo>();
            Mapper.CreateMap<DataAcces.CampoValor, CampoValor>();
            return Mapper.Map<List<DataAcces.SubCategoria>, List<SubCategoria>>(Entities);
        }
	}
}

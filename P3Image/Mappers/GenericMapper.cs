using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace P3Image.Mappers
{
    public static class GenericMapper<TModel, TEntity>
    {
        public static TModel MappEntityToModel(TEntity entity)
        {
            Mapper.CreateMap<TEntity, TModel>();
            return Mapper.Map<TEntity, TModel>(entity);
        }

        public static List<TModel> MappEntityListToModels(List<TEntity> TEntities)
        {
            Mapper.CreateMap<TEntity, TModel>();
            return Mapper.Map<IEnumerable<TEntity>, List<TModel>>(TEntities);
        }

        public static TEntity MappModelToEntity(TModel model)
        {
            Mapper.CreateMap<TModel, TEntity>();
            return Mapper.Map<TModel, TEntity>(model);
        }

        public static List<TEntity> MappModelListToEntities(List<TModel> models)
        {
            Mapper.CreateMap<TModel, TEntity>();
            return Mapper.Map<IEnumerable<TModel>, List<TEntity>>(models);
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Routing.Template;

namespace RSAMobileAPI.RSAEntities
{
    public abstract class Entity
    {
        public T MapTo<T>() where T : class
        {
            return Mapper.Map<T>(this);
        }
        public static TResult MapFrom<TSource, TResult>(TSource source)
     where TSource : class
     where TResult : Entity
        {
            return Mapper.Map<TResult>(source);
        }

    }
}

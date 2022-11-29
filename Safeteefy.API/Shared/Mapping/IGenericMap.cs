
namespace Safeteefy.API.Shared.Mapping;

public interface IGenericMap<in TFrom, TTo> where TFrom : class where TTo: class
{
    TTo Map(TFrom from, TTo to);
}
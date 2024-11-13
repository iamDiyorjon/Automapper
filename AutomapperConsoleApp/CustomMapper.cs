using System.Reflection;

namespace AutomapperConsoleApp;

public class CustomMapper
{
    private readonly Dictionary<Tuple<Type, Type>, object> _mappings = 
    new Dictionary<Tuple<Type, Type>, object>();

    public void CreateMap<TSource, TDestination>()
    {
        var config = new MappingConfig<TSource, TDestination>();
        _mappings[Tuple.Create(typeof(TSource), typeof(TDestination))] = config;
    }

    public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
    {
        var key = Tuple.Create(typeof(TSource), typeof(TDestination));
        if (_mappings.TryGetValue(key, out var config))
        {
            var destination = new TDestination();
            ((MappingConfig<TSource, TDestination>)config).Map(source, destination);

            return destination;
        }
        throw new Exception("Bunaqa config yozilmaganku ukajonim.");
    }
}

public class MappingConfig<TSource, TDestination>
{
    public void Map(TSource source, TDestination destination)
    {
        PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
        PropertyInfo[] destinationProperties = typeof(TDestination).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            foreach (var destItem in destinationProperties)
            {
                if (destItem.Name == sourceProperty.Name && 
                    destItem.PropertyType == sourceProperty.PropertyType &&
                    destItem != null &&
                    destItem.CanWrite)
                {
                    destItem.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
        }
    }
}
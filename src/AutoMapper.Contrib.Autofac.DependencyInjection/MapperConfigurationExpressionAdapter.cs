namespace AutoMapper.Contrib.Autofac.DependencyInjection;

internal class MapperConfigurationExpressionAdapter
{
    public MapperConfigurationExpression MapperConfigurationExpression { get; }

    public MapperConfigurationExpressionAdapter(MapperConfigurationExpression mapperConfigurationExpression)
    {
        this.MapperConfigurationExpression = mapperConfigurationExpression;
    }
}
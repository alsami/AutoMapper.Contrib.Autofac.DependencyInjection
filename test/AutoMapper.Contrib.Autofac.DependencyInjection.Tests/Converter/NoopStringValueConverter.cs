namespace AutoMapper.Contrib.Autofac.DependencyInjection.Tests.Converter
{
    public class NoopStringValueConverter : IValueConverter<string, string>
    {
        public string Convert(string sourceMember, ResolutionContext context) => sourceMember;
    }
}
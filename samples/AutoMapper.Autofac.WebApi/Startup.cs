using Autofac;
using AutoMapper.Autofac.Shared.Entities;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace AutoMapper.Autofac.WebApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterAutoMapper(typeof(Customer).Assembly);
    }
}
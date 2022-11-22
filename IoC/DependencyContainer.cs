using DatabaseConnection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.FormProducto;
using Presenters.ListProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CreateProducto;
using UseCases.FormProducto;
using UseCases.ListProducto;
using UseCasesPorts.FormProducto;
using UseCasesPorts.ListProducto;

namespace IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddProductoServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<Conexion>();

            services.AddScoped<IListProductoInputPort, ListProductoInteractor>();
            services.AddScoped<IListProductoOutputPort, ListProductoPresenter>();

            services.AddScoped<ICreateProductoInputPort, CreateProductoInteractor>();
            services.AddScoped<ICreateProductoOutputPort, CreateProductoPresenter>();

            services.AddScoped<IUpdateProductoInputPort, UpdateProductoInteractor>();
            services.AddScoped<IUpdateProductoOutputPort, UpdateProductoPresenter>();

            services.AddScoped<IDeleteProductoInputPort, DeleteProductoInteractor>();
            services.AddScoped<IDeleteProductoOutputPort, DeleteProductoPresenter>();

            return services;
        }
    }
}

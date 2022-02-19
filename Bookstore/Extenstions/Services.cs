using Bookstore.Services;
using Bookstore.Services.Interface;
using BookStore.Business.Authors;
using BookStore.Business.Languages;
using BookStore.Business.Publishers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApi.Extenstions
{
    public static class Services
    {
        public static void ServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<IBooks,Books>();
            services.AddScoped<IPublishers,Publishers>();
            services.AddScoped<ILanguages,Languages>();
            services.AddScoped<IAuthors,Authors>();

        }
    }
}

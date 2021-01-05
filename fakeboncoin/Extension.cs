using fakeboncoin.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeboncoin
{
    public static class Extension
    {
        public static void AddAll(this IServiceCollection services)
        {
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddTransient<IFavoris, FavorisCookieService>();
        }
    }
}

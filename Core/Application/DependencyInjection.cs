using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddMediatR(y => y.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}

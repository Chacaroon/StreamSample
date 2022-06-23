using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder;
public static class FromBuilderExtensions
{
    public static IServiceCollection AddFormBuilder(this IServiceCollection services)
    {
        services.AddSingleton<FormBuilderFactory>();

        return services;
    }
}

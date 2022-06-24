using FormBuilder.Strategies;
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
        services.AddTransient<StrategyResolver>();

        services.AddTransient<BaseStrategy, FormControlStrategy>();
        services.AddTransient<BaseStrategy, FormGroupStrategy>();
        services.AddTransient<BaseStrategy, FormArrayStrategy>();

        return services;
    }
}

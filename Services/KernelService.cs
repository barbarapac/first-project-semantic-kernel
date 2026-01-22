using first_project_semantic_kernel._Shared;
using first_project_semantic_kernel.Plugins;
using Microsoft.SemanticKernel;

namespace first_project_semantic_kernel.Services;

public static class KernelService
{
    public static Kernel CreateKernel()
    {
        var builder = Kernel
            .CreateBuilder()
            .AddOllamaChatCompletion(
                modelId: AppConfig.ModelId,
                endpoint: new Uri(AppConfig.OllamaEndpoint)
            );

        builder.Services
            .AddLogging(x => x
                .AddConsole()
                .SetMinimumLevel(LogLevel.Trace)
            );

        var kernel = builder.Build();
        kernel.Plugins.AddFromType<ProductPlugins>("Plugins");

        return kernel;
    }
}
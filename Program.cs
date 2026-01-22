using first_project_semantic_kernel.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;

var builder = Kernel.CreateBuilder()
    .AddOllamaChatCompletion(
        modelId: "llama3.1:latest",
        endpoint:  new Uri("http://localhost:11434")
    );
    
builder.Services.AddLogging(x => x.AddConsole().SetMinimumLevel(LogLevel.Trace));
 
var app = builder.Build();
var chatCompletionService = app.Services.GetRequiredService<IChatCompletionService>();

app.Plugins.AddFromType<ProductPlugins>("Plugins");

OllamaPromptExecutionSettings settings = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

var history = new ChatHistory();

string? input;

do
{
    Console.Write("User > ");
    input = Console.ReadLine();
    
    if (!string.IsNullOrWhiteSpace(input))
    {
        history.AddUserMessage(input);   
        var result = await chatCompletionService
            .GetChatMessageContentAsync(
                chatHistory: history,
                executionSettings: settings,
                kernel: app);
    
        Console.WriteLine($"Assistant > {result}");
        
        history.AddMessage(result.Role, result.Content ?? string.Empty);
    }
} while (input is not null);
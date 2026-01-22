using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;

namespace first_project_semantic_kernel.Services;

public class ChatService
{
    private readonly IChatCompletionService _chatCompletionService;
    private readonly Kernel _kernel;
    private readonly ChatHistory _history;
    private readonly OllamaPromptExecutionSettings _settings;

    public ChatService(Kernel kernel)
    {
        _kernel                = kernel;
        _chatCompletionService = kernel.Services.GetRequiredService<IChatCompletionService>();
        _history               = new ChatHistory();
        _settings              = new OllamaPromptExecutionSettings
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
        };
    }

    public async Task<string> SendMessageAsync(string userMessage)
    {
        _history.AddUserMessage(userMessage);

        var result = await _chatCompletionService
            .GetChatMessageContentAsync(
                chatHistory:       _history,
                executionSettings: _settings,
                kernel:            _kernel
            );

        _history.AddMessage(result.Role, result.Content ?? string.Empty);

        return result.Content ?? string.Empty;
    }
}
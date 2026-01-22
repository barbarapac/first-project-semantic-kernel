using first_project_semantic_kernel._Shared;

namespace first_project_semantic_kernel.Services;

public static class ConsoleService
{
    public static string? ReadUserInput()
    {
        Console.Write(AppConfig.UserPrompt);
        return Console.ReadLine();
    }

    public static void WriteAssistantResponse(string response)
    {
        Console.WriteLine($"{AppConfig.AssistantPrompt}{response}");
    }

    public static bool IsValidInput(string? input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }
}
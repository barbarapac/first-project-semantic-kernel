using first_project_semantic_kernel.Services;

var kernel      = KernelService.CreateKernel();
var chatService = new ChatService(kernel);

string? input;

do
{
    input = ConsoleService.ReadUserInput();
    
    if (ConsoleService.IsValidInput(input))
    {
        var response = await chatService.SendMessageAsync(input!);
        ConsoleService.WriteAssistantResponse(response);
    }
} while (input is not null);
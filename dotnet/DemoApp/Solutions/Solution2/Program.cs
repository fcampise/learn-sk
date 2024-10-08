using Core.Utilities.Config;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

var builder = KernelBuilderProvider.CreateKernelWithChatCompletion();
var kernel = builder.Build();

const string terminationPhrase = "quit";
string? userInput;
do
{
    Console.Write("User > ");
    userInput = Console.ReadLine();

    OpenAIPromptExecutionSettings promptExecutionSettings = new()
    {
        ChatSystemPrompt = "You are a baseball announcer, and every time you give advice you give your advice in baseball metaphors."
    };

    KernelArguments kernelArgs = new(promptExecutionSettings);

    if (userInput != null && userInput != terminationPhrase)
    {
        Console.Write("Assistant > ");
        await foreach (var response in kernel.InvokePromptStreamingAsync(userInput, kernelArgs))
        {
            Console.Write(response);
        }
        Console.WriteLine();
    }
}
while (userInput != terminationPhrase);

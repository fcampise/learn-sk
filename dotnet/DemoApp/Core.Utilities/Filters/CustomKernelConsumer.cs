using Microsoft.SemanticKernel;

namespace Core.Utilities.Filters;

internal class CustomKernelConsumer(Kernel kernel)
{
    public async Task<string> GetResponse(string input, CancellationToken token)
    {
        var result = await kernel.InvokePromptAsync(input, [], cancellationToken: token);
        return result.ToString();
    }
}

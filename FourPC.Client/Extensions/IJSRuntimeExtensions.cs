using Microsoft.JSInterop;

namespace FourPC.Client.Extensions;

public static class IJSRuntimeExtensions
{
    public static async ValueTask<BoundingRect> GetBoundingRect(this IJSRuntime js, string elementId)
    {
        var boundingRect = await js.InvokeAsync<BoundingRect>("ijsRuntimeExtensions.getBoundingRect", elementId);
        return boundingRect;
    }
}

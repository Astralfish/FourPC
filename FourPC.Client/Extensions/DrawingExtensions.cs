using System.Drawing;

namespace FourPC.Client.Extensions;

public static class DrawingExtensions
{
    public static string ToHex(this Color color)
    {
        return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    }
}

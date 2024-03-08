namespace FourPC.Core.Chessboard.Cells;

public class CellId
{
    public int Value { get; private init; }

    public CellId(int value)
    {
        Value = value;
    }

    public static int Min = 0;
    public static int Max = 159;
}

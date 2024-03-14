﻿namespace FourPC.Core.Chessboard.Cells;

public class CellPosition
{
    public int X { get; private init; }

    public int Y { get; private init; }

    public CellPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public CellPosition(int n)
    {
        X = n % (Max + 1);
        Y = n / (Max + 1);
    }

    public static CellPosition operator+(CellPosition lhs, CellPosition rhs) => new CellPosition(lhs.X + rhs.X, lhs.Y + rhs.Y);

    public bool IsValid => X >= 0 && X <= Max && Y > 0 && Y < Max;

    public static int Min = 0;
    public static int Max = 13;
}

﻿using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Pieces;

namespace FourPC.Core.MoveGeneration;

public class KingMoveGenerator
{
    public static IEnumerable<Move> Generate(Board board, Piece piece)
    {
        return RayCaster.CastAllDirections(board, piece, 1);
    }
}
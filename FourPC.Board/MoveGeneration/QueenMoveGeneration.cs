using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Pieces;

namespace FourPC.Core.MoveGeneration;

public class QueenMoveGeneration
{
    public static IEnumerable<Move> Generate(Board board, Piece piece)
    {
        return RookMoveGenerator.Generate(board, piece)
            .Concat(BishopMoveGenerator.Generate(board, piece));
    }
}

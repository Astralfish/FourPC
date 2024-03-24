using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Pieces;

namespace FourPC.Core.MoveGeneration;

public class BishopMoveGenerator
{
    public static IEnumerable<Move> Generate(Board board, Piece piece)
    {
        return RayCaster.CastDiagonal(board, piece);
    }
}

using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Pieces;

namespace FourPC.Core.MoveGeneration;

public class RookMoveGenerator
{
    public static IEnumerable<Move> Generate(Board board, Piece piece)
    {
        return RayCaster.CastAlongAxes(board, piece);
    }
}

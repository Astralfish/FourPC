using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;

namespace FourPC.Core.MoveGeneration;

public class BishopMoveGenerator
{
    public static IEnumerable<Move> Generate(Board board, Piece piece)
    {
        return RayCaster.CastRay(board, piece, new CellPosition(1, 1))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(1, -1)))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(-1, 1)))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(-1, -1)));
    }
}

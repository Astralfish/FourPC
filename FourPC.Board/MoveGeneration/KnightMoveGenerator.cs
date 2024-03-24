using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard;

namespace FourPC.Core.MoveGeneration;

public class KnightMoveGenerator
{
    public static IEnumerable<Move> CastAlongAxes(Board board, Piece piece, int length = int.MaxValue)
    {
        return RayCaster.CastRay(board, piece, new CellPosition(1, 2), length)
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(-1, 2), length))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(1, -2), length))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(-1, -2), length))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(2, 1), length))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(2, -1), length))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(-2, 1), length))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(-2, -1), length));
    }
}

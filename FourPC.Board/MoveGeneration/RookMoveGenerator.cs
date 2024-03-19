using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;

namespace FourPC.Core.MoveGeneration;

public class RookMoveGenerator
{
    public IEnumerable<Move> Generate(Board board, Piece piece)
    {
        return RayCaster.CastRay(board, piece, new CellPosition(0, 1))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(0, -1)))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(1, 0)))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(-1, 0)));
    }
}

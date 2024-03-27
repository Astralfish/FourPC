using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPC.Core.MoveGeneration;
internal class PawnMoveGenerator
{
    public static IEnumerable<Move> Generate(Board board, Piece piece, int length = int.MaxValue)
    {
        return RayCaster.CastRay(board, piece, board.GetForwardDirection(piece), length, false)
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(-1, 0), length))
            .Concat(RayCaster.CastRay(board, piece, new CellPosition(0, -1), length));
    }
}

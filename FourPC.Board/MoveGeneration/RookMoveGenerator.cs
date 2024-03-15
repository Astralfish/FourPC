using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPC.Core.MoveGeneration;

public class RookMoveGenerator
{
    public IEnumerable<Move> Generate(Board board, Piece piece)
    {
        return CastRay(board, piece, new CellPosition(0, 1))
            .Concat(CastRay(board, piece, new CellPosition(0, -1)))
            .Concat(CastRay(board, piece, new CellPosition(1, 0)))
            .Concat(CastRay(board, piece, new CellPosition(-1, 0)));
    }

    //TODO: method the same for bishops and queen, refactor to separate class
    //TODO: tests
    private IEnumerable<Move> CastRay(Board board, Piece piece, CellPosition offset)
    {
        var targetPosition = piece.Position + offset;
        while (targetPosition.IsValid)
        {
            var targetPiece = board.PieceAt(targetPosition);
            if (targetPiece == null)
            {
                yield return new Move(piece.Position, targetPosition, false);
            }
            else if (targetPiece.Owner != piece.Owner)
            {
                yield return new Move(piece.Position, targetPosition, true);
            }
            else
            {
                yield break;
            }
        }
    }
}

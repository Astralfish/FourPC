using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard;

namespace FourPC.Core.MoveGeneration;
internal class RayCaster
{
    public static IEnumerable<Move> CastRay(Board board, Piece piece, CellPosition offset)
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
                yield break;
            }
            else
            {
                yield break;
            }
            targetPosition = targetPosition + offset;
        }
    }
}

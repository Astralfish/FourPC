using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard;

namespace FourPC.Core.MoveGeneration;
internal class RayCaster
{
    public static IEnumerable<Move> CastRay(Board board, Piece piece, CellPosition offset, int length = int.MaxValue)
    {
        var targetPosition = piece.Position + offset;
        var currentLength = 1;
        while (targetPosition.IsValid && currentLength <= length)
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
            currentLength++;
        }
    }

    public static IEnumerable<Move> CastAlongAxes(Board board, Piece piece, int length = int.MaxValue)
    {
        return CastRay(board, piece, new CellPosition(1, 0), length)
            .Concat(CastRay(board, piece, new CellPosition(-1, 0), length))
            .Concat(CastRay(board, piece, new CellPosition(0, 1), length))
            .Concat(CastRay(board, piece, new CellPosition(0, -1), length));
    }

    public static IEnumerable<Move> CastDiagonal(Board board, Piece piece, int length = int.MaxValue)
    {
        return CastRay(board, piece, new CellPosition(1, 1), length)
            .Concat(CastRay(board, piece, new CellPosition(1, -1), length))
            .Concat(CastRay(board, piece, new CellPosition(-1, 1), length))
            .Concat(CastRay(board, piece, new CellPosition(-1, -1), length));
    }

    public static IEnumerable<Move> CastAllDirections(Board board, Piece piece, int length = int.MaxValue)
    {
        return CastAlongAxes(board, piece, length)
            .Concat(CastDiagonal(board, piece, length));
    }
}

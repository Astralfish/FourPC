using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard;

namespace FourPC.Core.MoveGeneration;
internal class RayCaster
{
    public static IEnumerable<Move> CastRay(Board board, Piece piece, CellPosition offset, int length = int.MaxValue, bool canCapture = true)
    {
        var targetPosition = piece.Position + offset;
        var currentLength = 1;
        while (targetPosition.IsValid && currentLength <= length)
        {
            var targetPiece = board.PieceAt(targetPosition);
            if (!targetPiece.HasValue)
            {
                yield return new Move(piece, targetPosition, false);
            }
            else if (targetPiece.ValueOr(piece).Owner != piece.Owner && canCapture)
            {
                yield return new Move(piece, targetPosition, true);
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

    public static IEnumerable<Move> CastRay(Board board, Piece piece, CellPosition offset)
    {
        var targetPosition = piece.Position + offset;
        var currentLength = 1;
        while (board.IsValid(targetPosition))
        {
            yield return new Move(piece, targetPosition, false);
            targetPosition = targetPosition + offset;
            currentLength++;
        }
    }

    public static IEnumerable<Move> MapIf(IEnumerable<Move> ray, bool condition, Func<IEnumerable<Move>, IEnumerable<Move>> map) 
    {
        if (condition)
        {
            return map(ray);
        }
        else
        {
            return ray;
        }
    }

    public static IEnumerable<Move> LimitLength(IEnumerable<Move> ray, int length)
    {
        return ray.Take(length);
    }

    public static IEnumerable<Move> Capture(IEnumerable<Move> ray, Board board, Func<(Piece own, Piece other), bool> capturePredicate)
    {
        foreach (var move in ray)
        {
            var targetPiece = board.PieceAt(move.To);

            yield return targetPiece.Match(
                some: p => new Move(move.Piece, move.To, capturePredicate((move.Piece, p))),
                none: () => move);
        }
    }

    public static IEnumerable<Move> StopAtCapture(IEnumerable<Move> ray)
    {
        foreach (var move in ray)
        {
            yield return move;
            if (move.IsCapture)
            {
                yield break;
            }
        }
    }
}

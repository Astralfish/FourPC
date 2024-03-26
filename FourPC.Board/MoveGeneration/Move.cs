using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using Optional;

namespace FourPC.Core.MoveGeneration;

public record Move(Piece Piece, CellPosition To, bool IsCapture, Option<PieceType> Promotion)
{ 
    public Move(Piece piece, CellPosition to, bool isCapture)
        : this(piece, to, isCapture, Option.None<PieceType>())
    {
    }
}

using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;

namespace FourPC.Core.MoveGeneration;

public record Move(Piece piece, CellPosition To, bool IsCapture, )
{ 
}

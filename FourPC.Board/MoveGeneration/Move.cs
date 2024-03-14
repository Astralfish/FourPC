using FourPC.Core.Chessboard.Cells;

namespace FourPC.Core.MoveGeneration;

public record Move(CellPosition From, CellPosition To, bool IsCapture)
{ 
}

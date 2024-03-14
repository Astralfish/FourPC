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

    }

    public HashSet<CellPosition> MovementPattern(CellPosition start)
    {
        var result = new HashSet<CellPosition>();

    }

    private IEnumerable<CellPosition> ShootRay(Board board, CellPosition start, CellPosition offset)
    {
        var currentPosition = start + offset;
        while (currentPosition.IsValid)
        {
            if (board)
        }
    }
}

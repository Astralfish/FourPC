using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard.Players;

namespace FourPC.Core.Chessboard;

public record Board
{
    public Board(IEnumerable<CellType> cells, IEnumerable<Piece> pieces, IEnumerable<Player> players)
    {
        Cells = cells;
        Pieces = pieces;
        Players = players;
    }

    public IEnumerable<CellType> Cells { get; private init; }

    public IEnumerable<Piece> Pieces { get; private init; }

    public IEnumerable<Player> Players { get; private init; }

}

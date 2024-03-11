using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard.Players;

namespace FourPC.Core.Chessboard;

public record Board
{
    public const int Size = 14;

    public Board(IReadOnlyCollection<CellType> cells, IReadOnlyCollection<Piece> pieces, IReadOnlyCollection<Player> players)
    {
        Cells = cells;
        Pieces = pieces;
        Players = players;
    }

    public IReadOnlyCollection<CellType> Cells { get; private init; }

    public IReadOnlyCollection<Piece> Pieces { get; private init; }

    public IReadOnlyCollection<Player> Players { get; private init; }

    public IEnumerable<IEnumerable<CellType>> Cells2D => Cells.Chunk(Size);

}

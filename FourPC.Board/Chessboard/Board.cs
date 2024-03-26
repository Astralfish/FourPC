using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard.Players;
using Optional;
using Optional.Collections;

namespace FourPC.Core.Chessboard;

public record Board
{
    public const int Size = 14;
    public int MaxPosition => Size - 1;
    public int MinPosition => 0;

    public Board(IReadOnlyCollection<CellType> cells, IReadOnlyCollection<Piece> pieces, IReadOnlyCollection<Player> players)
    {
        Cells = cells;
        Pieces = pieces;
        Players = players;
    }

    //TODO: cells are needed only for drawing, it should not be a part of board state
    public IReadOnlyCollection<CellType> Cells { get; private init; }

    public IReadOnlyCollection<Piece> Pieces { get; private init; }

    public IReadOnlyCollection<Player> Players { get; private init; }

    public IEnumerable<IEnumerable<CellType>> Cells2D => Cells.Chunk(Size);

    public Option<Piece> PieceAt(CellPosition position) => Pieces.FirstOrNone(p => p.Position == position);

    public bool IsStartingPosition(Piece piece)
    {
        throw new NotImplementedException();
    }

    public bool CanPromoteAtPosition(Piece piece, CellPosition position)
    {
        throw new NotImplementedException();
    }

    public bool IsValid(CellPosition position) => (position.X >= 3 && position.X <= MaxPosition - 3 && position.Y >= MinPosition && position.Y <= MaxPosition) ||
        (position.X >= MinPosition && position.X <= MaxPosition && position.Y >= 3 && position.Y <= MaxPosition - 3);
}

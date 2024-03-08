using FourPC.Core.Board.Pieces;
using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Players;

namespace FourPC.Core.Chessboard.Pieces;

public record Piece
{
    public Piece(PieceType pieceType, PlayerNumber owner, CellId position)
    {
        PieceType = pieceType;
        Owner = owner;
        Position = position;
    }

    public PieceType PieceType { get; private init; }

    public PlayerNumber Owner { get; private init; }

    public CellId Position { get; private init; }
}

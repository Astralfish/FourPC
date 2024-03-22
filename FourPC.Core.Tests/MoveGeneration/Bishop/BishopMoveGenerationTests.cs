using FluentAssertions;
using FourPC.Core.BoardGeneration;
using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard.Players;
using FourPC.Core.MoveGeneration;

namespace FourPC.Core.Tests.MoveGeneration.Bishop;

public class BishopMoveGenerationTests
{
    [Fact]
    public void BishopShouldMoveDiagonally()
    {
        var cells = BoardGenerator.GenerateCells();
        var players = BoardGenerator.GeneratePlayers();
        var bishop = new Piece(PieceType.Bishop, PlayerNumber.PlayerBottom, new CellPosition(7, 1));
        var board = new Board(cells.ToList(), new List<Piece>() { bishop }, players);

        var result = BishopMoveGenerator.Generate(board, bishop).ToList();
        var expected = new List<Move>()
        {
            new Move(new CellPosition(7, 1), new CellPosition(6, 0), false),

            new Move(new CellPosition(7, 1), new CellPosition(6, 2), false),
            new Move(new CellPosition(7, 1), new CellPosition(5, 3), false),
            new Move(new CellPosition(7, 1), new CellPosition(4, 4), false),
            new Move(new CellPosition(7, 1), new CellPosition(3, 5), false),
            new Move(new CellPosition(7, 1), new CellPosition(2, 6), false),
            new Move(new CellPosition(7, 1), new CellPosition(1, 7), false),
            new Move(new CellPosition(7, 1), new CellPosition(0, 8), false),

            new Move(new CellPosition(7, 1), new CellPosition(8, 0), false),

            new Move(new CellPosition(7, 1), new CellPosition(8, 2), false),
            new Move(new CellPosition(7, 1), new CellPosition(9, 3), false),
            new Move(new CellPosition(7, 1), new CellPosition(10, 4), false),
            new Move(new CellPosition(7, 1), new CellPosition(11, 5), false),
            new Move(new CellPosition(7, 1), new CellPosition(12, 6), false),
            new Move(new CellPosition(7, 1), new CellPosition(13, 7), false),

        };
        result.Should().BeEquivalentTo(expected, o => o.WithoutStrictOrdering());
    }

    [Fact]
    public void BishopShouldCaptureHorizontallyOrVertically()
    {
        var cells = BoardGenerator.GenerateCells();
        var players = BoardGenerator.GeneratePlayers();
        var bishop = new Piece(PieceType.Bishop, PlayerNumber.PlayerBottom, new CellPosition(7, 1));
        var pieces = new List<Piece>()
        {
            bishop,
            new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(6, 0)),
            new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(3, 5)),
            new Piece(PieceType.Knight, PlayerNumber.PlayerTop, new CellPosition(8, 0)),
            new Piece(PieceType.Bishop, PlayerNumber.PlayerTop, new CellPosition(12, 6)),
        };
        var board = new Board(cells.ToList(), pieces, players);

        var result = BishopMoveGenerator.Generate(board, bishop).ToList();
        var expected = new List<Move>()
        {
            new Move(new CellPosition(7, 1), new CellPosition(6, 0), true),

            new Move(new CellPosition(7, 1), new CellPosition(6, 2), false),
            new Move(new CellPosition(7, 1), new CellPosition(5, 3), false),
            new Move(new CellPosition(7, 1), new CellPosition(4, 4), false),
            new Move(new CellPosition(7, 1), new CellPosition(3, 5), true),

            new Move(new CellPosition(7, 1), new CellPosition(8, 0), true),

            new Move(new CellPosition(7, 1), new CellPosition(8, 2), false),
            new Move(new CellPosition(7, 1), new CellPosition(9, 3), false),
            new Move(new CellPosition(7, 1), new CellPosition(10, 4), false),
            new Move(new CellPosition(7, 1), new CellPosition(11, 5), false),
            new Move(new CellPosition(7, 1), new CellPosition(12, 6), true),
        };
        result.Should().BeEquivalentTo(expected, o => o.WithoutStrictOrdering());
    }
}

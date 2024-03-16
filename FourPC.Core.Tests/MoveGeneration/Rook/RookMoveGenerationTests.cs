using FluentAssertions;
using FourPC.Core.BoardGeneration;
using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard.Players;
using FourPC.Core.MoveGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPC.Core.Tests.MoveGeneration.Rook;

public class RookMoveGenerationTests
{
    [Fact]
    public void RookShouldMoveHorizontallyOrVertically()
    {
        var cells = BoardGenerator.GenerateCells();
        var players = BoardGenerator.GeneratePlayers();
        var rook = new Piece(PieceType.Rook, PlayerNumber.PlayerBottom, new CellPosition(7, 1));
        var board = new Board(cells.ToList(), new List<Piece>() { rook }, players);

        var rookMoveGenerator = new RookMoveGenerator();
        var result = rookMoveGenerator.Generate(board, rook).ToList();
        var expected = new List<Move>()
        {
            new Move(new CellPosition(7, 1), new CellPosition(7, 2), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 3), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 4), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 5), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 6), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 7), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 8), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 9), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 10), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 11), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 12), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 13), false),
            new Move(new CellPosition(7, 1), new CellPosition(7, 0), false),

            new Move(new CellPosition(7, 1), new CellPosition(8, 1), false),
            new Move(new CellPosition(7, 1), new CellPosition(9, 1), false),
            new Move(new CellPosition(7, 1), new CellPosition(10, 1), false),
            new Move(new CellPosition(7, 1), new CellPosition(6, 1), false),
            new Move(new CellPosition(7, 1), new CellPosition(5, 1), false),
            new Move(new CellPosition(7, 1), new CellPosition(4, 1), false),
            new Move(new CellPosition(7, 1), new CellPosition(3, 1), false),
        };
        result.Should().BeEquivalentTo(expected, o => o.WithoutStrictOrdering());
    }
}

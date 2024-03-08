using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard.Players;

namespace FourPC.Core.BoardGeneration;

public class BoardGenerator
{
    public Board GenerateInitial() => new Board(GenerateCells(), GeneratePieces(), GeneratePlayers());

    internal static IEnumerable<CellType> GenerateCells() =>
        Enumerable.Range(CellId.Min, CellId.Max)
            .Select(n => new CellId(n))
            .Select(CellIdToType);

    internal static IEnumerable<Piece> GeneratePieces() => StartingArrangement;

    internal static IEnumerable<Player> GeneratePlayers() => StartingPlayers;

    private static CellType CellIdToType(CellId cellId) => (CellType)(cellId.Value % 2);

    private static List<Piece> StartingArrangement = new List<Piece>
    {
        new Piece(PieceType.Rook, PlayerNumber.Player1, new CellId(0)),
        new Piece(PieceType.Knight, PlayerNumber.Player1, new CellId(1)),
        new Piece(PieceType.Bishop, PlayerNumber.Player1, new CellId(2)),
        new Piece(PieceType.King, PlayerNumber.Player1, new CellId(3)),
        new Piece(PieceType.Queen, PlayerNumber.Player1, new CellId(4)),
        new Piece(PieceType.Bishop, PlayerNumber.Player1, new CellId(5)),
        new Piece(PieceType.Knight, PlayerNumber.Player1, new CellId(6)),
        new Piece(PieceType.Rook, PlayerNumber.Player1, new CellId(7)),
        //TODO: rest of the pieces
    };

    private static List<Player> StartingPlayers = new List<Player>
    {
        new Player(PlayerNumber.Player1),
        new Player(PlayerNumber.Player2),
        new Player(PlayerNumber.Player3),
        new Player(PlayerNumber.Player4),
    };
}

using FourPC.Core.Chessboard;
using FourPC.Core.Chessboard.Cells;
using FourPC.Core.Chessboard.Pieces;
using FourPC.Core.Chessboard.Players;

namespace FourPC.Core.BoardGeneration;

public class BoardGenerator
{
    public static Board GenerateInitial() => new Board(GenerateCells().ToList(), GeneratePieces(), GeneratePlayers());

    internal static IEnumerable<CellType> GenerateCells()
    {
        for (int y = 0; y <= CellPosition.Max; y ++)
        {

            for (int x = 0; x <= CellPosition.Max; x++)
            {
                yield return CellPositionToType(new CellPosition(x, y));
            }
        }
    }

    internal static IReadOnlyCollection<Piece> GeneratePieces() => StartingArrangement.AsReadOnly();

    internal static IReadOnlyCollection<Player> GeneratePlayers() => StartingPlayers.AsReadOnly();

    private static CellType CellPositionToType(CellPosition cellId) => cellId switch
    {
        { X: (>= 0 and <= 2) or (>= 11 and <= 13), Y: (>= 0 and <= 2) or (>= 11 and <= 13) } => CellType.Nothing,
        { X: int x, Y: int y } when ((x ^ y) & 1) == 1 => CellType.White,
        _ => CellType.Black,
    };

    private static List<Piece> StartingArrangement = new List<Piece>
    {
        new Piece(PieceType.Rook, PlayerNumber.Player1, new CellPosition(3, 0)),
        new Piece(PieceType.Knight, PlayerNumber.Player1, new CellPosition(4, 0)),
        new Piece(PieceType.Bishop, PlayerNumber.Player1, new CellPosition(5, 0)),
        new Piece(PieceType.King, PlayerNumber.Player1, new CellPosition(6, 0)),
        new Piece(PieceType.Queen, PlayerNumber.Player1, new CellPosition(7, 0)),
        new Piece(PieceType.Bishop, PlayerNumber.Player1, new CellPosition(8, 0)),
        new Piece(PieceType.Knight, PlayerNumber.Player1, new CellPosition(9, 0)),
        new Piece(PieceType.Rook, PlayerNumber.Player1, new CellPosition(10, 0)),
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

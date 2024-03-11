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
        new Piece(PieceType.Rook, PlayerNumber.PlayerBottom, new CellPosition(3, 13)),
        new Piece(PieceType.Knight, PlayerNumber.PlayerBottom, new CellPosition(4, 13)),
        new Piece(PieceType.Bishop, PlayerNumber.PlayerBottom, new CellPosition(5, 13)),
        new Piece(PieceType.King, PlayerNumber.PlayerBottom, new CellPosition(6, 13)),
        new Piece(PieceType.Queen, PlayerNumber.PlayerBottom, new CellPosition(7, 13)),
        new Piece(PieceType.Bishop, PlayerNumber.PlayerBottom, new CellPosition(8, 13)),
        new Piece(PieceType.Knight, PlayerNumber.PlayerBottom, new CellPosition(9, 13)),
        new Piece(PieceType.Rook, PlayerNumber.PlayerBottom, new CellPosition(10, 13)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerBottom, new CellPosition(3, 12)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerBottom, new CellPosition(4, 12)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerBottom, new CellPosition(5, 12)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerBottom, new CellPosition(6, 12)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerBottom, new CellPosition(7, 12)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerBottom, new CellPosition(8, 12)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerBottom, new CellPosition(9, 12)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerBottom, new CellPosition(10, 12)),

        new Piece(PieceType.Rook, PlayerNumber.PlayerLeft, new CellPosition(0, 3)),
        new Piece(PieceType.Knight, PlayerNumber.PlayerLeft, new CellPosition(0, 4)),
        new Piece(PieceType.Bishop, PlayerNumber.PlayerLeft, new CellPosition(0, 5)),
        new Piece(PieceType.King, PlayerNumber.PlayerLeft, new CellPosition(0, 6)),
        new Piece(PieceType.Queen, PlayerNumber.PlayerLeft, new CellPosition(0, 7)),
        new Piece(PieceType.Bishop, PlayerNumber.PlayerLeft, new CellPosition(0, 8)),
        new Piece(PieceType.Knight, PlayerNumber.PlayerLeft, new CellPosition(0, 9)),
        new Piece(PieceType.Rook, PlayerNumber.PlayerLeft, new CellPosition(0, 10)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(1, 3)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(1, 4)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(1, 5)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(1, 6)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(1, 7)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(1, 8)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(1, 9)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerLeft, new CellPosition(1, 10)),

        new Piece(PieceType.Rook, PlayerNumber.PlayerTop, new CellPosition(3, 0)),
        new Piece(PieceType.Knight, PlayerNumber.PlayerTop, new CellPosition(4, 0)),
        new Piece(PieceType.Bishop, PlayerNumber.PlayerTop, new CellPosition(5, 0)),
        new Piece(PieceType.King, PlayerNumber.PlayerTop, new CellPosition(6, 0)),
        new Piece(PieceType.Queen, PlayerNumber.PlayerTop, new CellPosition(7, 0)),
        new Piece(PieceType.Bishop, PlayerNumber.PlayerTop, new CellPosition(8, 0)),
        new Piece(PieceType.Knight, PlayerNumber.PlayerTop, new CellPosition(9, 0)),
        new Piece(PieceType.Rook, PlayerNumber.PlayerTop, new CellPosition(10, 0)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerTop, new CellPosition(3, 1)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerTop, new CellPosition(4, 1)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerTop, new CellPosition(5, 1)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerTop, new CellPosition(6, 1)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerTop, new CellPosition(7, 1)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerTop, new CellPosition(8, 1)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerTop, new CellPosition(9, 1)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerTop, new CellPosition(10, 1)),


        new Piece(PieceType.Rook, PlayerNumber.PlayerRight, new CellPosition(13, 3)),
        new Piece(PieceType.Knight, PlayerNumber.PlayerRight, new CellPosition(13, 4)),
        new Piece(PieceType.Bishop, PlayerNumber.PlayerRight, new CellPosition(13, 5)),
        new Piece(PieceType.King, PlayerNumber.PlayerRight, new CellPosition(13, 6)),
        new Piece(PieceType.Queen, PlayerNumber.PlayerRight, new CellPosition(13, 7)),
        new Piece(PieceType.Bishop, PlayerNumber.PlayerRight, new CellPosition(13, 8)),
        new Piece(PieceType.Knight, PlayerNumber.PlayerRight, new CellPosition(13, 9)),
        new Piece(PieceType.Rook, PlayerNumber.PlayerRight, new CellPosition(13, 10)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(12, 3)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(12, 4)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(12, 5)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(12, 6)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(12, 7)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(12, 8)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(12, 9)),
        new Piece(PieceType.Pawn, PlayerNumber.PlayerRight, new CellPosition(12, 10)),


        //TODO: rest of the pieces
    };

    private static List<Player> StartingPlayers = new List<Player>
    {
        new Player(PlayerNumber.PlayerBottom),
        new Player(PlayerNumber.PlayerLeft),
        new Player(PlayerNumber.PlayerTop),
        new Player(PlayerNumber.PlayerRight),
    };
}

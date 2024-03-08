namespace FourPC.Core.Chessboard.Players;

public class Player
{
    public PlayerNumber Number { get; private set; }

    public bool HasCastlingRightsQueenside { get; private set; }

    public bool HasCastlingRightsKingside { get; private set; }

    public Player(PlayerNumber number)
    {
        Number = number;
        HasCastlingRightsKingside = true;
        HasCastlingRightsQueenside = true;
    }

    public void RemoveCastlingRights()
    {
        HasCastlingRightsKingside = false;
        HasCastlingRightsQueenside = false;
    }

    public void RemoveCastlingRightsKingside()
    {
        HasCastlingRightsKingside = false;
    }

    public void RemoveCastlingRightsQueenside()
    {
        HasCastlingRightsQueenside = false;
    }

}

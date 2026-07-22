using BeatingQueensGambit.Core.Game;

namespace BeatingQueensGambit.Core.Openings;

public static class OpeningReplay
{
    public static void PlayOpening(
        ChessGame game,
        OpeningType opening)
    {
        var moves =
            OpeningBook.GetLine(opening);

        foreach (var moveText in moves)
        {
            var move =
                OpeningMoveParser.Parse(moveText);

            game.MakeMove(move);
        }
    }
}
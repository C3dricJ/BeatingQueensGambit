using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Openings;

public static class OpeningLoader
{
    public static void Load(
        ChessBoard board,
        OpeningType opening)
    {
        switch (opening)
        {
            case OpeningType.Standard:
                BoardInitializer.InitializeStandardBoard(board);
                break;

            case OpeningType.QueensGambitAccepted:
                LoadQueensGambitAccepted(board);
                break;

            case OpeningType.QueensGambitDeclined:
                LoadQueensGambitDeclined(board);
                break;

            case OpeningType.SlavDefense:
                LoadSlav(board);
                break;

            case OpeningType.SemiSlav:
                LoadSemiSlav(board);
                break;

            case OpeningType.ChigorinDefense:
                LoadChigorin(board);
                break;

            case OpeningType.AlbinCounterGambit:
                LoadAlbin(board);
                break;

            case OpeningType.RandomTraining:
                LoadRandom(board);
                break;
        }
    }

    static void LoadQueensGambitAccepted(ChessBoard board)
    {

    }

    static void LoadQueensGambitDeclined(ChessBoard board)
    {

    }

    static void LoadSlav(ChessBoard board)
    {

    }

    static void LoadSemiSlav(ChessBoard board)
    {

    }

    static void LoadChigorin(ChessBoard board)
    {

    }

    static void LoadAlbin(ChessBoard board)
    {

    }

    static void LoadRandom(ChessBoard board)
    {

    }
}
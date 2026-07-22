using System;
using BeatingQueensGambit.Core.Board;

namespace BeatingQueensGambit.Core.Openings;

public static class OpeningLoader
{
    private static readonly Random _random = new();

    public static void Load(
        ChessBoard board,
        OpeningType opening)
    {
        switch (opening)
        {
            case OpeningType.Standard:
                LoadStandard(board);
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

            case OpeningType.Chigorin:
                LoadChigorin(board);
                break;

            case OpeningType.Albin:
                LoadAlbin(board);
                break;

            case OpeningType.RandomQueensGambit:
                LoadRandom(board);
                break;
        }
    }

    //--------------------------------------------------------
    // Individual Openings
    //--------------------------------------------------------

    private static void LoadStandard(ChessBoard board)
    {
        BoardInitializer.InitializeStandardBoard(board);
    }

    private static void LoadQueensGambitAccepted(
        ChessBoard board)
    {
        BoardInitializer.InitializeStandardBoard(board);

        BoardInitializer.ApplyMove(board, "d2", "d4");

        BoardInitializer.ApplyMove(board, "d7", "d5");

        BoardInitializer.ApplyMove(board, "c2", "c4");

        BoardInitializer.ApplyMove(board, "d5", "c4");
    }

    private static void LoadQueensGambitDeclined(ChessBoard board)
    {
        BoardInitializer.InitializeStandardBoard(board);
    }

    private static void LoadSlav(ChessBoard board)
    {
        BoardInitializer.InitializeStandardBoard(board);
    }

    private static void LoadSemiSlav(ChessBoard board)
    {
        BoardInitializer.InitializeStandardBoard(board);
    }

    private static void LoadChigorin(ChessBoard board)
    {
        BoardInitializer.InitializeStandardBoard(board);
    }

    private static void LoadAlbin(ChessBoard board)
    {
        BoardInitializer.InitializeStandardBoard(board);
    }

    private static void LoadRandom(ChessBoard board)
    {
        OpeningType[] openings =
        {
            OpeningType.QueensGambitAccepted,
            OpeningType.QueensGambitDeclined,
            OpeningType.SlavDefense,
            OpeningType.SemiSlav,
            OpeningType.Chigorin,
            OpeningType.Albin
        };

        Load(board, openings[_random.Next(openings.Length)]);
    }
}
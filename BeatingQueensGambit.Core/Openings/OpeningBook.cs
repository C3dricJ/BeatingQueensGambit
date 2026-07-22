using System.Collections.Generic;

namespace BeatingQueensGambit.Core.Openings;

public static class OpeningBook
{
    public static IReadOnlyList<string> GetLine(
        OpeningType opening)
    {
        return opening switch
        {
            OpeningType.QueensGambitAccepted =>
            [
                "d2d4",
                "d7d5",
                "c2c4",
                "d5c4",
                "g1f3"
            ],

            OpeningType.QueensGambitDeclined =>
            [
                "d2d4",
                "d7d5",
                "c2c4",
                "e7e6",
                "g1f3"
            ],

            OpeningType.SlavDefense =>
            [
                "d2d4",
                "d7d5",
                "c2c4",
                "c7c6",
                "g1f3"
            ],

            OpeningType.SemiSlav =>
            [
                "d2d4",
                "d7d5",
                "c2c4",
                "c7c6",
                "g1f3",
                "e7e6"
            ],

            OpeningType.Chigorin =>
            [
                "d2d4",
                "d7d5",
                "c2c4",
                "b8c6",
                "g1f3"
            ],

            OpeningType.Albin =>
            [
                "d2d4",
                "d7d5",
                "c2c4",
                "e7e5",
                "g1f3"
            ],

            _ => []
        };
    }
}
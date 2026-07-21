using BeatingQueensGambit.Core.Openings;
using BeatingQueensGambit.Engine.AI;

namespace BeatingQueensGambit.UI;

public class GameSettings
{
    public Difficulty Difficulty { get; set; } =
        Difficulty.Medium;

    public int Minutes { get; set; } = 10;

    public OpeningType Opening { get; set; } =
        OpeningType.QueensGambitDeclined;
}
using BeatingQueensGambit.Engine.AI;

namespace BeatingQueensGambit.UI;

public class GameSettings
{
    public Difficulty Difficulty { get; set; } = Difficulty.Medium;

    // 0 = Unlimited
    public int Minutes { get; set; } = 10;
}
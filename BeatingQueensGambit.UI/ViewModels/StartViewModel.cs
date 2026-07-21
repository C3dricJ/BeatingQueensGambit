using CommunityToolkit.Mvvm.ComponentModel;
using BeatingQueensGambit.Engine.AI;

namespace BeatingQueensGambit.UI.ViewModels;

public partial class StartViewModel : ObservableObject
{
    [ObservableProperty]
    private Difficulty selectedDifficulty = Difficulty.Medium;

    [ObservableProperty]
    private int selectedMinutes = 10;

    public Difficulty[] Difficulties =>
    [
        Difficulty.Easy,
        Difficulty.Medium,
        Difficulty.Hard,
        Difficulty.Master
    ];

    public int[] TimeControls =>
    [
        0,
        5,
        10,
        15
    ];

    public GameSettings BuildSettings()
    {
        return new GameSettings
        {
            Difficulty = SelectedDifficulty,
            Minutes = SelectedMinutes
        };
    }
}
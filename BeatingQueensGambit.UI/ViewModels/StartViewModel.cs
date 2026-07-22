using CommunityToolkit.Mvvm.ComponentModel;
using BeatingQueensGambit.Engine.AI;
using BeatingQueensGambit.Core.Openings;

namespace BeatingQueensGambit.UI.ViewModels;

public partial class StartViewModel : ObservableObject
{
    //--------------------------------------------
    // Difficulty
    //--------------------------------------------

    [ObservableProperty]
    private Difficulty selectedDifficulty = Difficulty.Medium;

    //--------------------------------------------
    // Time Control
    //--------------------------------------------

    [ObservableProperty]
    private int selectedMinutes = 10;

    //--------------------------------------------
    // Opening
    //--------------------------------------------

    [ObservableProperty]
    private OpeningType selectedOpening =
        OpeningType.RandomQueensGambit;

    //--------------------------------------------
    // Lists
    //--------------------------------------------

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

    public OpeningType[] Openings =>
    [
        OpeningType.Standard,
        OpeningType.QueensGambitAccepted,
        OpeningType.QueensGambitDeclined,
        OpeningType.SlavDefense,
        OpeningType.SemiSlav,
        OpeningType.Chigorin,
        OpeningType.Albin,
        OpeningType.RandomQueensGambit
    ];

    //--------------------------------------------
    // Build Settings
    //--------------------------------------------

    public GameSettings BuildSettings()
    {
        return new GameSettings
        {
            Difficulty = SelectedDifficulty,
            Minutes = SelectedMinutes,
            Opening = SelectedOpening
        };
    }
}
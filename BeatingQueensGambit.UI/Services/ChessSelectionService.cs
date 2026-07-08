using BeatingQueensGambit.Core.Models;

namespace BeatingQueensGambit.UI.Services;

public class ChessSelectionService
{
    public Position? SelectedSquare { get; private set; }

    public bool HasSelection =>
        SelectedSquare != null;

    public void Select(Position position)
    {
        SelectedSquare = position;
    }

    public void Clear()
    {
        SelectedSquare = null;
    }
}
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using BeatingQueensGambit.Core.Game;
using BeatingQueensGambit.Core.Models;

namespace BeatingQueensGambit.UI.ViewModels;

public class ChessViewModel : INotifyPropertyChanged
{
    public ObservableCollection<SquareViewModel> Squares { get; }

    private readonly ChessGame _game;

    private SquareViewModel? _selectedSquare;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string SelectedSquareText =>
        _selectedSquare == null
            ? "None"
            : $"{(char)('A' + _selectedSquare.Column)}{8 - _selectedSquare.Row}";

    public ChessViewModel()
    {
        _game = new ChessGame();

        Squares = new ObservableCollection<SquareViewModel>();

        BuildBoard();
    }

    private void BuildBoard()
    {
        Squares.Clear();

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                var piece =
                    _game.Board.GetPiece(
                        new Position(row, column));

                Squares.Add(
                    new SquareViewModel(
                        row,
                        column,
                        piece,
                        this));
            }
        }
    }

    public void SelectSquare(SquareViewModel square)
    {
        if (_selectedSquare != null)
            _selectedSquare.Deselect();

        _selectedSquare = square;

        _selectedSquare.Select();

        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(nameof(SelectedSquareText)));
    }

    public SquareViewModel? GetSquare(Position position)
    {
        return Squares.FirstOrDefault(s =>
            s.Row == position.Row &&
            s.Column == position.Column);
    }
}
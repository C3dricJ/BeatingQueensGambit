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

    private Position? _selectedPosition;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string SelectedSquareText =>
        _selectedSquare == null
            ? "None"
            : $"{(char)('A' + _selectedSquare.Column)}{8 - _selectedSquare.Row}";

    public string CurrentTurnText =>
    _game.CurrentTurn.ToString();

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

    public void RefreshBoard()
    {
        foreach (var square in Squares)
        {
            var piece =
                _game.Board.GetPiece(
                    new Position(
                        square.Row,
                        square.Column));

            square.SetPiece(piece);
        }
    }

    public void SelectSquare(SquareViewModel square)
    {
        //----------------------------------------------------
        // FIRST CLICK
        //----------------------------------------------------

        if (_selectedPosition == null)
        {
            _selectedSquare?.Deselect();

            foreach (var boardSquare in Squares)
                boardSquare.HideLegalMove();

            _selectedSquare = square;

            _selectedPosition =
                new Position(square.Row, square.Column);

            square.Select();

            var legalMoves =
                _game.GetLegalMoves(_selectedPosition);

            foreach (var move in legalMoves)
            {
                GetSquare(move)?.ShowLegalMove();
            }

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(SelectedSquareText)));

            return;
        }

        //----------------------------------------------------
        // SECOND CLICK
        //----------------------------------------------------

        Position destination =
            new Position(square.Row, square.Column);

        bool moved =
            _game.TryMove(
                _selectedPosition,
                destination);

        //----------------------------------------------------
        // Successful Move
        //----------------------------------------------------

        if (moved)
        {
            RefreshBoard();

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(CurrentTurnText)));

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(LastMoveText)));
        }

        

        //----------------------------------------------------
        // Clear UI
        //----------------------------------------------------

        foreach (var boardSquare in Squares)
        {
            boardSquare.Deselect();
            boardSquare.HideLegalMove();
        }

        _selectedSquare = null;
        _selectedPosition = null;

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

    public string LastMoveText
    {
        get
        {
            if (_game.LastMove == null)
                return "None";

            var move = _game.LastMove;

            return $"{ToSquare(move.From)} → {ToSquare(move.To)}";
        }
    }

    private string ToSquare(Position p)
    {
        return $"{(char)('A' + p.Column)}{8 - p.Row}";
    }
}
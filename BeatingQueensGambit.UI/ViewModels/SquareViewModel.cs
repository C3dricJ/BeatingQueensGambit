using System;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BeatingQueensGambit.UI.ViewModels;

public partial class SquareViewModel : ObservableObject
{
    public int Row { get; }

    public int Column { get; }

    public Position Position { get; }

    public Piece? Piece { get; private set; }

    public ChessViewModel? Parent { get; }

    [ObservableProperty]
    private bool isSelected;

    [ObservableProperty]
    private bool isLegalMove;

    // NEW
    [ObservableProperty]
    private bool isLastMove;

    private bool _isKingInCheck;

    public bool IsKingInCheck
    {
        get => _isKingInCheck;
        set
        {
            _isKingInCheck = value;
            OnPropertyChanged(nameof(SquareColor));
        }
    }

    public Bitmap? PieceImage
    {
        get
        {
            if (Piece == null)
                return null;

            string color =
                Piece.Color == PieceColor.White
                    ? "white"
                    : "black";

            string pieceName = Piece switch
            {
                King => "king",
                Queen => "queen",
                Rook => "rook",
                Bishop => "bishop",
                Knight => "knight",
                Pawn => "pawn",
                _ => ""
            };

            var uri = new Uri(
                $"avares://BeatingQueensGambit.UI/Assets/Pieces/{color}_{pieceName}.png");

            return new Bitmap(
                Avalonia.Platform.AssetLoader.Open(uri));
        }
    }

    public IBrush SquareColor
    {
        get
        {
            //------------------------------------------------
            // Selected Piece
            //------------------------------------------------

            if (IsSelected)
            {
                return new SolidColorBrush(
                    Color.Parse("#FFD54F"));
            }

            //------------------------------------------------
            // KING IN CHECK
            //------------------------------------------------

            if (IsKingInCheck)
            {
                return new SolidColorBrush(
                    Color.Parse("#E53935"));
            }

            //------------------------------------------------
            // Last Move
            //------------------------------------------------

            if (IsLastMove)
            {
                return new SolidColorBrush(
                    Color.Parse("#C8D6A3"));
            }

            //------------------------------------------------
            // Legal Moves
            //------------------------------------------------

            if (IsLegalMove)
            {
                return new SolidColorBrush(
                    Color.Parse("#1fbf27"));
            }

            //------------------------------------------------
            // Normal Board
            //------------------------------------------------

            return (Row + Column) % 2 == 0
                ? new SolidColorBrush(Color.Parse("#EEEED2"))
                : new SolidColorBrush(Color.Parse("#769656"));
        }
    }

    public SquareViewModel(
        int row,
        int column,
        Piece? piece,
        ChessViewModel parent)
    {
        Parent = parent;

        Row = row;
        Column = column;

        Position = new Position(row, column);

        Piece = piece;
    }

    public void SetPiece(Piece? piece)
    {
        Piece = piece;

        OnPropertyChanged(nameof(PieceImage));
    }

    public void Select()
    {
        IsSelected = true;
        OnPropertyChanged(nameof(SquareColor));
    }

    public void Deselect()
    {
        IsSelected = false;
        OnPropertyChanged(nameof(SquareColor));
    }

    public void ShowLegalMove()
    {
        IsLegalMove = true;
        OnPropertyChanged(nameof(SquareColor));
    }

    public void HideLegalMove()
    {
        IsLegalMove = false;
        OnPropertyChanged(nameof(SquareColor));
    }

    // NEW
    public void ShowLastMove()
    {
        IsLastMove = true;
        OnPropertyChanged(nameof(SquareColor));
    }

    // NEW
    public void HideLastMove()
    {
        IsLastMove = false;
        OnPropertyChanged(nameof(SquareColor));
    }

    public void ShowCheck()
    {
        IsKingInCheck = true;
    }

    public void HideCheck()
    {
        IsKingInCheck = false;
    }

}
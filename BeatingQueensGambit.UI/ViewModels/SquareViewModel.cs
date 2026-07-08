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

    [ObservableProperty]
    private bool isSelected;

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

    public IBrush SquareColor =>
    IsSelected
        ? new SolidColorBrush(Color.Parse("#D9B44A"))
        : ((Row + Column) % 2 == 0
            ? new SolidColorBrush(Color.Parse("#F0D9B5"))
            : new SolidColorBrush(Color.Parse("#B58863")));

    public SquareViewModel(
        int row,
        int column,
        Piece? piece)
    {
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
}
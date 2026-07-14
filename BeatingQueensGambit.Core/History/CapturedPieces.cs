using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Core.History;

public class CapturedPieces
{
    public List<Piece> WhiteCaptured { get; }
        = new();

    public List<Piece> BlackCaptured { get; }
        = new();

    public void Add(Piece piece)
    {
        if (piece.Color ==
            Enums.PieceColor.White)
        {
            WhiteCaptured.Add(piece);
        }
        else
        {
            BlackCaptured.Add(piece);
        }
    }

    public void Clear()
    {
        WhiteCaptured.Clear();
        BlackCaptured.Clear();
    }
}
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;

namespace BeatingQueensGambit.Core.History;

/// <summary>
/// Represents one completed chess move.
/// </summary>
public class MoveRecord
{
    public PieceType Piece { get; }

    public PieceColor Color { get; }

    public Position From { get; }

    public Position To { get; }

    public bool WasCapture { get; }

    public bool WasCheck { get; set; }

    public bool WasCheckmate { get; set; }

    public bool WasCastleKingside { get; }

    public bool WasCastleQueenside { get; }

    public bool WasPromotion { get; }

    public PieceType? PromotionPiece { get; }

    public MoveRecord(
        PieceType piece,
        PieceColor color,
        Position from,
        Position to,
        bool wasCapture,
        bool wasCastleKingside,
        bool wasCastleQueenside,
        bool wasPromotion,
        PieceType? promotionPiece)
    {
        Piece = piece;
        Color = color;
        From = from;
        To = to;
        WasCapture = wasCapture;

        WasCastleKingside = wasCastleKingside;
        WasCastleQueenside = wasCastleQueenside;

        WasPromotion = wasPromotion;
        PromotionPiece = promotionPiece;
    }
}
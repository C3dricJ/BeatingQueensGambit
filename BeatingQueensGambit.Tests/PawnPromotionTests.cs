using Xunit;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;
using BeatingQueensGambit.Core.Rules;

namespace BeatingQueensGambit.Tests;

public class PawnPromotionTests
{
    [Fact]
    public void WhitePawnOnLastRank_ShouldPromote()
    {
        var board = new ChessBoard();

        var pawn = new Pawn(PieceColor.White);

        var position = new Position(0, 4);

        board.SetPiece(position, pawn);

        Assert.True(
            PawnPromotion.ShouldPromote(
                pawn,
                position));
    }

    [Fact]
    public void BlackPawnOnLastRank_ShouldPromote()
    {
        var board = new ChessBoard();

        var pawn = new Pawn(PieceColor.Black);

        var position = new Position(7, 4);

        board.SetPiece(position, pawn);

        Assert.True(
            PawnPromotion.ShouldPromote(
                pawn,
                position));
    }

    [Fact]
    public void PawnNotOnLastRank_ShouldNotPromote()
    {
        var board = new ChessBoard();

        var pawn = new Pawn(PieceColor.White);

        var position = new Position(4, 4);

        board.SetPiece(position, pawn);

        Assert.False(
            PawnPromotion.ShouldPromote(
                pawn,
                position));
    }
}
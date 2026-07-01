using Xunit;
using BeatingQueensGambit.Core.AI;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Tests;

public class MinimaxTests
{
    [Fact]
    public void EmptyBoardReturnsZero()
    {
        var board = new ChessBoard();

        int score =
            Minimax.Search(
                board,
                PieceColor.White);

        Assert.Equal(0, score);
    }

    [Fact]
    public void WhiteQueenReturnsPositiveScore()
    {
        var board = new ChessBoard();

        board.SetPiece(
            new Position(3,3),
            new Queen(PieceColor.White));

        int score =
            Minimax.Search(
                board,
                PieceColor.White);

        Assert.Equal(900, score);
    }

    [Fact]
    public void BlackQueenReturnsNegativeScore()
    {
        var board = new ChessBoard();

        board.SetPiece(
            new Position(3,3),
            new Queen(PieceColor.Black));

        int score =
            Minimax.Search(
                board,
                PieceColor.White);

        Assert.Equal(-900, score);
    }
}
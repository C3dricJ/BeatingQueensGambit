using Xunit;
using BeatingQueensGambit.Core.AI;
using BeatingQueensGambit.Core.Board;
using BeatingQueensGambit.Core.Enums;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.Tests;

public class MinimaxTests
{
    //----------------------------------------------------
    // Helper
    //----------------------------------------------------

    private ChessBoard CreateBoard()
    {
        var board = new ChessBoard();

        // Every legal chess position must have both kings.
        board.SetPiece(
            new Position(7, 4),
            new King(PieceColor.White));

        board.SetPiece(
            new Position(0, 4),
            new King(PieceColor.Black));

        return board;
    }

    //----------------------------------------------------

    [Fact]
    public void EmptyBoardReturnsZero()
    {
        var board = CreateBoard();

        int score =
            Minimax.Search(
            board,
            1,
            true,
            PieceColor.White);

        Assert.Equal(0, score);
    }

    //----------------------------------------------------

    [Fact]
    public void WhiteQueenReturnsPositiveScore()
    {
        var board = CreateBoard();

        board.SetPiece(
            new Position(3, 3),
            new Queen(PieceColor.White));

        int score =
            Minimax.Search(
            board,
            1,
            true,
            PieceColor.White);

        Assert.Equal(900, score);
    }

    //----------------------------------------------------

    [Fact]
    public void BlackQueenReturnsNegativeScore()
    {
        var board = CreateBoard();

        board.SetPiece(
            new Position(3, 3),
            new Queen(PieceColor.Black));

        int score =
            Minimax.Search(
            board,
            1,
            true,
            PieceColor.White);

        Assert.Equal(-900, score);
    }

    //----------------------------------------------------

    [Fact]
    public void WhiteShouldPreferCapturingQueen()
    {
        var board = CreateBoard();

        board.SetPiece(
            new Position(4, 4),
            new Queen(PieceColor.White));

        board.SetPiece(
            new Position(4, 6),
            new Queen(PieceColor.Black));

        int score =
            Minimax.Search(
            board,
            1,
            true,
            PieceColor.White);

        Assert.True(score >= 900);
    }
}
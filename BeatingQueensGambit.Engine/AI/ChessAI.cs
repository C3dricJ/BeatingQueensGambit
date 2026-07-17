using System;
using System.Collections.Generic;
using System.Linq;
using BeatingQueensGambit.Core.Game;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Moves;

namespace BeatingQueensGambit.Engine.AI;

public class ChessAI
{
    private readonly Random _random = new();

    public Move? ChooseMove(ChessGame game)
    {
        var legalMoves = GetAllLegalMoves(game);

        if (legalMoves.Count == 0)
            return null;

        return legalMoves[_random.Next(legalMoves.Count)];
    }

    private List<Move> GetAllLegalMoves(ChessGame game)
    {
        var moves = new List<Move>();

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                var from = new Position(row, column);

                var piece = game.Board.GetPiece(from);

                if (piece == null)
                    continue;

                if (piece.Color != game.CurrentTurn)
                    continue;

                foreach (var destination in game.GetLegalMoves(from))
                {
                    moves.Add(new Move(from, destination));
                }
            }
        }

        return moves;
    }
}
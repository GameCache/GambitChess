using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GambitChess.Game.Boards;
using GambitChess.Game.Pieces;

namespace GambitChess.Game
{
    /// <summary>Pieces and default setup to use for a game.</summary>
    public sealed class PieceSet
    {
        /// <summary>Largest X change any piece will attempt.</summary>
        public int MaxStepX { get; }

        /// <summary>Largest Y change any piece will attempt.</summary>
        public int MaxStepY { get; }

        /// <summary>Possible pieces to use.</summary>
        internal IDictionary<string, IPiece> Pieces { get; }

        /// <summary>Forsyth–Edwards Notation for the initial state.</summary>
        private readonly string _defaultFen;

        /// <summary>Order in which each side makes moves.</summary>
        private readonly Side[] _turnOrder;

        /// <summary>Initializes a new instance of the <see cref="PieceSet"/> class.</summary>
        /// <param name="defaultFen">Forsyth–Edwards Notation for the initial state.</param>
        /// <param name="turnOrder">Order in which each side makes moves.</param>
        /// <param name="pieces">Possible pieces to use.</param>
        internal PieceSet(string defaultFen, Side[] turnOrder, params IPiece[] pieces)
        {
            Pieces = pieces.ToDictionary(p => $"{p.Id}", p => p);
            MaxStepX = Pieces.Values.Max(p => p.MaxStepX);
            MaxStepY = Pieces.Values.Max(p => p.MaxStepY);

            _defaultFen = defaultFen;
            _turnOrder = turnOrder;
        }

        /// <summary>Creates a board representing the default position.</summary>
        /// <returns>The created board.</returns>
        public IPlayerBoard SetupBoard()
        {
            return SetupBoard(_defaultFen);
        }

        /// <summary>Creates a board representing the <paramref name="position"/>.</summary>
        /// <param name="position">Forsyth–Edwards Notation for the position to setup.</param>
        /// <returns>The created board representing <paramref name="position"/>.</returns>
        public IPlayerBoard SetupBoard(string position)
        {
            string[] rows = (position ?? _defaultFen).Split("/");

            Square[][] tiles = CreateBoardTiles(rows);

            for (int i = 0; i < rows.Length; i++)
            {
                int gap = 0;
                int skip = 0;

                for (int j = 0; j < rows[i].Length; j++)
                {
                    string next = rows[i][j].ToString();

                    if (Pieces.TryGetValue(next, out IPiece? place))
                    {
                        gap += skip;
                        skip = 0;

                        tiles[i + MaxStepY][j + gap + MaxStepX].Content = place;
                    }
                    else
                    {
                        skip = skip * 10 + int.Parse(next, CultureInfo.InvariantCulture) - 1;
                    }
                }
            }

            return new PlayerBoard(new BoardEngine(this, tiles, new TurnKeeper(0, _turnOrder)));
        }

        /// <summary>Creates a blank tile set to hold <paramref name="rows"/>.</summary>
        /// <param name="rows">Positional piece information by row.</param>
        /// <returns>The created tiles.</returns>
        private Square[][] CreateBoardTiles(string[] rows)
        {
            int height = rows.Length;
            int width = rows.Max(r => r.Length);

            Square[][] tiles = new Square[MaxStepY * 2 + height][];

            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Square[MaxStepX * 2 + width];
                Array.Fill(tiles[i], Square.Invalid);
            }

            for (int i = MaxStepY; i < MaxStepY + height; i++)
            {
                for (int j = MaxStepX; j < MaxStepX + width; j++)
                {
                    tiles[i][j] = new Square($"{(char)('a' + j - MaxStepX)}{MaxStepY + height - i}",
                        (i == MaxStepY + 1 || i == MaxStepY + height - 2),
                        (i == MaxStepY || i == MaxStepY + height - 1));
                }
            }

            return tiles;
        }
    }
}

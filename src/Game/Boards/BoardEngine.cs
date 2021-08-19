using System.Collections.Generic;
using System.Linq;
using System.Text;
using GambitChess.Game.Moves;
using GambitChess.Game.Pieces;
using GambitChess.Game.Pieces.Types;

namespace GambitChess.Game.Boards
{
    internal sealed class BoardEngine : IBoardEngine, IBoardState
    {
        private readonly PieceSet _set;

        private readonly Square[][] _tiles;

        private readonly TurnKeeper _turnOrder;

        private readonly IList<IMove> _history = new List<IMove>();

        private readonly IDictionary<Square, int> _changed;

        public BoardEngine(PieceSet set, Square[][] setup, TurnKeeper turn)
        {
            _set = set;
            _tiles = setup;
            _turnOrder = turn;
            _changed = setup.SelectMany(s => s).Where(s => s != Square.Invalid).ToDictionary(s => s, s => -1);
        }

        /// <inheritdoc/>
        public IEnumerable<IMove> GenerateMoves()
        {
            int yMod = _set.MaxStepY;
            int xMod = _set.MaxStepX;
            for (int i = yMod; i < _tiles.Length - yMod; i++)
            {
                for (int j = xMod; j < _tiles[i].Length - xMod; j++)
                {
                    Square next = _tiles[i][j];
                    if (next.Content?.Side == _turnOrder.CurrentTurn)
                    {
                        foreach (IMove move in next.Content.GenerateMoves(this, next, j, i))
                        {
                            yield return move;
                        }
                    }
                }
            }
        }

        /// <inheritdoc/>
        public void Make(IMove move)
        {
            move.Make();
            _turnOrder.SetToNextTurn();
            _history.Add(move);
            foreach (Square change in move.Changes())
            {
                if (_changed[change] == -1)
                {
                    _changed[change] = _history.Count;
                }
            }
        }

        /// <inheritdoc/>
        public void Undo(int count = 1)
        {
            for (int i = 0; i < count && _history.Any(); i++)
            {
                IMove last = _history[_history.Count - 1];
                _history.RemoveAt(_history.Count - 1);

                last.Undo();
                _turnOrder.SetToPreviousTurn();
                foreach (Square change in last.Changes())
                {
                    if (_changed[change] > _history.Count)
                    {
                        _changed[change] = -1;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public Square CheckSpace(int x, int y)
        {
            return _tiles[y][x];
        }

        /// <inheritdoc/>
        public ISet<Square> FindThreatenedSquares()
        {
            HashSet<Square> threatened = new();

            int yMod = _set.MaxStepY;
            int xMod = _set.MaxStepX;
            for (int i = yMod; i < _tiles.Length - yMod; i++)
            {
                for (int j = xMod; j < _tiles[i].Length - xMod; j++)
                {
                    Square next = _tiles[i][j];
                    if (next.Content != null && next.Content.Side != _turnOrder.CurrentTurn)
                    {
                        foreach (Square target in next.Content.FindThreats(this, j, i))
                        {
                            _ = threatened.Add(target);
                        }
                    }
                }
            }

            return threatened;
        }

        /// <inheritdoc/>
        public bool HasChanged(Square location)
        {
            return _changed[location] > -1;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder result = new();
            int yMod = _set.MaxStepY;
            int xMod = _set.MaxStepX;

            Square? whiteKing = null;
            int whiteKingX = -1;
            int whiteKingY = -1;
            Square? blackKing = null;
            int blackKingX = -1;
            int blackKingY = -1;

            for (int i = yMod; i < _tiles.Length - yMod; i++)
            {
                if (i > yMod)
                {
                    _ = result.Append('/');
                }

                int skip = 0;
                for (int j = xMod; j < _tiles[i].Length - xMod; j++)
                {
                    Square next = _tiles[i][j];
                    if (next.Content == null)
                    {
                        skip++;
                    }
                    else if (skip > 0)
                    {
                        _ = result.Append(skip);
                        skip = 0;
                    }
                    _ = result.Append(next.Content);

                    if (next.Content is King)
                    {
                        if (next.Content.Side == Side.White)
                        {
                            whiteKing = next;
                            whiteKingX = j;
                            whiteKingY = i;
                        }
                        else
                        {
                            blackKing = next;
                            blackKingX = j;
                            blackKingY = i;
                        }
                    }
                }

                if (skip > 0)
                {
                    _ = result.Append(skip);
                }
            }

            _ = result.Append(' ').Append(_turnOrder.CurrentTurn == Side.White ? 'w' : 'b');

            string castling = "";
            if (whiteKing != null && !HasChanged(whiteKing))
            {
                for (int currentX = whiteKingX + 1; currentX < _tiles[whiteKingY].Length; currentX++)
                {
                    Square kingsideRook = _tiles[whiteKingY][currentX];
                    if (!kingsideRook.Exists)
                    {
                        break;
                    }
                    if (kingsideRook.Content is Rook && kingsideRook.Content.Side == Side.White && !HasChanged(kingsideRook))
                    {
                        castling += "K";
                    }
                }
                for (int currentX = whiteKingX - 1; currentX > 0; currentX--)
                {
                    Square queensideRook = _tiles[whiteKingY][currentX];
                    if (!queensideRook.Exists)
                    {
                        break;
                    }
                    if (queensideRook.Content is Rook && queensideRook.Content.Side == Side.White && !HasChanged(queensideRook))
                    {
                        castling += "Q";
                    }
                }
            }
            if (blackKing != null && !HasChanged(blackKing))
            {
                for (int currentX = blackKingX + 1; currentX < _tiles[blackKingY].Length; currentX++)
                {
                    Square kingsideRook = _tiles[blackKingY][currentX];
                    if (!kingsideRook.Exists)
                    {
                        break;
                    }
                    if (kingsideRook.Content is Rook && kingsideRook.Content.Side == Side.Black && !HasChanged(kingsideRook))
                    {
                        castling += "k";
                    }
                }
                for (int currentX = blackKingX - 1; currentX > 0; currentX--)
                {
                    Square queensideRook = _tiles[blackKingY][currentX];
                    if (!queensideRook.Exists)
                    {
                        break;
                    }
                    if (queensideRook.Content is Rook && queensideRook.Content.Side == Side.Black && !HasChanged(queensideRook))
                    {
                        castling += "q";
                    }
                }
            }

            _ = result.Append(' ').Append(castling.Length == 0 ? "-" : castling);

            int lastCap = 0;
            for (int i = _history.Count - 1; i > 0; i--)
            {
                if (_history[i] is not Move current || current.IsCapture)
                {
                    break;
                }
                else
                {
                    lastCap++;
                }
            }
            _ = result.Append(' ').Append(lastCap);

            _ = result.Append(' ').Append(1 + _history.Count / 2);

            return result.ToString();
        }

        internal string DebugPrint()
        {
            StringBuilder result = new();
            for (int i = 0; i < _tiles.Length; i++)
            {
                for (int j = 0; j < _tiles[i].Length; j++)
                {
                    _ = result.Append('|').Append(_tiles[i][j].DebugPrint());
                }
                _ = result.AppendLine("|");
            }
            return result.ToString();
        }
    }
}
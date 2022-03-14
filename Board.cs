using System.Collections.Generic;

namespace TicTacToe
{
    /// <summary>
    /// 
    /// This class represents the 3x3 board used in the game.
    /// 
    /// </summary>
    /// 
    internal class Board
    {
        #region INTERNAL FIELDS

        private readonly Piece[,] pieces;
        private readonly List<Position> emptyPositions;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// 
        /// Piece in the specified position.
        /// 
        /// </summary>
        /// 
        public Piece this[Position position]
        {
            get
            {
                return this.pieces[position.Row - 1, position.Col - 1];
            }
        }

        /// <summary>
        /// 
        /// List with positions not ocuppied in the board.
        /// 
        /// </summary>
        /// 
        public List<Position> EmptyPositions
        {
            get
            {
                return this.emptyPositions;
            }
        }

        #endregion

        #region CONSTRUCTORS

        public Board()
        {
            this.pieces = new Piece[3, 3];
            this.emptyPositions = new List<Position> { new Position(1, 1), new Position(1, 2), new Position(1, 3),
                                                       new Position(2, 1), new Position(2, 2), new Position(2, 3),
                                                       new Position(3, 1), new Position(3, 2), new Position(3, 3) };
        }

        #endregion

        #region METHODS

        /// <summary>
        /// 
        /// Puts a piece on the board in the specified position.
        /// 
        /// </summary>
        /// 
        /// <param name="position">Position to occupy.</param>
        /// <param name="piece">Piece to put on.</param>
        public void PutPiece(Position position, Piece piece)
        {
            this.pieces[position.Row - 1, position.Col - 1] = piece;
            this.emptyPositions.Remove(position);
        }

        #endregion
    }
}

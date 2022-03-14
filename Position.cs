using System;

namespace TicTacToe
{
    /// <summary>
    /// 
    /// This class represents a position to play in the game,
    /// in terms of row and col of the cell.
    /// 
    /// </summary>
    /// 
    internal class Position
    {
        #region INTERNAL FIELDS

        private readonly int row;
        private readonly int col;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// 
        /// Number of the row, from 1 to 3 (READ-ONLY).
        /// 
        /// </summary>
        public int Row
        {
            get
            {
                return this.row;
            }
        }

        /// <summary>
        /// 
        /// Number of the col, from 1 to 3 (READ-ONLY).
        /// 
        /// </summary>
        public int Col
        {
            get
            {
                return this.col;
            }
        }

        #endregion

        #region CONSTRUCTORS

        /// <param name="row">Row of the position, from 1 to 3.</param>
        /// <param name="col">Col of the position, from 1 to 3.</param>
        /// <exception cref="ArgumentException">Occurs on row or col out of range.</exception>
        public Position(int row, int col)
        {
            if (row >= 1 && row <= 3 && col >= 1 && col <= 3)
            {
                this.row = row;
                this.col = col;
            }
            else
            {
                throw new ArgumentException("ERR: Row or col are invalid.");
            }
        }

        #endregion

        #region METHODS

        /// <returns>A string with row and col data.</returns>
        public override string ToString()
        {
            return "(" + this.row +"," + this.col + ")";
        }

        /// <summary>
        /// 
        /// Two positions are equal if their rows and cols are the same.
        /// 
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj != null && this.GetType().Equals(obj.GetType()))
            {
                Position other = (Position)obj;
                return this.row == other.row && this.col == other.col;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (this.row << 2) ^ this.col;
        }

        #endregion
    }
}

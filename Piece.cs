namespace TicTacToe
{
    /// <summary>
    /// 
    /// This class is abstract and represents a generic piece
    /// of the game.
    /// 
    /// </summary>
    internal abstract class Piece
    {
        #region INTERNAL FIELDS

        private readonly char symbol;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// 
        /// Symbol on the piece (READ-ONLY).
        /// 
        /// </summary>
        public char Symbol
        {
            get 
            { 
                return this.symbol; 
            }
        }

        #endregion

        #region CONSTRUCTORS

        /// <param name="symbol">The symbol on the piece.</param>
        public Piece(char symbol)
        {
            this.symbol = symbol;   
        }

        #endregion

        #region METHODS

        public abstract Piece Clone();

        /// <returns>A string that represent the symbol on the piece.</returns>
        public override string ToString()
        {
            return this.Symbol.ToString();
        }

        public override int GetHashCode()
        {
            return this.symbol;
        }

        /// <summary>
        /// 
        /// Two pieces are equal if their symbols are the same.
        /// 
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj != null && this.GetType().Equals(obj.GetType()))
            {
                return this.symbol == ((Piece)obj).symbol;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Piece lhs, Piece rhs)
        {
            if (lhs is null)
                return false;
            else
                return lhs.Equals(rhs);
        }

        public static bool operator !=(Piece lhs, Piece rhs) => !(lhs == rhs);

        #endregion
    }
}

namespace TicTacToe
{
    /// <summary>
    /// 
    /// This class represents the list of players and also
    /// controls the sequence of the game and the player in
    /// turn.
    /// 
    /// </summary>
    /// 
    internal class PlayerList
    {
        #region INTERNAL FIELDS

        private readonly Player[] players;
        private int playerInTurn;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// 
        /// ith player in the list.
        /// 
        /// </summary>
        /// 
        public Player this[int i]
        {
            get
            {
                return this.players[i-1];
            }
            set
            {
                this.players[i-1] = value;    
            }
        }

        /// <summary>
        /// 
        /// Player in turn to play.
        /// 
        /// </summary>
        /// 
        public Player PlayerInTurn
        {
            get
            {
                return this.players[this.playerInTurn];
            }
        }

        #endregion

        #region CONSTRUCTORS

        /// <param name="n">Numbers of players.</param>
        public PlayerList(int n)
        {
            this.players = new Player[n];
            this.playerInTurn = 0;
        }

        #endregion

        /// <summary>
        /// 
        /// Changes the player in turn based on sequential order.
        /// 
        /// </summary>
        /// <returns>Player after next turn.</returns>
        #region METHODS

        public Player NextTurn()
        {
            this.playerInTurn++;
            this.playerInTurn %= this.players.Length;
            return this.PlayerInTurn;
        }

        #endregion
    }
}

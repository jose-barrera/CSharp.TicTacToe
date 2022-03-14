using System;

namespace TicTacToe
{
    internal class Game
    {
        #region DELEGATES / EVENTS

        public delegate void TurnFinished();
        public event TurnFinished OnTurnFinished;

        #endregion

        #region ENUMS

        public enum GameState
        {
            InProgress, Won, Draw
        };

        #endregion

        #region INTERNAL FIELDS

        private readonly Board board;
        private readonly PlayerList playerList;
        private Player winner;
        private GameState state;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// 
        /// Current board of the game.
        /// 
        /// </summary>
        /// 
        public Board Board
        {
            get
            {
                return this.board;
            }
        }
        
        /// <summary>
        /// 
        /// First player in the game.
        /// 
        /// </summary>
        /// 
        public Player Player1
        {
            get
            {
                return this.playerList[0];
            }
        }
        
        /// <summary>
        /// 
        /// Second player in the game.
        /// 
        /// </summary>
        /// 
        public Player Player2
        {
            get
            {
                return this.playerList[1];
            }
        }
        
        /// <summary>
        /// 
        /// Current player in turn.
        /// 
        /// </summary>
        /// 
        public Player PlayerInTurn
        {
            get
            {
                return this.playerList.PlayerInTurn;
            }
        }

        /// <summary>
        /// 
        /// Player who won the game; null if there is no winner.
        /// 
        /// </summary>
        /// 
        public Player Winner
        {
            get
            {
                return this.winner;
            }
        }
        
        /// <summary>
        /// 
        /// Current state of game.
        /// 
        /// </summary>
        /// 
        public GameState State
        {
            get
            {
                return this.state;
            }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// 
        /// When creating a game, the order of the players is
        /// random, but X player is always the first one.
        /// 
        /// </summary>
        /// <param name="name1">Name of first player.</param>
        /// <param name="name2">Name of second player.</param>
        public Game(string name1, string name2)
        {
            this.board = new Board();
            this.playerList = new PlayerList(2);
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                this.playerList[1] = new Player(name1, new PieceX());
                this.playerList[2] = new Player(name2, new PieceO());
            }
            else
            {
                this.playerList[1] = new Player(name2, new PieceX());
                this.playerList[2] = new Player(name1, new PieceO());
            }
            this.state = GameState.InProgress;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// 
        /// Executes the indicated play of the current player, updating
        /// the board and the game state and validating if there is a winning
        /// play or the game is finished with draw. When the game is
        /// finished, the changed-state event is raised; otherwise next turn
        /// is applied and the game continues.
        /// 
        /// </summary>
        /// <param name="position">Position to play for the current player.</param>
        public void Play(Position position)
        {
            this.board.PutPiece(position, playerList.PlayerInTurn.Piece);
            if (CheckWinner())
            {
                this.winner = playerList.PlayerInTurn;
                this.state = GameState.Won;
            }
            else
            {
                if (this.board.EmptyPositions.Count == 0)
                {
                    this.state = GameState.Draw;
                }
                else
                {
                    this.playerList.NextTurn();
                }
            }
            this.OnTurnFinished?.Invoke();
        }

        /// <summary>
        /// 
        /// Checks if there is a winning layout for the specified piece.
        /// 
        /// </summary>
        /// <param name="piece">Type of piece to check.</param>
        /// <returns>True if the player has won the game; false otherwise.</returns>
        private bool CheckWinner()
        {
            bool winner = false;
            Position p11 = new Position(1, 1); Position p12 = new Position(1, 2); Position p13 = new Position(1, 3);
            Position p21 = new Position(2, 1); Position p22 = new Position(2, 2); Position p23 = new Position(2, 3);
            Position p31 = new Position(3, 1); Position p32 = new Position(3, 2); Position p33 = new Position(3, 3);

            // Checks the rows.
            winner = winner || this.board[p11] == this.board[p12] && this.board[p12] == this.board[p13];
            winner = winner || this.board[p21] == this.board[p22] && this.board[p22] == this.board[p23];
            winner = winner || this.board[p31] == this.board[p32] && this.board[p32] == this.board[p33];
            // Checks the cols.
            winner = winner || this.board[p11] == this.board[p21] && this.board[p21] == this.board[p31];
            winner = winner || this.board[p12] == this.board[p22] && this.board[p22] == this.board[p32];
            winner = winner || this.board[p13] == this.board[p23] && this.board[p23] == this.board[p33];
            // Checks the diagonals.
            winner = winner || this.board[p11] == this.board[p22] && this.board[p22] == this.board[p33];
            winner = winner || this.board[p13] == this.board[p22] && this.board[p22] == this.board[p31];

            return winner;
        }

        #endregion

    }
}

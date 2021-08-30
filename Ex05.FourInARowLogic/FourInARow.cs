using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex05.FourInARowLogic
{
    public class FourInARow
    {
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private int m_GameRoundCounter;
        private readonly Board r_TheGameBoard;
        private bool m_IsGameOver;
        private bool m_IsContinueToAnotherRound;

        public FourInARow(int i_BoardWidth, int i_BoardLength, int i_PlayerType)
        {
            r_TheGameBoard = new Board(i_BoardWidth, i_BoardLength);
            r_Player1 = new Player(2, 'X');
            r_Player2 = new Player(i_PlayerType, 'O');
            m_GameRoundCounter = 0;
            m_IsGameOver = false;
        }

        public Board TheGameBoard
        {
            get
            {
                return r_TheGameBoard;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }

            set
            {
                m_IsGameOver = value;
            }
        }

        public bool IsContinueToAnotherRound
        {
            get
            {
                return m_IsContinueToAnotherRound;
            }

            set
            {
                m_IsContinueToAnotherRound = value;
            }
        }
        public Player GetPlayer1
        {
            get
            {
                return r_Player1;
            }
        }
        public Player GetPlayer2
        {
            get
            {
                return r_Player2;
            }
        }


        public void InitGame()
        {
            IsGameOver = false;
            m_IsContinueToAnotherRound = true;
            m_GameRoundCounter = 0;
            r_TheGameBoard.InitBoard(r_TheGameBoard.BoardLength, r_TheGameBoard.BoardWidth);
            //Console.Clear();
            r_Player1.IsPlayerWon = false;
            r_Player2.IsPlayerWon = false;


        }

        public Player GetCurrentPlayer()
        {
            return m_GameRoundCounter % 2 == 0 ? r_Player1 : r_Player2;
        }

        public Player GetPreviousPlayer()
        {
            return m_GameRoundCounter % 2 != 0 ? r_Player1 : r_Player2;
        }

        

        public int m_GameRound
        {
            get
            {
                return m_GameRoundCounter;
            }

            set
            {
                m_GameRoundCounter = value;
            }
        }

        public void IsPlayerWon(int i_CurrentChipRow, int i_PlayerColumnChoice)
        {
            bool isPlayerWon = 
                                   r_TheGameBoard.IsFourInARow(
                                       (char)GetCurrentPlayer().PlayerLetterType,
                                       i_CurrentChipRow,
                                       i_PlayerColumnChoice - 1)
                                   || r_TheGameBoard.IsFourInADiagonal((char)GetCurrentPlayer().PlayerLetterType)
                                   || r_TheGameBoard.IsFourInACol(
                                       (char)GetCurrentPlayer().PlayerLetterType,
                                       i_CurrentChipRow,
                                       i_PlayerColumnChoice - 1); ;

            GetCurrentPlayer().IsPlayerWon = isPlayerWon;
        }

        public void UpdateBoardAndMoveToNextTurn(int i_ColumnChipToAdd, ref int o_CurrentChipRow, ref bool io_IsFullColumnNumber,char i_PlayerLetterType)
        {
           
            io_IsFullColumnNumber = TheGameBoard.AddChips(
                i_ColumnChipToAdd,
                i_PlayerLetterType,
                ref o_CurrentChipRow);
            

        }
        public int GetComputerChoice()
        {
            int computerChoice = new Random().Next(1, r_TheGameBoard.BoardWidth+1);

            //Thread.Sleep(500);

            return computerChoice;
        }

        public bool IsPlayerChoiceColumnInRange(string i_PlayerChoice, ref int io_PlayerColumnChoice)
        {
            bool isValidPlayerChoiceColumn = false;

            if(i_PlayerChoice != string.Empty)
            {
                io_PlayerColumnChoice = int.Parse(i_PlayerChoice);
                isValidPlayerChoiceColumn = io_PlayerColumnChoice <= r_TheGameBoard.BoardWidth;
            }

            return isValidPlayerChoiceColumn;
        }
    }
}
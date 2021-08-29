﻿using System;
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
            r_Player1 = new Player(2, 1);
            r_Player2 = new Player(i_PlayerType, 2);
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

        public bool IsPlayerWon(int i_CurrentChipRow, int i_PlayerColumnChoice)
        {
            bool isPlayerWon = isPlayerWon =
                                   r_TheGameBoard.IsFourInARow(
                                       GetCurrentPlayer().PlayerLetterType,
                                       i_CurrentChipRow,
                                       i_PlayerColumnChoice - 1)
                                   || r_TheGameBoard.IsFourInADiagonal(GetCurrentPlayer().PlayerLetterType)
                                   || r_TheGameBoard.IsFourInACol(
                                       GetCurrentPlayer().PlayerLetterType,
                                       i_CurrentChipRow,
                                       i_PlayerColumnChoice - 1); ;

            return isPlayerWon;
        }

        public void UpdateBoardAndMoveToNextTurn(int i_ColumnChipToAdd, ref int o_CurrentChipRow, ref bool io_IsFullColumnNumber)
        {

            io_IsFullColumnNumber = TheGameBoard.AddChips(
                i_ColumnChipToAdd,
                GetCurrentPlayer().PlayerLetterType,
                ref o_CurrentChipRow);
            /*if(r_Player2.PlayerType == Player.ePlayerType.Computer&&!io_IsFullColumnForHumanMove)
            {
                while(!io_IsFullColumnForComputerMove)
                {
                    io_IsFullColumnForComputerMove = TheGameBoard.AddChips(
                     GetComputerChoice(),
                     r_Player2.PlayerLetterType,
                    ref o_CurrentChipRow);

                }
           

            }*/
            

        }
        public int GetComputerChoice()
        {
            int computerChoice = new Random().Next(1, r_TheGameBoard.BoardWidth);

            Thread.Sleep(500);

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
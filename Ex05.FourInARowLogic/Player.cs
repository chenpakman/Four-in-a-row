using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.FourInARowLogic
{

        public class Player
        {
            public enum ePlayerType
            {
                Computer = 1,
                Person = 2
            }

            private ePlayerType m_PlayerType;
            private int m_ScoreOfPlayer=0;
            private char m_LetterType;
            private int m_NumberOfPlayer;

            public Player(int i_PlayerType, int i_NumberOfPlayer)
            {
                m_PlayerType = (ePlayerType)i_PlayerType;
                m_ScoreOfPlayer = 0;
                m_LetterType = i_NumberOfPlayer == 1 ? 'X' : 'O';
                m_NumberOfPlayer = i_NumberOfPlayer;
            }

            public char PlayerLetterType
            {
                get
                {
                    return m_LetterType;
                }

                set
                {
                    m_LetterType = value;
                }
            }

            public int NumberOfPlayer
            {
                get
                {
                    return m_NumberOfPlayer;
                }

                set
                {
                    m_NumberOfPlayer = value;
                }
            }

            public int PlayerScore
            {
                get
                {
                    return m_ScoreOfPlayer;
                }

                set
                {
                    m_ScoreOfPlayer = value;
                }
            }

            public ePlayerType PlayerType
            {
                get
                {
                    return m_PlayerType;
                }

                set
                {
                    m_PlayerType = value;
                }
            }
        }
    
}

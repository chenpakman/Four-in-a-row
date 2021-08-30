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
        public enum ePlayerChip
        {
            X,
            O
            
        }


            private ePlayerType m_PlayerType;
            private int m_ScoreOfPlayer=0;
            private ePlayerChip m_LetterType;
            bool m_IsPlayerWon;
            int m_NumOfPlayer;

            public Player(int i_PlayerType, char i_ChipOfPlayer)
            {
                m_PlayerType = (ePlayerType)i_PlayerType;
                m_ScoreOfPlayer = 0;
                m_LetterType = (ePlayerChip)i_ChipOfPlayer;
                 m_IsPlayerWon = false;
                m_NumOfPlayer = i_ChipOfPlayer == 'X'? 1 : 2;
            }

            public ePlayerChip PlayerLetterType
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

        public bool IsPlayerWon
        {
            get
            {
                return m_IsPlayerWon;
            }

            set
            {
                m_IsPlayerWon = value;
            }
        }

        public int NumberOfPlayer
        {
            get
            {
                return m_NumOfPlayer;
            }

            set
            {
                m_NumOfPlayer = value;
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

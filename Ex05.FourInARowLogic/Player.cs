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

        private readonly ePlayerType r_PlayerType;
        private int m_ScoreOfPlayer;
        private readonly ePlayerChip r_LetterType;
        private bool m_IsPlayerWon;
        private readonly int r_NumOfPlayer;

        public Player(int i_PlayerType, char i_ChipOfPlayer)
        {
            r_PlayerType = (ePlayerType)i_PlayerType;
            m_ScoreOfPlayer = 0;
            r_LetterType = (ePlayerChip)i_ChipOfPlayer;
            m_IsPlayerWon = false;
            r_NumOfPlayer = i_ChipOfPlayer == 'X' ? 1 : 2;
        }

        public ePlayerChip PlayerLetterType
        {
            get
            {
                return r_LetterType;
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
                return r_NumOfPlayer;
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
                return r_PlayerType;
            }
        }
    }
}
﻿namespace Ex05.FourInARowLogic
{
    public class Board
    {
        private readonly char[,] r_GameBoard;
        private readonly int r_BoardLength;
        private readonly int r_BoardWidth;
        private readonly int r_SequenceOfFour = 4;

        public Board(int i_BoardWidth, int i_BoardLength)
        {
            r_BoardLength = i_BoardLength;
            r_BoardWidth = i_BoardWidth;
            r_GameBoard = new char[r_BoardLength, r_BoardWidth];
            InitBoard(i_BoardLength, i_BoardWidth);
        }

        public int BoardWidth
        {
            get
            {
                return r_BoardWidth;
            }
        }

        public char[,] TheGameBoard
        {
            get
            {
                return r_GameBoard;
            }
        }

        public int BoardLength
        {
            get
            {
                return r_BoardLength;
            }
        }

        public void InitBoard(int i_BoardLength, int i_BoardWidth)
        {
            for(int i = 0; i < i_BoardLength; i++)
            {
                for(int j = 0; j < i_BoardWidth; j++)
                {
                    r_GameBoard[i, j] = ' ';
                }
            }
        }

        public bool AddChips(int i_ColumnChipToAdd, char i_PlayerChip, ref int o_CurrentChipRow)
        {
            bool isFullColumnNumber = IsFullColumn(i_ColumnChipToAdd - 1);

            if(!isFullColumnNumber)
            {
                for(int i = r_BoardLength - 1; i >= 0; i--)
                {
                    if(isEmptyPanel(i, i_ColumnChipToAdd - 1))
                    {
                        r_GameBoard[i, i_ColumnChipToAdd - 1] = i_PlayerChip;
                        o_CurrentChipRow = i;
                        break;
                    }
                }
            }

            return isFullColumnNumber;
        }

        private bool isEmptyPanel(int i_Row, int i_Col)
        {
            bool isEmptyPanel = r_GameBoard[i_Row, i_Col] == ' ';

            return isEmptyPanel;
        }

        public bool IsFullColumn(int i_ColumnChipToAdd)
        {
            bool isFullColumn = !(isEmptyPanel(0, i_ColumnChipToAdd));

            return isFullColumn;
        }

        public bool IsFourInARow(char i_PlayerChip, int i_ChipRowLocation, int i_ChipColLocation)
        {
            int count = 1;
            bool isFourInARow = false;

            for(int i = i_ChipColLocation; i > 0; i--)
            {
                if((r_GameBoard[i_ChipRowLocation, i] != r_GameBoard[i_ChipRowLocation, i - 1])
                   || (count == r_SequenceOfFour))
                {
                    break;
                }

                if(r_GameBoard[i_ChipRowLocation, i] == i_PlayerChip)
                {
                    count++;
                }
            }

            for(int i = i_ChipColLocation; i < BoardWidth - 1; i++)
            {
                if((r_GameBoard[i_ChipRowLocation, i] != r_GameBoard[i_ChipRowLocation, i + 1])
                   || (count == r_SequenceOfFour))
                {
                    break;
                }

                if(r_GameBoard[i_ChipRowLocation, i] == i_PlayerChip)
                {
                    count++;
                }
            }

            if(count >= r_SequenceOfFour)
            {
                isFourInARow = true;
            }

            return isFourInARow;
        }

        public bool IsFourInACol(char i_PlayerChip, int i_ChipRowLocation, int i_ChipColLocation)
        {
            int count = 1;
            bool isFourInACol = false;

            for(int i = i_ChipRowLocation; i > 0; i--)
            {
                if((r_GameBoard[i, i_ChipColLocation] != r_GameBoard[i - 1, i_ChipColLocation]) || (count == 4))
                {
                    break;
                }

                if(r_GameBoard[i, i_ChipColLocation] == i_PlayerChip)
                {
                    count++;
                }
            }

            for(int i = i_ChipRowLocation; i < r_BoardLength - 1; i++)
            {
                if((r_GameBoard[i, i_ChipColLocation] != r_GameBoard[i + 1, i_ChipColLocation]) || (count == 5))
                {
                    break;
                }

                if(r_GameBoard[i, i_ChipColLocation] == i_PlayerChip)
                {
                    count++;
                }
            }

            if(count >= r_SequenceOfFour)
            {
                isFourInACol = true;
            }

            return isFourInACol;
        }

        public bool IsFullBoard()
        {
            bool isFullBoard = true;

            for(int c = 0; c < r_BoardWidth; c++)
            {
                if(r_GameBoard[0, c] == ' ')
                {
                    isFullBoard = false;
                    break;
                }
            }

            return isFullBoard;
        }

        private bool isFourInADiagonalTopLeftToBottomRightIncludeMiddle(char i_PlayerChip)
        {
            int match = 0;
            bool isFourInADiagonal = false;
            int rowPosition = 0;
            char currentValue = ' ';

            for(int r = 0; r <= r_BoardLength - r_SequenceOfFour; r++)
            {
                rowPosition = r;
                match = 0;
                for(int column = 0; column < r_BoardWidth && rowPosition < r_BoardLength; column++)
                {
                    currentValue = r_GameBoard[rowPosition, column];
                    if(currentValue == i_PlayerChip)
                    {
                        match++;
                    }
                    else
                    {
                        match = 0;
                    }

                    if(match == 4)
                    {
                        isFourInADiagonal = true;
                        break;
                    }

                    rowPosition++;
                }

                if(isFourInADiagonal)
                {
                    break;
                }
            }

            return isFourInADiagonal;
        }

        private bool isFourInADiagonalBottomLeftToTopRightIncludeMiddle(char i_PlayerChip)
        {
            int match = 0;
            bool isFourInADiagonal = false;
            int rowPosition = 0;
            char currentValue = ' ';

            for(int r = r_BoardLength - 1; r >= r_BoardLength - r_SequenceOfFour; r--)
            {
                rowPosition = r;
                match = 0;
                for(int column = 0; column < r_BoardWidth && rowPosition < r_BoardLength && rowPosition >= 0; column++)
                {
                    currentValue = r_GameBoard[rowPosition, column];
                    if(currentValue == i_PlayerChip)
                    {
                        match++;
                    }
                    else
                    {
                        match = 0;
                    }

                    if(match == r_SequenceOfFour)
                    {
                        isFourInADiagonal = true;
                        break;
                    }

                    rowPosition--;
                }

                if(isFourInADiagonal)
                {
                    break;
                }
            }

            return isFourInADiagonal;
        }

        private bool isFourInADiagonalBottomLeftToTopRightAfterMiddle(char i_PlayerChip)
        {
            int match = 0;
            bool isFourInADiagonal = false;
            int columnPosition = 0;
            char currentValue = ' ';

            for(int c = 1; c < r_BoardWidth; c++)
            {
                columnPosition = c;
                match = 0;
                for(int row = r_BoardLength - 1;
                    row >= 0 && columnPosition < r_BoardWidth && columnPosition >= 1;
                    row--)
                {
                    currentValue = r_GameBoard[row, columnPosition];
                    if(currentValue == i_PlayerChip)
                    {
                        match++;
                    }
                    else
                    {
                        match = 0;
                    }

                    if(match == r_SequenceOfFour)
                    {
                        isFourInADiagonal = true;
                        break;
                    }

                    columnPosition++;
                }

                if(isFourInADiagonal)
                {
                    break;
                }
            }

            return isFourInADiagonal;
        }

        private bool isFourInADiagonalTopLeftToBottomRightAfterMiddle(char i_PlayerChip)
        {
            int match = 0;
            bool isFourInADiagonal = false;
            int columnPosition = 0;
            char currentValue = ' ';

            for(int c = 1; c <= r_BoardWidth - 4; c++)
            {
                columnPosition = c;
                match = 0;
                for(int row = 0; row < r_BoardLength && columnPosition < r_BoardWidth; row++)
                {
                    currentValue = r_GameBoard[row, columnPosition];
                    if(currentValue == i_PlayerChip)
                    {
                        match++;
                    }
                    else
                    {
                        match = 0;
                    }

                    if(match == r_SequenceOfFour)
                    {
                        isFourInADiagonal = true;
                        break;
                    }

                    columnPosition++;
                }

                if(isFourInADiagonal)
                {
                    break;
                }
            }

            return isFourInADiagonal;
        }

        public bool IsFourInADiagonal(char i_PlayerChip)
        {
            bool isFourInADiagonal = false;

            isFourInADiagonal = (isFourInADiagonalTopLeftToBottomRightAfterMiddle(i_PlayerChip)
                                 || isFourInADiagonalBottomLeftToTopRightIncludeMiddle(i_PlayerChip)
                                 || isFourInADiagonalBottomLeftToTopRightAfterMiddle(i_PlayerChip)
                                 || isFourInADiagonalTopLeftToBottomRightIncludeMiddle(i_PlayerChip));

            return isFourInADiagonal;
        }
    }
}
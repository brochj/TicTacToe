namespace TicTacToe.GameContext
{
    public class Victory
    {
        public string? Type;

        public bool IsVictory(char[] posistions)
        {
            return IsHorizontalWin(posistions) || IsVerticalWin(posistions) || IsDiagonalWin(posistions);
        }
        private bool IsHorizontalWin(char[] pos)
        {
            bool line1 = AreThePositionsTheSame(pos[0], pos[1], pos[2]);
            bool line2 = AreThePositionsTheSame(pos[3], pos[4], pos[5]);
            bool line3 = AreThePositionsTheSame(pos[6], pos[7], pos[8]);
            
            if (line1) { Type = VictoryType.Line1; }
            else if (line2) { Type = VictoryType.Line2; }
            else if (line3) { Type = VictoryType.Line3; }

            return line1 || line2 || line3;
        }
        private bool IsVerticalWin(char[] pos)
        {
            bool column1 = AreThePositionsTheSame(pos[0], pos[3], pos[6]);
            bool column2 = AreThePositionsTheSame(pos[1], pos[4], pos[7]);
            bool column3 = AreThePositionsTheSame(pos[2], pos[5], pos[8]);

            if (column1) { Type = VictoryType.Column1; }
            else if (column2) { Type = VictoryType.Column2; }
            else if (column3) { Type = VictoryType.Column3; }

            return column1 || column2 || column3;
        }
        private bool IsDiagonalWin(char[] pos)
        {
            bool diagonal1 = AreThePositionsTheSame(pos[0], pos[4], pos[8]);
            bool diagonal2 = AreThePositionsTheSame(pos[2], pos[4], pos[6]);

            if (diagonal1) { Type = VictoryType.Diagonal1; }
            else if (diagonal2) { Type = VictoryType.Diagonal2; }

            return diagonal1 || diagonal2;
        }
        private bool AreThePositionsTheSame(int pos1, int pos2, int pos3)
        {
            return pos1 == pos2 && pos1 == pos3;
        }
    }
}
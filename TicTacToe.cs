namespace TicTacToe
{
    class TicTacToeCore
    {
        private bool endGame;
        private char[] positions;
        private char turn;
        private int filledSpaces;
        public TicTacToeCore()
        {
            endGame = false;
            positions = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            turn = 'x';
            filledSpaces = 0;
        }

        public void Start()
        {
            while (!endGame)
            {
                RenderTable();
                ReadUserChoice();
                RenderTable();
                VerifyEndGame();
                ChangeTurn();
            }
        }

        private void ChangeTurn()
        {
            turn = turn == 'x' ? 'o' : 'x';
        }

        private void VerifyEndGame()
        {
            if (filledSpaces < 5)
                return;
            if (IsHorizontalWin() || IsVerticalWin() || IsDiagonalWin())
            {
                endGame = true;
                Console.WriteLine($"Fim de Jogo!! Vitória de {turn}");
                return;
            }

            if (filledSpaces is 9)
            {
                endGame = true;
                Console.WriteLine($"Empate!!");
                return;
            }
        }

        private bool IsHorizontalWin()
        {
            bool line1 = AreThePositionsTheSame(0, 1, 2);
            bool line2 = AreThePositionsTheSame(3, 4, 5);
            bool line3 = AreThePositionsTheSame(6, 7, 8);
            return line1 || line2 || line3;
        }
        private bool IsVerticalWin()
        {
            bool column1 = AreThePositionsTheSame(0, 3, 6);
            bool column2 = AreThePositionsTheSame(1, 4, 7);
            bool column3 = AreThePositionsTheSame(2, 5, 8);
            return column1 || column2 || column3;
        }
        private bool IsDiagonalWin()
        {
            bool diagonal1 = AreThePositionsTheSame(0, 4, 8);
            bool diagonal2 = AreThePositionsTheSame(2, 4, 6);
            return diagonal1 || diagonal2;
        }
        private bool AreThePositionsTheSame(int pos1, int pos2, int pos3)
        {
            return positions[pos1] == positions[pos2] && positions[pos1] == positions[pos3];
        }

        private void ReadUserChoice()
        {
            Console.WriteLine($"Agora é a vez do '{turn}', digite uma posição de 1 a 9 que esteja disponível");

            bool isValid = int.TryParse(Console.ReadLine(), out int positionChoosed);

            while (!isValid || !isUserChoiceValid(positionChoosed))
            {
                Console.WriteLine("Campo inválido, digite um número de 1 a 9 que esteja disponível");
                isValid = int.TryParse(Console.ReadLine(), out positionChoosed);

            }

            FillTheBlank(positionChoosed);
        }

        private void FillTheBlank(int positionChoosed)
        {
            int index = positionChoosed - 1;

            positions[index] = turn;
            filledSpaces++;
        }

        private bool isUserChoiceValid(int positionChoosed)
        {
            int index = positionChoosed - 1;


            return (positionChoosed < 10 && positionChoosed > 0 && positions[index] != 'o' && positions[index] != 'x');
        }

        private void RenderTable()
        {
            Console.Clear();
            Console.WriteLine(GetTable());

        }

        private string GetTable()
        {
            return $"__{positions[0]}__|__{positions[1]}__|__{positions[2]}__\n" +
                   $"__{positions[3]}__|__{positions[4]}__|__{positions[5]}__\n" +
                   $"  {positions[6]}  |  {positions[7]}  |  {positions[8]}  \n";
        }

    }
}
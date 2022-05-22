using TicTacToe.Config;
using TicTacToe.RenderContext;
using TicTacToe.GameContext;

namespace TicTacToe
{
    class TicTacToeCore
    {
        private bool endGame;
        private char[] positions;
        private char turn;
        private int filledSpaces;
        private Victory victory;
        public TicTacToeCore(Victory win)
        {
            endGame = false;
            positions = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            turn = Symbol.X;
            filledSpaces = 0;
            victory = win;
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
        private void RenderTable()
        {
            Console.Clear();
            Render.Table(positions);
        }
        private void ChangeTurn()
        {
            turn = turn == Symbol.X ? Symbol.O : Symbol.X;
        }
        private void VerifyEndGame()
        {

            if (filledSpaces < 5)
                return;


            if (IsVictory())
            {
                endGame = true;

                Console.WriteLine($"Fim de Jogo!! Vitória de '{turn}'");
                Console.WriteLine($"Tipo da Vitória {victory.Type}");
                return;
            }

            if (filledSpaces is 9)
            {
                endGame = true;
                Console.WriteLine($"Empate!!");
                return;
            }
        }
        private bool IsVictory()
        {
            return victory.IsVictory(positions);
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
        private bool isUserChoiceValid(int positionChoosed)
        {
            return (IsBetweenOneAndNine(positionChoosed) && IsThePositionFilled(positionChoosed));
        }
        private bool IsThePositionFilled(int pos)
        {
            int index = pos - 1;
            return positions[index] != Symbol.O && positions[index] != Symbol.X;
        }
        private bool IsBetweenOneAndNine(int number) => number > 0 && number < 10;
        private void FillTheBlank(int positionChoosed)
        {
            int index = positionChoosed - 1;

            positions[index] = turn;
            filledSpaces++;
        }
    }
}
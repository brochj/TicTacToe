namespace TicTacToe.RenderContext
{
    public class Render
    {
        public static void Table(char[] positions)
        {
            Console.WriteLine(DrawTable(positions));
        }
        private static string DrawTable(char[] positions)
        {
            return String.Join("",
                DrawEmptyLine(),
                DrawLineWithSymbol(positions[0], positions[1], positions[2]),
                DrawEmptyLine(),

                DrawHorizontalLine(),

                DrawEmptyLine(),
                DrawLineWithSymbol(positions[3], positions[4], positions[5]),
                DrawEmptyLine(),

                DrawHorizontalLine(),

                DrawEmptyLine(),
                DrawLineWithSymbol(positions[6], positions[7], positions[8]),
                DrawEmptyLine()

            );
        }
        private static string DrawEmptyLine()
        {
            return Center($"       |       |       \n");
        }
        private static string DrawLineWithSymbol(char pos1, char pos2, char pos3)
        {
            return Center($"   {pos1}   |   {pos2}   |   {pos3}   \n");
        }
        private static string DrawHorizontalLine(char symbol = '-', int width = 23)
        {
            return Center(new string(symbol, width) + "\n");
        }
        public static string Center(string line)
        {
            return String.Format("{0," + ((Console.WindowWidth / 2) + (line.Length / 2)) + "}", line);
        }
    }
}
public class ScreenGame(int columns = 10, int rows = 10, string icon = "-")
{
    public int ColumnLength { get; set; } = columns;
    public int RowLength { get; set; } = rows;
    public string ScreenBackgroundIcon { get; set; } = icon;
    private string[,] Screen = InitScreen(columns, rows, icon);

    static public string[,] InitScreen(int columnLength, int rowLength, string icon)
    {
        string[,] screen = new string[rowLength, columnLength];

        for (int row = 0; row < rowLength; row++)
            for (int column = 0; column < columnLength; column++)
                screen[row, column] = icon;

        return screen;
    }

    static public void Insert(int[] newPosition, string[,] screen, string newIcon)
    {
        for (int row = 0; row < screen.GetLength(0); row++)
        {
            if (row == newPosition[1])
            {
                for (int column = 0; column < screen.GetLength(1); column++)
                {
                    if (column == newPosition[0])
                    {
                        screen[row, column] = newIcon;
                        break;
                    }
                }
            }
        }
    }

    public void Display()
    {
        for (int row = 0; row < RowLength; row++)
        {
            for (int column = 0; column < ColumnLength; column++)
            {
                Console.Write(Screen[row, column]);
            }
            Console.Write("\n");
        }
    }

    public void Update(int[] newPosition, string newIcon)
    {
        Screen = InitScreen(ColumnLength, RowLength, ScreenBackgroundIcon);
        Insert(newPosition, Screen, newIcon);
    }

    public void Update(int[,] newPositions, string newIcon)
    {
        Screen = InitScreen(ColumnLength, RowLength, ScreenBackgroundIcon);
        for (int i = 0; i < newPositions.GetLength(0); i++)
        {
            int column = newPositions[i, 0];
            int row = newPositions[i, 1]; ;
            int[] newPosition = [column, row];
            Insert(newPosition, Screen, newIcon);
        }
    }
}
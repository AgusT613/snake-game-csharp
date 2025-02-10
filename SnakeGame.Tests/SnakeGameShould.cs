namespace SnakeGame.Tests;

public class SnakeGameShould
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(15, 10)]
    public void DisplayScreen(int columns, int rows)
    {
        var screenObj = new ScreenGame(columns: columns, rows: rows);
        string[,] screen = ScreenGame.InitScreen(screenObj.ColumnLength, screenObj.RowLength, screenObj.ScreenBackgroundIcon);

        var columnLength = screen.GetLength(1);
        var rowLength = screen.GetLength(0);

        Assert.True(columnLength == columns);
        Assert.True(rowLength == rows);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 9)]
    [InlineData(14, 9)]
    public void InsertOneElementToScreen(int column, int row)
    {
        var screenObj = new ScreenGame(columns: 15, rows: 10);
        string[,] screen = ScreenGame.InitScreen(screenObj.ColumnLength, screenObj.RowLength, screenObj.ScreenBackgroundIcon);
        int[] newPosition = [column, row];
        string newIcon = "@";

        ScreenGame.Insert(newPosition, screen, newIcon);

        Assert.True(screen[row, column] == newIcon);
    }


}

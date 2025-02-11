public class SnakeGame(ScreenGame screen, Food food, Player player)
{
    public int FoodCounter { get; set; } = 0;
    public int[,] FoodPositionsList = GetFoodPositionsList(screen.ColumnLength, screen.RowLength);
    private readonly Food Food = food;
    private readonly Player Player = player;

    public static int[,] GetFoodPositionsList(int screenWidth, int screenHeight)
    {
        Random position = new();
        float maxNumberOfItems = screenWidth * screenHeight * 0.25F;
        int foodElements = position.Next(5, (int)maxNumberOfItems);
        int[,] foodPosition = new int[foodElements, 2];

        for (int i = 0; i < foodPosition.GetLength(0); i++)
        {
            int foodPositionX = position.Next(0, screenWidth);
            int foodPositionY = position.Next(0, screenHeight);

            foodPosition[i, 0] = foodPositionX;
            foodPosition[i, 1] = foodPositionY;
        }

        return foodPosition;
    }

    public void Start()
    {
        screen.Update(newPositions: FoodPositionsList, Food.ToString());
        screen.Insert([Player.X, Player.Y], Player.ToString());

        screen.Display();
    }

    public void Restart()
    {
        FoodCounter = 0;
        FoodPositionsList = GetFoodPositionsList(screen.ColumnLength, screen.RowLength);
    }

    public void MovePlayer(string? direction)
    {
        switch (direction)
        {
            case "w":
                Player.Y--;
                break;
            case "s":
                Player.Y++;
                break;
            case "d":
                Player.X++;
                break;
            case "a":
                Player.X--;
                break;
        }

        if (Player.X < 0)
            Player.X = screen.ColumnLength - 1;
        else if (Player.X > screen.ColumnLength - 1)
            Player.X = 0;

        if (Player.Y < 0)
            Player.Y = screen.RowLength - 1;
        else if (Player.Y > screen.RowLength - 1)
            Player.Y = 0;
    }

    public void CheckPlayerGetFood(int playerX, int playerY)
    {
        for (int i = 0; i < FoodPositionsList.GetLength(0); i++)
        {
            if (FoodPositionsList[i, 0] == playerX && FoodPositionsList[i, 1] == playerY)
            {
                FoodPositionsList[i, 0] = -1;
                FoodPositionsList[i, 1] = -1;
                FoodCounter += 1;
                break;
            }
        }
    }

    public int GetTotalFood()
    {
        return FoodPositionsList.GetLength(0);
    }
}
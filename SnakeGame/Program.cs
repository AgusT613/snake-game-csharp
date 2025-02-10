// Screen Game
int screenWidth = 10;
int screenHeight = 10;

// Game Entities
string gameScreen = "";
string floor = "-";
string player = "@";
string food = "!";

// Entity Positions
int playerX = 0;
int playerY = 0;
int[,] foodPosition = FoodPositionsList();

// Game State
int foodCounter = 0;

// Program
while (true)
{
    Console.Clear();
    DrawScreenGame(playerX, playerY);
    if (foodCounter >= foodPosition.GetLength(0))
    {
        Console.Write("You win the game. Wanna play again? [y/n] ");
        if (Console.ReadLine() == "y")
        {
            foodCounter = 0;
            foodPosition = FoodPositionsList();
        }
        else
            break;
    }
    else
    {
        string? direction = Console.ReadLine();
        MovePlayer(direction);
        DrawScreenGame(playerX, playerY);
    }
}

// Functions
void DrawScreenGame(int playerPositionX, int playerPositionY)
{
    gameScreen = "";

    for (int i = 0; i < screenHeight; i++)
    {
        for (int i2 = 0; i2 < screenWidth; i2++)
        {
            // Display player and floor item in the screen
            if (playerPositionY == i && playerPositionX == i2)
                gameScreen += player;
            else
                gameScreen += floor;

            // Display food items in the screen and delete any floor item if index positions matches
            for (int foodIndex = 0; foodIndex < foodPosition.GetLength(0); foodIndex++)
            {
                if (playerPositionY == foodPosition[foodIndex, 1] && playerPositionX == foodPosition[foodIndex, 0])
                {
                    foodPosition[foodIndex, 0] = -1;
                    foodPosition[foodIndex, 1] = -1;
                    foodCounter++;
                    continue;
                }
                else if (i == foodPosition[foodIndex, 1] && i2 == foodPosition[foodIndex, 0])
                {
                    gameScreen = gameScreen.Remove(gameScreen.LastIndexOf(floor), 1);
                    gameScreen += food;
                }
            }
        }

        gameScreen += "\n";
    }

    Console.WriteLine($"Current food: {foodCounter}");
    Console.WriteLine(gameScreen);
}

void MovePlayer(string? direction)
{
    switch (direction)
    {
        case "w":
            playerY--;
            break;
        case "s":
            playerY++;
            break;
        case "d":
            playerX++;
            break;
        case "a":
            playerX--;
            break;
    }

    if (playerX < 0)
        playerX = screenWidth - 1;
    else if (playerX > screenWidth - 1)
        playerX = 0;

    if (playerY < 0)
        playerY = screenHeight - 1;
    else if (playerY > screenHeight - 1)
        playerY = 0;
}

int[,] FoodPositionsList()
{
    int[,] foodPosition = new int[5, 2];

    Random position = new Random();
    for (int i = 0; i < foodPosition.GetLength(0); i++)
    {
        int foodPositionX = position.Next(0, screenWidth);
        int foodPositionY = position.Next(0, screenHeight);

        foodPosition[i, 0] = foodPositionX;
        foodPosition[i, 1] = foodPositionY;
    }

    return foodPosition;
}
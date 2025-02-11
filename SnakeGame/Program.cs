var screenGame = new ScreenGame();
var food = new Food("!", screenGame);
var player = new Player("@");

var snakeGame = new SnakeGame(screenGame, food, player);

while (true)
{
    Console.Clear();
    Console.WriteLine($"Total: {snakeGame.GetTotalFood()}\tFood counter: {snakeGame.FoodCounter}");
    snakeGame.Start();
    if (snakeGame.FoodCounter >= snakeGame.GetTotalFood())
    {
        Console.Write("You win the game. Wanna play again? [y/n] ");
        if (Console.ReadLine() == "y")
        {
            snakeGame.Restart();
        }
        else
            break;
    }
    else
    {
        string? direction = Console.ReadLine();
        snakeGame.MovePlayer(direction);
        snakeGame.CheckPlayerGetFood(player.X, player.Y);
    }
}
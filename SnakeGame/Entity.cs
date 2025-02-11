
public abstract class Entity(string icon)
{
    string Icon { get; set; } = icon;
    public abstract int X { get; set; }
    public abstract int Y { get; set; }

    public override string ToString()
    {
        return Icon;
    }
}

public class Player(string icon) : Entity(icon)
{
    public override int X { get; set; } = 0;
    public override int Y { get; set; } = 0;
}

public class Food(string icon, ScreenGame screen) : Entity(icon)
{
    public override int X { get; set; } = new Random().Next(0, screen.ColumnLength);
    public override int Y { get; set; } = new Random().Next(0, screen.RowLength);
}
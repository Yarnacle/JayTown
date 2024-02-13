using Microsoft.Xna.Framework;

namespace JayTown.Physics;

public abstract class RectangleHitbox: IHasHitbox
{
    protected Vector2 Position;
    private Rectangle _rectangle;
    private int _width;
    private int _height;

    protected RectangleHitbox(Vector2 position,int width,int height)
    {
        Position = position;
        _width = width;
        _height = height;
        _rectangle = new Rectangle(new Point((int)position.X,(int)position.Y), new Point(width, height));
    }

    public virtual bool Intersects(Vector2 point)
    {
        return _rectangle.Contains(point);
    }

    public Vector2 GetPosition()
    {
        return Position;
    }
}
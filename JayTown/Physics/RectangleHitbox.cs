using Microsoft.Xna.Framework;

namespace JayTown.Physics;

public abstract class RectangleHitbox: IHasHitbox
{
    protected Point Position;
    private Rectangle _rectangle;
    private int _width;
    private int _height;

    protected RectangleHitbox(Point position,int width,int height)
    {
        Position = position;
        _width = width;
        _height = height;
        _rectangle = new Rectangle(position, new Point(width, height));
    }

    public virtual bool Intersects(Point point)
    {
        return _rectangle.Contains(point);
    }

    public Point GetPosition()
    {
        return Position;
    }
}
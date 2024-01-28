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
        this.Position = position;
        this._width = width;
        this._height = height;
        this._rectangle = new Rectangle(position, new Point(width, height));
    }

    public virtual bool Intersects(Point point)
    {
        return this._rectangle.Contains(point);
    }

    public Point GetPosition()
    {
        return this.Position;
    }
}
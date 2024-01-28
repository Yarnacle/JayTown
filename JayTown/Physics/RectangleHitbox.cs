using Microsoft.Xna.Framework;

namespace JayTown.Physics;

public abstract class RectangleHitbox: IHasHitbox
{
    protected Point position;
    private Rectangle rectangle;
    private int width;
    private int height;

    public RectangleHitbox(Point position,int width,int height)
    {
        this.position = position;
        this.width = width;
        this.height = height;
        this.rectangle = new Rectangle(position, new Point(width, height));
    }

    public virtual bool Intersects(Point point)
    {
        return this.rectangle.Contains(point);
    }

    public Point GetPosition()
    {
        return this.position;
    }
}
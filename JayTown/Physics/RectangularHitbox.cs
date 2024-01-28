using Microsoft.Xna.Framework;

namespace JayTown.Physics;

public abstract class RectangularHitbox: IHasHitbox
{
    private Point position;
    private Rectangle rectangle;
    private int width;
    private int height;

    public RectangularHitbox(Point position,int width,int height)
    {
        this.position = position;
        this.width = width;
        this.height = height;
        this.rectangle = new Rectangle(position, new Point(width, height));
    }

    public bool Intersects(Point point)
    {
        return this.rectangle.Contains(point);
    }

    public Point GetPosition()
    {
        return this.position;
    }
}
using Microsoft.Xna.Framework;

namespace JayTown.Physics;

public interface IHasHitbox
{
    public bool Intersects(Point point);
    public Point GetPosition();
}
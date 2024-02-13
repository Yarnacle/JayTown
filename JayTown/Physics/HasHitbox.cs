using System.Numerics;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace JayTown.Physics;

public interface IHasHitbox
{
    public bool Intersects(Vector2 point);
    public Vector2 GetPosition();
}
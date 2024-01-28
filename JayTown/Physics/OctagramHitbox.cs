using System;
using System.Transactions;
using Microsoft.Xna.Framework;

namespace JayTown.Physics;

public abstract class OctagramHitbox: RectangleHitbox
{
    public static double RadiusMultiplier = Math.Sqrt(2) / 2;

    private int radius;
    
    public OctagramHitbox(Point position,int radius): base(position,(int)Math.Round(radius * RadiusMultiplier),(int)Math.Round(radius * RadiusMultiplier))
    {
        this.radius = radius;
    }

    public override bool Intersects(Point point)
    {
        if (Math.Abs(this.position.X - point.X) + Math.Abs(this.position.Y - point.Y) <= radius)
        {
            return true;
        }

        return base.Intersects(point);
    }
}
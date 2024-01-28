using System;
using Microsoft.Xna.Framework;

namespace JayTown.Physics;

public abstract class OctagramHitbox: RectangleHitbox
{
    private static readonly double RadiusMultiplier = Math.Sqrt(2) / 2;

    private readonly int _radius;
    
    protected OctagramHitbox(Point position,int radius): base(position,(int)Math.Round(radius * RadiusMultiplier),(int)Math.Round(radius * RadiusMultiplier))
    {
        this._radius = radius;
    }

    public override bool Intersects(Point point)
    {
        return Math.Abs(this.Position.X - point.X) + Math.Abs(this.Position.Y - point.Y) <= _radius || base.Intersects(point);
    }
}
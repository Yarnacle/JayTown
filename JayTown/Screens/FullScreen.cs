using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public abstract class FullScreen: Screen
{
    public static Rectangle ScreenRectangle = new Rectangle(0, 0, 1000, 1000);
    
    protected FullScreen(SpriteBatch spriteBatch) : base(spriteBatch)
    {
        
    }
}
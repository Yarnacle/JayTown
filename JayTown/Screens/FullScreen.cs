using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public abstract class FullScreen: Screen
{
    public static readonly Rectangle Box = new Rectangle(0, 0, 1000, 1000);
    
    protected FullScreen(ScreenManager manager,SpriteBatch spriteBatch) : base(manager,spriteBatch)
    {
        
    }
}
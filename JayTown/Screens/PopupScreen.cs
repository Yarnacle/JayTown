using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public abstract class PopupScreen: Screen
{
    protected Rectangle Box;
    protected PopupScreen(ScreenManager manager,SpriteBatch spriteBatch,Rectangle box): base(manager,spriteBatch)
    {
        Box = box;
    }

    public Rectangle GetBox()
    {
        return Box;
    }
}
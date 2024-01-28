using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public abstract class Screen
{
    protected SpriteBatch spriteBatch;
    
    protected Screen(SpriteBatch spriteBatch)
    {
        this.spriteBatch = spriteBatch;
    }
    
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(GameTime gameTime);
}
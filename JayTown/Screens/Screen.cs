using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public abstract class Screen
{
    protected readonly SpriteBatch SpriteBatch;
    
    protected Screen(SpriteBatch spriteBatch)
    {
        this.SpriteBatch = spriteBatch;
    }
    
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(GameTime gameTime);
}
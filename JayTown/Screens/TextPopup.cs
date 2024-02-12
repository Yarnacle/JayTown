using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public class TextPopup: Popup
{
    protected string Text;
    protected readonly SpriteFont Font;
    protected Color Color;
    
    public TextPopup(ScreenManager manager,SpriteBatch spriteBatch,Rectangle box,SpriteFont font,string text,Color color) : base(manager,spriteBatch,box)
    {
        Text = text;
        Font = font;
        Color = color;
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Textures.General.SolidColor,Box,Color.Gray);
        SpriteBatch.DrawString(Font,Text,new Vector2(Box.X,Box.Y),Color);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public void SetColor(Color color)
    {
        Color = color;
    }
}
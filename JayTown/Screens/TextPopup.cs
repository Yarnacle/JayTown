using System.Text;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public class TextPopup: Popup
{
    protected string Text;
    protected readonly SpriteFont Font;
    protected Color Color;
    protected float Scale;
    protected int Padding;
    protected Texture2D Background;
    
    public TextPopup(ScreenManager manager,SpriteBatch spriteBatch,Rectangle box,SpriteFont font,string text,Color color,float scale,int padding,Texture2D background) : base(manager,spriteBatch,box)
    {
        Text = text;
        Font = font;
        Color = color;
        Scale = scale;
        Padding = padding;
        Background = background;
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Background,Box,Color.White);
        SpriteBatch.DrawString(Font,WrappedText(),new Vector2(Box.X + Padding,Box.Y + Padding),Color,0,new Vector2(0,0),Scale,SpriteEffects.None,0);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public void SetColor(Color color)
    {
        Color = color;
    }
    
    private string WrappedText()
    {
        var width = Box.Width - Padding * 2;
        if(Font.MeasureString(Text).X < width) {
            return Text;
        }
        var words = Text.Split(' ');
        var wrappedText = new StringBuilder();
        var lineWidth = 0f;
        var spaceWidth = Font.MeasureString(" ").X;
        foreach (var t in words)
        {
            var size = Font.MeasureString(t);
            if (lineWidth + size.X < width) {
                lineWidth += size.X + spaceWidth;
            } else {
                wrappedText.Append('\n');
                lineWidth = size.X + spaceWidth;
            }
            wrappedText.Append(t);
            wrappedText.Append(' ');
        }

        return wrappedText.ToString();
    }
}
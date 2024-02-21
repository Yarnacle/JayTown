using System;
using System.Text;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens;

public class TextPopup: Popup
{
    protected string Text;
    protected string WrappedText;
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
        UpdateWrapped();
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Draw(Background,Box,Color.White);
        // SpriteBatch.Draw(Textures.General.SolidColor,new Rectangle(Box.X + Padding,Box.Y + Padding,Box.Width - 2 * Padding,Box.Height - 2 * Padding),Color.Yellow);
        SpriteBatch.DrawString(Font,WrappedText,new Vector2(Box.X + Padding,Box.Y + Padding),Color,0,new Vector2(0,0),Scale,SpriteEffects.None,0);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public void SetColor(Color color)
    {
        Color = color;
    }

    public void SetText(string text)
    {
        Text = text;
        UpdateWrapped();
    }
    
    private void UpdateWrapped()
    {
        var width = Box.Width - Padding * 2;
        if(Font.MeasureString(Text).X * Scale < width) {
            WrappedText = Text;
        }

        var lines = Text.Split('\n');
        var wrappedLines = new StringBuilder();
        foreach (var line in lines)
        {
            var words = line.Split(' ');
            var wrappedText = new StringBuilder();
            var lineWidth = 0f;
            var spaceWidth = Font.MeasureString(" ").X * Scale;
            foreach (var t in words)
            {
                var size = Font.MeasureString(t) * Scale;
                if (lineWidth + size.X < width)
                {
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    wrappedText.Append('\n');
                    lineWidth = size.X + spaceWidth;
                }

                wrappedText.Append(t);
                wrappedText.Append(' ');
            }

            wrappedLines.Append(wrappedText);
            wrappedLines.Append('\n');
        }
        
        WrappedText = wrappedLines.ToString();
    }
}
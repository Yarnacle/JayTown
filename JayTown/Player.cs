using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using JayTown.Physics;

namespace JayTown;

public class Player: RectangleHitbox
{
    private const float QuarterRotation = (float) Math.PI / 2;

    private static Texture2D _texture;
    private static int _width;
    private static int _height;
    private Vector2 _velocity;
    private float _rotation;
    private float _speed = 5;

    private bool _horizontalFlip;
    
    public Player(Texture2D texture, Vector2 position, int width, int height): base(position,width,height)
    {
        Player._texture = texture; //load this better
        _width = width;
        _height = height;
        _velocity = new Vector2(0,0);
        _rotation = 0f;
    }
    public void Update(GameTime gameTime)
    {
        if (Game1.IsKeyDown(Keys.W))
        {
            _velocity.Y += -_speed;
        }

        if (Game1.IsKeyDown(Keys.S))
        {
            _velocity.Y += _speed;
        }

        if (Game1.IsKeyDown(Keys.A))
        {
            _horizontalFlip = true;
            _velocity.X += -_speed;
        }

        if (Game1.IsKeyDown(Keys.D))
        {
            _horizontalFlip = false;
            _velocity.X += _speed;
        }
        Position += _velocity;
        _velocity.X = 0;
        _velocity.Y = 0;
        
        Game1.UpdateKb();
    }
    public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
        spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, _width, _height), new Rectangle(0, 0, _texture.Width, _texture.Height), Color.White, _rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), _horizontalFlip ? SpriteEffects.FlipHorizontally:SpriteEffects.None, 0);
    }

}
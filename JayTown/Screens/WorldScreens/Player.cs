using System;
using System.IO;
using JayTown.GameTextures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JayTown.Screens.WorldScreens;

public class Player: Tile
{
    public enum Direction {None,Up,Down,Left,Right}
    
    private readonly SpriteBatch _spriteBatch;
    private World _world;
    
    // private const float QuarterRotation = (float) Math.PI / 2;

    private Point _destination;
    private Direction _moveDirection;
    
    private static Texture2D _texture;

    private bool _horizontalFlip;
    
    public Player(ScreenManager manager,SpriteBatch spriteBatch,Texture2D texture, Point gridPosition): base(manager,spriteBatch,gridPosition,Color.Transparent)
    {
        _moveDirection = Direction.None;
        _spriteBatch = spriteBatch;
        _destination = GridPosition;
        _texture = texture;
    }
    public void SetWorld(World world)
    {
        _world = world;
        switch (_moveDirection)
        {
            case Direction.Down:
                GridPosition.Y = -1;
                _destination.Y = 0;
                break;
            case Direction.Up:
                GridPosition.Y = 10;
                _destination.Y = 9;
                break;
            case Direction.Left:
                GridPosition.X = 10;
                _destination.X = 9;
                break;
            case Direction.Right:
                GridPosition.X = -1;
                _destination.X = 0;
                break;
        }
        Box.X = GridPosition.X * 100;
        Box.Y = GridPosition.Y * 100;
    }
    
    public override void Update(GameTime gameTime)
    {
        if (_moveDirection != Direction.None)
        {
            const int speed = 4;
            switch (_moveDirection)
            {
                case Direction.Down:
                    Box.Y += speed;
                    break;
                case Direction.Up:
                    Box.Y -= speed;
                    break;
                case Direction.Right:
                    Box.X += speed;
                    break;
                case Direction.Left:
                    Box.X -= speed;
                    break;
            }
            
            if (Box.X == _destination.X * 100 && Box.Y == _destination.Y * 100)
            {
                GridPosition = _destination;
                _moveDirection = Direction.None;
            }

            return;
        }
        if (Game1.IsKeyDown(Keys.W) || Game1.IsKeyDown(Keys.S))
        {
            if (Game1.IsKeyDown(Keys.W))
            {
                _destination.Y--;
            }
            else
            {
                _destination.Y++;
            }
        }
        else if (Game1.IsKeyDown(Keys.D) || Game1.IsKeyDown(Keys.A))
        {
            if (Game1.IsKeyDown(Keys.A))
            {
                _destination.X--;
            }
            else
            {
                _destination.X++;
            }
        }
        if (_destination.X < GridPosition.X)
        {
            _moveDirection = Direction.Left;
            _horizontalFlip = true;
        }
        else if (_destination.X > GridPosition.X)
        {
            _moveDirection = Direction.Right;
            _horizontalFlip = false;
        }
        else if (_destination.Y < GridPosition.Y)
        {
            _moveDirection = Direction.Up;
        }
        else if (_destination.Y > GridPosition.Y)
        {
            _moveDirection = Direction.Down;
        }

        if (!_world.CheckTile(_destination))
        {
            _moveDirection = Direction.None;
            _destination = GridPosition;
        }
    }
    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Draw(Textures.General.SolidColor,new Rectangle(_destination.X * 100,_destination.Y * 100,100,100),Color.Gray);
        _spriteBatch.Draw(_texture, Box, new Rectangle(0, 0, _texture.Width,_texture.Height), Color.White, 0, new Vector2(0,0), _horizontalFlip ? SpriteEffects.FlipHorizontally:SpriteEffects.None, 0);
    }
}
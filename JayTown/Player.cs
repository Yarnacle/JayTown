using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace JayTown
{
    public class Player
    {
        public static Texture2D texture;
        public static int width;
        public static int height;
        public Vector2 position;
        public Vector2 velocity;
        public float rotation;
        public float speed = 5;
        public Player(Texture2D texture, int x, int y, int w, int h)
        {

            Player.texture = texture; //load this better
            width = w;
            height = h;
            this.position = new Vector2(x, y);
            this.velocity = new Vector2();
            rotation = 0f;
        }
        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState(); //pass this from game class and add to functoin parameters
            KeyboardState kb = Keyboard.GetState(); //same as above
            if (kb.IsKeyDown(Keys.W))
                velocity.Y = -speed;
            if (kb.IsKeyDown(Keys.S))
                velocity.Y = speed;
            if (kb.IsKeyDown(Keys.A))
                velocity.X = -speed;
            if (kb.IsKeyDown(Keys.D))
                velocity.X = speed;
            rotation = (float)(Math.Atan2(this.position.Y - mouse.Y, this.position.X - mouse.X) + Math.PI / 2);
            position += velocity;
            velocity.X = 0;
            velocity.Y = 0;
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, width, height), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }

    }
}

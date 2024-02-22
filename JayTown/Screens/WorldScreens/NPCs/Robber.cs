using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class Robber: Npc
{

    public Robber(ScreenManager manager, SpriteBatch spriteBatch, World world) : base(manager, spriteBatch,
        Color.Purple, world, new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.Purple, "What do you want?"),
            Tuple.Create(Color.White, "..."),
            Tuple.Create(Color.Purple, "Do I look like a criminal to you?! I'll be on my way now.")
        }, new Point(1, 4), new List<Point>()
        {
            new Point(1, 2),
            new Point(2, 2),
            new Point(2, -1)
        })
    {

    }

    public void Start()
    {
        Destination = 0;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (DialogueState == State.After)
        {
            if (Destination == -1)
            {
                Destination = 0;
            }
        }
        if (Destination == Path.Count)
        {
            Console.WriteLine("Finished");
            if (World == ScreenManager.Worlds["SpawnEntrance"])
            {
                World.RemoveNPC(Color);
                ChangeWorld(ScreenManager.Worlds["FarmCorner"],new Point(3,5),new List<Point>(){new Point(0,5),new Point(0,0)},new List<Tuple<Color, string>>()
                {
                        
                });
                DialogueState = State.After;
            }
            else if (World == ScreenManager.Worlds["FarmCorner"]) {
                Destination = -1;
            }
        }
    }

    public override void InitiateDialogue()
    {
            base.InitiateDialogue();
    }
}
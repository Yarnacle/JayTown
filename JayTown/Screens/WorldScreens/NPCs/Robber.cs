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
            new(1, 2),
            new(2, 2),
            new(2, -1)
        },new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.Purple,"uRggh...")
        })
    {

    }

    public override void AfterDeath()
    {
        ScreenManager.Worlds["Spawn"].GetNPCs()[Color.Maroon].NewDialogue(new List<Tuple<Color, string>>()
        {
            Tuple.Create(Color.DarkRed,"Good work. You know it's thanks to you that we can have peace in this town."),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.DarkRed,"Cool. Anyway, I have received reports of someone disturbing the peace near Pav and Chenny's cabin down south. Mind taking care of it?"),
            Tuple.Create(Color.White,"..."),
            Tuple.Create(Color.DarkRed,"Great, I knew I could count on you.")
        });
    }

    public void Start()
    {
        if (Dead)
        {
            return;
        }
        Destination = 0;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (Dead)
        {
            return;
        }
        if (DialogueState == State.After)
        {
            if (Destination == -1 && Dialogue.Count != 1)
            {
                Destination = 0;
            }
        }
        if (Destination == Path.Count)
        {
            Console.WriteLine("Pathing finished");
            if (World == ScreenManager.Worlds["SpawnEntrance"])
            {
                World.RemoveNPC(Color);
                ChangeWorld(ScreenManager.Worlds["FarmRoad"],new Point(3,5),new List<Point>(){new Point(0,5),new Point(0,0)},new List<Tuple<Color, string>>()
                {
                        
                });
                DialogueState = State.After;
            }
            else if (World == ScreenManager.Worlds["FarmRoad"]) {
                Destination = -1;
            }
        }
    }
}
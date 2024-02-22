using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class MayorJay: Npc
{
    private int _plotProgress;
    
    public MayorJay(ScreenManager manager,SpriteBatch spriteBatch,World world) : base(manager,spriteBatch, Color.Maroon,world,new List<Tuple<Color,string>>()
    {
        Tuple.Create(Color.DarkRed,"Hello! Ready for your next task?"),
        Tuple.Create(Color.White,"..."),
        Tuple.Create(Color.DarkRed,"Talkative as usual. Anyway there's a ROBBER on the lose. Get him please.")
    },new Point(6,4),new List<Point>(),null)
    {
        _plotProgress = 0;
    }

    public override void NextDialogue()
    {
        base.NextDialogue();
        
        if (DialogueState == State.After) // on dialogue finish
        {
            if (_plotProgress == 0)
            {
                ScreenManager.Worlds["SpawnEntrance"].AddNPC(new Robber(ScreenManager,SpriteBatch,ScreenManager.Worlds["SpawnEntrance"]));
            }
            else if (_plotProgress == 1)
            {
                ScreenManager.Worlds["Cabin1"].AddNPC(new Chenny(ScreenManager,SpriteBatch,ScreenManager.Worlds["Cabin1"]));
                ScreenManager.Worlds["Cabin1"].AddNPC(new Pav(ScreenManager,SpriteBatch,ScreenManager.Worlds["Cabin1"]));
            }

            _plotProgress++;
        }
    }
}
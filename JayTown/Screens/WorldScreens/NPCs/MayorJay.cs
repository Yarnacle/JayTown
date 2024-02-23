using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.Screens.WorldScreens.NPCs;

public class MayorJay: Npc
{
    private int _plotProgress;
    
    public MayorJay(ScreenManager manager,SpriteBatch spriteBatch,World world) : base(manager,spriteBatch, Color.Maroon,world,new List<Tuple<Color,string>>()
    {
        Tuple.Create(Color.IndianRed,"Hello! Ready for your next task?"),
        Tuple.Create(Color.White,"..."),
        Tuple.Create(Color.IndianRed,"Talkative as usual. Anyway there's a ROBBER on the lose. Get him please.")
    },new Point(6,4),null,null)
    {
        _plotProgress = 3;
    }

    public override void FinishedDialogue()
    {
        if (_plotProgress == 0)
        {
            ScreenManager.Worlds["SpawnEntrance"]
                .AddNPC(new Robber(ScreenManager, SpriteBatch, ScreenManager.Worlds["SpawnEntrance"]));
        }
        else if (_plotProgress == 1)
        {
            ScreenManager.Worlds["Cabin1"]
                .AddNPC(new Chenny(ScreenManager, SpriteBatch, ScreenManager.Worlds["Cabin1"]));
            ScreenManager.Worlds["Cabin1"].AddNPC(new Pav(ScreenManager, SpriteBatch, ScreenManager.Worlds["Cabin1"]));
        }
        else if (_plotProgress == 2)
        {
            ScreenManager.Worlds["FarmBend"].AddNPC(new Vorrow(ScreenManager,SpriteBatch,ScreenManager.Worlds["FarmBend"]));
        }
        else if (_plotProgress == 3)
        {
            ScreenManager.Worlds["CobbleRoad"].AddNPC(new Nav(ScreenManager,SpriteBatch,ScreenManager.Worlds["CobbleRoad"]));
            ScreenManager.Worlds["RoadEnd"].AddNPC(new Lan(ScreenManager, SpriteBatch, ScreenManager.Worlds["RoadEnd"]));
            ScreenManager.Worlds["RoadEnd"].AddNPC(new Shash(ScreenManager,SpriteBatch,ScreenManager.Worlds["RoadEnd"]));
        }

        _plotProgress++;
    }
}
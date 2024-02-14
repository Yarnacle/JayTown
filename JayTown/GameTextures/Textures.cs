using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.GameTextures;

public static class Textures
{
    private static GraphicsDevice _graphicsDevice;

    public static readonly Dictionary<Color,Texture2D> Tiles = new();
    
    // Directories
    public static readonly dynamic HomeScreen = new ExpandoObject();
    public static readonly dynamic General = new ExpandoObject();
    public static readonly dynamic PixelMaps = new ExpandoObject();
    
    public static void Load(GraphicsDevice graphicsDevice,ContentManager content)
    {
        _graphicsDevice = graphicsDevice;
        
        // Textures
        General.SolidColor = LoadTile("General/SolidColor.png",Color.White);
        General.ClearScreen = Load("General/ClearScreen.png");
        General.Font = LoadFont(content,"PixelFont");
        General.Lan = LoadTile("HomeScreen/Lan.png",Color.Red);

        PixelMaps.Spawn = Load("PixelMaps/Spawn.png");
        
        HomeScreen.Background = Load("HomeScreen/Background.png");
    }

    private static Texture2D Load(string path)
    {
        var fileStream = new FileStream("Content/Textures/" + path, FileMode.Open);
        var texture = Texture2D.FromStream(_graphicsDevice,fileStream);
        fileStream.Close();
        return texture;
    }

    private static Texture2D LoadTile(string path, Color tileColor)
    {
         var texture = Load(path);
         Tiles[tileColor] = texture;
         return texture;
    }

    private static SpriteFont LoadFont(ContentManager content,string path)
    {
        return content.Load<SpriteFont>(path);
    }
}
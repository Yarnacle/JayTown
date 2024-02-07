using System.Dynamic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JayTown.GameTextures;

public static class Textures
{
    private static GraphicsDevice _graphicsDevice;
    
    // Directories
    public static readonly dynamic HomeScreen = new ExpandoObject();
    public static readonly dynamic General = new ExpandoObject();
    
    public static void Load(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
        
        // Textures
        General.SolidColor = Load("General/SolidColor.png");
        General.ClearScreen = Load("General/ClearScreen.png");
        
        HomeScreen.Lan = Load("HomeScreen/Lan.png");
    }

    private static Texture2D Load(string path)
    {
        using var fileStream = new FileStream("Content/Textures/" + path, FileMode.Open);
        var texture = Texture2D.FromStream(_graphicsDevice,fileStream);
        return texture;
    }
}
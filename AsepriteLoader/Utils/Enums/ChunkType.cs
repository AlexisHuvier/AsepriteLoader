namespace AsepriteLoader.Utils.Enums;

public enum ChunkType
{
    OldPalette = 4,
    OldPalette2 = 17,
    Layer = 8196,
    Cel = 8197,
    CelExtra = 8198,
    ColorProfile = 8199,
    ExternalFiles = 8200,
    
    [Obsolete("Deprecated in Aseprite")]
    Mask = 8214,
    
    Path = 8215, // NEVER USED
    Tags = 8216,
    Palette = 8217,
    UserData = 8224,
    Slice = 8226,
    Tileset = 8227
}
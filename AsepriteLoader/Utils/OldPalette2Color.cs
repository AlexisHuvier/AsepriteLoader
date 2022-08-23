namespace AsepriteLoader.Utils;

public class OldPalette2Color
{
    public readonly byte Red;
    public readonly byte Green;
    public readonly byte Blue;

    public OldPalette2Color(BinaryReader stream)
    {
        Red = stream.ReadByte();
        Green = stream.ReadByte();
        Blue = stream.ReadByte();
    }

    public override string ToString() => $"OldPalette2Color : ({Red}, {Green}, {Blue})";
}
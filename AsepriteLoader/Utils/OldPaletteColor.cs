namespace AsepriteLoader.Utils;

public class OldPaletteColor
{
    public readonly byte Red;
    public readonly byte Green;
    public readonly byte Blue;

    public OldPaletteColor(BinaryReader stream)
    {
        Red = stream.ReadByte();
        Green = stream.ReadByte();
        Blue = stream.ReadByte();
    }

    public override string ToString() => $"OldPaletteColor : ({Red}, {Green}, {Blue})";
}
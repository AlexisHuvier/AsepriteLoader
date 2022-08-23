namespace AsepriteLoader.Utils;

public class PaletteEntry
{
    public readonly bool HasName;
    public readonly byte Red;
    public readonly byte Green;
    public readonly byte Blue;
    public readonly byte Alpha;
    
    // IF HAS NAME
    public readonly string ColorName;

    public PaletteEntry(BinaryReader stream)
    {
        HasName = stream.ReadUInt16() == 1;
        Red = stream.ReadByte();
        Green = stream.ReadByte();
        Blue = stream.ReadByte();
        Alpha = stream.ReadByte();
        ColorName = "";

        if (HasName)
            ColorName = BinaryReaderUtils.ReadString(stream);
    }

    public override string ToString() =>
        $"PaletteEntry :\n - HasName : {HasName} ({ColorName})\n - RGBA : ({Red}, {Green}, {Blue}, {Alpha})";
}
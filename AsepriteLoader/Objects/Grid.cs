namespace AsepriteLoader.Objects;

public class Grid
{
    public readonly short X;
    public readonly short Y;
    public readonly ushort Width;
    public readonly ushort Height;
    
    public Grid(BinaryReader stream)
    {
        X = stream.ReadInt16();
        Y = stream.ReadInt16();
        Width = stream.ReadUInt16();
        Height = stream.ReadUInt16();
    }
}
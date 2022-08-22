namespace AsepriteLoader.Objects;

public class Chunk
{
    public readonly uint Size;
    public readonly ushort Type;

    public Chunk(BinaryReader stream)
    {
        Size = stream.ReadUInt32();
        Type = stream.ReadUInt16();
    }
}
namespace AsepriteLoader.Objects;

public class Frame
{
    public readonly uint Size;
    public readonly uint ChunkNumber;
    public readonly ushort Duration;

    public Frame(BinaryReader stream)
    {
        Size = stream.ReadUInt32();
        stream.ReadUInt16(); // MAGIC NUMBER
        var oldChunkNumber = stream.ReadUInt16();
        Duration = stream.ReadUInt16();
        stream.ReadBytes(2); // FOR FUTURE
        var newChunkNumber = stream.ReadUInt32();
        ChunkNumber = newChunkNumber == 0 ? oldChunkNumber : newChunkNumber;
    }
}
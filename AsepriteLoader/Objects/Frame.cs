namespace AsepriteLoader.Objects;

public class Frame
{
    public readonly uint Size;
    public readonly uint ChunkNumber;
    public readonly ushort Duration;
    public readonly List<Chunk> Chunks;

    public Frame(AsepriteFile file, BinaryReader stream)
    {
        Size = stream.ReadUInt32();
        stream.ReadUInt16(); // MAGIC NUMBER
        var oldChunkNumber = stream.ReadUInt16();
        Duration = stream.ReadUInt16();
        stream.ReadBytes(2); // FOR FUTURE
        var newChunkNumber = stream.ReadUInt32();
        ChunkNumber = newChunkNumber == 0 ? oldChunkNumber : newChunkNumber;
        Chunks = new List<Chunk>();
        for (var i = 0; i < ChunkNumber; i++)
            Chunks.Add(new Chunk(file, stream));
    }

    public override string ToString() =>
        $"Frame :\n - Size : {Size}\n - Duration : {Duration}\n - Chunks ({ChunkNumber}) : \n  - " +
        string.Join("\n - ", Chunks).Replace("\n", "\n ");
}
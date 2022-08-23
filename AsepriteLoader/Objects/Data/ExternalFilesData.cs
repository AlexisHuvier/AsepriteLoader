using AsepriteLoader.Utils;

namespace AsepriteLoader.Objects.Data;

public class ExternalFilesData: ChunkData
{
    public readonly uint EntryNumber;
    public readonly List<ExternalFilesEntry> Entries;

    public ExternalFilesData(BinaryReader stream)
    {
        EntryNumber = stream.ReadUInt32();
        stream.ReadBytes(8);
        Entries = new List<ExternalFilesEntry>();
        for(var i = 0; i < EntryNumber; i++) 
            Entries.Add(new ExternalFilesEntry(stream));
    }

    public override string ToString() => 
        $"ExternalFilesData :\n - Entries ({EntryNumber}) : \n  - " +
        string.Join("\n - ", Entries).Replace("\n", "\n ");
}
using AsepriteLoader.Utils;

namespace AsepriteLoader.Objects.Data;

public class PaletteData: ChunkData
{
    public readonly uint PaletteEntryNumber;
    public readonly uint FirstColorIndex;
    public readonly uint LastColorIndex;
    public readonly List<PaletteEntry> PaletteEntries;

    public PaletteData(BinaryReader stream)
    {
        PaletteEntryNumber = stream.ReadUInt32();
        FirstColorIndex = stream.ReadUInt32();
        LastColorIndex = stream.ReadUInt32();
        stream.ReadBytes(8); // FOR FUTURE
        PaletteEntries = new List<PaletteEntry>();
        for(var i = 0; i < PaletteEntryNumber; i++)
            PaletteEntries.Add(new PaletteEntry(stream));
    }
    
    public override string ToString() => 
        $"PaletteData :\n - Color Index Change : First = {FirstColorIndex} / Last = {LastColorIndex}\n" +
        $" - Palette Entries ({PaletteEntryNumber}) : \n  - " +
        string.Join("\n - ", PaletteEntries).Replace("\n", "\n ");
}
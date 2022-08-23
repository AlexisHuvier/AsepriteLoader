namespace AsepriteLoader.Utils;

public class OldPalettePacket
{
    public readonly byte PaletteEntryNumber;
    public readonly byte ColorNumber;
    public readonly List<OldPaletteColor> Colors;

    public OldPalettePacket(BinaryReader stream)
    {
        PaletteEntryNumber = stream.ReadByte();
        ColorNumber = stream.ReadByte();
        Colors = new List<OldPaletteColor>();
        for(var i = 0; i < ColorNumber; i++)
            Colors.Add(new OldPaletteColor(stream));
    }

    public override string ToString() =>
        $"OldPalettePacket :\n - Number : {PaletteEntryNumber}\n - Colors ({ColorNumber}) :\n  - " +
        string.Join("\n  - ", Colors);
}
namespace AsepriteLoader.Utils;

public class OldPalette2Packet
{
    public readonly byte PaletteEntryNumber;
    public readonly byte ColorNumber;
    public readonly List<OldPalette2Color> Colors;

    public OldPalette2Packet(BinaryReader stream)
    {
        PaletteEntryNumber = stream.ReadByte();
        ColorNumber = stream.ReadByte();
        Colors = new List<OldPalette2Color>();
        for(var i = 0; i < ColorNumber; i++)
            Colors.Add(new OldPalette2Color(stream));
    }

    public override string ToString() =>
        $"OldPalette2Packet :\n - Number : {PaletteEntryNumber}\n - Colors ({ColorNumber}) :\n  - " +
        string.Join("\n  - ", Colors);
}
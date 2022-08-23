using AsepriteLoader.Utils;

namespace AsepriteLoader.Objects.Data;

public class OldPaletteData: ChunkData
{
    public readonly ushort PacketNumber;
    public readonly List<OldPalettePacket> Packets;

    public OldPaletteData(BinaryReader stream)
    {
        PacketNumber = stream.ReadUInt16();
        Packets = new List<OldPalettePacket>();
        for (var i = 0; i < PacketNumber; i++)
            Packets.Add(new OldPalettePacket(stream));
    }

    public override string ToString() =>
        $"OldPaletteData :\n - Packets ({PacketNumber}) : \n  - " +
        string.Join("\n - ", Packets).Replace("\n", "\n ");
}
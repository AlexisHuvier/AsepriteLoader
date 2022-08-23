using AsepriteLoader.Utils;

namespace AsepriteLoader.Objects.Data;

public class OldPalette2Data: ChunkData
{
    public readonly ushort PacketNumber;
    public readonly List<OldPalette2Packet> Packets;

    public OldPalette2Data(BinaryReader stream)
    {
        PacketNumber = stream.ReadUInt16();
        Packets = new List<OldPalette2Packet>();
        for (var i = 0; i < PacketNumber; i++)
            Packets.Add(new OldPalette2Packet(stream));
    }

    public override string ToString() =>
        $"OldPalette2Data :\n - Packets ({PacketNumber}) : \n  - " +
        string.Join("\n - ", Packets).Replace("\n", "\n ");
}
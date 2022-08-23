using AsepriteLoader.Utils;
using AsepriteLoader.Utils.Enums;
using AsepriteLoader.Utils.Flags;

namespace AsepriteLoader.Objects.Data;

public class LayerData: ChunkData
{
    public readonly LayerFlags Flags;
    public readonly LayerType Type;
    public readonly ushort ChildLevel;
    public readonly ushort DefaultWidth;
    public readonly ushort DefaultHeight;
    public readonly BlendMode BlendMode;
    public readonly byte Opacity;
    public readonly string Name;
    public readonly uint TilemapIndex;

    public LayerData(BinaryReader stream)
    {
        Flags = (LayerFlags)stream.ReadUInt16();
        Type = (LayerType)stream.ReadUInt16();
        ChildLevel = stream.ReadUInt16();
        DefaultWidth = stream.ReadUInt16();
        DefaultHeight = stream.ReadUInt16();
        BlendMode = (BlendMode)stream.ReadUInt16();
        Opacity = stream.ReadByte();
        stream.ReadBytes(3); // FOR FUTURE
        Name = BinaryReaderUtils.ReadString(stream);
        if (Type == LayerType.Tilemap)
            TilemapIndex = stream.ReadUInt32();
    }

    public override string ToString() =>
        $"LayerData :\n - Flags : {Flags}\n - Type : {Type}\n - Child Level : {ChildLevel}\n " +
        $"- Default Size : {DefaultWidth}x{DefaultHeight}\n - Blend Mode : {BlendMode}\n - Opacity : {Opacity}\n " +
        $"- Name : {Name}\n - Tilemap Index : {TilemapIndex}";
}
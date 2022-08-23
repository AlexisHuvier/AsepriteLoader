using AsepriteLoader.Utils;

namespace AsepriteLoader.Objects.Data;

public class MaskData: ChunkData
{
    public readonly short X;
    public readonly short Y;
    public readonly ushort Width;
    public readonly ushort Height;
    public readonly string Name;
    public readonly List<byte> BitmapData;

    public MaskData(BinaryReader stream)
    {
        X = stream.ReadInt16();
        Y = stream.ReadInt16();
        Width = stream.ReadUInt16();
        Height = stream.ReadUInt16();
        stream.ReadBytes(8); // FOR FUTURE
        Name = BinaryReaderUtils.ReadString(stream);
        BitmapData = new List<byte>(stream.ReadBytes(Height * ((Width + 7) / 8)));
    }

    public override string ToString() =>
        $"MaskData :\n - Position : X = {X} / Y = {Y}\n - Size : {Width}x{Height}\n - Name : {Name}\n" +
        $" - Bitmap Data Size : {BitmapData.Count}";
}
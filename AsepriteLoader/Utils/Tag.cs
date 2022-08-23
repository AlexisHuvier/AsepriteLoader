using AsepriteLoader.Utils.Enums;

namespace AsepriteLoader.Utils;

public class Tag
{
    public readonly ushort FromFrame;
    public readonly ushort ToFrame;
    public readonly LoopAnimationDirection LoopAnimationDirection;
    
    [Obsolete("Deprecated, used for Aseprite v1.2.x")]
    public readonly List<byte> RGBValues;

    public readonly string Name;

    public Tag(BinaryReader stream)
    {
        FromFrame = stream.ReadUInt16();
        ToFrame = stream.ReadUInt16();
        LoopAnimationDirection = (LoopAnimationDirection)stream.ReadByte();
        stream.ReadBytes(8); // FOR FUTURE
        RGBValues = new List<byte>(stream.ReadBytes(3));
        stream.ReadByte(); // EXTRA BYTE
        Name = BinaryReaderUtils.ReadString(stream);
    }

    public override string ToString() => $"Tag :\n - Frame : From = {FromFrame} / To = {ToFrame}\n" +
                                         $" - Loop Animation Direction : {LoopAnimationDirection}\n" +
                                         $" - RGB Values for Tag Color : ({RGBValues[0]}, {RGBValues[1]}, {RGBValues[2]})\n" +
                                         $" - Name : {Name}";
}
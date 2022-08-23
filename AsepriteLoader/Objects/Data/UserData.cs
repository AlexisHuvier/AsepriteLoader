using AsepriteLoader.Utils;
using AsepriteLoader.Utils.Flags;

namespace AsepriteLoader.Objects.Data;

public class UserData: ChunkData
{
    public readonly UserFlags UserFlags;
    
    // FLAGS BIT 1
    public readonly string Text;
    
    // FLAGS BIT 2
    public readonly byte Red;
    public readonly byte Green;
    public readonly byte Blue;
    public readonly byte Alpha;

    public UserData(BinaryReader stream)
    {
        UserFlags = (UserFlags)stream.ReadUInt32();
        Text = "";

        if ((UserFlags & UserFlags.HasText) == UserFlags.HasText)
            Text = BinaryReaderUtils.ReadString(stream);

        if ((UserFlags & UserFlags.HasColor) == UserFlags.HasColor)
        {
            Red = stream.ReadByte();
            Green = stream.ReadByte();
            Blue = stream.ReadByte();
            Alpha = stream.ReadByte();
        }
    }

    public override string ToString() => $"UserData :\n - Flags : {UserFlags}" +
                                         ((UserFlags & UserFlags.HasText) == UserFlags.HasText
                                             ? $"\n - Text : {Text}"
                                             : "") +
                                         ((UserFlags & UserFlags.HasColor) == UserFlags.HasColor
                                             ? $"\n - Color : ({Red}, {Green}, {Blue}, {Alpha})"
                                             : "");
}
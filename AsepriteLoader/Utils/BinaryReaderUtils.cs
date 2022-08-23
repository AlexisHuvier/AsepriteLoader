using System.Text;
using AsepriteLoader.Utils.Enums;
using AsepriteLoader.Utils.Pixel;

namespace AsepriteLoader.Utils;

public class BinaryReaderUtils
{
    public static string ReadString(BinaryReader reader)
    {
        var length = reader.ReadUInt16();
        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }

    public static PixelBase ReadPixel(AsepriteFile file, BinaryReader reader)
    {
        switch (file.Header.ColorDepth)
        {
            case ColorDepth.RGBA:
                return new PixelRgba(reader);
            case ColorDepth.GrayScale:
                return new PixelGray(reader);
            case ColorDepth.Indexed:
                return new PixelIndexed(reader);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
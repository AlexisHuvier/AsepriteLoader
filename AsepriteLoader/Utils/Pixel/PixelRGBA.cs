namespace AsepriteLoader.Utils.Pixel;

public class PixelRgba: PixelBase
{
    public readonly byte Red;
    public readonly byte Green;
    public readonly byte Blue;
    public readonly byte Alpha;

    public PixelRgba(BinaryReader stream)
    {
        Red = stream.ReadByte();
        Green = stream.ReadByte();
        Blue = stream.ReadByte();
        Alpha = stream.ReadByte();
    }

    public override string ToString() => $"Pixel RGBA : ({Red}, {Green}, {Blue}, {Alpha})";
}
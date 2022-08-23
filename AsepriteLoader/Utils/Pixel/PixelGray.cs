namespace AsepriteLoader.Utils.Pixel;

public class PixelGray: PixelBase
{
    public readonly byte Value;
    public readonly byte Alpha;

    public PixelGray(BinaryReader stream)
    {
        Value = stream.ReadByte();
        Alpha = stream.ReadByte();
    }

    public override string ToString() => $"Pixel GrayScale : ({Value}, {Alpha})";
}
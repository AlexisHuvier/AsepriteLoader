namespace AsepriteLoader.Utils.Pixel;

public class PixelIndexed: PixelBase
{
    public readonly byte Index;
    
    public PixelIndexed(BinaryReader stream)
    {
        Index = stream.ReadByte();
    }

    public override string ToString() => $"Pixel Indexed : ({Index})";
}
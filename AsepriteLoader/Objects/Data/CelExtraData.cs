namespace AsepriteLoader.Objects.Data;

public class CelExtraData: ChunkData
{
    public readonly bool PreciseBoundsSet;
    public readonly double X;
    public readonly double Y;
    public readonly double Width;
    public readonly double Height;

    public CelExtraData(BinaryReader stream)
    {
        PreciseBoundsSet = stream.ReadUInt32() != 1;
        X = stream.ReadUInt32() / 65536d;
        Y = stream.ReadUInt32() / 65536d;
        Width = stream.ReadUInt32() / 65536d;
        Height = stream.ReadUInt32() / 65536d;
        stream.ReadBytes(16); // FOR FUTURE
    }

    public override string ToString() =>
        $"CelExtraData :\n - Precise Bounds are set : {PreciseBoundsSet}\n - Position : X = {X} / Y = {Y}\n " +
        $"- Size : {Width}x{Height}";
}
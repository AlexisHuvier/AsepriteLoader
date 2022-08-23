using AsepriteLoader.Utils.Enums;

namespace AsepriteLoader.Objects;

public class Header
{
    public readonly uint FileSize;
    public readonly ushort FrameNumber;
    public readonly ushort Width;
    public readonly ushort Height;
    public readonly ColorDepth ColorDepth;
    public readonly bool LayerOpacityValid;

    [Obsolete("Use the frame duration field from each frame header")]
    public readonly ushort Speed;

    public readonly byte PaletteEntry;
    public readonly ushort ColorNumber;
    public readonly byte PixelWidth;
    public readonly byte PixelHeight;
    public readonly float PixelRatio;
    public readonly Grid Grid;
    
    public Header(BinaryReader stream)
    {
        FileSize = stream.ReadUInt32();
        stream.ReadUInt16(); // MAGIC NUMBER
        FrameNumber = stream.ReadUInt16();
        Width = stream.ReadUInt16();
        Height = stream.ReadUInt16();
        ColorDepth = (ColorDepth)stream.ReadUInt16();
        LayerOpacityValid = stream.ReadUInt32() == 1;
        Speed = stream.ReadUInt16();
        stream.ReadUInt32(); // WILL BE SET TO 0
        stream.ReadUInt32(); // WILL BE SET TO 0
        PaletteEntry = stream.ReadByte();
        stream.ReadBytes(3); // IGNORED
        ColorNumber = stream.ReadUInt16();
        PixelWidth = stream.ReadByte();
        PixelHeight = stream.ReadByte();
        if (PixelWidth == 0 || PixelHeight == 0)
            PixelRatio = 1;
        else
            PixelRatio = PixelWidth / Convert.ToSingle(PixelHeight);
        Grid = new Grid(stream);
        stream.ReadBytes(84); // FOR FUTURE
    }

    public override string ToString() => 
        $"Header :\n - File Size : {FileSize} o\n - Frame Number : {FrameNumber}\n - Size : {Width}x{Height}\n" +
        $" - Color Depth : {ColorDepth}\n - Layer Opacity is Valid : {LayerOpacityValid}\n - Speed : {Speed}\n" +
        $" - Palette Entry : {PaletteEntry}\n - Color Number : {ColorNumber}\n - Pixel Size : {PixelWidth}x{PixelHeight}\n" +
        $" - Pixel Ratio : {PixelRatio}\n - " + Grid.ToString().Replace("\n", "\n ");
}
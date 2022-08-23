using AsepriteLoader.Utils;
using AsepriteLoader.Utils.Enums;
using AsepriteLoader.Utils.Pixel;

namespace AsepriteLoader.Objects.Data;

public class CelData: ChunkData
{
    public readonly ushort LayerIndex;
    public readonly short X;
    public readonly short Y;
    public readonly byte Opacity;
    public readonly CelType CelType;
    
    // CEL TYPE 0 (RAW IMAGE DATA)
    public readonly ushort RawImageWidth;
    public readonly ushort RawImageHeight;
    public readonly List<PixelBase> RawImagePixels;
    
    // CEL TYPE 1 (LINKED CEL)
    public readonly ushort LinkedCelFramePosition;
    
    // CEL TYPE 2 (COMPRESSED IMAGE)
    public readonly ushort CompressedImageWidth;
    public readonly ushort CompressedImageHeight;
    public readonly List<byte> CompressedImageRawCels;
    
    //  CEL TYPE 3 (COMPRESSED TILEMAP)
    public readonly ushort CompressedTilemapWidth;
    public readonly ushort CompressedTilemapHeight;
    public readonly ushort CompressedTilemapBitsPerTile;
    public readonly uint CompressedTilemapTileBitmask;
    public readonly uint CompressedTilemapXFlipBitmask;
    public readonly uint CompressedTilemapYFlipBitmask;
    public readonly uint CompressedTilemap90CWRotationBitmask;
    public readonly List<byte> CompressedTilemapTiles;

    public CelData(AsepriteFile aseprite, BinaryReader stream, uint size, long start)
    {
        LayerIndex = stream.ReadUInt16();
        X = stream.ReadInt16();
        Y = stream.ReadInt16();
        Opacity = stream.ReadByte();
        CelType = (CelType)stream.ReadUInt16();
        stream.ReadBytes(7); // FOR FUTURE;

        RawImagePixels = new List<PixelBase>();
        CompressedImageRawCels = new List<byte>();
        CompressedTilemapTiles = new List<byte>();
        
        switch (CelType)
        {
            case CelType.RawImageData:
                RawImageWidth = stream.ReadUInt16();
                RawImageHeight = stream.ReadUInt16();
                for (var y = 0; y < RawImageHeight; y++)
                {
                    for (var x = 0; x < RawImageWidth; x++)
                        RawImagePixels.Add(BinaryReaderUtils.ReadPixel(aseprite, stream));
                }
                break;
            case CelType.LinkedCel:
                LinkedCelFramePosition = stream.ReadUInt16();
                break;
            case CelType.CompressedImage:
                CompressedImageWidth = stream.ReadUInt16();
                CompressedImageHeight = stream.ReadUInt16();
                CompressedImageRawCels = new List<byte>(stream.ReadBytes(Convert.ToInt32(size - (stream.BaseStream.Position - start))));
                break;
            case CelType.CompressedTileMap:
                CompressedTilemapWidth = stream.ReadUInt16();
                CompressedTilemapHeight = stream.ReadUInt16();
                CompressedTilemapBitsPerTile = stream.ReadUInt16();
                CompressedTilemapTileBitmask = stream.ReadUInt32();
                CompressedTilemapXFlipBitmask = stream.ReadUInt32();
                CompressedTilemapYFlipBitmask = stream.ReadUInt32();
                CompressedTilemap90CWRotationBitmask = stream.ReadUInt32();
                stream.ReadBytes(10); // RESERVED
                CompressedTilemapTiles =
                    new List<byte>(stream.ReadBytes(Convert.ToInt32(size - (stream.BaseStream.Position - start))));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public override string ToString()
    {
        return CelType switch
        {
            CelType.RawImageData => $"CelData :\n - Layer Index : {LayerIndex}\n - Position : X = {X} / Y = {Y}\n" +
                                    $" - Opacity : {Opacity}\n - Cel Type : {CelType}\n " +
                                    $"- Size : {RawImageWidth}x{RawImageHeight}",
            CelType.LinkedCel => $"CelData :\n - Layer Index : {LayerIndex}\n - Position : X = {X} / Y = {Y}\n" +
                                 $" - Opacity : {Opacity}\n - Cel Type : {CelType}\n " +
                                 $"- Frame Position : {LinkedCelFramePosition}",
            CelType.CompressedImage => $"CelData :\n - Layer Index : {LayerIndex}\n - Position : X = {X} / Y = {Y}\n" +
                                       $" - Opacity : {Opacity}\n - Cel Type : {CelType}\n " +
                                       $"- Compressed Image Size : {CompressedImageWidth}x{CompressedImageHeight}",
            CelType.CompressedTileMap => $"CelData :\n - Layer Index : {LayerIndex}\n - Position : X = {X} / Y = {Y}\n" +
                                         $" - Opacity : {Opacity}\n - Cel Type : {CelType}\n " +
                                         $"- Compressed Tilemap Size : {CompressedTilemapWidth}x{CompressedTilemapHeight}",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
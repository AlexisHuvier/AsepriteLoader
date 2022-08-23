using AsepriteLoader.Utils;
using AsepriteLoader.Utils.Flags;
using AsepriteLoader.Utils.Pixel;

namespace AsepriteLoader.Objects.Data;

public class TilesetData: ChunkData
{
    public readonly uint TilesetId;
    public readonly TilesetFlags TilesetFlags;
    public readonly uint TileNumber;
    public readonly ushort TileWidth;
    public readonly ushort TileHeight;
    public readonly short BaseIndex;
    public readonly string Name;
    
    // FLAGS BIT 1
    public readonly uint ExternalFileID;
    public readonly uint ExternalTilesetID;
    
    // FLAGS BIT 2
    public readonly uint CompressedDataLength;
    public readonly List<PixelBase> CompressedTilesetImage;

    public TilesetData(AsepriteFile file, BinaryReader stream)
    {
        TilesetId = stream.ReadUInt32();
        TilesetFlags = (TilesetFlags)stream.ReadUInt32();
        TileNumber = stream.ReadUInt32();
        TileWidth = stream.ReadUInt16();
        TileHeight = stream.ReadUInt16();
        BaseIndex = stream.ReadInt16();
        stream.ReadBytes(14); // RESERVED
        Name = BinaryReaderUtils.ReadString(stream);
        CompressedTilesetImage = new List<PixelBase>();

        if ((TilesetFlags & TilesetFlags.IncludeLinkExternal) == TilesetFlags.IncludeLinkExternal)
        {
            ExternalFileID = stream.ReadUInt32();
            ExternalTilesetID = stream.ReadUInt32();
        }

        if ((TilesetFlags & TilesetFlags.IncludeTilesInside) == TilesetFlags.IncludeTilesInside)
        {
            CompressedDataLength = stream.ReadUInt32();
            for(var i = 0; i < (TileWidth * TileHeight * TileNumber); i++)
                CompressedTilesetImage.Add(BinaryReaderUtils.ReadPixel(file, stream));
        }
    }

    public override string ToString() =>
        $"TilesetData :\n - ID : {TilesetId}\n - Flags : {TilesetFlags}\n - Tile Number : {TileNumber}\n" +
        $" - Tile Size : {TileWidth}x{TileHeight}\n - Base Index : {BaseIndex}\n - Name : {Name}" +
        ((TilesetFlags & TilesetFlags.IncludeLinkExternal) == TilesetFlags.IncludeLinkExternal
            ? $"\n - External File ID : {ExternalFileID}\n - External Tileset ID : {ExternalTilesetID}"
            : "") +
        ((TilesetFlags & TilesetFlags.IncludeTilesInside) == TilesetFlags.IncludeTilesInside
            ? $"\n - Compressed Data Length : {CompressedDataLength}\n - Compressed Image Count : {CompressedTilesetImage.Count}"
            : "") ;
}
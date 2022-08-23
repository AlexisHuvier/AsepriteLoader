using AsepriteLoader.Objects.Data;
using AsepriteLoader.Utils;
using AsepriteLoader.Utils.Enums;

namespace AsepriteLoader.Objects;

public class Chunk
{
    public readonly uint Size;
    public readonly ChunkType Type;
    public readonly ChunkData Data;

    public Chunk(AsepriteFile file, BinaryReader stream)
    {
        var start = stream.BaseStream.Position;
        Size = stream.ReadUInt32();
        Type = (ChunkType)stream.ReadUInt16();
        Data = new ChunkData();
        switch (Type)
        {
            case ChunkType.OldPalette:
                Data = new OldPaletteData(stream);
                break;
            case ChunkType.OldPalette2:
                Data = new OldPalette2Data(stream);
                break;
            case ChunkType.Layer:
                Data = new LayerData(stream);
                break;
            case ChunkType.Cel:
                Data = new CelData(file, stream, Size, start);
                break;
            case ChunkType.CelExtra:
                Data = new CelExtraData(stream);
                break;
            case ChunkType.ColorProfile:
                Data = new ColorProfileData(stream);
                break;
            case ChunkType.ExternalFiles:
                Data = new ExternalFilesData(stream);
                break;
            case ChunkType.Mask:
                Data = new MaskData(stream);
                break;
            case ChunkType.Path:
                break; // NEVER USED
            case ChunkType.Tags:
                Data = new TagsData(stream);
                break;
            case ChunkType.Palette:
                Data = new PaletteData(stream);
                break;
            case ChunkType.UserData:
                Data = new UserData(stream);
                break;
            case ChunkType.Slice:
                Data = new SliceData(stream);
                break;
            case ChunkType.Tileset:
                Data = new TilesetData(file, stream);
                break;
            default:
                Console.WriteLine($"Unknown type : {Type}");
                break;
        }
    }

    public override string ToString() =>
        $"Chunk :\n - Size : {Size}\n - Type : {Type}" + ("\n - " + Data).Replace("\n", "\n ");
}
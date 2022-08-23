using AsepriteLoader.Utils;
using AsepriteLoader.Utils.Flags;

namespace AsepriteLoader.Objects.Data;

public class SliceData: ChunkData
{
    public readonly uint SliceKeyNumber;
    public readonly SliceFlags SliceFlags;
    public readonly string Name;
    public readonly List<SliceKey> SliceKeys;

    public SliceData(BinaryReader stream)
    {
        SliceKeyNumber = stream.ReadUInt32();
        SliceFlags = (SliceFlags)stream.ReadUInt32();
        stream.ReadUInt32(); // RESERVED
        Name = BinaryReaderUtils.ReadString(stream);
        SliceKeys = new List<SliceKey>();
        for(var i = 0; i < SliceKeyNumber; i++) 
            SliceKeys.Add(new SliceKey(SliceFlags, stream));
    }
    
    public override string ToString() => 
        $"SliceData :\n - SliceFlags : {SliceFlags}\n - Name : {Name}\n" +
        $" - Slice Keys ({SliceKeyNumber}) : \n  - " +
        string.Join("\n - ", SliceKeys).Replace("\n", "\n ");
}
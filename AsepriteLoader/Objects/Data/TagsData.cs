using AsepriteLoader.Utils;

namespace AsepriteLoader.Objects.Data;

public class TagsData: ChunkData
{
    public readonly ushort TagNumber;
    public readonly List<Tag> Tags;

    public TagsData(BinaryReader stream)
    {
        TagNumber = stream.ReadUInt16();
        stream.ReadBytes(8);
        Tags = new List<Tag>();
        for(var i = 0; i < TagNumber; i++) 
            Tags.Add(new Tag(stream));
    }
    
    public override string ToString() => 
        $"TagsData :\n - Tags ({TagNumber}) : \n  - " +
        string.Join("\n - ", Tags).Replace("\n", "\n ");
}
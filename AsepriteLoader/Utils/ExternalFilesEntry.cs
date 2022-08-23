namespace AsepriteLoader.Utils;

public class ExternalFilesEntry
{
    public readonly uint EntryId;
    public readonly string FileName;

    public ExternalFilesEntry(BinaryReader stream)
    {
        EntryId = stream.ReadUInt32();
        stream.ReadBytes(8); // RESERVED
        FileName = BinaryReaderUtils.ReadString(stream);
    }

    public override string ToString() => $"ExternalFilesEntry :\n - EntryID : {EntryId}\n - FileName : {FileName}";
}
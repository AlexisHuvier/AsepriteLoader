namespace AsepriteLoader;

public class AsepriteFile
{
    public Objects.Header Header;
    
    public AsepriteFile(string path) : this(new BinaryReader(new FileStream(path, FileMode.Open))) {}
    public AsepriteFile(BinaryReader stream)
    {
        Header = new Objects.Header(stream);
    }
}
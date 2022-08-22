namespace AsepriteLoader;

public class AsepriteFile
{
    public Header.Header Header;
    
    public AsepriteFile(string path) : this(new BinaryReader(new FileStream(path, FileMode.Open))) {}
    public AsepriteFile(BinaryReader stream)
    {
        Header = new Header.Header(stream);
    }
}
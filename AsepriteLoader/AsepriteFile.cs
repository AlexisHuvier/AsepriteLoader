using AsepriteLoader.Objects;

namespace AsepriteLoader;

public class AsepriteFile
{
    public readonly Header Header;
    public readonly List<Frame> Frames;
    
    public AsepriteFile(string path) : this(new BinaryReader(new FileStream(path, FileMode.Open))) {}
    public AsepriteFile(BinaryReader stream)
    {
        Header = new Header(stream);
        Frames = new List<Frame>();
        Frames.Add(new Frame(stream));
    }
}
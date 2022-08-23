using AsepriteLoader.Objects;

namespace AsepriteLoader;

public class AsepriteFile
{
    public readonly Header Header;
    public readonly List<Frame> Frames;
    
    public AsepriteFile(string path) : this(new BinaryReader(new FileStream(path, FileMode.Open))) {}
    public AsepriteFile(BinaryReader stream)
    {
        try
        {
            Header = new Header(stream);
            Frames = new List<Frame>();
            for (var i = 0; i < Header.FrameNumber; i++)
                Frames.Add(new Frame(this, stream));
        }
        catch (EndOfStreamException)
        {
            Console.WriteLine(this);
            throw;
        }
    }

    public override string ToString() => 
        $"AsepriteFile :\n - " + Header.ToString().Replace("\n", "\n ") + 
        $"\n - Frames ({Header.FrameNumber}) : \n  - " + string.Join("\n - ", Frames).Replace("\n", "\n ");
}
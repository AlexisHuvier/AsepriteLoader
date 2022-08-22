using AsepriteLoader;

namespace AsepriteLoaderExample // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ase = new AsepriteFile("Resources/card.ase");
            
            Console.WriteLine("=============== File ===============");
            Console.WriteLine("-------------- Header --------------");
            Console.WriteLine($"File Size : {ase.Header.FileSize} o");
            Console.WriteLine($"Number of Frames : {ase.Header.Frames}");
            Console.WriteLine($"Size : {ase.Header.Width}x{ase.Header.Height}");
            Console.WriteLine($"ColorDepth : {ase.Header.ColorDepth}");
            Console.WriteLine($"Layer Opacity is Valid : {ase.Header.LayerOpacityValid}");
            Console.WriteLine($"Speed (Obsolete) : {ase.Header.Speed}ms");
            Console.WriteLine($"Palette Entry (Index) : {ase.Header.PaletteEntry}");
            Console.WriteLine($"Number of Colors : {ase.Header.ColorNumber}");
            Console.WriteLine($"Pixel Size : {ase.Header.PixelWidth}x{ase.Header.PixelHeight} ({ase.Header.PixelRatio})");
            Console.WriteLine($"Grid Pos : X = {ase.Header.Grid.X} / Y = {ase.Header.Grid.Y}");
            Console.WriteLine($"Grid Size : {ase.Header.Grid.Width}x{ase.Header.Grid.Height}");
            Console.WriteLine("====================================");
            Console.WriteLine("-------------- Frames --------------");
            foreach (var frame in ase.Frames)
            {
                Console.WriteLine($"---- Frame {ase.Frames.IndexOf(frame)+1} / {ase.Frames.Count}");
                Console.WriteLine($"Size : {frame.Size}");
                Console.WriteLine($"Number of Chunks : {frame.ChunkNumber}");
                Console.WriteLine($"Duration : {frame.Duration}");
            Console.WriteLine("====================================");
        }
    }
}
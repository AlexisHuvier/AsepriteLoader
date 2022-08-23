using AsepriteLoader;

namespace AsepriteLoaderExample 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ase = new AsepriteFile("Resources/card.ase");

            Console.WriteLine(ase);
        }
    }
}
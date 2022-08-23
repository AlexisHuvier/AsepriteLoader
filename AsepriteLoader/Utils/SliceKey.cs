using AsepriteLoader.Utils.Flags;

namespace AsepriteLoader.Utils;

public class SliceKey
{
    public readonly uint FrameNumber;
    public readonly int SliceXOriginCoordinate;
    public readonly int SliceYOriginCoordinate;
    public readonly uint SliceWidth;
    public readonly uint SliceHeight;
    
    // FLAGS BIT 1
    public readonly int CenterXPosition;
    public readonly int CenterYPosition;
    public readonly uint CenterWidth;
    public readonly uint CenterHeight;
    
    // FLAGS BIT 2
    public readonly int PivotXPosition;
    public readonly int PivotYPosition;

    private readonly SliceFlags SliceFlags;

    public SliceKey(SliceFlags flags, BinaryReader stream)
    {
        SliceFlags = flags;
        
        FrameNumber = stream.ReadUInt32();
        SliceXOriginCoordinate = stream.ReadInt32();
        SliceYOriginCoordinate = stream.ReadInt32();
        SliceWidth = stream.ReadUInt32();
        SliceHeight = stream.ReadUInt32();

        if ((flags & SliceFlags.NinePatches) == SliceFlags.NinePatches)
        {
            CenterXPosition = stream.ReadInt32();
            CenterYPosition = stream.ReadInt32();
            CenterWidth = stream.ReadUInt32();
            CenterHeight = stream.ReadUInt32();
        }

        if ((flags & SliceFlags.PivotInformation) == SliceFlags.PivotInformation)
        {
            PivotXPosition = stream.ReadInt32();
            PivotYPosition = stream.ReadInt32();
        }
    }

    public override string ToString() =>
        $"SliceKey :\n - Frame Number : {FrameNumber}\n " +
        $"- Slice Origin Coordinate : X = {SliceXOriginCoordinate} / Y = {SliceYOriginCoordinate}\n " +
        $"- Slice Size : {SliceWidth}x{SliceHeight}" +
        ((SliceFlags & SliceFlags.NinePatches) == SliceFlags.NinePatches
            ? $"\n - Center Position : X = {CenterXPosition} / Y = {CenterYPosition}\n - Center Size : {CenterWidth}x{CenterHeight}"
            : "") +
        ((SliceFlags & SliceFlags.PivotInformation) == SliceFlags.PivotInformation
            ? $"\n - Pivot Position : X = {PivotXPosition} / Y = {PivotYPosition}"
            : "");
}
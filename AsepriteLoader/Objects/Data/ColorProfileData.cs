using AsepriteLoader.Utils;
using AsepriteLoader.Utils.Enums;

namespace AsepriteLoader.Objects.Data;

public class ColorProfileData: ChunkData
{
    public readonly ColorProfileType Type;
    public readonly bool SpecialFixedGamma;
    public readonly double FixedGamma;
    
    // IF TYPE ICC
    // ReSharper disable once InconsistentNaming
    public readonly uint ICCProfileDataLength;
    // ReSharper disable once InconsistentNaming
    public readonly List<byte> ICCProfileData;

    public ColorProfileData(BinaryReader stream)
    {
        Type = (ColorProfileType)stream.ReadUInt16();
        SpecialFixedGamma = stream.ReadUInt16() == 1;
        FixedGamma = stream.ReadUInt32() / 65536d;
        stream.ReadBytes(8); // RESERVED
        ICCProfileData = new List<byte>();

        if (Type == ColorProfileType.ICCProfile)
        {
            ICCProfileDataLength = stream.ReadUInt32();
            ICCProfileData = new List<byte>(stream.ReadBytes((int)ICCProfileDataLength));
        }
    }

    public override string ToString() =>
        $"ColorProfileData :\n - Type : {Type}\n - Use Special Fixed Gamma : {SpecialFixedGamma}\n" +
        $" - Fixed Gamma : {FixedGamma}" + (Type == ColorProfileType.ICCProfile
            ? $"\n - ICC Profile Data Length : {ICCProfileDataLength}"
            : "");
}
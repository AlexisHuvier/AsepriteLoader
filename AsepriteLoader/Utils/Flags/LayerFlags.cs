namespace AsepriteLoader.Utils.Flags;

[Flags]
public enum LayerFlags
{
    Visible = 1,
    Editable = 2,
    LockMovement = 4,
    Background = 8,
    PreferLinkedCels = 16,
    ShouldBeDisplayedCollapsed = 32,
    IsReferenceLayer = 64
}
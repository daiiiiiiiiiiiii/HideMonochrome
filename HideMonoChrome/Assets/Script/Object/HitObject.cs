using UnityEngine;

public enum State
{
    Idle,
    Run,
    JumpUp,
    JumpDown,
    // Climb,
    // Down,
    // Dead,
    // Die,
    Max
}

public enum ObjectType
{
    None,
    Ground,
    Needle,
    Ladder,
    Swiych,
    Goal,
    Max
}

public interface IHitObject
{
    ObjectType GetObjectType(Collider2D col);
}

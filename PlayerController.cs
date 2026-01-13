//Component Id Constants    
// Source - https://stackoverflow.com/a
// Posted by Jimmeh, modified by community. See post 'Timeline' for change history
// Retrieved 2026-01-06, License - CC BY-SA 2.5


using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;
namespace fanganrompa;


public class PlayerController : Component
{
    public override int CompID => 80085;
    private MainCamera camera = (MainCamera)ComponentManager.GetComponentByID(0);
    public override void Start()
    {
        camera.MouseLock(true);
    }

    public override void Update()
    {
        Vector2 rot = new();
        float vertical = new();
        float horizontal = new();

        rot.X += Input.GetHorizontalMouseDelta() * 0.15f;
        rot.Y += Input.GetVerticalMouseDelta() * 0.15f;

        horizontal += Input.GetHorizontalMovement() * 0.15f;
        vertical += Input.GetVerticalMovement() * 0.15f;

        camera.Rotation = new Vector3(rot.X, rot.Y, 0);
        camera.Transform = new Vector3(vertical, horizontal, 0);
    }

    
}

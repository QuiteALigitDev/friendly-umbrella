using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace fanganrompa;


public class MainCamera : Component
{

    public override void Start() 
    {
        GlobalAssets.MainCamera.Position = new Vector3(2.0f, 4.0f, 6.0f);
        GlobalAssets.MainCamera.Target = new Vector3(0.0f, 0.5f, 0.0f);
        GlobalAssets.MainCamera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        GlobalAssets.MainCamera.FovY = 45.0f;
        GlobalAssets.MainCamera.Projection = CameraProjection.Perspective;
    }

    public override void Update()
    {
        
    }
}

using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace fanganrompa;


public class MainCamera : Component
{
    public override int CompID => 0;
    public Vector3 Rotation = new();
    public Vector3 Transform = new();
    public float Zoom = new();

    public override void Start() 
    {
        GlobalAssets.MainCamera.Position = new Vector3(2.0f, 4.0f, 6.0f);
        GlobalAssets.MainCamera.Target = new Vector3(0.0f, 0.5f, 0.0f);
        GlobalAssets.MainCamera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        GlobalAssets.MainCamera.FovY = 45.0f;
        GlobalAssets.MainCamera.Projection = CameraProjection.Perspective;
    }
    public void MouseLock(bool locked){
        if (locked){Raylib.DisableCursor();}else{Raylib.EnableCursor();}
    }
    public override void Update()
    {
        //ComponentManager.Log(Rotation.ToString());
        Raylib.UpdateCameraPro(ref GlobalAssets.MainCamera, Transform, Rotation, Zoom);   
    }
}

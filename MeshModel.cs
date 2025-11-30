using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace fanganrompa;


public class MeshModel : Component
{
    Model watermill;
    Model watermillBackface;
    Shader outline;

    public override void Start()
    {
        ComponentManager.Log("Player spawned");
        watermill = MeshObj.CreateObj("Models/FixedDragon.obj", "Materials/DefaultTex.png", GlobalAssets.MainShader);
        watermillBackface = MeshObj.CreateObj("Models/Suzanna.obj", "Materials/DefaultTex.png", GlobalAssets.MainShader);
    }

    public override void Update()
    {

        // Draw outline mesh
        MeshObj.RenderObj(watermillBackface, new Vector3(-5, 1, 0), 4f);


        MeshObj.RenderObj(watermill, new Vector3(0, 1, 0), 1.0f);
    }

    
}

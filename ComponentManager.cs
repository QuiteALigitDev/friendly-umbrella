using System.Collections.Generic;
using System.Numerics;
using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Runtime.InteropServices;


public static class ComponentManager
{
    private static List<Component> components = new List<Component>();
    private static bool started = false;

    public static void AddComponent(Component c)
    {
        components.Add(c);
    }

    public static void StartAll()
    {
        if (started) return;
        started = true;

        foreach (var c in components)
            c.Start();
    }

    public static void UpdateAll()
    {
        foreach (var c in components)
            c.Update();
    }

    // Example of stuff other scripts can call:
    public static void Log(string msg)
    {
        System.Console.WriteLine(msg);
    }
}

public static class MeshObj{

    public unsafe static Model CreateObj(string ModelPath, string DiffusePath, Shader shader){
        Model model = LoadModel(ModelPath);
        Texture2D modelTex = LoadTexture(DiffusePath);


        model.Materials[0].Maps[(int)MaterialMapIndex.Albedo].Texture = modelTex;
        model.Materials[0].Shader = shader;

        return model;
    }

    public static void RenderObj(Model model, Vector3 position, float scale, Color? tint = null){
        if (tint == null)
        {
            tint = Color.White;
        }
        DrawModel(model, position, scale, Color.White);
    }
    public static void CreateCollider(){
        
    }
}

public static class GlobalAssets
{
    public static Shader MainShader;
    public static Camera3D MainCamera;
}

public abstract class Component
{
    public virtual void Start() { }
    public virtual void Update() { }
}

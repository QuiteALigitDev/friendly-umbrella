using System.Collections.Generic;
using System.Numerics;
using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Runtime.InteropServices;
using System.IO.Pipes;


public static class ComponentManager
{
    private static readonly Dictionary<int, Component> components = new Dictionary<int, Component>();
    private static bool started = false;

    public static void AddComponent(Component c)
    {
        components.Add(c.CompID, c);
    }
    public static Component GetComponentByID(int id)
    {
        return components[id];
    }

    public static void StartAll()
    {
        if (started) return;
        started = true;

        foreach (var c in components.Values)
            c.Start();
    }

    public static void UpdateAll()
    {
        foreach (var c in components.Values)
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


public static class Input{
    //Mouse Delta
    public static float GetHorizontalMouseDelta(){ return GetMouseDelta().X; }
    public static float GetVerticalMouseDelta(){ return GetMouseDelta().Y; }
    //Keyboard?????
    public static class KeyCode{
        public const Raylib_cs.KeyboardKey Escape = KeyboardKey.Escape;
        public const Raylib_cs.KeyboardKey F1 = KeyboardKey.F1;
        public const Raylib_cs.KeyboardKey F2 = KeyboardKey.F2;
        public const Raylib_cs.KeyboardKey F3 = KeyboardKey.F3;
        public const Raylib_cs.KeyboardKey F4 = KeyboardKey.F4;
        public const Raylib_cs.KeyboardKey F5 = KeyboardKey.F5;
        public const Raylib_cs.KeyboardKey F6 = KeyboardKey.F6;
        public const Raylib_cs.KeyboardKey F7 = KeyboardKey.F7;
        public const Raylib_cs.KeyboardKey F8 = KeyboardKey.F8;
        public const Raylib_cs.KeyboardKey F9 = KeyboardKey.F9;
        public const Raylib_cs.KeyboardKey F10 = KeyboardKey.F10;
        public const Raylib_cs.KeyboardKey F11 = KeyboardKey.F11;
        public const Raylib_cs.KeyboardKey F12 = KeyboardKey.F12;
        public const Raylib_cs.KeyboardKey Alpha1 = KeyboardKey.One;
        public const Raylib_cs.KeyboardKey Alpha2 = KeyboardKey.Two;
        public const Raylib_cs.KeyboardKey Alpha3 = KeyboardKey.Three;
        public const Raylib_cs.KeyboardKey Alpha4 = KeyboardKey.Four;
        public const Raylib_cs.KeyboardKey Alpha5 = KeyboardKey.Five;
        public const Raylib_cs.KeyboardKey Alpha6 = KeyboardKey.Six;
        public const Raylib_cs.KeyboardKey Alpha7 = KeyboardKey.Seven;
        public const Raylib_cs.KeyboardKey Alpha8 = KeyboardKey.Eight;
        public const Raylib_cs.KeyboardKey Alpha9 = KeyboardKey.Nine;
        public const Raylib_cs.KeyboardKey Alpha0 = KeyboardKey.Zero;
        public const Raylib_cs.KeyboardKey Minus = KeyboardKey.Minus;
        public const Raylib_cs.KeyboardKey Plus = KeyboardKey.Equal;
        public const Raylib_cs.KeyboardKey BackSpace = KeyboardKey.Backspace;
        public const Raylib_cs.KeyboardKey Tab = KeyboardKey.Tab;
        public const Raylib_cs.KeyboardKey LeftCurlyBracket = KeyboardKey.LeftBracket;
        public const Raylib_cs.KeyboardKey RightCurlyBracket = KeyboardKey.RightBracket;
        public const Raylib_cs.KeyboardKey Pipe = KeyboardKey.Backslash;
        public const Raylib_cs.KeyboardKey CapsLock = KeyboardKey.CapsLock;
        public const Raylib_cs.KeyboardKey LShift = KeyboardKey.LeftShift;
        public const Raylib_cs.KeyboardKey RShift = KeyboardKey.RightShift;
        public const Raylib_cs.KeyboardKey LCtrl = KeyboardKey.LeftControl;
        public const Raylib_cs.KeyboardKey RCtrl = KeyboardKey.RightControl;
        public const Raylib_cs.KeyboardKey LAlt = KeyboardKey.LeftAlt;
        public const Raylib_cs.KeyboardKey RAlt = KeyboardKey.RightAlt;
        public const Raylib_cs.KeyboardKey Mod = KeyboardKey.LeftSuper;
        public const Raylib_cs.KeyboardKey Space = KeyboardKey.Space;
        public const Raylib_cs.KeyboardKey Enter = KeyboardKey.Enter;
        public const Raylib_cs.KeyboardKey Delete = KeyboardKey.Delete;
        public const Raylib_cs.KeyboardKey Insert = KeyboardKey.Insert;
        public const Raylib_cs.KeyboardKey PrintScreen = KeyboardKey.PrintScreen;
        public const Raylib_cs.KeyboardKey UpArrow = KeyboardKey.Up;
        public const Raylib_cs.KeyboardKey RightArrow = KeyboardKey.Right;
        public const Raylib_cs.KeyboardKey DownArrow = KeyboardKey.Down;
        public const Raylib_cs.KeyboardKey LeftArrow = KeyboardKey.Left;
        public const Raylib_cs.KeyboardKey SemiColon = KeyboardKey.Semicolon;
        public const Raylib_cs.KeyboardKey QuestionMark = KeyboardKey.Slash;
        public const Raylib_cs.KeyboardKey Q = KeyboardKey.Q;
        public const Raylib_cs.KeyboardKey W = KeyboardKey.W;
        public const Raylib_cs.KeyboardKey E = KeyboardKey.E;
        public const Raylib_cs.KeyboardKey R = KeyboardKey.R;
        public const Raylib_cs.KeyboardKey T = KeyboardKey.T;
        public const Raylib_cs.KeyboardKey Y = KeyboardKey.Y;
        public const Raylib_cs.KeyboardKey U = KeyboardKey.U;
        public const Raylib_cs.KeyboardKey I = KeyboardKey.I;
        public const Raylib_cs.KeyboardKey O = KeyboardKey.O;
        public const Raylib_cs.KeyboardKey P = KeyboardKey.P;
        public const Raylib_cs.KeyboardKey A = KeyboardKey.A;
        public const Raylib_cs.KeyboardKey S = KeyboardKey.S;
        public const Raylib_cs.KeyboardKey D = KeyboardKey.D;
        public const Raylib_cs.KeyboardKey F = KeyboardKey.F;
        public const Raylib_cs.KeyboardKey G = KeyboardKey.G;
        public const Raylib_cs.KeyboardKey H = KeyboardKey.H;
        public const Raylib_cs.KeyboardKey J = KeyboardKey.J;
        public const Raylib_cs.KeyboardKey K = KeyboardKey.K;
        public const Raylib_cs.KeyboardKey L = KeyboardKey.L;
        public const Raylib_cs.KeyboardKey Z = KeyboardKey.Z;
        public const Raylib_cs.KeyboardKey X = KeyboardKey.X;
        public const Raylib_cs.KeyboardKey C = KeyboardKey.C;
        public const Raylib_cs.KeyboardKey V = KeyboardKey.V;
        public const Raylib_cs.KeyboardKey B = KeyboardKey.B;
        public const Raylib_cs.KeyboardKey N = KeyboardKey.N;
        public const Raylib_cs.KeyboardKey M = KeyboardKey.M;
    }
    public static bool GetKeyDown(Raylib_cs.KeyboardKey kc) { return IsKeyDown(kc); }
    public static float GetVerticalMovement(){if (GetKeyDown(KeyCode.W)) { return 1; } else if (GetKeyDown(KeyCode.S)) { return -1; } else { return 0; } }
    public static float GetHorizontalMovement(){if (GetKeyDown(KeyCode.D)) { return 1; } else if (GetKeyDown(KeyCode.A)) { return -1; } else { return 0; } }


}

public static class GlobalAssets
{
    public static Shader MainShader;
    public static Camera3D MainCamera;
}

public abstract class Component
{
    public abstract int CompID { get; }
    public virtual void Start() { }
    public virtual void Update() { }
}

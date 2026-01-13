/*******************************************************************************************
*
*   raylib [shaders] example - basic lighting
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3).
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@codifies) and reviewed by Ramon Santamaria (@raysan5)
*
*   Chris Camacho (@codifies -  http://bedroomcoders.co.uk/) notes:
*
*   This is based on the PBR lighting example, but greatly simplified to aid learning...
*   actually there is very little of the PBR example left!
*   When I first looked at the bewildering complexity of the PBR example I feared
*   I would never understand how I could do simple lighting with raylib however its
*   a testement to the authors of raylib (including rlights.h) that the example
*   came together fairly quickly.
*
*   Copyright (c) 2019 Chris Camacho (@codifies) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using System.Numerics;
using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Data;

namespace fanganrompa;

public class BasicLighting
{
    const int GLSL_VERSION = 330;

    public unsafe static int Main()
    {
        // Initialization
        //--------------------------------------------------------------------------------------
        const int screenWidth = 800;
        const int screenHeight = 450;

        //Register Components
        ComponentManager.AddComponent(new MeshModel());
        ComponentManager.AddComponent(new MainCamera());
        ComponentManager.AddComponent(new PlayerController());

        // Enable Multi Sampling Anti Aliasing 4x (if available)
        SetConfigFlags(ConfigFlags.Msaa4xHint);
        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - basic lighting");

        // Define the camera to look into our 3d world
        GlobalAssets.MainCamera = new Camera3D();


        // Load plane model from a generated mesh
        Model model = LoadModelFromMesh(GenMeshPlane(10.0f, 10.0f, 3, 3));
        //Model watermill = LoadModel("Models/Suzanna.obj");
        //Texture2D watermilltex = LoadTexture("watermill_diffuse.png");

        GlobalAssets.MainShader = LoadShader("Shaders/Vertex/CellShading.vs", "Shaders/Fragment/CellShading.fs");
        Shader Normals = LoadShader("Shaders/Vertex/CellShading.vs", "Shaders/Fragment/NormalView.fs");
        

        // Assign out lighting shader to model
        // model.Materials[0].Shader = GlobalAssets.MainShader;
        // watermill.Materials[0].Shader = GlobalAssets.MainShader;
        // watermill.Materials[0].Maps[(int)MaterialMapIndex.Albedo].Texture = watermilltex;

        // // Get some required shader loactions
        var Camloc = GetShaderLocation(GlobalAssets.MainShader, "CameraView");

        //Init PP
        Shader PP = LoadShader(null, "Shaders/Fragment/HandDrawnOutline.fs");


        SetTargetFPS(60);
        //Start
        ComponentManager.StartAll();
        RenderTexture2D RenderBuffer = LoadRenderTexture(screenWidth, screenHeight);
        //--------------------------------------------------------------------------------------
        // Main game loop
        while (!WindowShouldClose())
        {
            //UpdateCamera(ref GlobalAssets.MainCamera, CameraMode.FirstPerson);
            //Raylib.DisableCursor();


            SetShaderValue(GlobalAssets.MainShader, Camloc, GlobalAssets.MainCamera.Target, ShaderUniformDataType.Vec3);

            //Hot Reload
            if (IsMouseButtonPressed(MouseButton.Right)){
                Shader updatedShader = LoadShader("Shaders/Vertex/CellShading.vs", "Shaders/Fragment/CellShading.fs");

                if (updatedShader.Id != 0){
                    GlobalAssets.MainShader = updatedShader;
                }
            }
            if(IsMouseButtonPressed(MouseButton.Middle)){
                if (Raylib.IsCursorHidden())
                {
                    Raylib.EnableCursor();
                }
                else
                { Raylib.DisableCursor(); }
            }

            // Draw
            //----------------------------------------------------------------------------------
            BeginDrawing();
            BeginShaderMode(Normals);
            BeginTextureMode(RenderBuffer);
            ClearBackground(Color.RayWhite);

            BeginMode3D(GlobalAssets.MainCamera);

            // Update
            ComponentManager.UpdateAll();
            DrawModel(model, Vector3.Zero, 1.0f, Color.White);
            //DrawModel(watermill, new Vector3(0, 1, 0), 1.0f, Color.White);

            DrawGrid(10, 1.0f);

            EndMode3D();
            EndTextureMode();
            EndShaderMode();

            //PP
            //Rlgl.SetBlendMode(BlendMode.Additive);
            ClearBackground(Color.RayWhite);
            BeginMode3D(GlobalAssets.MainCamera);

            // Update
            ComponentManager.UpdateAll();
            DrawModel(model, Vector3.Zero, 1.0f, Color.White);
            //DrawModel(watermill, new Vector3(0, 1, 0), 1.0f, Color.White);

            DrawGrid(10, 1.0f);

            EndMode3D();

            BeginShaderMode(PP);
            DrawTextureRec(RenderBuffer.Texture, new Rectangle(0, 0, RenderBuffer.Texture.Width, -RenderBuffer.Texture.Height), new Vector2(0, 0), Color.White);
            EndShaderMode();


            DrawFPS(10, 10);
            //DrawText("Use keys [Y][R][G][B] to toggle lights", 10, 40, 20, Color.DarkGray);

            EndDrawing();
            //----------------------------------------------------------------------------------
        }

        // De-Initialization
        //--------------------------------------------------------------------------------------
        UnloadModel(model);
        UnloadRenderTexture(RenderBuffer);
        UnloadShader(GlobalAssets.MainShader);


        CloseWindow();
        //--------------------------------------------------------------------------------------

        return 0;
    }
}
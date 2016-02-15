using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CRT : MonoBehaviour
{
    public Material material;
    private RenderTexture lastFrame;

    void Awake()
    {
        lastFrame = null;
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }

}
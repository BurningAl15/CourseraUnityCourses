using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraShader : MonoBehaviour {
    [Range(0f, 255f)]
    public float size;
    public Material material;
   
    void Start () {
        material.SetFloat("_Radius", 0);
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.W) && size<255f)
            size ++;
        else if (Input.GetKey(KeyCode.S) && size > 0f)
            size --;

        material.SetFloat("_Radius", size);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}

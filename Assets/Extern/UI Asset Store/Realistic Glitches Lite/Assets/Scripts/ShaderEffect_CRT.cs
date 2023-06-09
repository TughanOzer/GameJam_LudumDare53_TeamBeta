﻿using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderEffect_CRT : MonoBehaviour {

	public float scanlineIntensity = 100;
	public int scanlineWidth = 1;
//	public Color scanlineColor = Color.black;
//	public bool tVBulge = true;
	private Material material_Displacement;
	public Material material_Scanlines;

    public float speed = 1;

    void Awake ()
	{
		material_Scanlines = new Material( Shader.Find("Hidden/Scanlines2") );
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material_Scanlines.SetFloat("_Intensity", scanlineIntensity * 0.01f);
		material_Scanlines.SetFloat("_ValueX", scanlineWidth);
		material_Scanlines.SetFloat("_ScrollSpeed", speed);

		Graphics.Blit (source, destination, material_Scanlines);
    }


}

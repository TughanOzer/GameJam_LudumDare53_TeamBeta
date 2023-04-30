using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderEffect_CRT : MonoBehaviour {

	public float scanlineIntensity = 100;
	public int scanlineWidth = 1;
//	public Color scanlineColor = Color.black;
//	public bool tVBulge = true;
	private Material material_Displacement;
	public Material material_Scanlines;

	private float ScrollX = 0.5f;
	private float ScrollY = 0.5f;
	float position = 0;
    public float speed = 1;

    void Awake ()
	{
		material_Scanlines = new Material( Shader.Find("Hidden/Scanlines") );
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material_Scanlines.SetFloat("_Intensity", scanlineIntensity * 0.01f);
		material_Scanlines.SetFloat("_ValueX", scanlineWidth);

		Graphics.Blit (source, destination, material_Scanlines);
        //      float OffsetY = Time.time * ScrollY;
        //      float OffsetX = Time.time * ScrollY;
        //Debug.Log(OffsetX);
        //      material_Scanlines.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }


}

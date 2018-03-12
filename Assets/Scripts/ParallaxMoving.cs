using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMoving : MonoBehaviour
{
    public Transform[] layers;
    [Range(1f,10f)]
    public float smoothing = 5f;

    private float[] parallaxScales;
    private Vector3 prevCamPos;	

	// Use this for initialization
	void Start () {
	    prevCamPos = Camera.main.transform.position;
	    parallaxScales = new float[layers.Length];
	    for (int i = 0; i < layers.Length; i++) {
	        parallaxScales[i] = layers[i].position.z * -1;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < layers.Length; i++) {
	        float parallax_X =  (prevCamPos.x - Camera.main.transform.position.x) * parallaxScales[i];
            float parallax_Y =  (prevCamPos.y - Camera.main.transform.position.y) * parallaxScales[i];

	        float backgroundTargetPosX = layers[i].position.x + parallax_X;
            float backgroundTargetPosY = layers[i].position.y + parallax_Y;

	        Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgroundTargetPosY, layers[i].position.z);

	        layers[i].position = Vector3.Lerp(layers[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
	    }
	    prevCamPos = Camera.main.transform.position;
	}
}

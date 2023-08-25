using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds;
    public float smoothing;
    private float[] parallaxScale;

    private Transform cam;
    private Vector3 prevCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        prevCamPos = cam.transform.position;

        parallaxScale = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScale[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax_X = (prevCamPos.x - cam.position.x) * parallaxScale[i];
            float parallax_Y = (prevCamPos.y - cam.position.y) * parallaxScale[i];

            float backgroundPosX = backgrounds[i].position.x + parallax_X;
            float backgroundPosY = backgrounds[i].position.y + parallax_Y;

            Vector3 backgroundPos = new Vector3(backgroundPosX, backgroundPosY, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundPos, smoothing * Time.fixedDeltaTime);
        }

        prevCamPos = cam.position;
    }
}

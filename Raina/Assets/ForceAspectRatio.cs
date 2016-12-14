using UnityEngine;
using System.Collections;

public class ForceAspectRatio : MonoBehaviour {

    public float aspectWidth = 16.0f;
    public float aspectHeight = 9.0f;

    private Resolution resolution;

    // Use this for initialization
    void Start() {
        adjustViewportRatios();
    }

    void Update() {
        if (!Screen.currentResolution.Equals(resolution)) {
            adjustViewportRatios();
        }
    }

    void adjustViewportRatios () {
        float targetaspect = aspectWidth / aspectHeight;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;

        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;

        if (scaleheight < 1.0f)
        {
            // Our viewport doesn't match the camera's aspect ratio because it's taller
            // so we leave top and bottom 'holes' without camera
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
        }
        else
        {
            // Same as above, but the viewport is wider than the aspect ratio
            // we leave left and right columns
            float scalewidth = 1.0f / scaleheight;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;
        }

        camera.rect = rect;
        resolution = Screen.currentResolution;
    }
}

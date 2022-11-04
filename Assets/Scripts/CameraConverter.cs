using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConverter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float ratio = (float)Screen.height / Screen.width;
        float ortSize = Screen.width*ratio / 200f;
        Camera.main.orthographicSize = ortSize;


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    
    public GameObject asset;
    
    public Slider rotate;
    public Slider zoom;
    public Camera cam;

    public Toggle doorControl;

    private void Update()
    {
        asset.transform.eulerAngles = new Vector3(0, rotate.value * 360, 0);
        cam.orthographicSize = zoom.value;
    }
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject player;
    private CameraManager cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<CameraManager>();
        setCamera();
	}
	
	// Update is called once per frame
	void setCamera () {
    	cam.setTarget((Instantiate(player, Vector3.zero, Quaternion.identity) as GameObject).transform);
	}
}

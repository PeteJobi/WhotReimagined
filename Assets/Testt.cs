using UnityEngine;
using System.Collections;

public class Testt : MonoBehaviour {
    public float b;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3.Lerp(Vector3.zero, Vector3.right * 4, b);
	}
}

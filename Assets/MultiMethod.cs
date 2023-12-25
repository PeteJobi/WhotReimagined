using UnityEngine;
using System.Collections;

public class MultiMethod : MonoBehaviour {

    public delegate void PressedK(string word);
    public static event PressedK Doo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("k"))
        {
            Doo("lad");
        }
	}
}

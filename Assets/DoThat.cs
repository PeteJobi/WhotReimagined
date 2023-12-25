using UnityEngine;
using System.Collections;

public class DoThat : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MultiMethod.Doo += ShowK;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("q"))
        {
            MultiMethod.Doo -= ShowK;
        }
	}
    void ShowK(string vb)
    {
        Debug.Log(vb + "i is KKKKKKKKKKKK");
    }
}

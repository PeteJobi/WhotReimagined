using UnityEngine;
using System.Collections;

public class DoThis : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MultiMethod.Doo += ShowM;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ShowM(string woo)
    {
        Debug.Log(woo + "t is MMMMMMMMMMM");
    }
}

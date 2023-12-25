using UnityEngine;
using System.Collections;

public class CardProp : MonoBehaviour {
    public string suit;
    public int value;
    public Material mat;
	// Use this for initialization
	void Awake () {
        mat = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

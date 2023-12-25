using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Logos : MonoBehaviour {

    public float Hit, Wit;
    public float camSize;
    public GameObject backG;
    public GameObject foreG;
    public GameObject pieLogo;
    public GameObject whotCred;
    public GameObject cred;
    public GameObject credText;
    public float loadProg;
    public Texture2D splashS;
    public GameObject whot, reim;
	// Use this for initialization
	void Start () {
        Hit = Screen.height;
        Wit = Screen.width;
        camSize = Camera.main.orthographicSize;
        GameObject.Find("DataMan").GetComponent<Datas>().startedFromLogos = true;

        foreG = GameObject.Find("Foreground");
        backG = GameObject.Find("Background");
        pieLogo = GameObject.Find("PieLogo");
        whotCred = GameObject.Find("WhotCred");
        cred = GameObject.Find("Credits");
        credText = GameObject.Find("CreditsText");
        splashS = (Texture2D)Resources.Load("splashScreen");
        whot = GameObject.Find("Whot");
        reim = GameObject.Find("Reim");
        FixScale2(whot.transform);
        FixScale2(reim.transform);
        //wVel = rVel = 5;
        //whotPosx = whot.transform.position.x;
        //whot.transform.po
        //pDpos = GameObject.Find("PilePos").transform;
        //FixPos(pDpos.transform, new Vector2(100, 100));
        //pDpos.transform.position += new Vector3(5, 5);
        //InstantiatePile();
        FixPos(whotCred.transform, new Vector2(50, 0));
        FixPos(cred.transform, new Vector2(50, 0));
        if (Camera.main.aspect >= 1.5f)
            whotCred.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), 1, 1);
        else
            whotCred.transform.localScale = new Vector3(1, (camSize * 2), 1);
        FixScale(whotCred.transform);
        cred.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), 1.4f, 1);
        StartCoroutine(ShowLogos());
        //backG.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), (camSize * 2), 1);
        //foreG.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), (camSize * 2), 1);
        //backG.GetComponent<MeshRenderer>().material.mainTexture = backs[0];
        //backG.GetComponent<MeshRenderer>().material.mainTexture = backs[Random.Range(0, backs.Length)];
        //backG.GetComponent<MeshRenderer>().material.shader = Shader.Find("Unlit/Texture");
	}
	
	// Update is called once per frame
    //void Update()
    //{
        

    //}
    void FixScale(Transform but)
    {
        Texture2D tex = (Texture2D)but.gameObject.GetComponent<MeshRenderer>().material.mainTexture;
        if (tex)
        {
            if (Camera.main.aspect >= 1.5f)
                but.localScale = new Vector3(but.localScale.x, but.localScale.x / (((float)tex.width / (float)tex.height)), but.localScale.z);
            else
                but.localScale = new Vector3(but.localScale.y * (((float)tex.width / (float)tex.height)), but.localScale.y, but.localScale.z);
        }
    }
    void FixScale2(Transform but)
    {
        Texture2D tex = (Texture2D)but.gameObject.GetComponent<MeshRenderer>().material.mainTexture;
        but.localScale = new Vector3(but.localScale.y * (((float)tex.width / (float)tex.height)), but.localScale.y, but.localScale.z);
    }
    void FixPos(Transform but, Vector2 posVec)
    {
        but.localPosition = new Vector3((((posVec.x / 100) * (2 * (camSize + (Wit - Hit) / (Hit / camSize)))) - camSize) - ((Wit - Hit) / (Hit / camSize)), (((posVec.y / 100) * (2 * camSize))) - camSize, but.localPosition.z);
    }
    IEnumerator ShowLogos()
    {
        whotCred.SetActive(false);
        cred.SetActive(false);
        credText.SetActive(false);
        float wVel = 0;
        float rVel = 0;
        float secs = 2;
        float tran = 0;
        float speed = 1;
        float slideSpeed = 0.5f;
        Color c = foreG.GetComponent<MeshRenderer>().material.color;
        while (tran <= speed)
        {
            tran += Time.deltaTime;
            c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(1, 0, (tran / speed));
            foreG.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        yield return new WaitForSeconds(secs);
        tran = 0;
        while (tran <= speed)
        {
            tran += Time.deltaTime;
            c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(0, 1, (tran / speed));
            foreG.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        Destroy(pieLogo);
        whotCred.SetActive(true);
        tran = 0;
        while (tran <= speed)
        {
            tran += Time.deltaTime;
            c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(1, 0, (tran / speed));
            foreG.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        cred.SetActive(true);
        credText.SetActive(true);
        tran = 0;
        while (tran <= speed)
        {
            tran += Time.deltaTime;
            c = cred.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(0, 1, (tran / speed));
            cred.GetComponent<MeshRenderer>().material.color = c;
            credText.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        yield return new WaitForSeconds(secs);
        tran = 0;
        while (tran <= speed)
        {
            tran += Time.deltaTime;
            c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(0, 1, (tran / speed));
            foreG.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        whotCred.GetComponent<MeshRenderer>().material.mainTexture = splashS;
        whotCred.transform.localScale = new Vector3(1, (camSize * 2), 1);
        FixScale2(whotCred.transform);
        cred.SetActive(false);
        credText.SetActive(false);
        StartCoroutine(ZoomOutCam(slideSpeed));
        tran = 0;
        while (tran <= speed)
        {
            tran += Time.deltaTime;
            c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(1, 0, (tran / speed));
            foreG.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        while (System.Math.Round(whot.transform.position.x, 3) < 0)
        {
            whot.transform.position = new Vector3(Mathf.SmoothDamp(whot.transform.position.x, 0, ref wVel, slideSpeed), whot.transform.position.y, whot.transform.position.z);
            reim.transform.position = new Vector3(Mathf.SmoothDamp(reim.transform.position.x, 0, ref rVel, slideSpeed), reim.transform.position.y, reim.transform.position.z);
            yield return null;
        }
        tran = 0;
        while (tran <= speed)
        {
            tran += Time.deltaTime;
            c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(0, 1, (tran / speed));
            foreG.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        GameObject fore2 = (GameObject)Instantiate(foreG, Vector3.forward * -6, Quaternion.identity);
        c = fore2.GetComponent<MeshRenderer>().material.color;
        c.a = 0;
        fore2.GetComponent<MeshRenderer>().material.color = c;
        yield return new WaitForSeconds(0.5f);
        tran = 0;
        while (tran <= speed)
        {
            tran += Time.deltaTime;
            c = fore2.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(0, 1, (tran / speed));
            fore2.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        Application.LoadLevel(1);
        //while (loadProg <= 100)
            //loadProg = Application.GetStreamProgressForLevel(1) * 100;
    }
    IEnumerator ZoomOutCam(float speed)
    {
        float cVel = 0;
        Camera.main.orthographicSize = 2;
        while (System.Math.Round(Camera.main.orthographicSize, 3) < 5)
        {
            Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, 5, ref cVel, speed);
            yield return null;
        }
    }
    /*void InstantiatePile()
    {
        int[] circVal = new int[] { 1, 2, 3, 4, 5, 7, 8, 10, 11, 12, 13, 14 };
        int[] triVal = new int[] { 1, 2, 3, 4, 5, 7, 8, 10, 11, 12, 13, 14 };
        int[] croVal = new int[] { 1, 2, 3, 5, 7, 10, 11, 13, 14 };
        int[] squVal = new int[] { 1, 2, 3, 5, 7, 10, 11, 13, 14 };
        int[] starVal = new int[] { 1, 2, 3, 4, 5, 7, 8 };
        int[] whotVal = new int[] { 20, 20, 20, 20 };
        int totCards = circVal.Length + triVal.Length + croVal.Length + squVal.Length + starVal.Length + whotVal.Length;
        List<int> cardValues = new List<int>();
        List<GameObject> pile = new List<GameObject>();
        cardValues.AddRange(circVal);
        cardValues.AddRange(triVal);
        cardValues.AddRange(croVal);
        cardValues.AddRange(squVal);
        cardValues.AddRange(starVal);
        cardValues.AddRange(whotVal);
        pile = new List<GameObject>(new GameObject[totCards]);
        Texture2D[] cF = Resources.LoadAll<Texture2D>("Cards");
        List<Texture2D> cardFaces = new List<Texture2D>(cF);
        for (int i = 0; i < 3; i++)
        {
            cardFaces.Add(cardFaces[cardFaces.Count - 1]);
        }
        for (int i = 0; i < totCards; i++)
        {
            pile[i] = (GameObject)Instantiate(Resources.Load("Card"), (pDpos.position + new Vector3((i * -0.003f), i * 0.01f, i * 0.005f)), Quaternion.identity);
            pile[i].name = "card" + i.ToString();
            pile[i].transform.eulerAngles = Vector3.up * 180;
            pile[i].transform.localScale = Vector3.up * 2.5f;
            //allCards.Add(pile[i]);
        }
        for (int i = 0; i < circVal.Length; i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Circle";
            pile[i].GetComponent<CardProp>().value = circVal[i];
            //cardSuits.Add("Circle");
        }
        for (int i = circVal.Length; i < (circVal.Length + triVal.Length); i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Triangle";
            //cardSuits.Add("Triangle");
            pile[i].GetComponent<CardProp>().value = triVal[i - circVal.Length];
        }
        for (int i = (circVal.Length + triVal.Length); i < (circVal.Length + triVal.Length + croVal.Length); i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Cross";
            //cardSuits.Add("Cross");
            pile[i].GetComponent<CardProp>().value = croVal[i - (circVal.Length + triVal.Length)];
        }
        for (int i = (circVal.Length + triVal.Length + croVal.Length); i < (circVal.Length + triVal.Length + croVal.Length + squVal.Length); i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Square";
            //cardSuits.Add("Square");
            pile[i].GetComponent<CardProp>().value = squVal[i - (circVal.Length + triVal.Length + croVal.Length)];
        }
        for (int i = (circVal.Length + triVal.Length + croVal.Length + squVal.Length); i < totCards - 4; i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Star";
            //cardSuits.Add("Star");
            pile[i].GetComponent<CardProp>().value = starVal[i - (circVal.Length + triVal.Length + croVal.Length + squVal.Length)];
        }
        for (int i = totCards - 4; i < totCards; i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Whot";
            //cardSuits.Add("Whot");
            pile[i].GetComponent<CardProp>().value = 20;
        }
        for (int i = 0; i < pile.Count; i++)
        {
            for (int j = 0; j < cardFaces.Count; j++)
            {
                if (cardFaces[j].name == (pile[i].GetComponent<CardProp>().suit + pile[i].GetComponent<CardProp>().value.ToString()))
                {
                    pile[i].GetComponent<CardProp>().mat.mainTexture = cardFaces[j];
                    FixScale2(pile[i].transform);
                    pile[i].AddComponent<BoxCollider>();
                    pile[i].AddComponent<Rigidbody>();
                    pile[i].GetComponent<Rigidbody>().drag = 2f;
                    pile[i].GetComponent<Rigidbody>().AddForce(new Vector3(-5f, 0, 0), ForceMode.Impulse);
                    pile[i].GetComponent<Rigidbody>().AddExplosionForce(10000, pDpos.position, 400);
                    pile[i].GetComponent<Rigidbody>().AddTorque(new Vector3(-5, 0, 0), ForceMode.Force);
                   // Debug.Log("hh");
                    break;
                }
                Destroy(pile[i].GetComponent<CardProp>());
            }
        }
        //Shuffle();
    }*/
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(w/2, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        string text = loadProg.ToString() + "%";
        if (loadProg > 0)
            GUI.Label(rect, text, style);
    }
}//©

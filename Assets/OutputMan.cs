using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OutputMan : MonoBehaviour {
    public CardsMan cardsMan;
    public InputMan inputMan;
    public CardRules cardRules;
    public GameObject[] text;
    public GameObject mesBox;
    public Vector3 mesBoxPool;
    public bool canUseMesBox;
    public GameObject mesBut1;
    public GameObject mesBut2;
    public GameObject mesBut3;
    public TextMesh top;
    public TextMesh bod;
    public TextMesh mb1;
    public TextMesh mb2;
    public TextMesh mb3;
	// Use this for initialization
	void Start () {
        cardsMan = GetComponent<CardsMan>();
        inputMan = GetComponent<InputMan>();
        cardRules = GetComponent<CardRules>();
        mesBox = GameObject.Find("MessageBox");
        mesBoxPool = mesBox.transform.position;
        CollectMessageBox();
        //WriteMessageBox("", "\n14✚ 2✚ 5✚ 3✚ 13✚ 2✚ 5✚ 1✚ 1✚ 10✚ 13✚ 7✚ 4✚ 10✚ 13✚ 10✚ 20W = 140", new string[] { "2<", "1Menu", "3>" });
        //string bv ★✚▲✔✘●■ 14■ 2✚ 5■ 3★ 13■ 2● 5✚ 1▲ 1✚ 10✚ 13▲ 7✚ 4★ 10▲ 13● 10● 20W= "No part of this publication may be reproduced, stored in a retrieval system or transmitted in any form or by any means, electronic, mechanical photocopying, recording, scanning or otherwise, except as permitted under Sections 107 or 108 of the 1976 United States Copyright Act, without or otherwise, except as permitted under Sections 107 or 108 of the 1976 United States Copyright Act, without";
        //string bv = "Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta Ta ";
	}
	
	// Update is called once per frame
    //void Update () {
    //    if (Input.GetKeyDown("x"))
    //    {
    //        //StartCoroutine(ShrinkButton(mesBut3,false));
    //        //HideMessageBox();
    //    }
    //}
    public void ShadowText(GameObject textt)
    {
        GameObject shadow = (GameObject)Instantiate(textt, textt.transform.position, Quaternion.identity);
        shadow.transform.position -= new Vector3(0.04f, 0.04f, -0.01f) * textt.transform.localScale.x;
        shadow.GetComponent<TextMesh>().color = Color.black;
        shadow.name = textt.name + "1";
        shadow.transform.parent = textt.transform;
    }
    IEnumerator ShowMessageBox()
    {
        float tranT = Time.realtimeSinceStartup;
        float speed = 0.5f;
        Vector3 up = new Vector3(0, 0.5f, -4);
        Vector3 norm = Vector3.forward * -4;
        mesBox.transform.position = mesBoxPool;
        while (Time.realtimeSinceStartup - tranT <= speed)
        {
            mesBox.transform.position = Vector3.Lerp(mesBoxPool, up, ((Time.realtimeSinceStartup - tranT) / speed));
            yield return null;
        }
        mesBox.transform.position = up;
        tranT = Time.realtimeSinceStartup;
        speed = 0.1f;
        while (Time.realtimeSinceStartup - tranT <= speed)
        {
            mesBox.transform.position = Vector3.Lerp(up, norm, ((Time.realtimeSinceStartup - tranT) / speed));
            yield return null;
        }
        mesBox.transform.position = norm;
        mesBut1.transform.parent = null;
        mesBut2.transform.parent = null;
        mesBut3.transform.parent = null;
        canUseMesBox = true;
    }
    public void WriteMessageBox(string topic, string body, string[] buttonsText)
    {
        top.text = topic;
        int maxCh = 43;
        if (cardsMan.tenderMesBox == TenderState.GoOrView || cardsMan.tenderMesBox == TenderState.Results)
        {
            maxCh = 39;
        }
        int breakCo = 0;
        int spaceInd = 0;
        bool adLine = false;
        body = body.Replace("\n", "@");
        BreakLongWords(ref body, maxCh);
        char[] bbodyChar = body.ToCharArray();
        string bbody = "";
        for (int i = 0; i < bbodyChar.Length; i++)
        {
            bbody += bbodyChar[i].ToString();
            if (adLine)
            {
                bbody = bbody.Remove(i, 1);
                bbody += "^";
                breakCo = i + 1;
                adLine = false;
            }
            if (bbodyChar[i] == ' ')
            {
                spaceInd = i;
            }
            if (bbody[bbody.Length - 1].ToString() == "@")
            {
                bbody = bbody.Remove(i, 1);
                bbody = bbody.Insert(i, "^");
                breakCo = i + 1;
            }
            if (((i + 1) - breakCo) == maxCh)
            {
                if (i < (bbodyChar.Length - 1) && bbodyChar[i + 1] == ' ')
                {
                    adLine = true;
                }
                if (!adLine && (i+1)-spaceInd<maxCh)
                {
                    bbody = bbody.Remove(spaceInd, 1);
                    bbody = bbody.Insert(spaceInd, "^");
                    breakCo = spaceInd + 1;
                }
            }
        }
        bbody = bbody.Replace("^", "\n");
        FormatText(ref bbody);
        bod.text = bbody;
        mesBut1.SetActive(false);
        mesBut2.SetActive(false);
        mesBut3.SetActive(false);
        for (int i = 0; i < buttonsText.Length; i++)
        {
            if (buttonsText[i][0] == '1')
            {
                mesBut1.SetActive(true);
                mb1.text = buttonsText[i].Remove(0,1);
            }
            else if (buttonsText[i][0] == '2')
            {
                mesBut2.SetActive(true);
                mb2.text = buttonsText[i].Remove(0,1);
            }
            else if (buttonsText[i][0] == '3')
            {
                mesBut3.SetActive(true);
                mb3.text = buttonsText[i].Remove(0,1);
            }
        }
        if (mesBox.transform.position == mesBoxPool)
        {
            mesBut1.transform.parent = null;
            mesBut2.transform.parent = null;
            mesBut3.transform.parent = null;
            Vector3 laScale = new Vector3(2.7f, 0.9f, 1);
            mesBut1.transform.localScale = laScale;
            mesBut2.transform.localScale = laScale;
            mesBut3.transform.localScale = laScale;
            mesBut1.transform.parent = mesBox.transform;
            mesBut2.transform.parent = mesBox.transform;
            mesBut3.transform.parent = mesBox.transform;
            StartCoroutine(ShowMessageBox());
        }
    }
    void FormatText(ref string text)
    {
        foreach (int ind in cardsMan.realPlayers)
        {
            string namee = cardsMan.PlayerNameText(ind,true);
            text = text.Replace(namee, "<color=blue>" + namee + "</color>");
        }
    }
    void BreakLongWords(ref string text,int maxChar)
    {
        int s = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (new char[] { ' ', '@' }.Contains(text[i]))
            {
                s = i+1;
            }
            if (i - s >= maxChar)
            {
                text=text.Insert(i, "@");
                s = i+1;
            }
        }
    }
    void CollectMessageBox()
    {
        top = mesBox.transform.GetChild(0).GetComponent<TextMesh>();
        bod = mesBox.transform.GetChild(1).GetComponent<TextMesh>();
        mesBut1 = mesBox.transform.GetChild(2).gameObject;
        mesBut2 = mesBox.transform.GetChild(3).gameObject;
        mesBut3 = mesBox.transform.GetChild(4).gameObject;
        mb1 = mesBut1.transform.GetChild(0).GetComponent<TextMesh>();
        mb2 = mesBut2.transform.GetChild(0).GetComponent<TextMesh>();
        mb3 = mesBut3.transform.GetChild(0).GetComponent<TextMesh>();
    }
    public void ShrinkResizeButton(GameObject but)
    {
        but.transform.parent = null;
        Vector3 smScale = new Vector3(2.25f, 0.75f, 1);
        if (but.transform.localScale != smScale)
        {
            but.transform.localScale = smScale;
            but.transform.parent = mesBox.transform;
        }
        else
        {
            Vector3 laScale = new Vector3(2.7f, 0.9f, 1);
            but.transform.localScale = laScale;
            but.transform.parent = mesBox.transform;
        }
    }
    public void HideMessageBox()
    {
        if (mesBox.transform.position != mesBoxPool)
        {
            mesBut1.transform.parent = null;
            mesBut2.transform.parent = null;
            mesBut3.transform.parent = null;
            Vector3 laScale = new Vector3(2.7f, 0.9f, 1);
            mesBut1.transform.localScale = laScale;
            mesBut2.transform.localScale = laScale;
            mesBut3.transform.localScale = laScale;
            mesBut1.transform.parent = mesBox.transform;
            mesBut2.transform.parent = mesBox.transform;
            mesBut3.transform.parent = mesBox.transform;
            mesBox.transform.position = mesBoxPool;
            canUseMesBox = false;
        }
    }
}

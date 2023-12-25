using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InputMan : MonoBehaviour {
    public CardsMan cardsMan;
    public CardRules cardRules;
    public OutputMan outputMan;
    public bool canPlay;
    public bool hasPlayed;
    public Touch[] tos;
    public Vector3 tTWorldPos;
    public Vector3 tTWorldPosF;
    public string err;
    public bool hasTouched;
    Ray camRay;
    RaycastHit butHit;
    public Vector3 lastTPos;
    public Vector3 lastTPosScrn;
    public GameObject scrObject;
    public Vector3 lastScrPos;
    public Vector3 delta;
    public Vector3 deltaWorld;
    public int cardInd;
    public int turn;
    public List<GameObject> playerHand;
    public GameObject[] selCas;
    public float selTime;
    public bool sel;
    public bool justSelFirst;
    public List<int> selList;
    public Transform selCaTrans;
    public bool swiped;
    public Vector3 pool;
    public GameObject pileCol;
    public GameObject playPileCol;
    public bool touchedCard;
    public bool canScroll;
    public bool canTakeMar;
    public bool canShift;
    public Vector3 tVec;
    public List<GameObject> canBePlayed;
    public GameObject touchedObject;
	// Use this for initialization
	void Start () {
        cardsMan = GetComponent<CardsMan>();
        cardRules = GetComponent<CardRules>();
        outputMan = GetComponent<OutputMan>();
        selCas = new GameObject[5];
        selCas[0] = GameObject.Find("SelCard1");
        selCas[1] = GameObject.Find("SelCard2");
        selCas[2] = GameObject.Find("SelCard3");
        selCas[3] = GameObject.Find("SelCard4");
        selCas[4] = GameObject.Find("SelCard5");
        selCaTrans = cardsMan.selCaTrans.transform;
        scrObject = cardsMan.scrollObj;
        foreach (GameObject item in selCas)
        {
            item.SetActive(false);
        }
        pool = selCas[0].transform.position;
        pileCol = cardsMan.pileCol;
        playPileCol = cardsMan.playPileCol;
	}
	
	// Update is called once per frame
	void Update () {
        canPlay = cardsMan.canPlay;
        turn=cardsMan.turn;
        if(cardsMan.hasDistributed)
        playerHand = cardsMan.playHands[cardsMan.playInd];
        canBePlayed = cardRules.canBePlayed;
        tos = Input.touches;
        //if (Input.touchCount > 0)
        //{
            //tTWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            tTWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (Input.GetMouseButtonDown(0)){
                camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                //camRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(camRay, out butHit))
                {
                    touchedObject = butHit.collider.gameObject;
                    if (playerHand.Contains(butHit.collider.gameObject))
                    {
                        cardInd = playerHand.IndexOf(butHit.collider.gameObject);
                        touchedCard = true;
                        canScroll = true;
                    }
                    if (butHit.collider.gameObject.name == "BackScroll")
                    {
                        canScroll = true;
                        cardsMan.StopCoroutine("SlowScrDelta");
                    }
                    if (butHit.collider.gameObject.name == pileCol.name && cardsMan.canPlay)
                    {
                        canTakeMar = true;
                    }
                    /*if (butHit.collider.gameObject.name == playPileCol.name)
                    {
                        canShift = true;
                    }*/
                    if (outputMan.canUseMesBox && new string[] { "Button1", "Button2", "Button3" }.Contains(butHit.collider.gameObject.name))
                    {
                        outputMan.ShrinkResizeButton(butHit.collider.gameObject);
                    }
                    if (butHit.collider.gameObject.name == "NextTurnButton")
                    {
                        outputMan.ShrinkResizeButton(butHit.collider.gameObject);
                    }
                    if(canScroll)
                    lastTPos = tTWorldPos;
                    //Debug.Log(lastTPos);
                    lastTPosScrn = Input.mousePosition;
                    tVec = Input.mousePosition;

                    //lastTPosScrn = Input.GetTouch(0).position;
                    if (canPlay)
                    {
                        hasPlayed = false;
                    }
                    hasTouched = true;
                }
            }
                if (hasTouched)
                {
                    if (Mathf.Abs(Input.mousePosition.x - tVec.x) < 5f)
                    {
                        if(touchedCard)
                        selTime += Time.deltaTime;
                    }
                    else
                    {
                        swiped = true;
                        selTime = 0;
                    }
                    delta = Input.mousePosition - lastTPosScrn;
                    //delta = new Vector3(Input.GetTouch(0).position.x,Input.GetTouch(0).position.y) - lastTPosScrn;
                    if(canScroll)
                    deltaWorld = tTWorldPos - lastTPos;
                    lastTPosScrn = Input.mousePosition;
                    //lastTPosScrn = Input.GetTouch(0).position;
                    if (touchedCard && !hasPlayed && delta.y > 10 && SwipeAngle() <= 30 && cardsMan.canPlay)
                    {
                        if (!sel)
                        {
                            if (canBePlayed.Contains(playerHand[cardInd]))
                            {
                                StartCoroutine(cardsMan.PlayCard(turn, new List<int> { cardInd }));
                            }
                        }
                        else
                        {
                            foreach (GameObject item in selCas)
                            {
                                item.transform.parent = null;
                                item.transform.position = pool;
                            }
                            StartCoroutine(cardsMan.PlayCard(turn, selList));
                            sel = false;
                        }
                        hasPlayed = true;
                        touchedCard = false;
                    }
                    lastTPos = tTWorldPos;
                    if (canTakeMar && !hasPlayed && delta.y<-10)
                    {
                        if (!cardRules.gTM)
                        {
                            StartCoroutine(cardsMan.GoToMarket(turn, 1));
                        }
                        else
                        {
                            StartCoroutine(cardsMan.GoToMarket(turn, cardRules.gTMVal));
                        }
                        if (sel)
                        {
                            foreach (GameObject item in selCas)
                            {
                                item.transform.parent = null;
                                item.transform.position = pool;
                            }
                            selList.Clear();
                            sel = false;
                        }
                        hasPlayed = true;
                        canTakeMar = false;
                    }
                    if (!justSelFirst && selTime > 0.7f && !sel && !swiped && cardsMan.doubleGame)
                    {
                        if (canBePlayed.Contains(playerHand[cardInd]))
                        {
                            selList.Clear();
                            selCas[0].SetActive(true);
                            selCas[0].transform.position = new Vector3(playerHand[cardInd].transform.position.x, selCaTrans.position.y, playerHand[cardInd].transform.position.z);
                            selCas[0].transform.parent = playerHand[cardInd].transform;
                            selList.Add(cardInd);
                            justSelFirst = true;
                            DestroyCovers();
                            sel = true;
                            cardRules.ClearPrevious();
                            cardRules.RefreshCards();
                            cardRules.CheckSameVal();
                            cardsMan.GreyOutCards();
                        }
                    }
                }
                if (Input.GetMouseButtonUp(0)/*Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled*/)
                {
                    camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //camRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(camRay, out butHit))
                    {
                        if (touchedObject == butHit.collider.gameObject)
                        {
                            if (butHit.collider.gameObject.name == "ActHead" && !cardsMan.acTrans)
                            {
                                StartCoroutine(cardsMan.MoveActLog());
                            }
                            if (outputMan.canUseMesBox && new string[] { "Button1", "Button2", "Button3" }.Contains(butHit.collider.gameObject.name))
                            {
                                cardsMan.MessageBoxAction(butHit.collider.gameObject.name.Replace("Button", ""));
                            }
                            if (touchedObject.name == "NextTurnButton")
                            {
                                StartCoroutine(cardsMan.ReturnCardsCover());
                            }
                            if (cardsMan.ffNames.Contains(touchedObject.name))
                            {
                                if (Time.timeScale != 0)
                                    cardsMan.FastForward(touchedObject.name);
                            }
                            CheckChangeSuit();
                        }
                    }
                    if (touchedObject && new string[] { "Button1", "Button2", "Button3", "NextTurnButton" }.Contains(touchedObject.name))
                    {
                        outputMan.ShrinkResizeButton(touchedObject);
                    }
                    touchedObject = null;
                    if (sel && selList.Count <= 5 && !swiped && !justSelFirst)
                    {
                        if (cardInd != selList[selList.Count - 1])
                        {
                            if (!selList.Contains(cardInd) && canBePlayed.Contains(playerHand[cardInd]))
                            {
                                selCas[selList.Count].SetActive(true);
                                selCas[selList.Count].transform.position = new Vector3(playerHand[cardInd].transform.position.x, selCaTrans.position.y, playerHand[cardInd].transform.position.z);
                                selCas[selList.Count].transform.parent = playerHand[cardInd].transform;
                                selList.Add(cardInd);
                            }
                        }
                        else
                        {
                            selCas[selList.Count - 1].transform.parent = null;
                            selCas[selList.Count - 1].transform.position = pool;
                            selCas[selList.Count - 1].SetActive(false);
                            selList.Remove(cardInd);
                        }
                    }
                    if (selList.Count == 0 && sel)
                    {
                        DestroyCovers();
                        cardRules.ClearPrevious();
                        cardRules.RefreshCards();
                        cardRules.CheckCards();
                        cardsMan.GreyOutCards();
                        sel = false;
                    }
                    canTakeMar = false;
                    touchedCard = false;
                    cardsMan.StartCoroutine("SlowScrDelta");
                    canScroll = false;
                    hasTouched = false;
                    justSelFirst = false;
                    swiped = false;
                    selTime = 0;
                }
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    Time.timeScale = 0;
                    outputMan.WriteMessageBox("Retry?", "Do you want to retry?", new string[] { "1Menu", "2Back", "3Retry" });
                    cardsMan.tenderMesBox = TenderState.Restart;
                }
        }
	}
    void CheckChangeSuit()
    {
        if (butHit.collider.gameObject.name == "CCircle")
        {
            cardsMan.ChangeSuit("Circle");
        }
        else if (butHit.collider.gameObject.name == "CTriangle")
        {
            cardsMan.ChangeSuit("Triangle");
        }
        else if (butHit.collider.gameObject.name == "CSquare")
        {
            cardsMan.ChangeSuit("Square");
        }
        else if (butHit.collider.gameObject.name == "CCross")
        {
            cardsMan.ChangeSuit("Cross");
        }
        else if (butHit.collider.gameObject.name == "CStar")
        {
            cardsMan.ChangeSuit("Star");
        }
    }
    void DestroyCovers()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            Transform dc = playerHand[i].transform.Find("DarkCover(Clone)");
            if (dc)
            {
                Destroy(dc.gameObject);
            }
        }
    }
    float SwipeAngle()
    {
        return Vector3.Angle((Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastTPos), cardsMan.pos[4].up);
    }
    /*void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(w/2, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        string text = /*delta.x.ToString() + " " + Mathf.Abs(Input.mousePosition.x - tVec.x).ToString();
        GUI.Label(rect, text, style);
    }*/
}

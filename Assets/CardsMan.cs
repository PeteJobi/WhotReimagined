using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CardsMan : MonoBehaviour {
    public CardRules cardRules;
    public Datas dataScript;
    public GameObject dataMan;
    public AIMan aiScript;
    public float Hit;
    public float Wit;
    public float camSize;
    public InputMan inputMan;
    public OutputMan outputMan;
    public List<Transform> pos;
    public List<Vector3> cardPos;
    public List<Vector2> posV;
    public List<GameObject> pics;
    public List<GameObject> pile;
    public List<GameObject> playPile;
    public List<List<GameObject>> playHands;
    public Transform pDpos;
    public Transform pUpos;
    public GameObject ca;
    public Vector3 tarVec;
    public int totCards;
    public int iniNum;
    public List<Vector3> playerCaPos;
    public List<Vector3> playerCaTar;
    public Vector3 mVel;
    public Vector3 sVel;
    public float distSpeed;
    public float playSpeed;
    public float pFlipSpeed;
    public bool hasDistributed;
    public bool firstTimePassed;
    public int cLim;
    public bool isPlaying;
    public int playInd;
    public float pCaSpeed;
    public float pCaInterval;
    public int lastHand;
    public int lastInd;
    public GameObject pPileParent;
    public Vector3 pPileParentPos;
    public bool didntFinishedGToM;
    public bool didntFinishedGM;
    public Vector2 ab;
    public bool hasMoreThan5;
    public GameObject scrollObj;
    public int totNum;
    public List<int> realPlayers;
    public string[] absentSeats;
    public string[] presentSeats;
    public GameObject[] playArrs;
    public Vector3[] playArrsPos;
    public bool reachedLeft;
    public Vector3 pileScale;
    public Vector3 aiScale;
    public Vector3 playScale;
    public int turn;
    public bool canPlay;
    public GameObject pileCol;
    public GameObject playPileCol;
    public List<string> cardSuits;
    public List<int> cardValues;
    public List<GameObject> allCards;
    public float[] scrClamps;
    public GameObject selCaTrans;
    public int curCardInd;
    public bool hasGTM;
    public bool playAgain;
    public bool gTM;
    public int gTMVal;
    public bool skip;
    public bool reverse;
    public bool gM;
    public bool change;
    public List<GameObject> canBePlayed;
    public List<GameObject> cannotBePlayed;
    public GameObject suitC;
    public bool checkIfCanPlay;
    public bool checkIfAiCanPlay;
    public bool arrangeCards;
    public Object darkCover;
    public Texture2D circ, tri, cro, squ, sta, who;
    public bool isGenMar;
    public bool isGotMar;
    public bool aiCanPlay;
    public bool doubleGame;
    public GameObject[] twoPos;
    public int scrLim;
    public bool hasPlaced2;
    public Texture2D por0;
    public Texture2D por1;
    public int twPlSwitch;
    public GameObject scrMask;
    public GameObject leftBlock;
    public GameObject rightBlock;
    public GameObject backScroll;
    public bool justAI;
    public List<string> names;
    public List<string> realNames;
    public Vector3 nameTextPos;
    public Vector3 nameBGPos;
    public Texture2D turnFrame;
    public Texture2D normFrame;
    public Texture2D turnBG;
    public Texture2D normBG;
    public Texture2D turnDownBG;
    public Texture2D normDownBG;
    public GameObject actLog;
    public bool acTrans;
    public Vector3 topL;
    public Vector3 midL;
    public Vector3 downL;
    public Vector3 acPos;
    public Vector3 acTar;
    public bool acIsTop;
    public bool acIsMid;
    public bool acIsDown;
    public Texture2D acPointDown;
    public Texture2D acPointUp;
    public TextMesh acText;
    public List<string> aLog;
    public List<List<string>> caca;
    public string fPCard;
    public bool isTest;
    public bool tender;
    public bool comStreak;
    public GameObject pileNuGO;
    public TextMesh pileNu;
    public GameObject stockNuGO;
    public TextMesh stockNu;
    public int lastTurn;
    public int[] streakPoints;
    public int combo = 1;
    public int streak;
    public GameObject[] coms;
    public Vector2[] vcc;
    public Transform[] comPos;
    public Transform[] rankPos;
    public Transform[] pointsPos;
    public GameObject comboUIGO;
    public GameObject[] comboUIs;
    public List<GameObject> rankUIs;
    public GameObject[] tStreakUI;
    public TextMesh[] tStreakText;
    public GameObject streakPTextM;
    public GameObject[] cUIs;
    public TextMesh[] streakPTextMText;
    public Vector3 comboUIPool;
    public GameObject checkUpUI;
    public GameObject chMark;
    public int checkCount;
    public Shader blackAndWhite;
    public List<int> checkedOut;
    public bool everyoneChecked;
    public int playersLeft;
    public bool playerChecked;
    public Vector3[] pic2Center;
    public int streakPointGoal;
    public int aiDifficulty;
    public bool noMoreMarket;
    public GameObject mesBox;
    public TenderState tenderMesBox;
    public CheckedState checkedMesBox;
    public int iterCo;
    public float scrDelta;
    public bool hideBack;
    public GameObject sPBGPrefab;
    public GameObject[] sPBG;
    public GameObject ffBG;
    public GameObject midSp, fastSp;
    public string[] ffNames;
    public GameObject effectsUI;
    public MeshRenderer effectsUIMR;
    public Texture2D holdOn, pick2, pick3, susp, rev, genmark, ineed, conti, semilast, last, checku;
    public bool repConti;
    public int lastRealPlayer;
    //public string testString;
    public GameObject cardCover;
    public GameObject NextTurnText;
    public GameObject NextTurnButton;
    public List<int> disabledCards;
    public int tenderFlips, marketFlips;
    public GameObject tsp;
    public TextMesh tspText, spText, combText;
    public int myPos;
    public int totalSP;
    public string playerUserName;
    public Texture2D playerProfPic;


    // Use this for initialization
    void Awake()
    {
        dataMan = GameObject.Find("DataMan");
        if(dataMan)
        dataScript = dataMan.GetComponent<Datas>();
    }
    void Settings()
    {
        //isTest = true;
        if (dataMan)
        {
            doubleGame = dataScript.doubleGame;
            tender = dataScript.tender;
            comStreak = dataScript.streak;
            streakPointGoal = dataScript.streakPointGoal;
            tenderFlips = dataScript.tenderStock;
            iniNum = dataScript.numOfCards;
            totNum = dataScript.numOfPlayers;
            realPlayers = new List<int>();
            realPlayers.AddRange(dataScript.realPlayers);
            aiDifficulty = dataScript.aiDifficulty;
            disabledCards = dataScript.disabledCards;
            myPos = dataScript.myPos;
            totalSP = dataScript.totalSP;
            playerUserName = dataScript.playerName;
            playerProfPic = dataScript.myPic;
        }
        else
        {
            //doubleGame = true;
            //tender = true;
            comStreak = true;
            streakPointGoal = 50;
            tenderFlips = 1;
            iniNum = 26;
            totNum = 2;
            realPlayers = new List<int> { 0,1 };
            aiDifficulty = 1;
            disabledCards = new List<int> { };
            totalSP = 1500;
            myPos = 9;
            playerUserName = "DON";
        }
        realPlayers.Sort();
        if (comStreak || tender)
            aiDifficulty = 2;
    }
	void Start () {
        caca = new List<List<string>>();
        caca.Add(new List<string>());
        caca.Add(new List<string>());
        caca.Add(new List<string>());
        caca.Add(new List<string>());
        caca.Add(new List<string>());
        caca.Add(new List<string>());
        caca.Add(new List<string>());
        caca.Add(new List<string>());
        //hideBack = true;
        /*circVal = new int[] { 1, 2, 3, 4, 5, 7, 8, 10, 11, 12, 13, 14 };
        triVal = new int[] { 1, 2, 3, 4, 5, 7, 8, 10, 11, 12, 13, 14 };
        croVal = new int[] { 1, 2, 3, 5, 7, 10, 11, 13, 14 };
        squVal = new int[] { 1, 2, 3, 5, 7, 10, 11, 13, 14 };
        starVal = new int[] { 1, 2, 3, 4, 5, 7, 8 };
        whotVal = new int[] { 20, 20, 20, 20 };*/
        caca[0] = new List<string> { "12Triangle", "3Triangle"/*, "1Circle", "1Square"*/ };
        caca[7] = new List<string> { "13Circle", "14Cross"/*, "13Triangle", "8Square"*/ };
        caca[1] = new List<string> { "10Triangle", "10Circle"/*, "13Circle", "20Whot"*/ };
        caca[2] = new List<string> { "14Triangle", "13Triangle" };
        caca[4] = new List<string> { "5Triangle", "8Circle" };
        caca[5] = new List<string> { "7Cross", "20Whot" };
        caca[6] = new List<string> { "1Circle", "1Star" };
        caca[3] = new List<string> { "8Circle", "1Square" };
        //caca[0] = new List<string> { "14Triangle", "8Star", "3Triangle", "8Circle", "20Whot" };
        //caca[1] = new List<string> { "10Triangle", "13Circle", "13Square","20Whot","1Star" };
        fPCard = "7Triangle";
        //✩✔✘★✚▲●■①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳<size=80></size><color=blue></color><b></b>
        marketFlips = 1;
        cardRules = GetComponent<CardRules>();
        inputMan = GetComponent<InputMan>();
        outputMan = GetComponent<OutputMan>();
        aiScript = GetComponent<AIMan>();
        Settings();
        doubleGame = comStreak ? true : doubleGame;
        names = new List<string> { "Sara(AI)", "John(AI)", "Tola(AI)", "Ola(AI)", "Lucy(AI)", "Toyin(AI)", "Ayo(AI)", "Vic(AI)", "Lydia(AI)", "Seyi(AI)" };
        realNames = new List<string> { "Emma", "Taiwo", "Solo", "Casper", "Tooni", "Tobi", "Okiki", "Ani" };
        actLog = GameObject.Find("ActionLog");
        cLim = 4;
        Hit = Screen.height;
        Wit = Screen.width;
        camSize = Camera.main.orthographicSize;
        twoPos=new GameObject[2];
        twoPos[0] = GameObject.Find("TwoCardPos1");
        twoPos[1] = GameObject.Find("TwoCardPos2");
        FixPos(twoPos[0].transform, new Vector2(36, 18));
        FixPos(twoPos[1].transform, new Vector2(42, 84));
        LoadResources();
        SetBackGround();
        pUpos = GameObject.Find("PileUpPos").transform;
        pDpos = GameObject.Find("PileDownPos").transform;
        playArrs = new GameObject[2];
        playArrsPos = new Vector3[2];
        playArrs[0] = GameObject.Find("LeftArr");
        playArrs[1] = GameObject.Find("RightArr");
        FixPos(playArrs[0].transform, new Vector2(28, 25));
        FixPos(playArrs[1].transform, new Vector2(72, 25));
        if (totNum == 2)
        {
            FixPos(playArrs[0].transform, new Vector2(2, 18));
            FixPos(playArrs[1].transform, new Vector2(68, 18));
        }
        playArrsPos[0] = playArrs[0].transform.position;
        playArrsPos[1] = playArrs[1].transform.position;
        foreach (GameObject item in playArrs)
        {
            item.GetComponent<MeshRenderer>().enabled = false;
        }
        scrollObj = GameObject.Find("ScrollObject");
        scrollObj.transform.position = Vector3.zero;
        FixPos(pDpos, new Vector2(58, 55));
        FixPos(pUpos, new Vector2(42, 55));
        pileCol = GameObject.Find("PileCollider");
        playPileCol = GameObject.Find("PlayPileCollider");
        FixPos(pileCol.transform, new Vector2(58, 55));
        FixPos(playPileCol.transform, new Vector2(42, 55));
        selCaTrans = GameObject.Find("SelCardTrans");
        suitC = GameObject.Find("ChangeSuit");
        suitC.SetActive(false);
        FixPos(selCaTrans.transform, new Vector2(50, 38));
        pDpos.transform.position += Vector3.forward * 2;
        pUpos.transform.position += Vector3.forward * 2;
        distSpeed = 0.3f;
        playSpeed = 0.6f;
        pCaSpeed = 0.3f;
        pFlipSpeed = 1;
        pCaInterval = 1.5f;
        pileScale = new Vector3(1.640625f, 2.5f, 1f);
        aiScale = new Vector3(0.46875f, 0.7142857f, 1f);
        playScale = new Vector3(1.09375f, 1.666667f, 1f);
        scrLim = 4;
        if (totNum == 2)
        {
            aiScale = playScale;
            scrLim = 7;
            selCaTrans.transform.position -= Vector3.up * 0.7f;
        }
        scrClamps = new float[2];
        FixPos(actLog.transform, new Vector2(100, 0));
        topL = actLog.transform.localPosition;
        midL = new Vector3(topL.x, -7.25f, topL.z);
        downL = new Vector3(topL.x, -7.645f, topL.z);
        actLog.transform.position = midL;
        acIsMid = true;
        acPointUp = (Texture2D)actLog.transform.FindChild("ActHead").GetComponent<MeshRenderer>().material.mainTexture;
        acText = actLog.transform.FindChild("AcText").GetComponent<TextMesh>();
        pileNuGO = GameObject.Find("PileLeft");
        pileNu = pileNuGO.GetComponent<TextMesh>();
        stockNuGO = GameObject.Find("WhatStock");
        stockNu = stockNuGO.GetComponent<TextMesh>();
        FixPos(pileNuGO.transform, new Vector2(58, 63));
        FixPos(stockNuGO.transform, new Vector2(58, 47));
        InstantiatePile();
        pileCol.transform.localScale = pile[0].transform.localScale;
        playPileCol.transform.localScale = pile[0].transform.localScale;
        posV.Add(new Vector2(50, 91));//pos0
        posV.Add(new Vector2(77, 83));
        posV.Add(new Vector2(92, 50));//pos2
        posV.Add(new Vector2(77, 17));
        posV.Add(new Vector2(50, 9));//pos4
        posV.Add(new Vector2(23, 17));
        posV.Add(new Vector2(08, 50));//pos6
        posV.Add(new Vector2(23, 83));
        for (int i = 0; i < posV.Count; i++)
        {
            FixPos(pos[i], posV[i]);
        }
        comPos = new Transform[8];
        rankPos = new Transform[8];
        pointsPos = new Transform[8];
        for (int i = 0; i < comPos.Length; i++)
        {
            comPos[i] = new GameObject("ComPos" + i).transform;
            rankPos[i] = new GameObject("RankPos" + i).transform;
            pointsPos[i] = new GameObject("PointsPos" + i).transform;
        }
        FixPos(comPos[0], new Vector2(43, 91));
        FixPos(comPos[1], new Vector2(70, 83));
        FixPos(comPos[2], new Vector2(85, 50));
        FixPos(comPos[3], new Vector2(84, 17));
        FixPos(comPos[4], new Vector2(57, 9));
        FixPos(comPos[5], new Vector2(16, 17));
        FixPos(comPos[6], new Vector2(15, 50));
        FixPos(comPos[7], new Vector2(16, 83));
        FixPos(rankPos[0], new Vector2(53.5f, 86));//
        FixPos(rankPos[1], new Vector2(80.5f, 78));//
        FixPos(rankPos[2], new Vector2(95.5f, 45));//
        FixPos(rankPos[3], new Vector2(80.5f, 12));//
        FixPos(rankPos[4], new Vector2(53.5f, 14));//
        FixPos(rankPos[5], new Vector2(26.5f, 12));//
        FixPos(rankPos[6], new Vector2(11.5f, 45));//
        FixPos(rankPos[7], new Vector2(26.5f, 78));//
        FixPos(pointsPos[0], new Vector2(50, 75));//75
        FixPos(pointsPos[1], new Vector2(77, 93.5f));
        FixPos(pointsPos[2], new Vector2(92, 60.5f));
        FixPos(pointsPos[3], new Vector2(77, 27.5f));
        FixPos(pointsPos[4], new Vector2(50, 36));//36
        FixPos(pointsPos[5], new Vector2(23, 27.5f));
        FixPos(pointsPos[6], new Vector2(08, 60.5f));
        FixPos(pointsPos[7], new Vector2(23, 93.5f));
        absentSeats = new string[] { "01234567", "0123567", "123567", "02356", "2356", "026", "26", "0", "" };
        presentSeats = new string[] { "", "4", "04", "147", "0147", "13457", "013457", "1234567", "01234567" };
        InstantiatePlayers();
        playHands = new List<List<GameObject>>();
        sPBGPrefab = GameObject.Find("SPBG");
        StartCoroutine(Distribute());
        if (totNum > 2)
        {
            scrMask = GameObject.CreatePrimitive(PrimitiveType.Quad);
            scrMask.name = "ScrollMask";
            scrMask.transform.position = cardPos[playInd] - Vector3.forward * 1;
            scrMask.transform.position = new Vector3(scrMask.transform.position.x, scrMask.transform.position.y, 0.23f);
            scrMask.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), 2, 1);
            scrMask.GetComponent<MeshRenderer>().material.shader = Shader.Find("MaskedTexture");
            scrMask.GetComponent<MeshRenderer>().material.mainTexture = (Texture2D)Resources.Load("ScrollMask");
            scrMask.GetComponent<MeshCollider>().enabled = false;

            backScroll = GameObject.Find("BackScroll");
            backScroll.transform.position = scrMask.transform.position + Vector3.forward * 1.5f;
            backScroll.transform.localScale = new Vector3((camSize * (Wit / Hit) * (310f / 768f) * 2), 2, 1);
            backScroll.GetComponent<MeshRenderer>().enabled = false;

            leftBlock = GameObject.Find("BlockLeft");
            rightBlock = GameObject.Find("BlockRight");
            FixPos(leftBlock.transform, new Vector2(0, 0));
            FixPos(rightBlock.transform, new Vector2(100, 0));
            leftBlock.transform.position = new Vector3(leftBlock.transform.position.x, scrMask.transform.position.y, 0.3f);
            rightBlock.transform.position = new Vector3(rightBlock.transform.position.x, scrMask.transform.position.y, 0.3f);
            leftBlock.transform.localScale = new Vector3((camSize * (Wit / Hit) * (229f / 768f)), 1f, 1);
            rightBlock.transform.localScale = new Vector3((camSize * (Wit / Hit) * (229f / 768f)), 1f, 1);
            leftBlock.GetComponent<MeshRenderer>().enabled = false;
            rightBlock.GetComponent<MeshRenderer>().enabled = false;
        }
        if (realPlayers.Count > 1)
        {
            cardCover = GameObject.CreatePrimitive(PrimitiveType.Quad);
            cardCover.name = "CardsCover";
            cardCover.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), 2.5f, 1);
            cardCover.GetComponent<MeshRenderer>().material.mainTexture = (Texture2D)Resources.Load("CardsCover");
            cardCover.GetComponent<MeshRenderer>().material.shader = Shader.Find("Unlit/Transparent");
            cardCover.AddComponent<BoxCollider>();
            NextTurnText = GameObject.Find("NextTurnText");
            NextTurnButton = GameObject.Find("NextTurnButton");
            NextTurnText.transform.position = cardCover.transform.position - new Vector3(0, -0.55f, 0.1f);
            NextTurnButton.transform.position = cardCover.transform.position - new Vector3(0, 0.18f, 0.1f);
            NextTurnText.transform.parent = cardCover.transform;
            NextTurnButton.transform.parent = cardCover.transform;
            cardCover.transform.position = suitC.transform.position;
        }
        if (!tender)
        {
            Destroy(pileNuGO);
            Destroy(stockNuGO);
        }
        streakPoints = new int[totNum];
        tStreakUI = new GameObject[totNum];
        tStreakText = new TextMesh[totNum];
        sPBG = new GameObject[totNum];
        coms = new GameObject[totNum];
        /*vcc = new Vector2[totNum];
        vcc[0] = new Vector2(50, 75);
        vcc[1] = new Vector2(77, 93.5f);
        vcc[2] = new Vector2(92, 60.5f);
        vcc[3] = new Vector2(77, 27.5f);
        vcc[4] = new Vector2(50, 36);
        vcc[5] = new Vector2(23, 27.5f);
        vcc[6] = new Vector2(08, 60.5f);
        vcc[7] = new Vector2(23, 93.5f);*/
        /*comboUIGO = GameObject.Find("Combo");
        for (int i = 0; i < streakPoints.Length; i++)
        {
            coms[i] = (GameObject)Instantiate(comboUIGO, comboUIGO.transform.position, Quaternion.identity);
        }
        Destroy(comboUIGO);*/
        streakPTextM = GameObject.Find("StreakPoint");
        for (int i = 0; i < streakPoints.Length; i++)
        {
            tStreakUI[i] = (GameObject)Instantiate(streakPTextM, streakPTextM.transform.position, Quaternion.identity);
            tStreakUI[i].transform.position = pointsPos[PlayerPos(i)].transform.position;
            tStreakText[i] = tStreakUI[i].GetComponent<TextMesh>();
            sPBG[i] = (GameObject)Instantiate(sPBGPrefab, sPBGPrefab.transform.position, Quaternion.identity);
            sPBG[i].GetComponent<MeshRenderer>().enabled = false;
            sPBG[i].transform.position = new Vector3(tStreakUI[i].transform.position.x, tStreakUI[i].transform.position.y, sPBG[i].transform.position.z);
            if (totNum == 2)
            {
                tStreakUI[i].transform.localScale = Vector3.one;
                sPBG[i].transform.localScale = new Vector3(1.8f, 0.58f, 1);
            }
            sPBG[i].transform.parent = tStreakUI[i].transform;
            //outputMan.ShadowText(tStreakUI[i]);
        }
        Destroy(streakPTextM);
        Destroy(sPBGPrefab);
        combo = 1;
        CollectRankNCombo();
        cUIs = new GameObject[totNum];
        for (int i = 0; i < pics.Count; i++)
        {
            //cUIs[i] = (GameObject)Instantiate(streakPTextM, pics[i].transform.position, Quaternion.identity);
            //cUIs[i].transform.position -= Vector3.forward * 3;
            //cUIs[i].GetComponent<TextMesh>().color = Color.red;
        }
        CollectAndPositionAndScaleStuff();
        if (realPlayers.Count > 0) lastRealPlayer = realPlayers[0];
        tsp = GameObject.Find("TSP");
        tspText = tsp.transform.GetChild(0).GetComponent<TextMesh>(); tspText.text = totalSP.ToString();
        spText = tsp.transform.GetChild(1).GetComponent<TextMesh>(); spText.text = "0";
        combText = tsp.transform.GetChild(2).GetComponent<TextMesh>(); combText.text = "0";
        FixPos(tsp.transform, new Vector2(100, 100));
        if (myPos == 9) Destroy(tsp);
	}
	
	// Update is called once per frame
    void Update()
    {
        //FixScale(sPBGPrefab.transform);
        /*for (int i = 0; i < vcc.Length; i++)
        {
            FixPos(coms[i].transform, vcc[i]);
        }*/
        /*if (trans)
        {
            
        }*/
        if (Input.GetKeyDown("k")/* && canPlay*/)
        {
            //StartCoroutine(MoveActLog());
            Time.timeScale = 2;
            //actLog.transform.position = midL;
        }
        if (Input.GetKeyDown("m")/* && canPlay*/)
        {
            StartCoroutine(GoToMarket(0, 15));
            //NowTender();
        }
        if (Input.GetKeyDown("p")/* && canPlay*/)
        {
            //checkedOut = new List<int> { 0, 2, 3 };
            string[] uu=TenderStreakPositions();
            for (int i = 0; i < uu.Length; i++)
            {
                Debug.Log(uu[i] + " " + PlayerNameText(i, true));
            }
        }
        if (Input.GetKeyDown("x"))
        {
            StartCoroutine(GoToMarket(2, 35));
            /*string[] bb = TenderPositions();
            foreach (string item in bb)
            {
                Debug.Log(item);
            }*/
            //Time.timeScale = 1;
            //StartCoroutine(ShowSpecialCardUI(1,6));
        }
        if (!arrangeCards && hasDistributed && playHands[playInd].Count>scrLim && CanScrollEffect())
        {
            if (inputMan.canScroll) scrDelta = inputMan.deltaWorld.x;
            scrClamps[0] = (playHands[playInd].Count - scrLim) * -(pCaInterval / 2);
            scrClamps[1] = (playHands[playInd].Count - scrLim) * (pCaInterval / 2);
            scrollObj.transform.position = new Vector3(Mathf.Clamp((scrollObj.transform.position.x + scrDelta), scrClamps[0], scrClamps[1]), scrollObj.transform.position.y, scrollObj.transform.position.z);
        }
        if (playArrs[0].transform.position.x <= playArrsPos[0].x - 0.15f)
        {
            reachedLeft = true;
        }
        if (playArrs[0].transform.position.x >= playArrsPos[0].x)
        {
            reachedLeft = false; ;
        }
        if (hasMoreThan5)
        {
            ScrollArrows();
        }
        if (checkIfCanPlay)
        {
            if (!isPlaying && !arrangeCards && !isGenMar && !isGotMar && !didntFinishedGM && !didntFinishedGToM && !noMoreMarket)
            {
                canPlay = true;
                checkIfCanPlay = false;
            }
        }
        if (checkIfAiCanPlay)
        {
            if (!isPlaying && !isGotMar && !isGenMar && !didntFinishedGM && !didntFinishedGToM && !noMoreMarket)
            {
                AIPlay(turn);
                checkIfAiCanPlay = false;
            }
        }
	}
    void FixPos(Transform but, Vector2 posVec)
    {
        but.localPosition = new Vector3((((posVec.x / 100) * (2 * (camSize + (Wit - Hit) / (Hit / camSize)))) - camSize) - ((Wit - Hit) / (Hit / camSize)), (((posVec.y / 100) * (2 * camSize))) - camSize, but.localPosition.z);
    }
    void FixScale(Transform but)
    {
        Texture2D tex = (Texture2D)but.gameObject.GetComponent<MeshRenderer>().material.mainTexture;
        if(tex)
        but.localScale = new Vector3((((float)tex.width / (float)tex.height)) * but.localScale.y, but.localScale.y, but.localScale.z);
    }
    void InstantiatePile()
    {
        int[] circVal = new int[] { 1, 2, 3, 4, 5, 7, 8, 10, 11, 12, 13, 14 };
        int[] triVal = new int[] { 1, 2, 3, 4, 5, 7, 8, 10, 11, 12, 13, 14 };
        int[] croVal = new int[] { 1, 2, 3, 5, 7, 10, 11, 13, 14 };
        int[] squVal = new int[] { 1, 2, 3, 5, 7, 10, 11, 13, 14 };
        int[] starVal = new int[] { 1, 2, 3, 4, 5, 7, 8 };
        int[] whotVal = !disabledCards.Contains(20) ? new int[] { 20, 20, 20, 20 } : new int[] { };
        totCards = circVal.Length + triVal.Length + croVal.Length + squVal.Length + starVal.Length + whotVal.Length;
        ActLogAdd("<b>" + totCards.ToString() + "</b>" + " cards in total. " + "<b>" + totNum.ToString() + "</b>" + " players in total.");
        cardValues.AddRange(circVal);
        cardValues.AddRange(triVal);
        cardValues.AddRange(croVal);
        cardValues.AddRange(squVal);
        cardValues.AddRange(starVal);
        cardValues.AddRange(whotVal);
        pile = new List<GameObject>(new GameObject[totCards]);
        Texture2D[] cF = Resources.LoadAll<Texture2D>("Cards");
        List<Texture2D> cardFaces = new List<Texture2D>(cF);
        for (int i = 0; i < totCards; i++)
        {
            pile[i] = (GameObject)Instantiate(Resources.Load("Card"), (pDpos.position + new Vector3((i * -0.003f), i * 0.01f, i * 0.1f)), Quaternion.identity);
            pile[i].name = "card" + i.ToString();
            pile[i].transform.eulerAngles = Vector3.up * 180;
            pile[i].transform.localScale = Vector3.up * 2.5f;
            allCards.Add(pile[i]);
        }
        for (int i = 0; i < circVal.Length; i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Circle";
            pile[i].GetComponent<CardProp>().value = circVal[i];
            cardSuits.Add("Circle");
        }
        for (int i = circVal.Length; i < (circVal.Length + triVal.Length); i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Triangle";
            cardSuits.Add("Triangle");
            pile[i].GetComponent<CardProp>().value = triVal[i - circVal.Length];
        }
        for (int i = (circVal.Length + triVal.Length); i < (circVal.Length + triVal.Length + croVal.Length); i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Cross";
            cardSuits.Add("Cross");
            pile[i].GetComponent<CardProp>().value = croVal[i - (circVal.Length + triVal.Length)];
        }
        for (int i = (circVal.Length + triVal.Length + croVal.Length); i < (circVal.Length + triVal.Length + croVal.Length + squVal.Length); i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Square";
            cardSuits.Add("Square");
            pile[i].GetComponent<CardProp>().value = squVal[i - (circVal.Length + triVal.Length + croVal.Length)];
        }
        for (int i = (circVal.Length + triVal.Length + croVal.Length + squVal.Length); i < totCards - whotVal.Length; i++)
        {
            pile[i].GetComponent<CardProp>().suit = "Star";
            cardSuits.Add("Star");
            pile[i].GetComponent<CardProp>().value = starVal[i - (circVal.Length + triVal.Length + croVal.Length + squVal.Length)];
        }
        if (!disabledCards.Contains(20))
        {
            for (int i = 0; i < 3; i++)
            {
                cardFaces.Add(cardFaces[cardFaces.Count - 1]);
            }
            for (int i = totCards - 4; i < totCards; i++)
            {
                pile[i].GetComponent<CardProp>().suit = "Whot";
                cardSuits.Add("Whot");
                pile[i].GetComponent<CardProp>().value = 20;
            }
            who = cardFaces[cardFaces.Count - 1];
        }
        for (int i = 0; i < pile.Count; i++)
        {
            for (int j = 0; j < cardFaces.Count; j++)
            {
                if (cardFaces[j].name == (pile[i].GetComponent<CardProp>().suit + pile[i].GetComponent<CardProp>().value.ToString()))
                {
                    pile[i].GetComponent<CardProp>().mat.mainTexture = cardFaces[j];
                    FixScale(pile[i].transform);
                    break;
                }
                Destroy(pile[i].GetComponent<CardProp>());
            }
        }
        Shuffle();
    }
    void Shuffle()
    {
        List<string> laNo = new List<string>();
        for (int i = 0; i < pile.Count; i++)
        {
            laNo.Add(pile[i].name.Replace("card", ""));
        }
        for (int i = 0; i < pile.Count; i++)
        {
            if (pile[i].name.EndsWith(laNo[i]))
            {
                int rin = Random.Range(0, pile.Count);
                GameObject temp = pile[i];
                Vector3 tPos = pile[i].transform.position;
                pile[i].transform.position = pile[rin].transform.position;
                pile[i] = pile[rin];
                pile[rin].transform.position = tPos;
                pile[rin] = temp;
            }
        }
        if (isTest)
        {
            SetTestCards(caca, fPCard);
            isTest = false;
        }
        ActLogAdd("Deck was shuffled.");
        //ActLogAdd("14 <b><color=#800000ff>14✚★✚▲●■</color></b> 14✩★✚▲✔✘● ■");
    }
    IEnumerator Distribute()
    {
        for (int i = 0; i < iniNum; i++)
        {
            for (int j = 0; j < pics.Count; j++)
            {
                if (i == 0 && !firstTimePassed)
                    playHands.Add(new List<GameObject>());
                if (!IsPlayer(j))
                {
                    if (totNum > 2)
                    {
                        if (playHands[j].Count > (cLim - 1))
                        {
                            tarVec = playHands[j][playHands[j].Count - 1].transform.position + new Vector3(0.1f, 0f, 0.1f);
                        }
                        else
                        {
                            tarVec = cardPos[j] + Vector3.right * i * 0.5f;
                        }
                    }
                    else
                    {
                        tarVec = cardPos[j] + new Vector3(i * 0.5f, 0, i * 0.1f);
                    }
                }
                else
                {
                    if (playHands[j].Count == 0)
                    {
                        tarVec = cardPos[j];
                    }
                    else
                    {
                        tarVec = playHands[j][playHands[j].Count - 1].transform.position + Vector3.right * pCaInterval;
                    }
                }
                mVel = pile[0].transform.position;
                sVel = pile[0].transform.localScale;
                ca = pile[0];
                if (!IsPlayer(j))
                {
                    ca.GetComponent<MeshRenderer>().enabled = hideBack;
                }
                if (tender)
                    PileNumberLeft();
                float tranT = 0;
                while (tranT <= distSpeed)
                {
                    tranT += Time.deltaTime;
                    ca.transform.position = Vector3.Lerp(mVel, tarVec, (tranT / distSpeed));
                    if (tarVec.y != cardPos[playInd].y)
                    {
                        ca.transform.localScale = Vector3.Lerp(sVel, aiScale, (tranT / distSpeed));
                    }
                    else
                    {
                        ca.transform.localScale = Vector3.Lerp(sVel, playScale, (tranT / distSpeed));
                    }
                    yield return null;
                }
                playHands[j].Add(ca);
                pile.Remove(ca);
                for (int k = 0; k < pile.Count; k++)
                {
                    pile[k].transform.position = pDpos.position +  new Vector3((k * -0.003f), k * 0.01f, k * 0.01f);
                }
                if (IsPlayer(j) && playHands[playInd].Count>1)
                {
                    playerCaPos = new List<Vector3>(new Vector3[playHands[playInd].Count]);
                    playerCaTar = new List<Vector3>(new Vector3[playHands[playInd].Count]);
                    for (int l = 0; l < playHands[playInd].Count; l++)
                    {
                        playerCaPos[l] = (playHands[playInd][l].transform.position);
                        playerCaTar[l] = cardPos[playInd] - Vector3.right * (((playHands[playInd].Count - ((2 * l) + 1)) * (pCaInterval / 2)));
                    }
                    StartCoroutine(ArrangePlayerCards());
                }
            }
        }
        for (int i = 0; i < pile.Count; i++)
        {
            pile[i].GetComponent<MeshRenderer>().enabled = hideBack;
        }
        for (int i = 0; i < playPile.Count; i++)
        {
            playPile[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = hideBack;
        }
        hasDistributed = true;
        ActLogAdd("Deck was distributed. " + "<b>" + iniNum.ToString() + "</b>" + " cards to each player.");
        playersLeft = playHands.Count - checkedOut.Count;
        StartCoroutine(SetPlayCard());
        firstTimePassed = true;
        if (tender && realPlayers.Count == 0)
        {
            realPlayers.Add(0);
            sPBG[realPlayers[0]].GetComponent<MeshRenderer>().enabled = true;
            tStreakText[realPlayers[0]].text = TenderPointsTotal(realPlayers[0]).ToString();
            realPlayers.Clear();
        }
        CheckIfMoreOrLessThan6();
    }
    IEnumerator GeneralMarket(int sta, int myInd)
    {
        isGenMar = true;
        canPlay = false;
        for (int i = 0; i < 1; i++)
        {
            for (int u = sta; u < (playHands.Count - 1); u++)
            {
                int j = u + myInd + 1;
                if (j >= playHands.Count)
                {
                    j -= playHands.Count;
                }
                if (cardRules.reverse)
                {
                    j = myInd - u - 1;
                    if (j < 0)
                    {
                        j += playHands.Count;
                    }
                }
                if (pile.Count > 0)
                {
                    if (!checkedOut.Contains(j))
                    {
                        if (!IsPlayer(j))
                        {
                            if (totNum > 2)
                            {
                                if (playHands[j].Count > (cLim - 1))
                                {
                                    tarVec = playHands[j][playHands[j].Count - 1].transform.position + new Vector3(0.1f, 0f, 0.1f);
                                }
                                else
                                {
                                    tarVec = cardPos[j] + Vector3.right * playHands[j].Count * 0.5f;
                                }
                            }
                            else
                            {
                                tarVec = cardPos[j] + new Vector3(playHands[j].Count * 0.5f, 0, playHands[j].Count * 0.1f);
                            }

                        }
                        else
                        {
                            StopCoroutine("SlowScrDelta");
                            scrDelta = 0;
                            arrangeCards = true;
                            foreach (GameObject item in playHands[j])
                            {
                                item.transform.parent = null;
                            }
                            scrollObj.transform.position = new Vector3(0, 0, scrollObj.transform.position.z);
                            foreach (GameObject item in playHands[j])
                            {
                                item.transform.parent = scrollObj.transform;
                            }
                            if (playHands[j].Count == 0)
                            {
                                tarVec = cardPos[j];
                            }
                            else
                            {
                                tarVec = cardPos[playInd] + Vector3.right * pCaInterval;
                            }
                            //ca.AddComponent<BoxCollider>();
                        }
                        mVel = pile[0].transform.position;
                        sVel = pile[0].transform.localScale;
                        ca = pile[0];
                        if (IsPlayer(j))
                        {
                            ca.GetComponent<MeshRenderer>().enabled = true;
                        }
                        if (tender)
                            PileNumberLeft();
                        float tranT = 0;
                        while (tranT <= distSpeed)
                        {
                            tranT += Time.deltaTime;
                            ca.transform.position = Vector3.Lerp(mVel, tarVec, (tranT / distSpeed));
                            if (tarVec.y != cardPos[playInd].y)
                            {
                                ca.transform.localScale = Vector3.Lerp(sVel, aiScale, (tranT / distSpeed));
                            }
                            else
                            {
                                ca.transform.localScale = Vector3.Lerp(sVel, playScale, (tranT / distSpeed));
                            }
                            yield return null;
                        }
                        playHands[j].Add(ca);
                        pile.Remove(ca);
                        if (totNum != 2)
                        {
                            if (PlayerPos(j) == 0 && playHands[j].Count > 0)
                            {
                                FixPos(pointsPos[0], new Vector2(50, 75));
                                tStreakUI[j].transform.position = pointsPos[PlayerPos(j)].position;
                            }
                            else if (PlayerPos(j) == 4 && playHands[j].Count > 0)
                            {
                                FixPos(pointsPos[4], new Vector2(50, 36));
                                tStreakUI[j].transform.position = pointsPos[PlayerPos(j)].position;
                            }
                        }
                        for (int k = 0; k < pile.Count; k++)
                        {
                            pile[k].transform.position = pDpos.position + new Vector3((k * -0.003f), k * 0.01f, k * 0.01f);
                        }
                        if (IsPlayer(j))
                        {
                            playerCaPos = new List<Vector3>(new Vector3[playHands[playInd].Count]);
                            playerCaTar = new List<Vector3>(new Vector3[playHands[playInd].Count]);
                            for (int l = 0; l < playHands[playInd].Count; l++)
                            {
                                playerCaPos[l] = (playHands[playInd][l].transform.position);
                                playerCaTar[l] = cardPos[playInd] - Vector3.right * (((playHands[playInd].Count - ((2 * l) + 1)) * (pCaInterval / 2)));
                            }
                            StartCoroutine(ArrangePlayerCards());
                            if (tender) tStreakText[j].text = TenderPointsTotal(j).ToString();
                        }
                }
                    if (pile.Count==0 && tender && marketFlips == tenderFlips)
                    {
                        NowTender();
                        checkIfAiCanPlay = false;
                        checkIfCanPlay = false;
                        noMoreMarket = true;
                        break;
                    }
                    }
                    else
                    {
                        if (tender && marketFlips == tenderFlips)
                        {
                            NowTender();
                            checkIfAiCanPlay = false;
                            checkIfCanPlay = false;
                            noMoreMarket = true;
                        }
                        else
                        {
                            if (playPile.Count > 1)
                            {
                                lastHand = u;
                                lastInd = myInd;
                                StartCoroutine(FlipPlayPile());
                                didntFinishedGM = true;
                                break;
                            }
                            else
                            {
                                if (tender || comStreak)
                                {
                                    NowTender();
                                    noMoreMarket = true;
                                }
                            }
                        }
                        break;
                    }
                    lastInd = 0;
                    lastHand = 0;
            }
        }
        isGenMar = false;
        if (!didntFinishedGM && !noMoreMarket)
        //ActLogAdd("Everyone went to market.");
        canPlay = true;
        cardRules.gM = false;
        cardRules.gTMVal = 0;
        CheckIfMoreOrLessThan6();
    }
    public IEnumerator GoToMarket(int myInd, int howMany)
    {
        isGotMar = true;
        canPlay = false;
        if (checkedOut.Contains(myInd)) howMany = 0;
        if (lastTurn == myInd)
        {
            StartCoroutine("RemoveCombo");
            if (myPos == myInd)
            {
                combText.text = "0";
            }
            lastTurn = 9;
            repConti = false;
        }
        for (int i = 0; i < howMany; i++)
        {
            if (pile.Count > 0)
            {
                if (!IsPlayer(myInd))
                {
                    if (totNum > 2)
                    {
                        if (playHands[myInd].Count > (cLim - 1))
                        {
                            tarVec = playHands[myInd][playHands[myInd].Count - 1].transform.position + new Vector3(0.1f, 0f, 0.1f);
                        }
                        else
                        {
                            tarVec = cardPos[myInd] + Vector3.right * playHands[myInd].Count * 0.5f;
                        }
                    }
                    else
                    {
                        tarVec = cardPos[myInd] + new Vector3(playHands[myInd].Count * 0.5f, 0, playHands[myInd].Count * 0.1f);
                    }
                }
                else
                {
                    StopCoroutine("SlowScrDelta");
                    scrDelta = 0;
                    arrangeCards = true;
                    foreach (GameObject item in playHands[myInd])
                    {
                        item.transform.parent = null;
                    }
                    scrollObj.transform.position = new Vector3(0, 0, scrollObj.transform.position.z);
                    foreach (GameObject item in playHands[myInd])
                    {
                        item.transform.parent = scrollObj.transform;
                    }
                    if (playHands[myInd].Count == 0)
                    {
                        tarVec = cardPos[myInd];
                    }
                    else
                    {
                        tarVec = cardPos[playInd] + Vector3.right * pCaInterval;
                    }
                }
                mVel = pile[0].transform.position;
                sVel = pile[0].transform.localScale;
                ca = pile[0];
                if (IsPlayer(myInd))
                {
                    ca.GetComponent<MeshRenderer>().enabled = true;
                }
                if (tender)
                    PileNumberLeft();
                float tranT = 0;
                while (tranT <= distSpeed)
                {
                    tranT += Time.deltaTime;
                    ca.transform.position = Vector3.Lerp(mVel, tarVec, (tranT / distSpeed));
                    if (tarVec.y != cardPos[playInd].y)
                    {
                        ca.transform.localScale = Vector3.Lerp(sVel, aiScale, (tranT / distSpeed));
                    }
                    else
                    {
                        ca.transform.localScale = Vector3.Lerp(sVel, playScale, (tranT / distSpeed));
                    }
                    yield return null;
                }
                playHands[myInd].Add(ca);
                if (totNum != 2)
                {
                    if (PlayerPos(myInd) == 0 && playHands[myInd].Count > 0)
                    {
                        FixPos(pointsPos[0], new Vector2(50, 75));
                        tStreakUI[myInd].transform.position = pointsPos[PlayerPos(myInd)].position;
                    }
                    else if (PlayerPos(myInd) == 4 && playHands[myInd].Count > 0)
                    {
                        FixPos(pointsPos[4], new Vector2(50, 36));
                        tStreakUI[myInd].transform.position = pointsPos[PlayerPos(myInd)].position;
                    }
                }
                if (IsPlayer(myInd))
                {
                    ca.AddComponent<BoxCollider>();
                }
                pile.Remove(ca);
                for (int k = 0; k < pile.Count; k++)
                {
                    pile[k].transform.position = pDpos.position + new Vector3((k * -0.003f), k * 0.01f, k * 0.01f);
                }
                tranT = 0;
                if (pile.Count == 0 && tender && marketFlips == tenderFlips)
                {
                    NowTender();
                    checkIfAiCanPlay = false;
                    checkIfCanPlay = false;
                    noMoreMarket = true;
                    break;
                }
            }
            else
                {
                    if (tender && marketFlips == tenderFlips)
                    {
                        NowTender();
                        checkIfAiCanPlay = false;
                        checkIfCanPlay = false;
                        noMoreMarket = true;
                    }
                    else
                    {
                        if (playPile.Count > 1)
                        {
                            lastHand = howMany - i;
                            lastInd = myInd;
                            StartCoroutine(FlipPlayPile());
                            didntFinishedGToM = true;
                            break;
                        }
                        else
                        {
                            if (tender)
                            {
                                NowTender();
                                noMoreMarket = true;
                            }
                        }
                    }
                }
            if (IsPlayer(myInd))
            {
                playerCaPos = new List<Vector3>(new Vector3[playHands[playInd].Count]);
                playerCaTar = new List<Vector3>(new Vector3[playHands[playInd].Count]);
                for (int l = 0; l < playHands[playInd].Count; l++)
                {
                    playerCaPos[l] = (playHands[playInd][l].transform.position);
                    playerCaTar[l] = cardPos[playInd] - Vector3.right * (((playHands[playInd].Count - ((2 * l) + 1)) * (pCaInterval / 2)));
                }
                StartCoroutine(ArrangePlayerCards());
            }
            lastInd = 0;
            lastHand = 0;
        }
        if (IsPlayer(myInd))
        {
            for (int i = 0; i < playHands[myInd].Count; i++)
            {
                Transform dc = playHands[myInd][i].transform.Find("DarkCover(Clone)");
                if (dc)
                {
                    Destroy(dc.gameObject);
                }
            }
            if (tender) tStreakText[myInd].text = TenderPointsTotal(myInd).ToString();
        }
        isGotMar = false;
        hasGTM = true;
        cardRules.gTM = false;
        if (!didntFinishedGToM && !noMoreMarket)
        {
            if(cardRules.gTMVal>0){
                ActLogAdd(PlayerNameText(myInd,false) + " picked <b>" + (cardRules.gTMVal).ToString() + "</b>");
            }
            else
            {
                ActLogAdd(PlayerNameText(myInd,false) + " went to market.");
            }
            cardRules.gTMVal = 0;
            StartCoroutine(TakingTurns());
        }
        CheckIfMoreOrLessThan6();
    }
    void SetTestCards(List<List<string>> cards, string pp)
    {
        List<GameObject> wh = new List<GameObject>();
        for (int i = 0; i < cards.Count; i++)
        {
            for (int j = 0; j < cards[i].Count; j++)
            {
                for (int k = 0; k < pile.Count; k++)
                {
                    if (cardValues[allCards.IndexOf(pile[k])].ToString() + cardSuits[allCards.IndexOf(pile[k])] == cards[i][j] && !wh.Contains(pile[k]))
                    {
                        if (cards[i][j] == "20Whot")
                        {
                            wh.Add(pile[k]);
                        }
                        GameObject temp = pile[k];
                        Vector3 tPos = pile[k].transform.position;
                        pile[k].transform.position = pile[(j * cards.Count) + i].transform.position;
                        pile[k] = pile[(j * cards.Count) + i];
                        pile[(j * cards.Count) + i].transform.position = tPos;
                        pile[(j * cards.Count) + i] = temp;
                        break;
                    }
                }
            }
        }
        for (int k = 0; k < pile.Count; k++)
        {
            if (cardValues[allCards.IndexOf(pile[k])].ToString() + cardSuits[allCards.IndexOf(pile[k])] == pp)
            {
                GameObject temp = pile[k];
                Vector3 tPos = pile[k].transform.position;
                pile[k].transform.position = pile[cards[0].Count * cards.Count].transform.position;
                pile[k] = pile[cards[0].Count * cards.Count];
                pile[cards[0].Count * cards.Count].transform.position = tPos;
                pile[cards[0].Count * cards.Count] = temp;
            }
        }
    }
    bool hasAllWhot(List<string> car,int indd, string www)
    {
        int nu = 0;
        int nuPl = 0;
        bool hasTheWhot = false;
        bool yeah = false;
        for (int i = 0; i < car.Count; i++)
        {
            if (car[i] == "20Whot")
            {
                nu++;
            }
        }
        for (int i = 0; i < playHands[indd].Count; i++)
        {
            if (cardValues[allCards.IndexOf(playHands[indd][i])].ToString() + cardSuits[allCards.IndexOf(playHands[indd][i])] == "20Whot")
            {
                nuPl++;
            }
        }
        if (nuPl >= nu)
        {
            hasTheWhot = true;
        }
        if (hasTheWhot && www == "20Whot")
        {
            yeah = true;
        }
        return yeah;
    }
    IEnumerator SetPlayCard()
    {
        ca = pile[0];
        ca.GetComponent<MeshRenderer>().enabled = true;
        mVel = pile[0].transform.position;
        if (tender)
            PileNumberLeft();
        float tranT = 0;
        while (tranT <= 0.5f)
        {
            tranT += Time.deltaTime;
            ca.transform.position = Vector3.Lerp(mVel, pUpos.position, (tranT / 0.5f));
            ca.transform.eulerAngles = Vector3.up * Mathf.Lerp(180, 0, (tranT / 0.5f));
            for (int i = 0; i < playHands[playInd].Count; i++)
            {
                playHands[playInd][i].transform.eulerAngles = Vector3.up * Mathf.Lerp(180, 0, (tranT / 0.5f));
                playHands[playInd][i].transform.parent = scrollObj.transform;
            }
            yield return null;
        }
        playPile.Add(ca);
        pile.Remove(ca);
        ca.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = hideBack;
        string setSuit=cardSuits[allCards.IndexOf(ca)];
        int setVal=cardValues[allCards.IndexOf(ca)];
        ActLogAdd(BoWine(new List<int> { setVal }, new List<string> { setSuit }) + " was set as first play card");
        for (int i = 0; i < playHands[playInd].Count; i++)
        {
            if (!playHands[playInd][i].GetComponent<BoxCollider>())
                playHands[playInd][i].AddComponent<BoxCollider>();
        }
        turn = cardValues[allCards.IndexOf(playPile[playPile.Count - 1])] != 12 ? -1 : 0;
        curCardInd = allCards.IndexOf(playPile[playPile.Count - 1]);
        if (cardValues[allCards.IndexOf(playPile[playPile.Count - 1])] == 20)
        {
            if (turn < 0)
            {
                turn = 0;
            }
            if (realPlayers.Contains(turn))
            {
                suitC.SetActive(true);
                suitC.transform.position = Vector3.forward * -1.3f;
            }
            else
            {
                StartCoroutine(AIChangeSuit());
            }
        }
        else
        {
            //StartCoroutine(GoToMarket(0, 15));
            StartCoroutine(TakingTurns());
        }
        canPlay = true;
    }
    public IEnumerator PlayCard(int myInd, List<int> cards)
    {
        canPlay = false;
        isPlaying = true;
        hasGTM = false;
        if (myInd != lastTurn)
        {
            streak = 0;
            combo = 1;
            if (myPos !=9 && myPos != myInd)
            {
                combText.text = "0";
            }
            lastTurn = myInd;
        }
        List<int> vals = new List<int>();
        List<string> suits = new List<string>();
        for (int i = 0; i < cards.Count; i++)
        {
            vals.Add(cardValues[allCards.IndexOf(playHands[myInd][cards[i]])]);
            suits.Add(cardSuits[allCards.IndexOf(playHands[myInd][cards[i]])]);
        }
        if (IsPlayer(myInd))
        {
            for (int i = 0; i < playHands[myInd].Count; i++)
            {
                Transform dc = playHands[myInd][i].transform.Find("DarkCover(Clone)");
                if (dc)
                {
                    Destroy(dc.gameObject);
                }
            }
            StopCoroutine("SlowScrDelta");
            scrDelta = 0;
        }
        List<GameObject> pH = new List<GameObject>();
        for (int i = 0; i < cards.Count; i++)
        {
            if (playHands[myInd].Count > 0 && cards[i]<playHands[myInd].Count)
            {
                tarVec = playPile[playPile.Count - 1].transform.position + new Vector3(0.003f, 0.01f, -0.01f);
                ca = playHands[myInd][cards[i]];
                if (!IsPlayer(myInd))
                {
                    ca.GetComponent<MeshRenderer>().enabled = true;
                }
                mVel = ca.transform.position;
                sVel = ca.transform.localScale;
                if (IsPlayer(myInd))
                {
                    ca.transform.parent = null;
                    if (ca.GetComponent<BoxCollider>())
                        Destroy(ca.GetComponent<BoxCollider>());
                }
                streak++;
                streakPoints[myInd] += streak == 1 ? 1 : 0;
                if (myPos == myInd && streak==1)
                {
                    totalSP += 1;
                    dataScript.totalSP = totalSP;
                    tspText.text = totalSP.ToString();
                    spText.text = streakPoints[myPos].ToString();
                    combText.text = "1";
                }
                if (comStreak)
                {
                    if (streakPoints[myInd] == 1) sPBG[myInd].GetComponent<MeshRenderer>().enabled = true;
                    tStreakText[myInd].text = streakPoints[myInd].ToString();
                }
                if (streak > 1)
                {
                    combo *= 2;
                    combo = combo > 64 ? 64 : combo;
                    streakPoints[myInd] += combo;
                    if (myPos==myInd)
                    {
                        totalSP += combo;
                        dataScript.totalSP = totalSP;
                        tspText.text = totalSP.ToString();
                        spText.text = streakPoints[myPos].ToString();
                        combText.text = combo.ToString();
                    }
                    if (comStreak)
                    {
                        StopCoroutine("RemoveCombo");
                        StartCoroutine(ShowCombo(myInd));
                        tStreakText[myInd].text = streakPoints[myInd].ToString();
                    }
                }
                else
                {
                    if(comStreak)
                    StartCoroutine("RemoveCombo");
                }
                float tranT = 0;
                while (tranT <= playSpeed)
                {
                    tranT += Time.deltaTime;
                    ca.transform.position = Vector3.Lerp(mVel, tarVec, (tranT / playSpeed));
                    if (!playHands[playInd].Contains(ca))
                    {
                        ca.transform.localScale = Vector3.Lerp(sVel, pileScale, (tranT / playSpeed));
                        ca.transform.eulerAngles = Vector3.up * Mathf.Lerp(180, 0, (tranT / playSpeed));
                    }
                    else
                    {
                        ca.transform.localScale = Vector3.Lerp(sVel, pileScale, (tranT / playSpeed));
                    }
                    yield return null;
                }
                playPile.Add(ca);
                playHands[myInd].Remove(ca);
                //Debug.Log(playHands[myInd].Count - i);
                if (totNum != 2)
                {
                    if (PlayerPos(myInd) == 0 && playHands[myInd].Count - i == 0)
                    {
                        FixPos(pointsPos[0], new Vector2(50, 83));
                        tStreakUI[myInd].transform.position = pointsPos[PlayerPos(myInd)].position;
                    }
                    else if (PlayerPos(myInd) == 4 && playHands[myInd].Count - i == 0)
                    {
                        FixPos(pointsPos[4], new Vector2(50, 17));
                        tStreakUI[myInd].transform.position = pointsPos[PlayerPos(myInd)].position;
                    }
                }
                pH.Add(new GameObject("PlaceHolder"));
                playHands[myInd].Insert(cards[i], pH[i]);
                if (IsPlayer(myInd))
                {
                    foreach (GameObject item in playHands[myInd])
                    {
                        item.transform.parent = null;
                    }
                    scrollObj.transform.position = new Vector3(0, 0, scrollObj.transform.position.z);
                    foreach (GameObject item in playHands[myInd])
                    {
                        item.transform.parent = scrollObj.transform;
                    }
                }
                for (int j = 0; j < playPile.Count; j++)
                {
                    playPile[j].transform.position = pUpos.position + new Vector3((j * 0.003f), j * 0.01f, ((playPile.Count - 1 - j) * 0.01f));
                }
            }
            }
        for (int i = 0; i < playPile.Count; i++)
        {
              playPile[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = hideBack;
        }
        for (int u = 0; u < pH.Count; u++)
        {
            playHands[myInd].Remove(pH[u]);
            Destroy(pH[u]);
        }
        int lastPlayed = cardValues[allCards.IndexOf(playPile[playPile.Count - 1])];
        CheckSpecialCardUI(lastPlayed, myInd);
        if (!IsPlayer(myInd))
        {
            for (int k = 0; k < playHands[myInd].Count; k++)
            {
                if (totNum > 2)
                {
                    if (k > (cLim - 1))
                    {
                        playHands[myInd][k].transform.position = playHands[myInd][k - 1].transform.position + new Vector3(0.1f, 0f, 0.1f);
                    }
                    else
                    {
                        playHands[myInd][k].transform.position = cardPos[myInd] + Vector3.right * k * 0.5f;
                    }
                }
                else
                {
                    playHands[myInd][k].transform.position = cardPos[myInd] + new Vector3(k * 0.5f, 0, k * 0.1f);
                }
            }
        }
        if (IsPlayer(myInd))
            {
                playerCaPos = new List<Vector3>(new Vector3[playHands[playInd].Count]);
                playerCaTar = new List<Vector3>(new Vector3[playHands[playInd].Count]);
                for (int i = 0; i < playHands[playInd].Count; i++)
                {
                    playerCaPos[i] = (playHands[playInd][i].transform.position);
                    playerCaTar[i] = cardPos[playInd] - Vector3.right * (((playHands[playInd].Count - ((2 * i) + 1)) * (pCaInterval / 2)));
                }
                StartCoroutine(ArrangePlayerCards());
                if (tender) tStreakText[myInd].text = TenderPointsTotal(myInd).ToString();
            }
            ActLogAdd(PlayerNameText(myInd,false) + " played " + BoWine(vals, suits));
            if (cardValues[allCards.IndexOf(playPile[playPile.Count - (cards.Count+1)])] == 20)
            {
                playPile[playPile.Count - (cards.Count + 1)].GetComponent<MeshRenderer>().material.mainTexture = who;
                cardSuits[allCards.IndexOf(playPile[playPile.Count - (cards.Count + 1)])] = "Whot";
            }
            RemovePlayer(myInd);
            if (cardValues[allCards.IndexOf(playPile[playPile.Count - 1])] == 20)
            {
                if (realPlayers.Contains(myInd))
                {
                    suitC.SetActive(true);
                    suitC.transform.position = Vector3.forward * -3;
                }
                else
                {
                    StartCoroutine(AIChangeSuit());
                }
            }
            else
            {
                if(!playerChecked)
                StartCoroutine(TakingTurns());
            }
            CheckIfMoreOrLessThan6();
            isPlaying = false;
    }
    IEnumerator ArrangePlayerCards()
    {
        arrangeCards = true;
        float pTranT = 0;
        while (pTranT <= pCaSpeed)
        {
            pTranT += Time.deltaTime;
            for (int i = 0; i < playHands[playInd].Count; i++)
            {
                Vector3 fro = playerCaPos[i];
                Vector3 to = playerCaTar[i];
                playHands[playInd][i].transform.position = Vector3.Lerp(fro, to, (pTranT / pCaSpeed));
                if (hasDistributed)
                {
                    if (playHands[playInd][i].transform.eulerAngles.y > 0)
                    {
                        playHands[playInd][i].transform.eulerAngles = Vector3.up * Mathf.Lerp(180, 0, (pTranT / pCaSpeed));
                    }
                }
            }
            yield return null;
        }
        for (int i = 0; i < playHands[playInd].Count; i++)
        {
            playHands[playInd][i].transform.parent = scrollObj.transform;
            if(hasDistributed)
            playHands[playInd][i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = hideBack;
        }
        arrangeCards = false;
    }
    public bool IsPlayer(int myInd)
    {
        if (totNum>2 && pics[myInd].transform.position == pos[4].transform.position)
        {
            playInd = myInd;
            return true;
        }
        else if (totNum == 2 && pics[myInd].transform.position.x>0)
        {
            playInd = myInd;
            return true;
        }else
        {
            return false;
        }
    }
    IEnumerator FlipPlayPile()
    {
        foreach (GameObject item in playPile)
        {
            item.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        }
        marketFlips++;
        if (playPile.Count == 1)
        {
            NowTender();
            checkIfAiCanPlay = false;
            checkIfCanPlay = false;
            yield return null;
        }
        pPileParent = new GameObject("Par");
        pPileParent.transform.position = playPile[(int)((playPile.Count - 1) / 2)].transform.position;
        for (int i = 0; i < (playPile.Count - 1); i++)
        {
            playPile[i].transform.parent = pPileParent.transform;
        }
        pPileParentPos = pPileParent.transform.position;
        float pileTranT=0;
        while (pileTranT <= pFlipSpeed)
        {
            pileTranT += Time.deltaTime;
            Vector3 tar = new Vector3(pDpos.position.x, pPileParent.transform.position.y, pDpos.position.z);
            pPileParent.transform.position = Vector3.Lerp(pPileParentPos, tar, (pileTranT / pFlipSpeed));
            pPileParent.transform.eulerAngles = Vector3.up * Mathf.Lerp(0, 180, (pileTranT / pFlipSpeed));
            yield return null;
        }
        List<GameObject> tP = new List<GameObject>(new GameObject[playPile.Count]);
        for (int i = 0; i < playPile.Count - 1; i++)
        {
            playPile[i].transform.parent = null;
            pile.Add(playPile[i]);
            tP.Add(playPile[i]);
        }
        Destroy(pPileParent);
        for (int i = 0; i < tP.Count; i++)
        {
            playPile.Remove(tP[i]);
        }
        foreach (GameObject item in pile)
        {
            item.GetComponent<MeshRenderer>().enabled = hideBack;
        }
        if (tender)
        {
            switch (marketFlips)
            {
                case 1: stockNu.text = "1st";
                    break;
                case 2: stockNu.text = "2nd";
                    break;
                case 3: stockNu.text = "3rd";
                    break;
                default: stockNu.text = marketFlips.ToString() + "th";
                    break;
            }
            PileNumberLeft();
        }
        Shuffle();
        if (didntFinishedGM)
        {
            StartCoroutine(GeneralMarket(lastHand, lastInd));
            didntFinishedGM = false;
        }
        if (didntFinishedGToM)
        {
            StartCoroutine(GoToMarket(turn, lastHand));
            didntFinishedGToM = false;
        }
    }
    void SetBackGround()
    {
        GameObject backG = GameObject.CreatePrimitive(PrimitiveType.Quad);
        backG.name = "BackGround";
        backG.transform.position = Vector3.forward * 20;
        backG.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), (camSize * 2), 1);
        Texture2D[] backs = Resources.LoadAll<Texture2D>("BackGrounds");
        backG.GetComponent<MeshRenderer>().material.shader = Shader.Find("Unlit/Texture");
        backG.GetComponent<MeshRenderer>().material.mainTexture = backs[0];
        backG.GetComponent<MeshRenderer>().material.mainTexture = backs[Random.Range(0, backs.Length)];
    }
    void ShuffleIcons(ref Texture2D[] icons)
    {
        List<Texture2D> newIcons = new List<Texture2D>(icons);
        for (int i = 0; i < icons.Length; i++)
        {
            int n = Random.Range(0, newIcons.Count);
            icons[i] = newIcons[n];
            newIcons.Remove(newIcons[n]);
        }
    }
    void InstantiatePlayers()
    {
        if (totNum > 2)
        {
            Texture2D[] porIcons = Resources.LoadAll<Texture2D>("NarutoPortraits");
            if (porIcons[0].name != "por0")
            {
                ShuffleIcons(ref porIcons);
            }
            for (int i = 0; i < totNum; i++)
            {
                pics.Add((GameObject)Instantiate(Resources.Load("Portrait")));
                pics[i].name = "pic" + i.ToString();
                pics[i].GetComponent<MeshRenderer>().material.mainTexture = porIcons[i];
                if (i == myPos && dataMan) pics[i].GetComponent<MeshRenderer>().material.mainTexture = playerProfPic;
                nameTextPos = pics[i].transform.FindChild("NameText").transform.localPosition;
                nameBGPos = pics[i].transform.FindChild("NameBG").transform.localPosition;
                if (!realPlayers.Contains(i))
                {
                    pics[i].transform.FindChild("NameText").GetComponent<TextMesh>().text = PlayerName();
                }
                else
                {
                    pics[i].transform.FindChild("NameText").GetComponent<TextMesh>().text = RealPlayerName();
                    if (i == myPos) pics[i].transform.FindChild("NameText").GetComponent<TextMesh>().text = playerUserName;
                    pics[i].transform.FindChild("NameText").GetComponent<TextMesh>().color = new Color(1, 1, 0);
                }
            }
            normFrame = (Texture2D)pics[0].transform.FindChild("PortraitFrame").GetComponent<MeshRenderer>().material.mainTexture;
            normBG = (Texture2D)pics[0].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture;
            if (realPlayers.Count == 0)
            {
                justAI = true;
                realPlayers.Add(0);
            }
            PlacePlayers(realPlayers[0], totNum);
        }
        else
        {
            pics = new List<GameObject>(new GameObject[2]);
            if (realPlayers.Count == 0)
            {
                justAI = true;
                realPlayers.Add(0);
            }
            PlaceTwoPlayers(realPlayers[0]);
        }
        FixFrames();
    }
    void PlacePlayers(int realPos, int tot)
    {
        int u = 0;
        int x = 0;
        x = presentSeats[tot].IndexOf("4") - realPos;
        if (x < 0)
        {
            x = presentSeats[tot].Length + x;
        }
        u = int.Parse(presentSeats[tot][x].ToString());
        int n = 0;
        int p = 0;
        bool hasCombed = false;
        List<string> alCh = new List<string>();
        List<int> rr = new List<int>();
        for (int i = 0; i < pos.Count; i++)
        {
            n = i + u;
            if (n >= pos.Count)
            {
                n -= pos.Count;
            }
            if (!absentSeats[tot].Contains(n.ToString()))
            {
                string co = IsComboWithYou(i - p);
                string ra = IsRankWithYou(i - p);
                if (!hasCombed)
                {
                    if (co[0].ToString() == "1")
                    {
                        comboUIs[int.Parse(co[1].ToString())].transform.position = comPos[n].position;
                        hasCombed = true;
                    }
                }
                if (ra[0].ToString() == "1")
                {
                    alCh.Add(ra[1].ToString());
                    rr.Add(n);
                }
                if (firstTimePassed)
                {
                    /*if (n == 0)
                    {
                        if (playHands[i - p].Count == 0)
                            FixPos(pointsPos[0], new Vector2(50, 83));
                        else
                            FixPos(pointsPos[0], new Vector2(50, 75));
                    }
                    else if (n == 4)
                    {
                        if (playHands[i - p].Count == 0)
                            FixPos(pointsPos[4], new Vector2(50, 17));
                        else
                            FixPos(pointsPos[4], new Vector2(50, 36));
                    }*/
                    tStreakUI[i - p].transform.position = pointsPos[n].position;
                    if (tender)
                    {
                        sPBG[i - p].GetComponent<MeshRenderer>().enabled = n == 4 ? true : false;
                        tStreakText[i - p].text = n == 4 ? TenderPointsTotal(i - p).ToString() : "";
                    }
                    //sPBG[i - p].transform.position = pointsPos[n].position;
                }
                pics[i-p].transform.position = pos[n].position;
            }
            else
            {
                p++;
            }
        }
        for (int i = 0; i < rr.Count; i++)
        {
            rankUIs[int.Parse(alCh[i])].transform.position = rankPos[rr[i]].position;
        }
        hasCombed = false;
        cardPos.Clear();
        for (int i = 0; i < pics.Count; i++)
        {
            if (!IsPlayer(i))
            {
                cardPos.Add(pics[i].transform.position - new Vector3(0.7f, 1f));
                pics[i].transform.FindChild("NameText").transform.localPosition = nameTextPos;
                pics[i].transform.FindChild("NameBG").transform.localPosition = nameBGPos;
                if (i != turn)
                    pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = normBG;
                else
                {
                    pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = turnBG;
                }
            }
            else
            {
                cardPos.Add(pics[i].transform.position + new Vector3(0f, 1.6f, 1));
                pics[i].transform.FindChild("NameText").transform.localPosition = nameTextPos - Vector3.up * nameTextPos.y * 2;
                pics[i].transform.FindChild("NameBG").transform.localPosition = nameBGPos - Vector3.up * nameBGPos.y * 2;
                if (i != turn)
                    pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = normDownBG;
                else
                {
                    pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = turnDownBG;
                }
            }
        }
        if (hasDistributed)
        {
            for (int i = 0; i < playHands.Count; i++)
            {
                if (!IsPlayer(i))
                {
                    for (int j = 0; j < playHands[i].Count; j++)
                    {
                        if (j > (cLim - 1))
                        {
                            playHands[i][j].transform.position = playHands[i][j - 1].transform.position + new Vector3(0.1f, 0f, 0.1f);
                        }
                        else
                        {
                            playHands[i][j].transform.position = cardPos[i] + Vector3.right * (j * 0.5f);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < playHands[i].Count; j++)
                    {
                         playHands[i][j].transform.position = cardPos[i] - Vector3.right * (((playHands[i].Count - ((2 * j) + 1)) * (pCaInterval / 2)));
                    }
                }
            }
            scrollObj.transform.DetachChildren();
            if (lastRealPlayer != realPos)
            {
                scrollObj.transform.position = new Vector3(0, scrollObj.transform.position.y, scrollObj.transform.position.z);
            }
            Vector3 lastScrPos = scrollObj.transform.position;
            scrollObj.transform.position = new Vector3(0, scrollObj.transform.position.y, scrollObj.transform.position.z);
            for (int i = 0; i < playHands.Count; i++)
            {

                if (!IsPlayer(i))
                {
                    for (int j = 0; j < playHands[i].Count; j++)
                    {
                        playHands[i][j].transform.parent = null;
                        playHands[i][j].transform.localScale = aiScale;
                        playHands[i][j].transform.eulerAngles = Vector3.up * 180;
                        if (playHands[i][j].GetComponent<BoxCollider>())
                            Destroy(playHands[i][j].GetComponent<BoxCollider>());
                        playHands[i][j].GetComponent<MeshRenderer>().enabled = hideBack;
                        playHands[i][j].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                else
                {
                    for (int j = 0; j < playHands[i].Count; j++)
                    {
                        playHands[i][j].transform.localScale = playScale;
                        playHands[i][j].transform.eulerAngles = Vector3.up * 0;
                        playHands[i][j].transform.parent = scrollObj.transform;
                        if (!playHands[i][j].GetComponent<BoxCollider>())
                            playHands[i][j].AddComponent<BoxCollider>();
                        playHands[i][j].GetComponent<MeshRenderer>().enabled = true;
                        playHands[i][j].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = hideBack;
                    }
                }
            }
            scrollObj.transform.position = lastScrPos;
            CheckIfMoreOrLessThan6();
        }
        if (justAI)
        {
            realPlayers.Clear();
        }
    }
    void PlaceTwoPlayers(int realPos)
    {
        if (!hasPlaced2)
        {
            pics[0] = (GameObject)Instantiate(Resources.Load("TwoP0"));
            pics[1] = (GameObject)Instantiate(Resources.Load("TwoP1"));
            FixPos(pos[0].transform, new Vector2(100, 0));
            FixPos(pos[1].transform, new Vector2(0, 100));
            pics[0].transform.position = pos[0].transform.position;
            pics[1].transform.position = pos[1].transform.position;
            pics[0].transform.position = new Vector3(pics[0].transform.position.x, pics[0].transform.position.y, -3);
            pics[1].transform.position = new Vector3(pics[1].transform.position.x, pics[1].transform.position.y, -3);
            pic2Center = new Vector3[totNum];
            pic2Center[0] = new Vector3((pics[0].transform.position.x - pics[0].transform.localScale.x), (pics[0].transform.position.y + pics[0].transform.localScale.y), pics[0].transform.position.z);
            pic2Center[1] = new Vector3((pics[1].transform.position.x + pics[1].transform.localScale.x), (pics[1].transform.position.y - pics[1].transform.localScale.y), pics[1].transform.position.z);
            Texture2D[] porIcons = Resources.LoadAll<Texture2D>("NarutoPortraits");
            ShuffleIcons(ref porIcons);
            por0 = porIcons[0];
            por1 = porIcons[1];
            if (dataMan)
            {
                if(myPos==0)
                    por0 = playerProfPic;
                else if(myPos == 1)
                    por1 = playerProfPic;
            }
            pics[0].GetComponent<MeshRenderer>().material.mainTexture = por0;
            pics[1].GetComponent<MeshRenderer>().material.mainTexture = por1;
            hasPlaced2 = true;
            FixPos(playArrs[0].transform, new Vector2(2, 18));
            FixPos(playArrs[1].transform, new Vector2(68, 18));
            FixPos(comPos[0], new Vector2(96.5f, 45.5f));
            FixPos(comPos[1], new Vector2(19.5f, 55));
            FixPos(rankPos[0], new Vector2(95, 40));//
            FixPos(rankPos[1], new Vector2(18.5f, 61));//
            FixPos(pointsPos[0].transform, new Vector2(36, 5));
            FixPos(pointsPos[1].transform, new Vector2(42, 96));
            playArrsPos[0] = playArrs[0].transform.position;
            playArrsPos[1] = playArrs[1].transform.position;
            backScroll = GameObject.Find("BackScroll");
            backScroll.transform.position = new Vector3(0, twoPos[0].transform.position.y, 1.5f);
            backScroll.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), 2, 1);
            backScroll.GetComponent<MeshRenderer>().enabled = false;
            Debug.Log(realPlayers.Count);
            pics[1].transform.FindChild("NameText").GetComponent<TextMesh>().text = !realPlayers.Contains(1) ? PlayerName() : RealPlayerName();
            pics[0].transform.FindChild("NameText").GetComponent<TextMesh>().text = !realPlayers.Contains(0) ? PlayerName() : RealPlayerName();
            if (/*dataMan && */myPos != 9) pics[myPos].transform.FindChild("NameText").GetComponent<TextMesh>().text = playerUserName;
            pics[0].transform.FindChild("NameText").GetComponent<TextMesh>().color = !realPlayers.Contains(0) ? Color.white : new Color(1, 1, 0);
            pics[1].transform.FindChild("NameText").GetComponent<TextMesh>().color = !realPlayers.Contains(1) ? Color.white : new Color(1, 1, 0);
            if (justAI)
            {
                pics[1].transform.FindChild("NameText").GetComponent<TextMesh>().text = PlayerName();
                pics[0].transform.FindChild("NameText").GetComponent<TextMesh>().text = PlayerName();
                pics[0].transform.FindChild("NameText").GetComponent<TextMesh>().color = Color.white;
                pics[1].transform.FindChild("NameText").GetComponent<TextMesh>().color = Color.white;
            }
            normFrame = (Texture2D)pics[0].transform.FindChild("PortraitFrame").GetComponent<MeshRenderer>().material.mainTexture;
            normBG = (Texture2D)pics[0].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture;
            aiScale = playScale;
            scrLim = 7;
            if (scrMask)
            {
                Destroy(scrMask);
                Destroy(leftBlock);
                Destroy(rightBlock);
            }
            if (realPlayers.Count == 2)
            {
                pics[0].transform.FindChild("PortraitFrame").GetComponent<MeshRenderer>().material.mainTexture = turnFrame;
                pics[0].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = turnDownBG;
                pics[0].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = turnBG;
            }
            tStreakUI = new GameObject[2];
            tStreakText = new TextMesh[2];
        }
        if (realPos != twPlSwitch)
        {
            GameObject temp = null;
            temp = pics[0];
            pics[0] = pics[1];
            pics[1] = temp;
            pics[1].GetComponent<MeshRenderer>().material.mainTexture = por1;
            pics[0].GetComponent<MeshRenderer>().material.mainTexture = por0;
            string name0 = pics[0].transform.FindChild("NameText").GetComponent<TextMesh>().text;
            pics[0].transform.FindChild("NameText").GetComponent<TextMesh>().text = pics[1].transform.FindChild("NameText").GetComponent<TextMesh>().text;
            pics[1].transform.FindChild("NameText").GetComponent<TextMesh>().text = name0;
            for (int i = 0; i < pics.Count; i++)
            {
                string co = IsComboWithYou(i);
                if (co[0].ToString() == "1")
                {
                    int u = i == 0 ? 1 : 0;
                    comboUIs[int.Parse(co[1].ToString())].transform.position = comPos[PlayerPos(u)].position;
                    break;
                }
            }
            //Debug.Log(tStreakUI.Length);
            if (firstTimePassed)
            {
                Vector3 tempV = tStreakUI[0].transform.position;
                tStreakUI[0].transform.position = tStreakUI[1].transform.position;
                tStreakUI[1].transform.position = tempV;
            }
            if (tender)
            {
                int b = turn == 0 ? 1 : 0;
                sPBG[turn].GetComponent<MeshRenderer>().enabled = true;
                tStreakText[turn].text = TenderPointsTotal(turn).ToString();
                sPBG[b].GetComponent<MeshRenderer>().enabled = false;
                tStreakText[b].text = "";
            }
            twPlSwitch = realPos;
        }
        cardPos.Clear();
        for (int i = 0; i < pics.Count; i++)
        {
            if (IsPlayer(i))
            {
                cardPos.Add(new Vector3(twoPos[0].transform.position.x, twoPos[0].transform.position.y, pics[i].transform.position.z + 1));
            }
            else
            {
                cardPos.Add(new Vector3(twoPos[1].transform.position.x, twoPos[1].transform.position.y, pics[i].transform.position.z + 1));
            }
        }
        if (hasDistributed)
        {
            for (int i = 0; i < playHands.Count; i++)
            {
                if (!IsPlayer(i))
                {
                    for (int j = 0; j < playHands[i].Count; j++)
                    {
                        playHands[i][j].transform.position = cardPos[i] + new Vector3(j * 0.5f, 0, j * 0.1f);
                    }
                }
                else
                {
                    for (int j = 0; j < playHands[i].Count; j++)
                    {
                        playHands[i][j].transform.position = cardPos[i] - Vector3.right * (((playHands[i].Count - ((2 * j) + 1)) * (pCaInterval / 2)));
                    }
                }
            }
            scrollObj.transform.DetachChildren();
            if (lastRealPlayer != realPos)
            {
                scrollObj.transform.position = new Vector3(0, scrollObj.transform.position.y, scrollObj.transform.position.z);
            }
            Vector3 lastScrPos = scrollObj.transform.position;
            scrollObj.transform.position = new Vector3(0, scrollObj.transform.position.y, scrollObj.transform.position.z);
            for (int i = 0; i < playHands.Count; i++)
            {

                if (!IsPlayer(i))
                {
                    for (int j = 0; j < playHands[i].Count; j++)
                    {
                        playHands[i][j].transform.parent = null;
                        playHands[i][j].transform.localScale = playScale;
                        playHands[i][j].transform.eulerAngles = Vector3.up * 180;
                        if (playHands[i][j].GetComponent<BoxCollider>())
                            Destroy(playHands[i][j].GetComponent<BoxCollider>());
                        playHands[i][j].GetComponent<MeshRenderer>().enabled = hideBack;
                        playHands[i][j].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                else
                {
                    scrollObj.transform.position = new Vector3(0, scrollObj.transform.position.y, scrollObj.transform.position.z);
                    for (int j = 0; j < playHands[i].Count; j++)
                    {
                        playHands[i][j].transform.localScale = playScale;
                        playHands[i][j].transform.eulerAngles = Vector3.up * 0;
                        playHands[i][j].transform.parent = scrollObj.transform;
                        if (!playHands[i][j].GetComponent<BoxCollider>())
                            playHands[i][j].AddComponent<BoxCollider>();
                        playHands[i][j].GetComponent<MeshRenderer>().enabled = true;
                        playHands[i][j].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = hideBack;
                    }
                }
            }
            scrollObj.transform.position = lastScrPos;
            CheckIfMoreOrLessThan6();
        }
        if (justAI)
            realPlayers.Clear();
    }
    string PlayerName()
    {
        string na = names[Random.Range(0, names.Count)];
        names.Remove(na);
        return na;
    }
    string RealPlayerName()
    {
        string na = realNames[Random.Range(0, realNames.Count)];
        realNames.Remove(na);
        return na;
    }
    
    void CheckIfMoreOrLessThan6()
    {
        if (playHands[playInd].Count >= scrLim+1)
        {
            foreach (GameObject item in playArrs)
            {
                item.GetComponent<MeshRenderer>().enabled = true;
            }
            hasMoreThan5 = true;
        }
        else
        {
            foreach (GameObject item in playArrs)
            {
                item.GetComponent<MeshRenderer>().enabled = false;
            }
            hasMoreThan5 = false;
        }
    }
    void ScrollArrows()
    {
        for (int i = 0; i < playArrs.Length; i++)
        {
            if (!reachedLeft)
            {
                if (i == 0)
                {
                    playArrs[i].transform.position -= Vector3.right * 0.005f;
                }
                else
                {
                    playArrs[i].transform.position += Vector3.right * 0.005f;
                }
            }
            else if (reachedLeft)
            {
                if (i == 0)
                {
                    playArrs[i].transform.position += Vector3.right * 0.005f;
                }
                else
                {
                    playArrs[i].transform.position -= Vector3.right * 0.005f;
                }
            }
        }
    }
    IEnumerator TakingTurns()
    {
        curCardInd = allCards.IndexOf(playPile[playPile.Count - 1]);
        WhatsTurn();
        if (turn < 0)
        {
            turn = 0;
        }
        FixFrames();
        if (realPlayers.Contains(turn))
        {
            //if (Time.timeScale != 1) FastForward(ffNames[2]);
            GreyOutCards();
            yield return new WaitForSeconds(0.3f);
            if ((!cardRules.repTurnCards.Contains(cardValues[allCards.IndexOf(playPile[playPile.Count - 1])]) || hasGTM))
            {
                if (totNum > 2)
                    PlacePlayers(turn, totNum);
                else
                    PlaceTwoPlayers(turn);
                //if (realPlayers.Count > 1)
                    CoverCards(turn);
            }
            checkIfCanPlay = true;
        }
        else
        {
                yield return new WaitForSeconds(1f);
                checkIfAiCanPlay = true;
        }
    }
    string IsComboWithYou(int ind)
    {
        string yes = "0";
        for (int i = 0; i < comboUIs.Length; i++)
        {
            if (comboUIs[i].transform.position == comPos[PlayerPos(ind)].position)
            {
                yes = "1";
                yes += i.ToString();
                break;
            }
        }
        return yes;
    }
    string IsRankWithYou(int ind)
    {
        string yes = "0";
        for (int i = 0; i < rankUIs.Count; i++)
        {
            if ((Vector2)rankUIs[i].transform.position == (Vector2)rankPos[PlayerPos(ind)].position)
            {
                yes = "1";
                yes += i.ToString();
                break;
            }
        }
        return yes;
    }
    void AIPlay(int inD)
    {
        if (cardRules.canBePlayed.Count>0)
        {
            aiScript.AIPlay(inD);
        }
        else
        {
            if(!gTM)
            StartCoroutine(GoToMarket(inD, 1));
            else
            {
                StartCoroutine(GoToMarket(inD, gTMVal));
            }
        }
    }
    void FixFrames()
    {
        for (int i = 0; i < pics.Count; i++)
        {
            if (totNum > 2)
            {
                if (i == turn)
                {
                    pics[i].transform.FindChild("PortraitFrame").GetComponent<MeshRenderer>().material.mainTexture = turnFrame;
                    if (!IsPlayer(i))
                        pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = turnBG;
                    else
                        pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = turnDownBG;
                }
                else
                {
                    pics[i].transform.FindChild("PortraitFrame").GetComponent<MeshRenderer>().material.mainTexture = normFrame;
                    if (!IsPlayer(i))
                        pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = normBG;
                    else
                        pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = normDownBG;
                }
            }
            else
            {
                if (realPlayers.Count != 2)
                {
                    if (i == turn)
                    {
                        pics[i].transform.FindChild("PortraitFrame").GetComponent<MeshRenderer>().material.mainTexture = turnFrame;
                        if (!IsPlayer(i))
                            pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = turnDownBG;
                        else
                            pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = turnBG;
                    }
                    else
                    {
                        pics[i].transform.FindChild("PortraitFrame").GetComponent<MeshRenderer>().material.mainTexture = normFrame;
                        if (!IsPlayer(i))
                            pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = normDownBG;
                        else
                            pics[i].transform.FindChild("NameBG").GetComponent<MeshRenderer>().material.mainTexture = normBG;
                    }
                }
            }
        }
    }
    void WhatsTurn()
    {
        cardRules.CheckPlay();
        gTM = cardRules.gTM;
        gTMVal = cardRules.gTMVal;
        reverse = cardRules.reverse;
        gM = cardRules.gM;
        cannotBePlayed = cardRules.cannotBePlayed;
        canBePlayed = cardRules.canBePlayed;
        if (gM)
        {
            StartCoroutine(GeneralMarket(0, turn));
        }
    }
    public void GreyOutCards()
    {
        cannotBePlayed = cardRules.cannotBePlayed;
        List<GameObject> greys=new List<GameObject>(new GameObject[cannotBePlayed.Count]);
        for (int i = 0; i < cannotBePlayed.Count; i++)
        {
            greys[i] = (GameObject)Instantiate(darkCover);
            greys[i].transform.position = cannotBePlayed[i].transform.position;
            greys[i].transform.parent = cannotBePlayed[i].transform;
            greys[i].transform.eulerAngles = cannotBePlayed[i].transform.eulerAngles;
            greys[i].transform.localPosition -= Vector3.forward * 0.1f;
            greys[i].transform.localScale = Vector3.one;
        }
    }
    public void ChangeSuit(string suit)
    {
        suitC.transform.position = inputMan.pool;
        suitC.SetActive(false);
        switch (suit)
        {
            case "Circle": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = circ;
                break;
            case "Triangle": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = tri;
                break;
            case "Square": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = squ;
                break;
            case "Cross": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = cro;
                break;
            case "Star": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = sta;
                break;
        }
        cardSuits[allCards.IndexOf(playPile[playPile.Count - 1])] = suit;
        ActLogAdd(PlayerNameText(turn,false) + " requested for <b>" + suit + "</b>");
        hasGTM = true;
        StartCoroutine(TakingTurns());
    }
    public IEnumerator AIChangeSuit()
    {
        yield return new WaitForSeconds(0.5f);
        cardSuits[allCards.IndexOf(playPile[playPile.Count - 1])] = aiScript.MySuit();
        switch (cardSuits[allCards.IndexOf(playPile[playPile.Count - 1])])
        {
            case "Circle": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = circ;
                break;
            case "Triangle": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = tri;
                break;
            case "Square": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = squ;
                break;
            case "Cross": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = cro;
                break;
            case "Star": playPile[playPile.Count - 1].GetComponent<MeshRenderer>().material.mainTexture = sta;
                break;
        }
        hasGTM = true;
        ActLogAdd(PlayerNameText(turn,false) + " requested for <b>" + cardSuits[allCards.IndexOf(playPile[playPile.Count - 1])] + "</b>");
        if(!playerChecked)
        StartCoroutine(TakingTurns());
    }
    void LoadResources()
    {
        darkCover = Resources.Load("DarkCover");
        circ = (Texture2D)Resources.Load("Circle20");
        cro = (Texture2D)Resources.Load("Cross20");
        squ = (Texture2D)Resources.Load("Square20");
        tri = (Texture2D)Resources.Load("Triangle20");
        sta = (Texture2D)Resources.Load("Star20");
        turnFrame = (Texture2D)Resources.Load("porFrame");
        turnBG = (Texture2D)Resources.Load("namebackWINE");
        turnDownBG = (Texture2D)Resources.Load("namebackWINEdown");
        normDownBG = (Texture2D)Resources.Load("namebackSILVERdown");
        acPointDown = (Texture2D)Resources.Load("ActHeadDown");
    }
    public IEnumerator MoveActLog()
    {
        acTrans = true;
        if (acIsMid)
        {
            acPos = midL;
            acTar = topL;
        }
        else if (acIsTop)
        {
            acPos = topL;
            acTar = downL;
        }
        else if (acIsDown)
        {
            acPos = downL;
            acTar = midL;
        }
        acIsTop = false;
        acIsMid = false;
        acIsDown = false;
        float speed = acTar == midL ? 0.15f : playSpeed / 2;
        float acTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - acTime <= speed)
        {
            actLog.transform.position = Vector3.Lerp(acPos, acTar, ((Time.realtimeSinceStartup - acTime) / speed));
            yield return null;
        }
        actLog.transform.position = acTar;
        if (actLog.transform.position == topL)
        {
            acIsTop = true;
            actLog.transform.FindChild("ActHead").GetComponent<MeshRenderer>().material.mainTexture = acPointDown;
        }
        else if (actLog.transform.position == downL)
        {
            acIsDown = true;
            actLog.transform.FindChild("ActHead").GetComponent<MeshRenderer>().material.mainTexture = acPointUp;
        }
        else if (actLog.transform.position == midL)
        {
            acIsMid = true;
            actLog.transform.FindChild("ActHead").GetComponent<MeshRenderer>().material.mainTexture = acPointUp;
        }
        acTrans = false;
    }
    public void ActLogAdd(string action)
    {
        aLog.Insert(0, action);
        if (aLog.Count > 10)
        {
            aLog.RemoveAt(10);
        }
        acText.text="";
        for (int i = 0; i < aLog.Count; i++)
        {
            acText.text += aLog[i];
            acText.text += "\n";
        }
    }
    string BoWine(List<int> val, List<string> suit)
    {
        string sign = "";
        string final = "";
        for (int i = 0; i < val.Count; i++)
        {
            sign = Sign(suit[i]);
            final += val[i].ToString() + sign + " ";
        }
        return "<b><color=#800000ff>" + final + "</color></b>";
    }
    string Sign(string cardSuit)
    {
        string sign = "";
        switch (cardSuit)
        {
            case "Circle": sign = "●";
                break;
            case "Square": sign = "■";
                break;
            case "Cross": sign = "✚";//"";
                break;
            case "Star": sign = "★";
                break;
            case "Triangle": sign = "▲";
                break;
            case "Whot": sign = "W";
                break;
        }
        return sign;
    }
    public string PlayerNameText(int ind, bool plain)
    {
        string name = pics[ind].transform.FindChild("NameText").GetComponent<TextMesh>().text; ;
        string playerName = "";
        playerName = realPlayers.Contains(ind) ? "<b><color=blue>" + name + "</color></b>" : "<b>" + name + "</b>";
        if (plain) playerName = name;
        if (tenderMesBox == TenderState.GoOrView || tenderMesBox == TenderState.Results)
            playerName = name;
        return playerName;
    }
    void PileNumberLeft()
    {
        int piCo = pile.Count - 1;
        pileNu.text = piCo.ToString();
        if (piCo > 20)
        {
            pileNu.color = Color.white;
        }
        else if (piCo > 10)
        {
            pileNu.color = Color.yellow;
        }
        else
        {
            pileNu.color = Color.red;
        }
        pileNuGO.GetComponent<MeshRenderer>().enabled = piCo > 0 ? true : false;
        stockNuGO.GetComponent<MeshRenderer>().enabled = piCo > 0 ? true : false;
    }
    int PlayerPos(int myInd)
    {
        int p = 0;
        for (int i = 0; i < pos.Count; i++)
        {
            if ((Vector2)pics[myInd].transform.position == (Vector2)pos[i].transform.position)
            {
                p = i;
                break;
            }
        }
        return p;
    }
    void CollectRankNCombo()
    {
        rankUIs = new List<GameObject>(new GameObject[8]);
        comboUIs = new GameObject[6];
        rankUIs[0] = GameObject.Find("1st");
        rankUIs[1] = GameObject.Find("2nd");
        rankUIs[2] = GameObject.Find("3rd");
        for (int i = 3; i < rankUIs.Count; i++)
        {
            rankUIs[i] = GameObject.Find((i+1) + "th");
        }
        for (int i = 0; i < comboUIs.Length; i++)
        {
            int e = (int)Mathf.Pow(2, (i + 1));
            comboUIs[i] = GameObject.Find(e.ToString() + "Com");
        }
        comboUIPool = comboUIs[0].transform.position;
        foreach (Transform item in rankPos)
        {
            item.transform.position -= Vector3.forward * 4;
        }
    }
    IEnumerator CheckedUp(int ind)
    {
        ActLogAdd(PlayerNameText(ind,false) + " <b>checked up ✔</b>");
        Vector3 targ = totNum > 2 ? pos[PlayerPos(ind)].transform.position : pic2Center[PlayerPos(ind)];
        chMark = (GameObject)Instantiate(checkUpUI, targ, Quaternion.identity);
        Color c = chMark.GetComponent<MeshRenderer>().material.color;
        c.a = 0;
        chMark.GetComponent<MeshRenderer>().material.color = c;
        chMark.transform.position -= Vector3.forward * 4;
        float checkTranT = 0;
        float checkedSpeed = 0.8f;
        while (checkTranT <= checkedSpeed)
        {
            checkTranT += Time.deltaTime;
            if (totNum > 2)
                chMark.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 1), new Vector3(1.5f, 1.5f, 1), (checkTranT / checkedSpeed));
            else
                chMark.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 1), new Vector3(3f, 3f, 1), (checkTranT / checkedSpeed));
            c = chMark.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(0, 1, (checkTranT / checkedSpeed));
            chMark.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        checkTranT = 0;
        while (checkTranT <= checkedSpeed)
        {
            checkTranT += Time.deltaTime;
            c = chMark.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(1, 0, (checkTranT / checkedSpeed));
            if (totNum > 2)
                chMark.transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1.5f, 1), new Vector3(0.2f, 0.2f, 1), (checkTranT / checkedSpeed));
            else
                chMark.transform.localScale = Vector3.Lerp(new Vector3(3f, 3f, 1), new Vector3(0.5f, 0.5f, 1), (checkTranT / checkedSpeed));
            chMark.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        Destroy(chMark);
        rankUIs[checkedOut.Count].transform.localScale = totNum > 2 ? new Vector3(0.3f, 0.3f, 1) : new Vector3(0.5f, 0.5f, 1);
        rankUIs[checkedOut.Count].transform.position = rankPos[PlayerPos(ind)].position;
        pics[ind].GetComponent<MeshRenderer>().material.shader = blackAndWhite;
        checkTranT = 0;
        while (checkTranT <= checkedSpeed)
        {
            checkTranT += Time.deltaTime;
            c = rankUIs[0].GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(0, 1, (checkTranT / checkedSpeed));
            if (totNum > 2)
                rankUIs[checkedOut.Count].transform.localScale = Vector3.Lerp(new Vector3(0.3f, 0.3f, 1), new Vector3(1f, 1f, 1), (checkTranT / checkedSpeed));
            else
                rankUIs[checkedOut.Count].transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 1), new Vector3(1.5f, 1.5f, 1), (checkTranT / checkedSpeed));
            yield return null;
        }
        int leftCards = playHands[ind].Count;
        for (int i = 0; i < leftCards; i++)
        {
            if (IsPlayer(ind))
            {
                playHands[ind][0].transform.localEulerAngles = pile[0].transform.localEulerAngles;
                playHands[ind][0].GetComponent<MeshRenderer>().enabled = hideBack;
                playHands[ind][0].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            }
            playHands[ind][0].transform.localScale = pileScale;
            pile.Add(playHands[ind][0]);
            playHands[ind].RemoveAt(0);
        }
        for (int k = 0; k < pile.Count; k++)
        {
            pile[k].transform.position = pDpos.position + new Vector3((k * -0.003f), k * 0.01f, k * 0.01f);
        }
        if (PlayerPos(ind) == 0 && totNum>2)
        {
            FixPos(pointsPos[0], new Vector2(50, 83));
            tStreakUI[ind].transform.position = pointsPos[0].transform.position;
        }
        else if (PlayerPos(ind) == 4 && totNum > 2)
        {
            FixPos(pointsPos[4], new Vector2(50, 17));
            tStreakUI[ind].transform.position = pointsPos[4].transform.position;
            if (tender)
            {
                tStreakText[ind].text = "";
                sPBG[ind].GetComponent<MeshRenderer>().enabled=false;
            }
        }
        checkedOut.Add(ind);
        playersLeft = playHands.Count - checkedOut.Count;
        if (playersLeft == 1)
        {
            for (int i = 0; i < totNum; i++)
            {
                if (!checkedOut.Contains(i))
                {
                    rankUIs[checkedOut.Count].transform.position = rankPos[PlayerPos(i)].position;
                    rankUIs[checkedOut.Count].transform.localScale = totNum > 2 ? new Vector3(1, 1, 1) : new Vector3(1.5f, 1.5f, 1);
                    pics[i].GetComponent<MeshRenderer>().material.shader = blackAndWhite;
                    ActLogAdd(PlayerNameText(i,false) + " <b>lost ✘</b>");
                    checkedOut.Add(i);
                    break;
                }
            }
            StartCoroutine("RemoveCombo");
            everyoneChecked = true;
            checkedMesBox = CheckedState.GoToMenu;
        }
        bool wasRealPlayer = false;
        if (realPlayers.Contains(ind))
        {
            realPlayers.Remove(ind);
            if (realPlayers.Count == 0)
            {
                justAI = true;
                wasRealPlayer = true;
                AllRealPlayersChecked();
            }
        }
        if (!everyoneChecked && !wasRealPlayer)
        {
            StartCoroutine(TakingTurns());
        }
        playerChecked = false;
    }
    void AllRealPlayersChecked()
    {
        if (playersLeft > 1)
        {
            checkedMesBox = CheckedState.Checked;
            outputMan.WriteMessageBox("Exit the match?", "Do you want to leave this match or keep watching?", new string[] { "1Menu", "3Stay" });
        }
        else if (!everyoneChecked)
        {
            StartCoroutine(TakingTurns());
        }
    }
    IEnumerator ShowCombo(int myInd)
    {
        StopCoroutine("RemoveCombo");
        foreach (GameObject item in comboUIs)
        {
            if (item.transform.position != comboUIPool)
            {
                Color c = item.GetComponent<MeshRenderer>().material.color;
                c.a = 1;
                item.GetComponent<MeshRenderer>().material.color = c;
                item.transform.position = comboUIPool;
            }
        }
        int pos = PlayerPos(myInd);
        GameObject comboShow = null;
        switch (combo)
        {
            case 2: comboShow = comboUIs[0];
                break;
            case 4: comboShow = comboUIs[1];
                break;
            case 8: comboShow = comboUIs[2];
                break;
            case 16: comboShow = comboUIs[3];
                break;
            case 32: comboShow = comboUIs[4];
                break;
            case 64: comboShow = comboUIs[5];
                break;
            default: comboShow = comboUIs[5];
                break;
        }
        comboShow.transform.position = comPos[pos].position;
        float time = 0.3f;
        float trantT = 0;
        while (trantT < time)
        {
            trantT += Time.deltaTime;
            comboShow.transform.localScale = Vector3.Lerp(new Vector3(0.7f, 0.7f, 1), Vector3.one, (trantT / time));
            yield return null;
        }
    }
    IEnumerator RemoveCombo()
    {
        float time = 1;
        float trantT = 0;
        foreach (GameObject item in comboUIs)
        {
            if (item.transform.position != comboUIPool)
            {
                while (trantT < time)
                {
                    trantT += Time.deltaTime;
                    Color c = item.GetComponent<MeshRenderer>().material.color;
                    c.a = Mathf.Lerp(1, 0, (trantT / time));
                    item.GetComponent<MeshRenderer>().material.color = c;
                    yield return null;
                }
                item.transform.position = comboUIPool;
                Color d = item.GetComponent<MeshRenderer>().material.color;
                d.a = 1;
                item.GetComponent<MeshRenderer>().material.color = d;
                break;
            }
        }
    }
    void RemovePlayer(int ind)
    {
        if (!comStreak)
        {
            if (playHands[ind].Count == 0)
            {
                if (!cardRules.allSpecCards.Contains(cardValues[allCards.IndexOf(playPile[playPile.Count - 1])]))
                {
                    playerChecked = true;
                    StartCoroutine(CheckedUp(ind));
                }
            }
        }
        else
        {
            if (tStreakText[ind].text != "" && int.Parse(tStreakText[ind].text) >= streakPointGoal)
            {
                playerChecked = true;
                StartCoroutine(CheckedUp(ind));
            }
        }
    }
    void NowTender()
    {
        tenderMesBox = TenderState.Finished;
        string stock = tenderFlips == 1 ? "Market has" : tenderFlips.ToString() + " Markets have";
        if (!comStreak)
        {
            if (playPile.Count == 1)
                outputMan.WriteMessageBox("Tender!", "There's no more market available. Tender will be taken.", new string[] { "3Ok" });
            else
                outputMan.WriteMessageBox("Tender!", stock + " been exhausted. Tender will be taken.", new string[] { "3Ok" });
        }
        else
        {
            outputMan.WriteMessageBox("Streak Points Rank!", "There's no more market available. Players will be ranked by their streak points.", new string[] { "3Ok" });
        }
    }
    public void MessageBoxAction(string choice)
    {
        if (tenderMesBox==TenderState.Finished)
        {
            if (choice == "3")
            {
                outputMan.HideMessageBox();
                tenderMesBox = TenderState.Inactive;
                if (!comStreak)
                    StartCoroutine(TakeTender());
                else
                    StartCoroutine(TakeStreakRank());
            }
        }
        else if (tenderMesBox == TenderState.GoOrView)
        {
            if (choice == "1")
            {
                //outputMan.HideMessageBox();
                tenderMesBox = TenderState.Inactive;
                //LoadMenu();
                outputMan.WriteMessageBox("Retry?", "Do you want to retry?", new string[] { "1Menu", "2Back", "3Retry" });
                tenderMesBox = TenderState.Restart;
            }
            else if (choice == "3")
            {
                outputMan.WriteMessageBox("Results", TenderResults()[0], new string[] { "2<", "1Leave", "3>" });
                tenderMesBox++;
            }
        }
        else if (tenderMesBox == TenderState.Results)
        {
            string[] bb = TenderResults();
            if (choice == "2")
            {
                iterCo--;
                if (iterCo < 0) iterCo = 0;
            }
            else if (choice == "3")
            {
                iterCo++;
                if (iterCo >= bb.Length) iterCo = bb.Length - 1;
            }
            if (choice == "1")
            {
                //outputMan.HideMessageBox();
                iterCo = 0;
                tenderMesBox = TenderState.Inactive;
                //LoadMenu();
                outputMan.WriteMessageBox("Retry?", "Do you want to retry?", new string[] { "1Menu", "2Back", "3Retry" });
                tenderMesBox = TenderState.Restart;
            }
            else
                outputMan.WriteMessageBox("Results", bb[iterCo], new string[] { "2<", "1Leave", "3>" });
        }
        else if (tenderMesBox == TenderState.Restart)
        {
            if (choice == "1")
            {
                outputMan.HideMessageBox();
                checkedMesBox = CheckedState.Inactive;
                LoadMenu();
            }
            else if (choice == "2")
            {
                Time.timeScale = 1;
                outputMan.HideMessageBox();
            }
            else if (choice == "3")
            {
                RetryGame();
            }
        }
        if (checkedMesBox == CheckedState.Checked)
        {
            if (choice == "1")
            {
                //outputMan.HideMessageBox();
                checkedMesBox = CheckedState.Inactive;
                //LoadMenu();
                outputMan.WriteMessageBox("Retry?", "Do you want to retry?", new string[] { "1Menu", "2Back", "3Retry" });
                tenderMesBox = TenderState.Restart;
            }
            else if (choice == "3")
            {
                outputMan.HideMessageBox();
                checkedMesBox--;
                StartCoroutine(TakingTurns());
            }
        }
    }
    string[] TenderStreakPositions()
    {
        string[] pos = new string[totNum];
        int[] scores = !comStreak ? TenderScores() : StreakScores();
        List<int> order = new List<int>();
        order.AddRange(realPlayers);
        for (int i = 0; i < totNum; i++)
        {
            if (!order.Contains(i))
            {
                order.Add(i);
            }
        }
        if (!comStreak)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                if (!checkedOut.Contains(order[i]))
                {
                    scores[i] += 1;
                }
            }
        }
        int[] sorted = new List<int>(scores).ToArray();
        System.Array.Sort(sorted);
        if (comStreak)
            System.Array.Reverse(sorted);
        for (int i = 0; i < pos.Length; i++)
        {
            int p = System.Array.IndexOf(sorted, scores[i]) + 1;
            if (p == 1)
                pos[i] = "1st";
            else if (p == 2)
                pos[i] = "2nd";
            else if (p == 3)
                pos[i] = "3rd";
            else
                pos[i] = p.ToString() + "th";
        }
        for (int i = 0; i < pos.Length; i++)
        {
            List<string> allPos = new List<string>();
            List<string> nonePos = new List<string>();
            for (int j = 0; j < pos.Length; j++)
            {
                allPos.Add(pos[j][0].ToString());
            }
            for (int j = 1; j <= totNum; j++)
            {
                if (!allPos.Contains(j.ToString()))
                {
                    nonePos.Add(j.ToString());
                }
            }
            List<int> ind = new List<int>();
            for (int j = 0; j < pos.Length; j++)
            {
                if (pos[i] == pos[j])
                {
                    ind.Add(j);
                }
            }
            bool back = false;
            if (ind.Count >= 2)
            {
                string ppp = "";
                if (nonePos.Contains((int.Parse(pos[ind[0]][0].ToString()) - 1).ToString()))
                {
                    ppp = (int.Parse(pos[ind[0]][0].ToString()) - (ind.Count-1)).ToString();
                    back = true;
                }
                else
                {
                    ppp = pos[ind[0]][0].ToString();
                    back = false;
                }
                int iii = int.Parse(ppp);
                for (int j = 0; j < ind.Count; j++)
                {
                    if (!back)
                    {
                        string pp = "";
                        if (iii.ToString() == "1")
                            pp = "1st";
                        else if (iii.ToString() == "2")
                            pp = "2nd";
                        else if (iii.ToString() == "3")
                            pp = "3rd";
                        else
                            pp = iii.ToString() + "th";
                        pos[ind[j]] = pp;
                        iii++;
                    }
                    else
                    {
                        string pp = "";
                        if (iii.ToString() == "1")
                            pp = "1st";
                        else if (iii.ToString() == "2")
                            pp = "2nd";
                        else if (iii.ToString() == "3")
                            pp = "3rd";
                        else
                            pp = iii.ToString() + "th";
                        pos[i] = pp;
                        iii++;
                    }
                }
            }
        }
        for (int i = 0; i < checkedOut.Count; i++)
        {
            for (int j = 0; j < order.Count; j++)
            {
                if (checkedOut[i] == order[j])
                {
                    if ((i + 1) == 1)
                        pos[j] = "1st";
                    else if ((i + 1) == 2)
                        pos[j] = "2nd";
                    else if ((i + 1) == 3)
                        pos[j] = "3rd";
                    else
                        pos[j] = (i + 1).ToString() + "th";
                }
            }
        }
        return pos;
    }
    int[] TenderScores()
    {
        int[] scores = new int[totNum];
        List<int> order = new List<int>();
        order.AddRange(realPlayers);
        for (int i = 0; i < totNum; i++)
        {
            if (!order.Contains(i))
            {
                order.Add(i);
            }
        }
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = TenderPointsTotal(i);
        }
        return scores;
    }
    string[] TenderResults()
    {
        string[] res = new string[totNum];
        string[] pos = TenderStreakPositions();
        int[] scores = TenderScores();
        List<int> order = new List<int>();
        order.AddRange(realPlayers);
        for (int i = 0; i < totNum; i++)
        {
            if (!order.Contains(i))
            {
                order.Add(i);
            }
        }

        for (int i = 0; i < res.Length; i++)
        {
            res[i] = PlayerNameText(i,true) + ": " +" <b>" + pos[i].ToString() + "</b>" + "\n";
            for (int j = 0; j < playHands[i].Count; j++)
            {
                string sign = "";
                switch (cardSuits[allCards.IndexOf(playHands[i][j])])
                {
                    case "Circle": sign = "●";
                        break;
                    case "Square": sign = "■";
                        break;
                    case "Cross": sign = "✚";
                        break;
                    case "Star": sign = "★";
                        break;
                    case "Triangle": sign = "▲";
                        break;
                    case "Whot": sign = "W";
                        break;
                }
                res[i] += cardValues[allCards.IndexOf(playHands[i][j])].ToString() + sign + " ";
            }
            if (scores[i] == 0) res[i] += "No cards left ";
            res[i] += "= " + "<b>" + scores[i] + "</b>";
        }
        return res;
    }
    int[] StreakScores()
    {
        int[] scores = new int[totNum];
        List<int> order = new List<int>();
        order.AddRange(realPlayers);
        for (int i = 0; i < totNum; i++)
        {
            if (!order.Contains(i))
            {
                order.Add(i);
            }
        }
        for (int i = 0; i < scores.Length; i++)
        {
            string sc=tStreakText[i].text;
            if (sc == "") sc = "0";
            scores[i] = int.Parse(sc);
            if (scores[i] > streakPointGoal) scores[i] = streakPointGoal;
        }
        return scores;
    }
    IEnumerator TakeTender()
    {
        List<int> order = new List<int>();
        order.AddRange(realPlayers);
        for (int i = 0; i < totNum; i++)
        {
            if (!order.Contains(i))
            {
                order.Add(i);
            }
        }
        string[] pos = TenderStreakPositions();
        int[] scores = TenderScores();

        for (int i = 0; i < order.Count; i++)
        {
            tStreakText[order[i]].text = scores[order[i]].ToString();
            sPBG[order[i]].GetComponent<MeshRenderer>().enabled = true;
        }
        for (int j = 0; j < totNum; j++)
        {
            for (int i = 0; i < order.Count; i++)
            {
                if (pos[i][0].ToString() == (j+1).ToString())
                {
                    int ran = int.Parse(pos[order[i]][0].ToString()) - 1;
                    rankUIs[ran].transform.localScale = totNum > 2 ? new Vector3(0.3f, 0.3f, 1) : new Vector3(0.5f, 0.5f, 1);
                    rankUIs[ran].transform.position = rankPos[PlayerPos(order[i])].position;
                    pics[order[i]].GetComponent<MeshRenderer>().material.shader = blackAndWhite;
                    float checkTranT = 0;
                    float checkedSpeed = 0.8f;
                    while (checkTranT <= checkedSpeed)
                    {
                        checkTranT += Time.deltaTime;
                        Color c = rankUIs[ran].GetComponent<MeshRenderer>().material.color;
                        c.a = Mathf.Lerp(0, 1, (checkTranT / checkedSpeed));
                        if (totNum > 2)
                            rankUIs[ran].transform.localScale = Vector3.Lerp(new Vector3(0.3f, 0.3f, 1), new Vector3(1f, 1f, 1), (checkTranT / checkedSpeed));
                        else
                            rankUIs[ran].transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 1), new Vector3(1.5f, 1.5f, 1), (checkTranT / checkedSpeed));
                        yield return null;
                    }
                    break;
                }
            }
        }
        checkedOut.Clear();
        for (int i = 1; i <= pos.Length; i++)
        {
            string p = "";
            if (i == 1)
                p = "1st";
            else if (i == 2)
                p = "2nd";
            else if (i == 3)
                p = "3rd";
            else p = i.ToString() + "th";
            int n = System.Array.IndexOf(pos, p);
            checkedOut.Add(order[n]);
        }

        yield return new WaitForSeconds(2);
        outputMan.WriteMessageBox("View Details?", "Do you want to see the full details of the results?", new string[] { "1Back", "3View" });
        tenderMesBox = TenderState.GoOrView;
    }
    IEnumerator TakeStreakRank()
    {
        List<int> order = new List<int>();
        order.AddRange(realPlayers);
        for (int i = 0; i < totNum; i++)
        {
            if (!order.Contains(i))
            {
                order.Add(i);
            }
        }
        string[] pos = TenderStreakPositions();
        int[] scores = StreakScores();

        for (int i = 0; i < order.Count; i++)
        {
            tStreakText[order[i]].text = scores[order[i]].ToString();
            sPBG[order[i]].GetComponent<MeshRenderer>().enabled = true;
        }
        for (int j = 0; j < totNum; j++)
        {
            for (int i = 0; i < order.Count; i++)
            {
                if (pos[i][0].ToString() == (j + 1).ToString())
                {
                    int ran = int.Parse(pos[order[i]][0].ToString()) - 1;
                    rankUIs[ran].transform.localScale = totNum > 2 ? new Vector3(0.3f, 0.3f, 1) : new Vector3(0.5f, 0.5f, 1);
                    rankUIs[ran].transform.position = rankPos[PlayerPos(order[i])].position;
                    pics[order[i]].GetComponent<MeshRenderer>().material.shader = blackAndWhite;
                    float checkTranT = 0;
                    float checkedSpeed = 0.8f;
                    while (checkTranT <= checkedSpeed)
                    {
                        checkTranT += Time.deltaTime;
                        Color c = rankUIs[ran].GetComponent<MeshRenderer>().material.color;
                        c.a = Mathf.Lerp(0, 1, (checkTranT / checkedSpeed));
                        if (totNum > 2)
                            rankUIs[ran].transform.localScale = Vector3.Lerp(new Vector3(0.3f, 0.3f, 1), new Vector3(1f, 1f, 1), (checkTranT / checkedSpeed));
                        else
                            rankUIs[ran].transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 1), new Vector3(1.5f, 1.5f, 1), (checkTranT / checkedSpeed));
                        yield return null;
                    }
                    break;
                }
            }
        }
        checkedOut.Clear();
        for (int i = 1; i <= pos.Length; i++)
        {
            string p = "";
            if (i == 1)
                p = "1st";
            else if (i == 2)
                p = "2nd";
            else if (i == 3)
                p = "3rd";
            else p = i.ToString() + "th";
            int n = System.Array.IndexOf(pos, p);
            checkedOut.Add(order[n]);
        }

        yield return new WaitForSeconds(2);
        tenderMesBox = TenderState.Inactive;
        checkedMesBox = CheckedState.GoToMenu;
    }
    bool CanScrollEffect()
    {
        bool scroll = false;
        if (inputMan.canScroll)
        {
            scroll = true;
        }
        else
        {
            scroll = scrDelta != 0 ? true : false;
        }
        return scroll;
    }
    public IEnumerator SlowScrDelta()
    {
        float slowFactor = 0.007f;
        if (scrDelta > 0)
        {
            while (scrDelta > 0)
            {
                scrDelta -= slowFactor;
                yield return null;
            }
        }
        else if (scrDelta < 0)
        {
            while (scrDelta < 0)
            {
                scrDelta += slowFactor;
                yield return null;
            }
        }
        scrDelta = 0;
    }
    void CollectAndPositionAndScaleStuff()
    {
        checkUpUI = GameObject.Find("CheckedUpUI");
        mesBox = GameObject.Find("MessageBox");
        blackAndWhite = Shader.Find("Unlit/GreyScale");//1.8,0.58
        ffBG = GameObject.Find("FastForwardBG");
        midSp = GameObject.Find("MidSpeed");
        fastSp = GameObject.Find("FastSpeed");
        ffNames = new string[3];
        ffNames[0] = midSp.name;
        ffNames[1] = fastSp.name;
        FixPos(ffBG.transform, new Vector2(0, 0));
        FixPos(midSp.transform, new Vector2(2.7f, 3.2f));
        FixPos(fastSp.transform, new Vector2(8.27f, 3.2f));
        midSp.transform.parent = ffBG.transform;
        fastSp.transform.parent = ffBG.transform;
        effectsUI = GameObject.Find("SpecialCardEffects");
        effectsUIMR = effectsUI.GetComponent<MeshRenderer>();
        Texture2D[] eff = Resources.LoadAll<Texture2D>("CardEffects");
        holdOn = eff[3];
        pick2 = eff[7];
        pick3 = eff[6];
        susp = eff[10];
        rev = eff[8];
        genmark = eff[2];
        ineed = eff[4];
        conti = eff[1];
        semilast = eff[9];
        last = eff[5];
        checku = eff[0];
    }
    public void FastForward(string but)
    {
        float mid = 1.5f;
        float fast = 5;
        ffNames[2] = but;
        Color active=new Color(0.5f,0,0);
        switch (but)
        {
            case "MidSpeed":
                if (Time.timeScale != mid)
                {
                    Time.timeScale = mid;
                    midSp.GetComponent<MeshRenderer>().material.color = active;
                    fastSp.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                else
                {
                    Time.timeScale = 1;
                    midSp.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                break;
            case "FastSpeed":
                if (Time.timeScale != fast)
                {
                    Time.timeScale = fast;
                    fastSp.GetComponent<MeshRenderer>().material.color = active;
                    midSp.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                else
                {
                    Time.timeScale = 1;
                    fastSp.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                break;
        }
    }
    IEnumerator ShowSpecialCardUI(Texture2D eff, int ind)
    {
        effectsUIMR.material.mainTexture = eff;
        Vector3 from = totNum > 2 ? pos[PlayerPos(ind)].transform.position : pic2Center[PlayerPos(ind)];
        if (PlayerPos(ind) == 2) from -= Vector3.right * 1;
        else if (PlayerPos(ind) == 6) from += Vector3.right * 1;
        effectsUI.transform.position = from;
        effectsUI.transform.position -= Vector3.forward * 4;
        Vector3 tar = Vector3.zero;
        if (totNum > 2)
            tar = !new int[] { 0, 1, 7 }.Contains(PlayerPos(ind)) ? effectsUI.transform.position + Vector3.up * 2 : effectsUI.transform.position - Vector3.up * 2;
        else
            tar = PlayerPos(ind) == 0 ? effectsUI.transform.position + Vector3.up * 2 : effectsUI.transform.position - Vector3.up * 2;
        float tranT = 0;
        float speed = 0.8f;
        while (tranT <= speed)
        {
            tranT += Time.deltaTime;
            effectsUI.transform.position = Vector3.Lerp(from, tar, (tranT / speed));
            Color c = effectsUIMR.material.color;
            c.a = Mathf.Lerp(1, 0, ((tranT - (speed / 2)) / (speed / 2)));
            effectsUIMR.material.color = c;
            yield return null;
        }
        effectsUI.transform.position = comboUIPool;
        Color co = effectsUIMR.material.color;
        co.a = 1;
        effectsUIMR.material.color = co;
    }
    void CheckSpecialCardUI(int lastPlayed, int myInd)
    {
        Texture2D eff = null;
        if (playHands[myInd].Count > 2 || comStreak)
        {
            switch (lastPlayed)
            {
                case 1: eff = holdOn;
                    break;
                case 2: eff = pick2;
                    break;
                case 5: eff = pick3;
                    break;
                case 8: eff = susp;
                    break;
                case 12: eff = rev;
                    break;
                case 14: eff = genmark;
                    break;
                case 20: eff = ineed;
                    break;
                default:
                    eff = conti;
                    break;
            }
            if (!repConti)
            {
                if (cardRules.allSpecCards.Contains(lastPlayed))
                {
                    StartCoroutine(ShowSpecialCardUI(eff, myInd));
                    if (cardRules.repTurnCards.Contains(lastPlayed)) repConti = true;
                }
            }
            else
            {
                if (streak>1)
                {
                    StartCoroutine(ShowSpecialCardUI(eff, myInd));
                }
                if (!cardRules.repTurnCards.Contains(lastPlayed))
                repConti = false;
            }
        }
        else
        {
            repConti = false;
            int co = playHands[myInd].Count;
            switch (co)
            {
                case 2: eff = semilast;
                    break;
                case 1: eff = last;
                    break;
                case 0: eff = checku;
                    break;
            }
            if (cardRules.allSpecCards.Contains(lastPlayed) && co==0)
            {
                switch (lastPlayed)
                {
                    case 1: eff = holdOn;
                        break;
                    case 2: eff = pick2;
                        break;
                    case 5: eff = pick3;
                        break;
                    case 8: eff = susp;
                        break;
                    case 12: eff = rev;
                        break;
                    case 14: eff = genmark;
                        break;
                    case 20: eff = ineed;
                        break;
                    default:
                        eff = conti;
                        break;
                }
                StartCoroutine(ShowSpecialCardUI(eff, myInd));
                return;
            }
            StartCoroutine(ShowSpecialCardUI(eff, myInd));
        }
    }
    void CoverCards(int turn)
    {
        if (lastRealPlayer != turn)
        {
            playArrs[0].SetActive(false);
            playArrs[1].SetActive(false);
            cardCover.transform.position = totNum > 2 ? cardPos[playInd] - Vector3.forward * 1.5f : cardPos[playInd] - Vector3.forward * 0.2f;
            NextTurnText.GetComponent<TextMesh>().text = PlayerNameText(turn, true) + "'s Turn";
            NextTurnButton.transform.parent = null;
            if (tender)
            {
                tStreakText[turn].text = "";
                sPBG[turn].GetComponent<MeshRenderer>().enabled = false;
            }
            lastRealPlayer = turn;
        }
    }
    public IEnumerator ReturnCardsCover()
    {
        yield return new WaitForSeconds(0.1f);
        NextTurnButton.transform.parent = cardCover.transform;
        cardCover.transform.position = comboUIPool;
        playArrs[0].SetActive(true);
        playArrs[1].SetActive(true);
        if (tender)
        {
            tStreakText[turn].text = TenderPointsTotal(turn).ToString();
            sPBG[turn].GetComponent<MeshRenderer>().enabled = true;
        }
    }
    int TenderPointsTotal(int ind)
    {
        int score = 0;
        for (int i = 0; i < playHands[ind].Count; i++)
        {
            int c = cardValues[allCards.IndexOf(playHands[ind][i])];
            if (cardSuits[allCards.IndexOf(playHands[ind][i])] == "Star") c *= 2;
            score += c;
        }
        return score;
    }
    void LoadMenu()
    {
        TakeStats();
        Application.LoadLevel(1);
    }
    void RetryGame()
    {
        TakeStats();
        Application.LoadLevel(Application.loadedLevel);
    }
    void TakeStats()
    {
        Time.timeScale = 1;
        if (myPos != 9 && dataMan)
        {
            if (tender)
            {
                dataScript.stats[1]++;
                if (checkedOut.Contains(myPos) || checkedOut.Count == totNum)
                {
                    if (checkedOut[0] == myPos)
                        dataScript.stats[4]++;
                    else if (checkedOut[totNum - 1] == myPos)
                        dataScript.stats[7]++;
                }
            }
            else if (comStreak)
            {
                dataScript.stats[2]++;
                if (checkedOut.Contains(myPos) || checkedOut.Count == totNum)
                {
                    if (checkedOut[0] == myPos)
                        dataScript.stats[5]++;
                    else if (checkedOut[totNum - 1] == myPos)
                        dataScript.stats[8]++;
                }
            }
            else
            {
                dataScript.stats[0]++;
                if (checkedOut.Contains(myPos) || checkedOut.Count == totNum)
                {
                    if (checkedOut[0] == myPos)
                        dataScript.stats[3]++;
                    else if (checkedOut[totNum - 1] == myPos)
                        dataScript.stats[6]++;
                }
            }
            dataScript.totalSP = totalSP;
            PlayerPrefs.SetInt("tSP", dataScript.totalSP);
            string nn = "";
            for (int i = 0; i < 9; i++)
            {
                nn += dataScript.stats[i].ToString();
                if (i != 8) nn += ",";
            }
            PlayerPrefs.SetString("sta", nn);
            PlayerPrefs.Save();
        }
    }
    /*void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(w/2, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        //string text = testString;
        GUI.Label(rect, text, style);
    }*/

}
public enum TenderState
{
    Inactive,
    Finished,
    GoOrView,
    Results,
    Restart
}
public enum CheckedState
{
    Inactive,
    Checked,
    GoToMenu
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Menus : MonoBehaviour {
    public Datas dataScript;
    public GameObject dataMan;
    public float camSize;
    public float Hit, Wit;
    public GameObject background;
    public GameObject gameLogo;
    public GameObject darkEdge;
    public GameObject profile;
    public GameObject playBut;
    public GameObject optBut;
    public GameObject locBut, blueBut, lanBut, webBut;
    public float test;
    public Vector3 tTWorldPos;
    public Vector3 tTWorldPosF;
    Ray camRay;
    RaycastHit butHit;
    public GameObject touchedObject;
    public Vector3 tempVec;
    public bool canScroll;
    public Vector3 lastTPos;
    public Vector3 lastTPosScrn;
    public Vector3 lastScrPos;
    public Vector3 delta;
    public Vector3 deltaWorld;
    public Vector3 tVec;
    public bool hasTouched;
    public GameObject TopicBG;
    public GameObject foreG;
    public GameObject foreGTemp;
    public Vector3 largeLogo;
    public Vector3 smallLogo;
    public Vector3 largeBut;
    public Vector3 smallBut;
    public Texture2D sing, mult, pla, opt;
    MenuStates curMenu;
    MenuStates selectedMenu;
    GameModes curGameMode;
    public GameObject playSel;
    public GameObject backBut;
    public Vector2 tes, tes2, tes3, tes4;
    public GameObject topic;
    public GameObject leftBut, rightBut;
    public GameObject numPl;
    public GameObject fPlay, fSettings;
    public GameObject iconsDescribe;
    public GameObject numSp, numMar, numCar;
    public GameObject[] gameModes;
    public Vector3 iniModeScale;
    public GameObject gmPar;
    public float gameModeTransSpeed;
    public Vector3[] origModePos;
    public Texture2D me, ai, op, empty;
    Coroutine curCorou;
    public int prevPlaysInd;
    public GameObject optPar;
    public GameObject settingsBut, abtBut, helpBut;
    public GameObject cardCovPrefab, cardsPar, cardCov;
    public Texture2D ticked, unTicked;
    public TextMesh diffText;
    public GameObject dGCheckBox;
    public GameObject fakeDataMan;
    public bool fromPlay;
    public GameObject helpPar;
    public float scrDelta;
    public GameObject profPar, stats;
    public GameObject aboutPar;
    TouchScreenKeyboard keyboard;
    // Use this for initialization0.05,-0.45
	void Start () {
        dataMan = GameObject.Find("DataMan");
        dataScript = dataMan.GetComponent<Datas>();
        if (dataScript.startedFromLogos) Destroy(fakeDataMan);
        Hit = Screen.height;
        Wit = Screen.width;
        camSize = Camera.main.orthographicSize;
        foreG = GameObject.Find("Foreground"); foreG.transform.position = Vector3.zero;
        foreGTemp = (GameObject)Instantiate(foreG, foreG.transform.position-Vector3.forward*5, foreG.transform.rotation);
        foreG.SetActive(false);
        StartCoroutine(FadeIntoScene());
        largeLogo = new Vector3(2.367123f, 1.35f, 1);
        smallBut = new Vector3(2.850909f, 0.98f, 1);
        background = GameObject.Find("BackGround"); background.transform.position = Vector3.forward * 10;
        background.transform.localScale = new Vector3(1, (camSize * 2), 1);
        FixScale(background.transform);
        gameLogo = GameObject.Find("GameLogo");
        FixScale(gameLogo.transform);
        smallLogo = gameLogo.transform.localScale;
        float stretchSpeed = 1;
        StartCoroutine(StretchOut(stretchSpeed));
        FixPos(gameLogo.transform, new Vector2(100, 100));
        darkEdge = GameObject.Find("DarkEdge");
        FixPos(darkEdge.transform, new Vector2(100, 50));
        darkEdge.transform.localScale = new Vector3(15, (camSize * 2), 1);
        profile = GameObject.Find("Profile");
        FixPos(profile.transform, new Vector2(0, 100));
        playBut = GameObject.Find("PlayButton");
        FixScale(playBut.transform);
        largeBut = playBut.transform.localScale;
        FixPos(playBut.transform, new Vector2(100, 61));
        optBut = GameObject.Find("OptionsButton");
        FixScale(optBut.transform);
        FixPos(optBut.transform, new Vector2(100, 30));
        locBut = GameObject.Find("LocalButton");
        FixScale(locBut.transform);
        FixPos(locBut.transform, new Vector2(100, 4 * (100 / 5)));
        locBut.SetActive(false);
        blueBut = GameObject.Find("BluetoothButton");
        FixScale(blueBut.transform);
        FixPos(blueBut.transform, new Vector2(100, 3 * (100 / 5)));
        blueBut.SetActive(false);
        lanBut = GameObject.Find("LanButton");
        FixScale(lanBut.transform);
        FixPos(lanBut.transform, new Vector2(100, 2 * (100 / 5)));
        lanBut.SetActive(false);
        webBut = GameObject.Find("WebButton");
        FixScale(webBut.transform);
        FixPos(webBut.transform, new Vector2(100, 1 * (100 / 5)));
        webBut.SetActive(false);
        TopicBG = GameObject.Find("TopicBackground");
        FixPos(TopicBG.transform, new Vector2(50, 100));
        TopicBG.transform.localScale = new Vector3((camSize * (Wit / Hit) * 2), 1.8f, 1);
        TopicBG.SetActive(false);
        playSel = GameObject.Find("PlayerSelect"); playSel.transform.position = new Vector3(0, 1.58f, -3);
        playSel.SetActive(false);
        FixScale(playSel.transform);
        backBut = GameObject.Find("BackButton");
        FixPos(backBut.transform, new Vector2(9, 10.7f));
        backBut.SetActive(false);
        topic = GameObject.Find("Topic");
        FixPos(topic.transform, new Vector2(50, 100));
        numPl = GameObject.Find("NumPlay"); numPl.transform.position = new Vector3(0, 3.4f, -3);
        numPl.SetActive(false);
        fPlay = GameObject.Find("FinalPlayButton");
        fPlay.SetActive(false);
        fSettings = GameObject.Find("PlaySettings");
        fSettings.SetActive(false);
        FixScale(fPlay.transform);
        FixScale(fSettings.transform);
        FixPos(fPlay.transform, new Vector2(78.5f, 10.7f));
        FixPos(fSettings.transform, new Vector2(37, 10.7f));
        iconsDescribe = GameObject.Find("IconsDescribe"); iconsDescribe.transform.position = new Vector3(0, 0.03f, -3);
        iconsDescribe.SetActive(false);
        numSp = GameObject.Find("NumSP"); numSp.SetActive(false); numSp.transform.position = new Vector3(0, -2.46f, -3);
        numCar = GameObject.Find("NumCards"); numCar.SetActive(false); numCar.transform.position = new Vector3(0, -1.39f, -3);
        numMar = GameObject.Find("NumMarket"); numMar.SetActive(false); numMar.transform.position = new Vector3(0, -2.46f, -3);
        gameModes = new GameObject[] { GameObject.Find("WhotButton"), GameObject.Find("TenderButton"), GameObject.Find("StreakButton") };
        origModePos = new Vector3[gameModes.Length];
        for (int i = 0; i < origModePos.Length; i++) origModePos[i] = gameModes[i].transform.position;
        iniModeScale = gameModes[0].transform.localScale;
        gmPar = GameObject.Find("GameModesParent");
        foreach (GameObject mode in gameModes) mode.transform.parent = gmPar.transform;
        gameModeTransSpeed = 2;
        optPar = GameObject.Find("OptionsPar"); optPar.transform.position = new Vector3(0, 0, -3);
        settingsBut = optPar.transform.GetChild(0).gameObject;
        abtBut = optPar.transform.GetChild(2).gameObject;
        helpBut = optPar.transform.GetChild(1).gameObject;
        settingsBut.SetActive(false);
        abtBut.SetActive(false);
        helpBut.SetActive(false);
        cardCovPrefab = GameObject.Find("CardCover");
        cardsPar = GameObject.Find("CardsParent"); cardsPar.transform.position = new Vector3(0, 1.6f, -3);
        cardsPar.SetActive(false);
        helpPar = GameObject.Find("HelpPar"); helpPar.transform.position = new Vector3(0, -26.8f, -1); helpPar.SetActive(false);
        aboutPar = GameObject.Find("AboutPar"); aboutPar.transform.position = Vector3.forward * -3; aboutPar.SetActive(false);
        profPar = GameObject.Find("ProfPar"); profPar.transform.position = Vector3.forward * -3; profPar.SetActive(false);
        stats = profPar.transform.GetChild(2).gameObject;
        SetInitialValues();
        if (Camera.main.aspect < 1.5f)
        {
            playSel.transform.localScale = Vector3.one * 2.87f;
            FixScale(playSel.transform);
            gmPar.transform.localScale = new Vector3(0.95f, 0.95f, 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (curMenu == MenuStates.MainMenu)
                Application.Quit();
            else
                GoBack();
        }
        //FixScale(card1.transform);
        //FixPos(fPlay.transform, tes);
        //FixPos(fSettings.transform, new Vector2(tes2.x, tes.y));
        /*FixPos(playsText.transform, new Vector2(tes3.x, tes.y));
        FixPos(playsNumText.transform, new Vector2(tes4.x, tes.y));*/
        tTWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //camRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (curMenu == MenuStates.Help)
            {
                StopCoroutine("SlowScrDelta");
                scrDelta = 0;
                canScroll = true;
            }
            if (Physics.Raycast(camRay, out butHit))
            {
                touchedObject = butHit.collider.gameObject;
                tempVec = touchedObject.transform.localScale;
                if (new string[] { "PlayButton", "OptionsButton",locBut.name,blueBut.name,lanBut.name,webBut.name }.Contains(touchedObject.name))
                {
                    touchedObject.transform.localScale = smallBut;
                }
                if (touchedObject.name == "BackButton")
                {
                    touchedObject.transform.localScale = new Vector3(tempVec.x * 0.85f, tempVec.y * 0.85f, 1);
                }
                if (new string[] { fPlay.name, fSettings.name }.Contains(touchedObject.name))
                {
                    touchedObject.transform.localScale = new Vector3(tempVec.x * 0.85f, tempVec.y * 0.85f, 1);
                }
                if (touchedObject.name.Contains("LeftButton") || touchedObject.name.Contains("RightButton"))
                {
                    touchedObject.transform.localScale = new Vector3(tempVec.x * 0.85f, tempVec.y * 0.85f, 1);
                }
                if (new string[] { settingsBut.name, abtBut.name,helpBut.name }.Contains(touchedObject.name))
                {
                    touchedObject.transform.localScale = new Vector3(tempVec.x * 0.85f, tempVec.y * 0.85f, 1);
                }
                if (touchedObject.name == profile.name)
                {
                    touchedObject.transform.localScale = new Vector3(tempVec.x * 0.95f, tempVec.y * 0.95f, 1);
                }
                hasTouched = true;
            }
            if (canScroll)
                lastTPos = tTWorldPos;
            //Debug.Log(lastTPos);
            lastTPosScrn = Input.mousePosition;
            tVec = Input.mousePosition;
        }

        if (CanScrollEffect())
            deltaWorld = tTWorldPos - lastTPos;
        if (curMenu == MenuStates.Help)
        {
            if (canScroll) scrDelta = deltaWorld.y;
            helpPar.transform.position = new Vector3(helpPar.transform.position.x, Mathf.Clamp(helpPar.transform.position.y + scrDelta, -26f, 47.2f), helpPar.transform.position.z);
        }
        if (curMenu == MenuStates.Profile && keyboard != null && keyboard.text.Length<=10)
        {
            profPar.transform.GetChild(1).GetComponent<TextMesh>().text = keyboard.text;
        }
        lastTPos = tTWorldPos;

        if (Input.GetMouseButtonUp(0))
        {
            camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //camRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(camRay, out butHit))
            {
                if (touchedObject == butHit.collider.gameObject)
                {
                    if (touchedObject.name == "PlayButton")
                    {
                        if (curMenu == MenuStates.MainMenu)
                        {
                            playBut.GetComponent<MeshRenderer>().material.mainTexture = sing;
                            optBut.GetComponent<MeshRenderer>().material.mainTexture = mult;
                            curMenu = MenuStates.Play;
                            backBut.SetActive(true);
                        }
                        else if (curMenu == MenuStates.Play)
                        {
                            curMenu = MenuStates.Mode;
                            ShowMainMenuItems(false);
                            ShowModes();
                            selectedMenu = MenuStates.Single;
                        }
                    }else
                    if (touchedObject.name == "OptionsButton")
                    {
                        if (curMenu == MenuStates.MainMenu)
                        {
                            curMenu = MenuStates.Options;
                            ShowOptions(true);
                        }
                        else if (curMenu == MenuStates.Play)
                        {
                            curMenu = MenuStates.Multi;
                            ShowMainMenuItems(false);
                            ShowMultiMenuItems(true);
                        }
                    }
                    else if (touchedObject.name == "Wcol")
                    {
                        helpPar.transform.position = new Vector3(helpPar.transform.position.x, -24.45918f, helpPar.transform.position.z);
                    }
                    else if (touchedObject.name == "WRcol")
                    {
                        helpPar.transform.position = new Vector3(helpPar.transform.position.x, 7.415508f, helpPar.transform.position.z);
                    }
                    else if (touchedObject.name == "Ccol")
                    {
                        helpPar.transform.position = new Vector3(helpPar.transform.position.x, 25.94873f, helpPar.transform.position.z);
                    }
                    else if (touchedObject.name == "Tcol")
                    {
                        helpPar.transform.position = new Vector3(helpPar.transform.position.x, 37.31004f, helpPar.transform.position.z);
                    }
                    else
                    if (touchedObject.name == locBut.name)
                    {
                        curMenu = MenuStates.Mode;
                        ShowMultiMenuItems(false);
                        ShowModes();
                        selectedMenu = MenuStates.Local;
                    }
                    for (int i = 0; i < gameModes.Length; i++)
                    {
                        if (touchedObject.name == gameModes[i].name && touchedObject.transform.parent!=null)
                        {
                            curGameMode = (GameModes)i;
                            UpdateModeData(i);
                            StartCoroutine(RemoveModes(touchedObject));
                            break;
                        }
                    }
                    if (touchedObject.name == "SettingsButton")
                    {
                        ShowSettings(true);
                        curMenu = MenuStates.Settings;
                    }else
                        if (touchedObject.name == "HelpButton")
                        {
                            ShowHelp(true);
                            curMenu = MenuStates.Help;
                        }else
                    if (curMenu == MenuStates.Settings && touchedObject.name.Contains("Card"))
                    {
                        CardsToggle(touchedObject);
                    }else
                        if (touchedObject.name == "CheckBoxDG")
                        {
                            DGToggle(touchedObject);
                        }else
                    if (touchedObject.name == "BackButton")
                    {
                        GoBack();
                    }
                    int nOP = int.Parse(numPl.transform.GetChild(0).GetComponent<TextMesh>().text);
                    for (int i = 0; i < nOP; i++)
                    {
                        if (touchedObject.name == i.ToString() + "Player")
                        {
                            PlayerToggle(i, prevPlaysInd);
                            prevPlaysInd = i;
                        }
                    }
                    if (new string[] { "PlaysLeftButton", "PlaysRightButton" }.Contains(touchedObject.name))
                    {
                        IncDecPlayers(touchedObject.name);
                    }
                    else if (new string[] { "CardsLeftButton", "CardsRightButton" }.Contains(touchedObject.name))
                    {
                        IncDecCards(touchedObject.name);
                    }
                    else if (new string[] { "MarketLeftButton", "MarketRightButton" }.Contains(touchedObject.name))
                    {
                        IncDecStock(touchedObject.name);
                    }
                    else if (new string[] { "SPLeftButton", "SPRightButton" }.Contains(touchedObject.name))
                    {
                        IncDecStreakGoal(touchedObject.name);
                    }
                    else if (new string[] { "AILeftButton", "AIRightButton" }.Contains(touchedObject.name))
                    {
                        IncDecDifficulty(touchedObject.name);
                    }
                    else if (touchedObject.name == fPlay.name)
                    {
                        PlayerPrefs.Save();
                        fPlay.transform.GetChild(0).GetComponent<TextMesh>().text = "Loading...";
                        Application.LoadLevel(2);
                    }
                    else if (touchedObject.name == fSettings.name)
                    {
                        RemovePlayMenuItems();
                        ShowSettings(true);
                        fromPlay = true;
                        curMenu = MenuStates.Settings;
                    }
                    else if (touchedObject.name == abtBut.name)
                    {
                        curMenu = MenuStates.About;
                        ShowAbout(true);
                    }
                    else if (touchedObject.name == profile.name)
                    {
                        ShowProfile(true);
                        selectedMenu = curMenu;
                        curMenu = MenuStates.Profile;
                    }
                    else if (touchedObject.name == profPar.transform.GetChild(1).gameObject.name)
                    {
                        keyboard = TouchScreenKeyboard.Open(profPar.transform.GetChild(1).GetComponent<TextMesh>().text);
                    }
                }
            }
            if (touchedObject)
            {
                if (new string[] { "PlayButton", "OptionsButton", locBut.name, blueBut.name, lanBut.name, webBut.name }.Contains(touchedObject.name))
                {
                    touchedObject.transform.localScale = largeBut;
                }
                if (touchedObject.name == "BackButton")
                {
                    touchedObject.transform.localScale = tempVec;
                }
                if (new string[] { fPlay.name, fSettings.name,settingsBut.name,abtBut.name,helpBut.name, profile.name }.Contains(touchedObject.name))
                {
                    touchedObject.transform.localScale = tempVec;
                }
                if (touchedObject.name.Contains("LeftButton") || touchedObject.name.Contains("RightButton"))
                {
                    touchedObject.transform.localScale = tempVec;
                }
            }
            touchedObject = null;
            canScroll = false;
            StartCoroutine("SlowScrDelta");
            deltaWorld = Vector3.zero;
        }
    }
    void SetInitialValues()
    {
        int temp = dataScript.numOfCards;
        dataScript.numOfCards = 1;
        for (int i = 0; i < temp - 1; i++)
        {
            IncDecCards("CardsRightButton");
        }
        temp = dataScript.tenderStock;
        dataScript.tenderStock = 1;
        for (int i = 0; i < temp - 1; i++)
        {
            IncDecStock("MarketRightButton");
        }
        temp = dataScript.streakPointGoal;
        dataScript.streakPointGoal = 50;
        for (int i = 0; i < (temp / 50) - 1; i++)
        {
            IncDecStreakGoal("SPRightButton");
        }
        temp = dataScript.aiDifficulty;
        dataScript.aiDifficulty = 0;
        for (int i = 0; i < temp; i++)
        {
            IncDecDifficulty("AIRightButton");
        }
        List<int> tempp = new List<int>(dataScript.disabledCards);
        dataScript.disabledCards.Clear();
        for (int i = 0; i < tempp.Count; i++)
        {
            CardsToggle(cardsPar.transform.FindChild("Card" + tempp[i].ToString()).gameObject);
        }
        if (dataScript.doubleGame)
            dGCheckBox.GetComponent<MeshRenderer>().material.mainTexture = ticked;
        profile.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.totalSP.ToString();
        profile.transform.GetChild(2).GetComponent<MeshRenderer>().material.mainTexture = dataScript.myPic;

        profPar.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.totalSP.ToString();
        profPar.transform.GetChild(1).GetComponent<TextMesh>().text = dataScript.playerName;
        for (int i = 0; i < 9; i++)
        {
            stats.transform.GetChild(i).GetComponent<TextMesh>().text = dataScript.stats[i].ToString();
        }
        profPar.transform.GetChild(3).GetComponent<MeshRenderer>().material.mainTexture = dataScript.myPic;
    }
    void FixScale(Transform but)
    {
        Texture2D tex = (Texture2D)but.gameObject.GetComponent<MeshRenderer>().material.mainTexture;
        but.localScale = new Vector3(but.localScale.y * (((float)tex.width / (float)tex.height)), but.localScale.y, but.localScale.z);
    }
    void FixPos(Transform but, Vector2 posVec)
    {
        but.localPosition = new Vector3((((posVec.x / 100) * (2 * (camSize + (Wit - Hit) / (Hit / camSize)))) - camSize) - ((Wit - Hit) / (Hit / camSize)), (((posVec.y / 100) * (2 * camSize))) - camSize, but.localPosition.z);
    }
    IEnumerator FadeIntoScene()
    {
        float speed = 1;
        float tran = 0;
        Color c = foreGTemp.GetComponent<MeshRenderer>().material.color;
        while (tran < speed)
        {
            tran += Time.deltaTime;
            c = foreGTemp.GetComponent<MeshRenderer>().material.color;
            c.a = Mathf.Lerp(1, 0, (tran / speed));
            foreGTemp.GetComponent<MeshRenderer>().material.color = c;
            yield return null;
        }
        Destroy(foreGTemp);
    }
    IEnumerator StretchOut(float speed)
    {
        float tran = 0;
        while (tran < speed)
        {
            tran += Time.deltaTime;
            gameLogo.transform.localScale = Vector3.Lerp(smallLogo, largeLogo, (tran / speed));
            yield return null;
        }
        StartCoroutine(ShrinkIn(speed));
    }
    IEnumerator ShrinkIn(float speed)
    {
        float tran = 0;
        while (tran < speed)
        {
            tran += Time.deltaTime;
            gameLogo.transform.localScale = Vector3.Lerp(largeLogo, smallLogo, (tran / speed));
            yield return null;
        }
        StartCoroutine(StretchOut(speed));
    }
    void ShowMainMenuItems(bool show)
    {
        profile.SetActive(show);
        gameLogo.SetActive(show);
        //if(!show)
        if (curMenu != MenuStates.Multi)
        {
            foreG.SetActive(!show);
            darkEdge.SetActive(show);
        }
        if (curMenu != MenuStates.Mode && curMenu!=MenuStates.Multi)
        {
            TopicBG.SetActive(!show);
        }
        playBut.SetActive(show);
        optBut.SetActive(show);
    }
    void ShowPlayMenuItems()
    {
        UpdatePlayerSelect();
        numPl.SetActive(true);
        numCar.SetActive(true);
        if (curGameMode == GameModes.Tender)
            numMar.SetActive(true);
        else if (curGameMode == GameModes.Streak)
            numSp.SetActive(true);
        iconsDescribe.SetActive(true);
        if (curMenu == MenuStates.Single)
        {
            iconsDescribe.transform.GetChild(0).gameObject.SetActive(false);
            iconsDescribe.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            iconsDescribe.transform.GetChild(0).gameObject.SetActive(true);
            iconsDescribe.transform.GetChild(1).gameObject.SetActive(true);
        }
        playSel.SetActive(true);
        fPlay.SetActive(true);
        fSettings.SetActive(true);
    }
    void RemovePlayMenuItems()
    {
        numPl.SetActive(false);
        fPlay.SetActive(false);
        fSettings.SetActive(false);
        iconsDescribe.SetActive(false);
        playSel.SetActive(false);
        numSp.SetActive(false);
        numCar.SetActive(false);
        numMar.SetActive(false);
        TopicBG.SetActive(false);
        topic.GetComponent<TextMesh>().text = "";
    }
    void ShowModes()
    {
        gmPar.transform.position = new Vector3(0, -0.45f, -3);
        foreG.SetActive(true);
        darkEdge.SetActive(false);
        StartCoroutine("MoveModeUp");
    }
    IEnumerator RemoveModes(GameObject mode)
    {
        StopCoroutine("MoveModeUp");
        StopCoroutine("MoveModeDown");
        gmPar.transform.DetachChildren();
        curCorou = StartCoroutine(ScaleMode(mode));
        float tran = 0;
        float speed = 0.2f;
        Color c = new Color();
        while (tran < speed)
        {
            tran += Time.deltaTime;
            for (int i = 0; i < gameModes.Length; i++)
            {
                if (mode != gameModes[i])
                {
                    c = gameModes[i].GetComponent<MeshRenderer>().material.color;
                    c.a = Mathf.Lerp(1, 0, (tran / speed));
                    gameModes[i].GetComponent<MeshRenderer>().material.color = c;
                    yield return null;
                }
            }
        }
        gmPar.transform.position = new Vector3(0, 11.55f, -3);
    }
    void RemoveModesBack()
    {
        StopCoroutine("MoveModeUp");
        StopCoroutine("MoveModeDown");
        if (curCorou != null) StopCoroutine(curCorou);
        gmPar.transform.position = new Vector3(0, 11.55f, -3);
        for (int i = 0; i < gameModes.Length; i++)
        {
            gameModes[i].transform.localScale = iniModeScale;
            gameModes[i].transform.position = origModePos[i];
            Color c = gameModes[i].GetComponent<MeshRenderer>().material.color;
            c.a = 1;
            gameModes[i].GetComponent<MeshRenderer>().material.color = c;
            gameModes[i].transform.parent = gmPar.transform;
        }
    }
    IEnumerator ScaleMode(GameObject mode)
    {
        float tran = 0;
        float speed = 0.8f;
        Vector3 iniPos = mode.transform.position;
        Vector3 iniScale = mode.transform.localScale;
        Vector3 fiScale = new Vector3(iniScale.x * 1.5f, iniScale.y * 1.5f, 1);
        while (tran < speed)
        {
            tran += Time.deltaTime;
            mode.transform.position = Vector3.Lerp(iniPos, Vector3.forward * -3, (tran / speed));
            mode.transform.localScale = Vector3.Lerp(iniScale, fiScale, (tran / speed));
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        mode.transform.localScale = iniScale;
        for (int i = 0; i < gameModes.Length; i++)
        {
            gameModes[i].transform.position = origModePos[i];
            Color c = gameModes[i].GetComponent<MeshRenderer>().material.color;
            c.a = 1;
            gameModes[i].GetComponent<MeshRenderer>().material.color = c;
            gameModes[i].transform.parent = gmPar.transform;
        }
        curMenu = selectedMenu;
        if (curMenu == MenuStates.Single)
        {
            ShowMainMenuItems(false);
            ShowPlayMenuItems();
            topic.GetComponent<TextMesh>().text = "SINGLE PLAYER";
        }
        else
        {
            ShowMainMenuItems(false);
            ShowPlayMenuItems();
            topic.GetComponent<TextMesh>().text = "LOCAL MULTIPLAYER";
        }
    }
    IEnumerator MoveModeUp()
    {
        float tran = 0;
        float speed = gameModeTransSpeed;
        while (tran < speed)
        {
            tran += Time.deltaTime;
            gmPar.transform.position = Vector3.Lerp(new Vector3(0, -0.45f, -3), new Vector3(0, 0.05f, -3), (tran / speed));
            yield return null;
        }
        StartCoroutine("MoveModeDown");
    }
    IEnumerator MoveModeDown()
    {
        float tran = 0;
        float speed = gameModeTransSpeed;
        while (tran < speed)
        {
            tran += Time.deltaTime;
            gmPar.transform.position = Vector3.Lerp(new Vector3(0, 0.05f, -3), new Vector3(0, -0.45f, -3), (tran / speed));
            yield return null;
        }
        StartCoroutine("MoveModeUp");
    }
    void UpdateModeData(int gameM)
    {
        if (gameM == 0)
        {
            dataScript.tender = false;
            dataScript.streak = false;
        }
        else if (gameM == 1)
        {
            dataScript.tender = true;
            dataScript.streak = false;
        }
        else if (gameM == 2)
        {
            dataScript.tender = false;
            dataScript.streak = true;
        }
    }
    void PlayerToggle(int ind, int prevInd)
    {
        MeshRenderer mR = playSel.transform.GetChild(ind).gameObject.GetComponent<MeshRenderer>();
        if (curMenu == MenuStates.Single)
        {
            if (mR.material.mainTexture == me)
            {
                mR.material.mainTexture = ai;
                dataScript.myPos = 9;
                playSel.transform.GetChild(ind).GetChild(0).GetComponent<TextMesh>().text = "";
                dataScript.realPlayers.Clear();
            }
            else
            {
                mR.material.mainTexture = me;
                dataScript.myPos = ind;
                playSel.transform.GetChild(ind).GetChild(0).GetComponent<TextMesh>().text = dataScript.playerName;
                if (prevInd != ind && prevInd < dataScript.numOfPlayers)
                {
                    playSel.transform.GetChild(prevInd).gameObject.GetComponent<MeshRenderer>().material.mainTexture = ai;
                    playSel.transform.GetChild(prevInd).GetChild(0).GetComponent<TextMesh>().text = "";
                }
                dataScript.realPlayers = new List<int> { ind };
            }
        }
        else
        {
            if (mR.material.mainTexture == me)
            {
                mR.material.mainTexture = op;
                playSel.transform.GetChild(ind).GetChild(0).GetComponent<TextMesh>().text = "";
                dataScript.myPos = 9;
            }
            else if (mR.material.mainTexture == op)
            {
                mR.material.mainTexture = ai;
                playSel.transform.GetChild(ind).GetChild(0).GetComponent<TextMesh>().text = "";
                dataScript.realPlayers.Remove(ind);
            }
            else
            {
                bool alreadyMe = false;
                int nONP = 8 - int.Parse(numPl.transform.GetChild(0).GetComponent<TextMesh>().text);
                for (int i = 0; i < nONP; i++)
                {
                    if (playSel.transform.GetChild(i).GetComponent<MeshRenderer>().material.mainTexture == me)
                    {
                        alreadyMe = true;
                        break;
                    }
                }
                if (!alreadyMe)
                {
                    mR.material.mainTexture = me;
                    playSel.transform.GetChild(ind).GetChild(0).GetComponent<TextMesh>().text = dataScript.playerName;
                    dataScript.myPos = ind;
                }
                else
                {
                    mR.material.mainTexture = op;
                    playSel.transform.GetChild(ind).GetChild(0).GetComponent<TextMesh>().text = "";
                }
                dataScript.realPlayers.Add(ind);
            }
        }
    }
    void IncDecCards(string but)
    {
        switch (but)
        {
            case "CardsLeftButton": dataScript.numOfCards--;
                if (dataScript.numOfCards < 1) dataScript.numOfCards = 1;
                numCar.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.numOfCards.ToString();
                break;
            case "CardsRightButton": dataScript.numOfCards++;
                if (dataScript.numOfCards > (int)(48 / dataScript.numOfPlayers)) dataScript.numOfCards = (int)(48 / dataScript.numOfPlayers);
                numCar.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.numOfCards.ToString();
                break;
        }
        PlayerPrefs.SetInt("nCards", dataScript.numOfCards);
    }
    void IncDecPlayers(string but)
    {
        switch (but)
        {
            case "PlaysLeftButton": dataScript.numOfPlayers--;
                if (dataScript.numOfPlayers < 2) dataScript.numOfPlayers = 2;
                numPl.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.numOfPlayers.ToString();
                playSel.transform.GetChild(dataScript.numOfPlayers).GetComponent<MeshRenderer>().material.mainTexture = empty;
                playSel.transform.GetChild(dataScript.numOfPlayers).GetChild(0).GetComponent<TextMesh>().text = "";
                dataScript.realPlayers.Remove(dataScript.numOfPlayers);
                break;
            case "PlaysRightButton": dataScript.numOfPlayers++;
                if (dataScript.numOfPlayers > 8) dataScript.numOfPlayers = 8;
                numPl.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.numOfPlayers.ToString();
                playSel.transform.GetChild(dataScript.numOfPlayers - 1).GetComponent<MeshRenderer>().material.mainTexture = ai;
                if (dataScript.numOfCards > (int)(48 / dataScript.numOfPlayers))
                {
                    dataScript.numOfCards = (int)(48 / dataScript.numOfPlayers);
                    numCar.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.numOfCards.ToString();
                }
                break;
        }
        PlayerPrefs.SetInt("nPlay", dataScript.numOfPlayers);
    }
    void IncDecStock(string but)
    {
        switch (but)
        {
            case "MarketLeftButton": dataScript.tenderStock--;
                if (dataScript.tenderStock < 1) dataScript.tenderStock = 1;
                if (dataScript.tenderStock == 1)
                    numMar.transform.GetChild(0).GetComponent<TextMesh>().text = "1st";
                else if (dataScript.tenderStock == 2)
                    numMar.transform.GetChild(0).GetComponent<TextMesh>().text = "2nd";
                else if (dataScript.tenderStock == 3)
                    numMar.transform.GetChild(0).GetComponent<TextMesh>().text = "3rd";
                else
                    numMar.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.tenderStock.ToString() + "th";
                break;
            case "MarketRightButton": dataScript.tenderStock++;
                if (dataScript.tenderStock > 10) dataScript.tenderStock = 10;
                if (dataScript.tenderStock == 1)
                    numMar.transform.GetChild(0).GetComponent<TextMesh>().text = "1st";
                else if (dataScript.tenderStock == 2)
                    numMar.transform.GetChild(0).GetComponent<TextMesh>().text = "2nd";
                else if (dataScript.tenderStock == 3)
                    numMar.transform.GetChild(0).GetComponent<TextMesh>().text = "3rd";
                else
                    numMar.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.tenderStock.ToString() + "th";
                break;
        }
        PlayerPrefs.SetInt("tStock", dataScript.tenderStock);
    }
    void IncDecStreakGoal(string but)
    {
        switch (but)
        {
            case "SPLeftButton": dataScript.streakPointGoal -= 50;
                if (dataScript.streakPointGoal < 50) dataScript.streakPointGoal = 50;
                numSp.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.streakPointGoal.ToString();
                break;
            case "SPRightButton": dataScript.streakPointGoal += 50;
                numSp.transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.streakPointGoal.ToString();
                break;
        }
        PlayerPrefs.SetInt("SPG", dataScript.streakPointGoal);
    }
    void IncDecDifficulty(string but)
    {
        switch (but)
        {
            case "AILeftButton": dataScript.aiDifficulty--;
                if (dataScript.aiDifficulty < 0) dataScript.aiDifficulty = 0;
                break;
            case "AIRightButton": dataScript.aiDifficulty ++;
                if (dataScript.aiDifficulty > 2) dataScript.aiDifficulty = 2;
                break;
        }
        switch (dataScript.aiDifficulty)
        {
            case 0: diffText.text = "Easy";
                break;
            case 1: diffText.text = "Medium";
                break;
            case 2: diffText.text = "Hard";
                break;
        }
        PlayerPrefs.SetInt("aiDiff", dataScript.aiDifficulty);
    }
    void ShowMultiMenuItems(bool show)
    {
        locBut.SetActive(show);
        blueBut.SetActive(show);
        lanBut.SetActive(show);
        webBut.SetActive(show);
        //foreG.SetActive(!show);
        //darkEdge.SetActive(show);
    }
    void ShowOptions(bool show)
    {
        settingsBut.SetActive(show);
        abtBut.SetActive(show);
        helpBut.SetActive(show);
        foreG.SetActive(show);
        darkEdge.SetActive(!show);
        TopicBG.SetActive(show);
        topic.GetComponent<TextMesh>().text = show ? "OPTIONS" : "";
        profile.SetActive(!show);
        gameLogo.SetActive(!show);
        backBut.SetActive(show);
        playBut.SetActive(!show);
        optBut.SetActive(!show);
    }
    void ShowSettings(bool show)
    {
        cardsPar.SetActive(show);
        if (!fromPlay)
        {
            settingsBut.SetActive(!show);
            abtBut.SetActive(!show);
            helpBut.SetActive(!show);
            TopicBG.SetActive(show);
            topic.GetComponent<TextMesh>().text = show ? "SETTINGS" : "";
        }
        else
        {
            curMenu = selectedMenu;
            if (curMenu == MenuStates.Single)
            {
                topic.GetComponent<TextMesh>().text = show ? "SETTINGS" : "SINGLE PLAYER";
            }
            else
            {
                topic.GetComponent<TextMesh>().text = show ? "SETTINGS" : "LOCAL MULTIPLAYER";
            }
        }
    }
    void CardsToggle(GameObject card)
    {
        int ca = int.Parse(card.name.Replace("Card", ""));
        if (dataScript.disabledCards.Contains(ca))
        {
            dataScript.disabledCards.Remove(ca);
            Destroy(card.transform.GetChild(0).gameObject);
        }
        else
        {
            dataScript.disabledCards.Add(ca);
            cardCov = (GameObject)Instantiate(cardCovPrefab, card.transform.position - Vector3.forward * 0.5f, Quaternion.identity);
            cardCov.transform.parent = card.transform;
        }
        string nn = "";
        for (int i = 0; i < dataScript.disabledCards.Count; i++)
        {
            nn += dataScript.disabledCards[i].ToString();
            if (i != dataScript.disabledCards.Count - 1) nn += ",";
        }
        PlayerPrefs.SetString("dCards", nn);
    }
    void DGToggle(GameObject cB)
    {
        MeshRenderer mR = cB.GetComponent<MeshRenderer>();
        if (dataScript.doubleGame)
        {
            dataScript.doubleGame = false;
            PlayerPrefs.SetInt("dGame", 0);
            mR.material.mainTexture = unTicked;
        }
        else
        {
            dataScript.doubleGame = true;
            PlayerPrefs.SetInt("dGame", 1);
            mR.material.mainTexture = ticked;
        }
    }
    void UpdatePlayerSelect()
    {
        prevPlaysInd = 0;
        for (int i = 0; i < 8; i++)
        {
            if (i < 2)
                playSel.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.mainTexture = ai;
            else
                playSel.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.mainTexture = empty;
            playSel.transform.GetChild(i).GetChild(0).GetComponent<TextMesh>().text = "";
        }
        int temp = dataScript.numOfPlayers;
        dataScript.numOfPlayers = 2;
        for (int i = 0; i < temp - 2; i++)
        {
            IncDecPlayers("PlaysRightButton");
        }
        dataScript.myPos = 0;
        dataScript.realPlayers = new List<int> { 0 };
        playSel.transform.GetChild(dataScript.myPos).gameObject.GetComponent<MeshRenderer>().material.mainTexture = me;
        playSel.transform.GetChild(dataScript.myPos).transform.GetChild(0).GetComponent<TextMesh>().text = dataScript.playerName;
    }
    void GoBack()
    {
        if (new string[] { "Single", "Local" }.Contains(System.Enum.GetName(typeof(MenuStates), curMenu)))
        {
            RemovePlayMenuItems();
            ShowModes();
            curMenu = MenuStates.Mode;
        }
        else if (curMenu == MenuStates.Multi)
        {
            ShowMultiMenuItems(false);
            ShowMainMenuItems(true);
            curMenu = MenuStates.Play;
        }
        else if (curMenu == MenuStates.Mode)
        {
            RemoveModesBack();
            ShowMainMenuItems(true);
            curMenu = MenuStates.Play;
        }
        else if (curMenu == MenuStates.Play)
        {
            playBut.GetComponent<MeshRenderer>().material.mainTexture = pla;
            optBut.GetComponent<MeshRenderer>().material.mainTexture = opt;
            curMenu = MenuStates.MainMenu;
            backBut.SetActive(false);
        }
        else if (curMenu == MenuStates.Options)
        {
            curMenu = MenuStates.MainMenu;
            ShowOptions(false);
        }
        else if (curMenu == MenuStates.Settings)
        {
            if (!fromPlay)
            {
                ShowSettings(false);
                ShowOptions(true);
                curMenu = MenuStates.Options;
            }
            else
            {
                ShowSettings(false);
                ShowPlayMenuItems();
                fromPlay = false;
                curMenu = selectedMenu;
            }
        }
        else if (curMenu == MenuStates.Help)
        {
            ShowHelp(false);
            curMenu = MenuStates.Options;
        }
        else if (curMenu == MenuStates.About)
        {
            ShowAbout(false);
            curMenu = MenuStates.Options;
        }
        else if (curMenu == MenuStates.Profile)
        {
            ShowProfile(false);
            dataScript.playerName = profPar.transform.GetChild(1).GetComponent<TextMesh>().text;
            PlayerPrefs.SetString("pName", dataScript.playerName);
            curMenu = selectedMenu;
        }
    }
    void ShowHelp(bool show)
    {
        settingsBut.SetActive(!show);
        abtBut.SetActive(!show);
        helpBut.SetActive(!show);
        topic.GetComponent<TextMesh>().text = show ? "HELP" : "OPTIONS";

        helpPar.SetActive(show);
        if (show)
        {
            Color c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = 0.93f;
            foreG.GetComponent<MeshRenderer>().material.color = c;
            //GameObject foreGHelp = (GameObject)Instantiate(foreG, foreG.transform.position, foreG.transform.rotation);
            //foreGHelp.name = "ForeGHelp";
        }
        else
        {
            Color c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = 0.7f;
            foreG.GetComponent<MeshRenderer>().material.color = c;
            //Destroy(GameObject.Find("ForeGHelp"));
        }
    }
    bool CanScrollEffect()
    {
        bool scroll = false;
        if (canScroll)
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
        float slowFactor = 0.01f;
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
    void ShowAbout(bool show)
    {
        settingsBut.SetActive(!show);
        abtBut.SetActive(!show);
        helpBut.SetActive(!show);
        aboutPar.SetActive(show);
        topic.GetComponent<TextMesh>().text = show ? "ABOUT" : "OPTIONS";
        if (show)
        {
            Color c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = 0.93f;
            foreG.GetComponent<MeshRenderer>().material.color = c;
        }
        else
        {
            Color c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = 0.7f;
            foreG.GetComponent<MeshRenderer>().material.color = c;
        }
    }
    void ShowProfile(bool show)
    {
        profile.SetActive(!show);
        gameLogo.SetActive(!show);
        foreG.SetActive(show);
        darkEdge.SetActive(!show);
        TopicBG.SetActive(show);
        playBut.SetActive(!show);
        optBut.SetActive(!show);
        topic.GetComponent<TextMesh>().text = show ? "PROFILE" : "";
        profPar.SetActive(show);
        if (show)
        {
            Color c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = 0.93f;
            foreG.GetComponent<MeshRenderer>().material.color = c;
        }
        else
        {
            Color c = foreG.GetComponent<MeshRenderer>().material.color;
            c.a = 0.7f;
            foreG.GetComponent<MeshRenderer>().material.color = c;
        }
        if (selectedMenu == MenuStates.MainMenu)
            backBut.SetActive(show);
    }
    enum MenuStates
    {
        MainMenu,
        Play,
        Options,
        Settings,
        Mode,
        Single,
        Multi,
        Local,
        Help,
        About,
        Profile
    }
    enum GameModes
    {
        Whot,
        Tender,
        Streak
    }
    //void OnGUI()
    //{
    //    int w = Screen.width, h = Screen.height;

    //    GUIStyle style = new GUIStyle();

    //    Rect rect = new Rect(w/2, 0, w, h * 2 / 100);
    //    style.alignment = TextAnchor.UpperLeft;
    //    style.fontSize = h * 4 / 100;
    //    style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    //    string text = deltaWorld.ToString();
    //    GUI.Label(rect, text, style);
    //}
}
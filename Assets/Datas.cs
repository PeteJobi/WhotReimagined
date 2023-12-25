using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Datas : MonoBehaviour {
    public Menus menuScript;
    public CardsMan cardsManScript;
    public int numOfPlayers;
    public List<int> realPlayers;
    public int numOfCards;
    public bool tender, streak;
    public int aiDifficulty;
    public int myPos;
    public int tenderStock, streakPointGoal;
    public List<int> disabledCards;
    public bool doubleGame;
    public bool startedFromLogos;
    public string playerName;
    public int totalSP;
    public Texture2D myPic;
    public int[] stats;
	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(this.gameObject);
        myPos = 0;
        numOfPlayers = PlayerPrefs.GetInt("nPlay", 4);
        numOfCards = PlayerPrefs.GetInt("nCards", 4);
        realPlayers = new List<int> { 0 };
        disabledCards = new List<int>();
        string dC = PlayerPrefs.GetString("dCards", "");
        if (dC != "")
        {
            string[] nn = dC.Split(',');
            for (int i = 0; i < nn.Length; i++)
            {
                disabledCards.Add(int.Parse(nn[i]));
            }
        }
        tenderStock = PlayerPrefs.GetInt("tStock", 1);
        streakPointGoal = PlayerPrefs.GetInt("SPG", 100);
        aiDifficulty = PlayerPrefs.GetInt("aiDiff", 1);
        doubleGame = PlayerPrefs.GetInt("dGame", 1) == 1 ? true : false;
        playerName = PlayerPrefs.GetString("pName", "Doctore");
        totalSP = PlayerPrefs.GetInt("tSP", 0);
        myPic = (Texture2D)Resources.Load("ProfilePicture");
        stats = new int[9];
        string st = PlayerPrefs.GetString("sta", "0,0,0,0,0,0,0,0,0");
        if (st != "")
        {
            string[] nn = st.Split(',');
            for (int i = 0; i < nn.Length; i++)
            {
                stats[i] = int.Parse(nn[i]);
            }
        }
	}
	
	// Update is called once per frame
    //void Update () {
	
    //}
}

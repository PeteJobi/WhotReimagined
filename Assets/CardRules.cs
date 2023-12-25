using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardRules : MonoBehaviour {
    public CardsMan cardsMan;
    public InputMan inputSc;
    public bool canPlay;
    public List<string> cardSuits;
    public List<int> cardValues;
    public List<GameObject> allCards;
    public List<GameObject> playerHand;
    public List<int> playerHandCInd;
    public int curCardInd;
    public List<int> specCards;
    public List<int> allSpecCards;
    public List<GameObject> canBePlayed;
    public List<GameObject> cannotBePlayed;
    public bool hasGTM;
    public bool gTM;
    public int gTMVal;
    public bool gM;
    public bool reverse;
    public string cur;
    public List<int> repTurnCards;
    public List<int> marCards;
	// Use this for initialization
	void Start () {
        cardsMan = GetComponent<CardsMan>();
        inputSc = GetComponent<InputMan>();
        allSpecCards = new List<int> { 1, 2, 5, 8, 12, 14, 20 };
        specCards = new List<int>{1, 2, 5, 8, 12, 14};
        repTurnCards = cardsMan.totNum > 2 ? new List<int> { 1, 14 } : new List<int> { 1, 14, 8 };
        marCards = new List<int> { 2, 5 };
        RemoveDisabledCards();
        cardValues = cardsMan.cardValues;
        cardSuits = cardsMan.cardSuits;
        allCards = cardsMan.allCards;
	}
	
	// Update is called once per frame
	/*void Update () {
        if (Input.GetKeyDown("q"))
        {
            Time.timeScale = 1;
        }
	}*/
    public void CheckPlay()
    {
        ClearPrevious();
        curCardInd = cardsMan.curCardInd;
        cur = cardSuits[curCardInd] + " " + cardValues[curCardInd];
        hasGTM = cardsMan.hasGTM;
        if (!specCards.Contains(cardValues[curCardInd]) || hasGTM)
        {
            IncrementTurn(1);
            CheckCards();
        }
        else
        {
            if (!hasGTM)
            {
                if (cardValues[curCardInd] == 2 || cardValues[curCardInd] == 5)
                {
                    IncrementTurn(1);
                    gTM = true;
                    if (cardValues[curCardInd] == 2)
                    {
                        gTMVal += 2;
                    }
                    else
                    {
                        gTMVal += 3;
                    }
                    CheckSameVal();
                }
                else if (cardValues[curCardInd] == 1)
                {
                    if(cardsMan.turn<0)
                        cardsMan.turn = 0;
                    RefreshCards();
                    CheckCards();

                }
                else if (cardValues[curCardInd] == 8)
                {
                    if (cardSuits[curCardInd] == "Star" && cardsMan.playersLeft>2)
                    {
                        IncrementTurn(3);
                        CheckCards();
                    }
                    else
                    {
                        IncrementTurn(2);
                        CheckCards();
                    }
                }
                else if (cardValues[curCardInd] == 12)
                {
                    if (!reverse)
                    {
                        reverse = true;
                    }
                    else
                    {
                        reverse = false;
                    }
                    IncrementTurn(1);
                    CheckCards();
                }
                else if (cardValues[curCardInd] == 14)
                {
                    gM = true;
                    if (cardsMan.turn < 0)
                        cardsMan.turn = 0;
                    RefreshCards();
                    CheckCards();
                }
            }
        }
    }
    public void IncrementTurn(int increment)
    {
        string gb = "";
        gb += cardsMan.turn.ToString()+"   ";
        List<int> outt = new List<int>();
        outt.AddRange(cardsMan.checkedOut);
        outt.Sort();
        if (!reverse)
        {
            for (int j = 0; j < increment; j++)
            {
                cardsMan.turn++;
                if (cardsMan.turn >= cardsMan.playHands.Count)
                {
                    cardsMan.turn -= cardsMan.playHands.Count;
                }
                else if (cardsMan.turn < 0)
                {
                    cardsMan.turn += cardsMan.playHands.Count;
                }
                for (int i = 0; i < outt.Count; i++)
                {
                    gb += " " + outt[i];
                    if (outt.Contains(cardsMan.turn))
                    {
                        cardsMan.turn++;
                        if (cardsMan.turn >= cardsMan.playHands.Count)
                        {
                            cardsMan.turn -= cardsMan.playHands.Count;
                        }
                        else if (cardsMan.turn < 0)
                        {
                            cardsMan.turn += cardsMan.playHands.Count;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        else
        {
            for (int j = 0; j < increment; j++)
            {
                cardsMan.turn--;
                if (cardsMan.turn >= cardsMan.playHands.Count)
                {
                    cardsMan.turn -= cardsMan.playHands.Count;
                }
                else if (cardsMan.turn < 0)
                {
                    cardsMan.turn += cardsMan.playHands.Count;
                }
                for (int i = (outt.Count - 1); i >= 0; i--)
                {
                    if (/*cardsMan.turn == outt[i]*/outt.Contains(cardsMan.turn))
                    {
                        gb += " " + outt[i];
                        cardsMan.turn--;
                        if (cardsMan.turn >= cardsMan.playHands.Count)
                        {
                            cardsMan.turn -= cardsMan.playHands.Count;
                        }
                        else if (cardsMan.turn < 0)
                        {
                            cardsMan.turn += cardsMan.playHands.Count;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        //Debug.Log(gb+"   "+cardsMan.turn);
        RefreshCards();
    }
    public void CheckCards()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            if (cardValues[playerHandCInd[i]] == cardValues[curCardInd] || cardSuits[playerHandCInd[i]] == cardSuits[curCardInd] || cardValues[playerHandCInd[i]] == 20)
            {
                //Debug.Log(cardSuits[playerHandCInd[i]] + " b " + cardValues[playerHandCInd[i]]);
                canBePlayed.Add(playerHand[i]);
            }
            else
            {
                cannotBePlayed.Add(playerHand[i]);
            }
        }
    }
    public void CheckSameVal()
    {
        if (inputSc.sel)
        {
            curCardInd = allCards.IndexOf(playerHand[inputSc.cardInd]);
        }
        for (int i = 0; i < playerHand.Count; i++)
        {
            if (cardValues[playerHandCInd[i]] == cardValues[curCardInd])
            {
                canBePlayed.Add(playerHand[i]);
            }
            else
            {
                cannotBePlayed.Add(playerHand[i]);
            }
        }
    }
    public void RefreshCards()
    {
        curCardInd = cardsMan.curCardInd;
        playerHand = cardsMan.playHands[cardsMan.turn];
        foreach (GameObject item in playerHand)
        {
            playerHandCInd.Add(allCards.IndexOf(item));
        }
    }
    public void ClearPrevious()
    {
        canBePlayed.Clear();
        cannotBePlayed.Clear();
        playerHandCInd.Clear();
    }
    public void RemoveDisabledCards()
    {

        foreach (int item in cardsMan.disabledCards)
        {
            allSpecCards.Remove(item);
            specCards.Remove(item);
            repTurnCards.Remove(item);
            marCards.Remove(item);
        }
    }
    /*void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(w / 2, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        string text="";
        text = (cardSuits[curCardInd]+" "+cardValues[curCardInd]).ToString();
        //GUI.Label(rect, text, style);
    }*/
}

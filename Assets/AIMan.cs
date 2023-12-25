using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AIMan : MonoBehaviour
{
    public CardsMan cardsMan;
    public CardRules cardRules;
    public List<GameObject> canBePlayed;
    public List<GameObject> cannotBePlayed;
    public List<string> cardSuits;
    public List<int> cardValues;
    public List<GameObject> allCards;
    public List<int> playList;
    public List<GameObject> aiHand;
    public string nSuit;
    public bool doubleGame;
    public GameObject playCard;
    public List<GameObject> nextHand;
    public int inDex;
    public List<int> sp;
    public List<int> rp;
    public List<int> mp;
    public int pInd;
    public bool tender;
    public bool comStreak;
    AiDifficulty diff;
    // Use this for initialization
    void Start()
    {
        cardsMan = GetComponent<CardsMan>();
        cardRules = GetComponent<CardRules>();
        cardValues = cardsMan.cardValues;
        cardSuits = cardsMan.cardSuits;
        allCards = cardsMan.allCards;
        doubleGame = cardsMan.doubleGame;
        tender = cardsMan.tender;
        comStreak = cardsMan.comStreak;
        diff = (AiDifficulty)cardsMan.aiDifficulty;
        //string[] difficulties = Enum.GetNames(typeof(AiDifficulty));
        //int diffInt = (int)Enum.Parse(typeof(AiDifficulty), difficulties[0]);
        //string diffString = Enum.GetName(typeof(AiDifficulty), diffInt);
        //sp.Remove(2);
        //sp.Remove(5);
    }

    // Update is called once per frame
    /*void Update () {
	
    }*/

    public void AIPlay(int inD)
    {
        pInd = 0;
        inDex = inD;
        playList.Clear();
        canBePlayed = cardRules.canBePlayed;
        cannotBePlayed = cardRules.cannotBePlayed;
        aiHand = cardsMan.playHands[cardsMan.turn];
        CalcNextHand();
        playCard = cardsMan.playPile[cardsMan.playPile.Count - 1];
        sp.AddRange(cardRules.allSpecCards);
        rp.AddRange(cardRules.repTurnCards);
        mp.AddRange(cardRules.marCards);
        /*if (level == 1)
        {
           pInd  = aiHand.IndexOf(canBePlayed[UnityEngine.Random.Range(0, canBePlayed.Count)]);
           playList.Add(pInd);
        }*/
        if (doubleGame && diff!=AiDifficulty.easy)
        {
            int[] freqNu = new int[canBePlayed.Count];
            int[] valNu = new int[canBePlayed.Count];
            int[] mult = new int[canBePlayed.Count];
            for (int i = 0; i < canBePlayed.Count; i++)
            {
                for (int j = 0; j < aiHand.Count; j++)
                {
                    if (cardValues[allCards.IndexOf(canBePlayed[i])] == cardValues[allCards.IndexOf(aiHand[j])])
                    {
                        if (!tender)
                        {
                            if (!comStreak)
                            {
                                if (!cardRules.specCards.Contains(cardValues[allCards.IndexOf(canBePlayed[i])]) && cardValues[allCards.IndexOf(canBePlayed[i])] != 20)
                                {
                                    freqNu[i]++;
                                    valNu[i] = cardValues[allCards.IndexOf(canBePlayed[i])];
                                }
                            }
                            else
                            {
                                freqNu[i]++;
                                valNu[i] = cardValues[allCards.IndexOf(canBePlayed[i])];
                            }
                        }
                        else
                        {
                            if (!TenderSp().Contains(cardValues[allCards.IndexOf(canBePlayed[i])]))
                            {
                                freqNu[i]++;
                                valNu[i] = cardValues[allCards.IndexOf(canBePlayed[i])];
                                if (cardSuits[allCards.IndexOf(canBePlayed[i])] == "Star")
                                    valNu[i] *= 2;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < mult.Length; i++)
            {
                mult[i] = freqNu[i] * valNu[i];
            }
            int[] usin = new int[canBePlayed.Count];
            if (!tender)
            {
                playList.Add(aiHand.IndexOf(canBePlayed[Array.IndexOf(freqNu, freqNu.Max())]));
                usin = freqNu;
                if (comStreak && rp.Contains(cardValues[allCards.IndexOf(aiHand[playList[0]])]) && !Links())
                {
                    if (AnotherPair(freqNu))
                    {
                        int u = Array.IndexOf(freqNu, freqNu.Max()) + 1;
                        freqNu[Array.IndexOf(freqNu, freqNu.Max())]--;
                        if (u == freqNu.Length)
                            u = 0;
                        playList.Clear();
                        playList.Add(aiHand.IndexOf(canBePlayed[u]));
                        usin = freqNu;
                    }
                    else
                    {
                        playList.Clear();
                        GoMarket();
                        return;
                    }
                }
            }
            else
            {
                playList.Add(aiHand.IndexOf(canBePlayed[Array.IndexOf(mult, mult.Max())]));
                usin = mult;
            }
            if (freqNu[Array.IndexOf(usin, usin.Max())] > 2)
            {
                if (cardValues[allCards.IndexOf(aiHand[playList[0]])] == cardValues[allCards.IndexOf(playCard)])
                {
                    playList.Clear();
                }
                List<string> suits = new List<string>();
                for (int i = 0; i < aiHand.Count; i++)
                {
                    if (cardValues[allCards.IndexOf(aiHand[i])] == cardValues[allCards.IndexOf(canBePlayed[Array.IndexOf(usin, usin.Max())])])
                    {
                        if (!suits.Contains(cardSuits[allCards.IndexOf(aiHand[i])]) && !playList.Contains(i))
                        {
                            suits.Add(cardSuits[allCards.IndexOf(aiHand[i])]);
                        }
                    }
                }
                int[] freqSh = new int[suits.Count];
                for (int i = 0; i < aiHand.Count; i++)
                {
                    for (int j = 0; j < suits.Count; j++)
                    {
                        if (cardSuits[allCards.IndexOf(aiHand[i])] == suits[j])
                        {
                            freqSh[j]++;
                        }
                    }
                }
                string common = suits[Array.IndexOf(freqSh, freqSh.Max())];
                int last = 0;
                for (int i = 0; i < aiHand.Count; i++)
                {
                    if (cardValues[allCards.IndexOf(aiHand[i])] == cardValues[allCards.IndexOf(canBePlayed[Array.IndexOf(usin, usin.Max())])])
                    {
                        if (cardSuits[allCards.IndexOf(aiHand[i])] != common)
                        {
                            if (!playList.Contains(i))
                                playList.Add(i);
                        }
                        else
                        {
                            last = i;
                        }
                    }
                }
                playList.Add(last);
                if (comStreak)
                {
                    if (rp.Contains(cardValues[allCards.IndexOf(aiHand[last])]) && freqSh.Max() < 2)
                    {
                        playList.Clear();
                        GoMarket();
                        return;
                    }
                }
                int bigest = 0;
                int bigInd = 0;
                for (int i = 0; i < canBePlayed.Count; i++)
                {
                    int vall = cardValues[allCards.IndexOf(canBePlayed[i])];
                    if (cardSuits[allCards.IndexOf(canBePlayed[i])] == "Star")
                        vall *= 2;
                    if (vall > bigest)
                    {
                        bigest = vall;
                        bigInd = i;
                    }
                }
                if (cardValues[allCards.IndexOf(canBePlayed[bigInd])] > (cardValues[allCards.IndexOf(aiHand[playList[0]])] * playList.Count))
                {
                    playList.Clear();
                    playList.Add(aiHand.IndexOf(canBePlayed[bigInd]));
                }
                if (!tender && !comStreak)
                    LeftWithDoubles();
            }
            else if (freqNu[Array.IndexOf(usin, usin.Max())] == 2)
            {
                for (int i = 0; i < aiHand.Count; i++)
                {
                    if (cardValues[allCards.IndexOf(aiHand[i])] == cardValues[allCards.IndexOf(canBePlayed[Array.IndexOf(usin, usin.Max())])])
                    {
                        if (!playList.Contains(i))
                            playList.Add(i);
                    }
                }
                int[] freq2 = new int[2];
                for (int i = 0; i < aiHand.Count; i++)
                {
                    if (cardSuits[allCards.IndexOf(aiHand[i])] == cardSuits[allCards.IndexOf(aiHand[playList[0]])])
                    {
                        freq2[0]++;
                    }
                    else if (cardSuits[allCards.IndexOf(aiHand[i])] == cardSuits[allCards.IndexOf(aiHand[playList[1]])])
                    {
                        freq2[1]++;
                    }
                }
                freq2[0]--;
                freq2[1]--;
                if (freq2[1] == 0 && freq2[0] > freq2[1] && aiHand.Count > 3)
                {
                    if (cardValues[allCards.IndexOf(playCard)] == cardValues[allCards.IndexOf(aiHand[playList[0]])])
                    {
                        int tem = playList[0];
                        playList[0] = playList[1];
                        playList[1] = tem;
                    }
                    else
                    {
                        if (comStreak && rp.Contains(cardValues[allCards.IndexOf(aiHand[playList[0]])]))
                        {
                            playList.Clear();
                            GoMarket();
                            return;
                        }
                        if (!tender && !comStreak)
                        {
                            playList.Clear();
                            playList.Add(PlInd());
                        }
                    }
                }
                int bigest = 0;
                int bigInd = 0;
                for (int i = 0; i < canBePlayed.Count; i++)
                {
                    int vall = cardValues[allCards.IndexOf(canBePlayed[i])];
                    if (cardSuits[allCards.IndexOf(canBePlayed[i])] == "Star")
                        vall *= 2;
                    if (vall > bigest)
                    {
                        bigest = vall;
                        bigInd = i;
                    }
                }
                if (tender && cardValues[allCards.IndexOf(canBePlayed[bigInd])] > (cardValues[allCards.IndexOf(aiHand[playList[0]])] * playList.Count))
                {
                    playList.Clear();
                    playList.Add(aiHand.IndexOf(canBePlayed[bigInd]));
                }
                if (!tender && !comStreak)
                    LeftWithDoubles();
            }
            else if (freqNu[Array.IndexOf(usin, usin.Max())] < 2)
            {
                playList.Clear();
                if (!comStreak)
                    playList.Add(PlInd());
                else
                {
                    if (All14N1() || (mp.Contains(cardValues[allCards.IndexOf(canBePlayed[0])]) && cardRules.gTM))
                    {
                        playList.Clear();
                        GoMarket();
                        return;
                    }
                    else
                    {
                        playList.Add(PlInd());
                    }
                }
            }
        }
        else
        {
            playList.Add(PlInd());
        }
        if (!tender && !comStreak && diff==AiDifficulty.hard)
            HarrassNextHand();
        if (!tender && !comStreak)
        {
            if (aiHand.Count == 1 && sp.Contains(cardValues[allCards.IndexOf(aiHand[pInd])]) && cardRules.gTMVal == 0)
            {
                playList.Clear();
                GoMarket();
                return;
            }
            if (cardValues[allCards.IndexOf(aiHand[pInd])] == 20)
            {
                string[] suits = new string[] { "Circle", "Square", "Triangle", "Cross", "Star" };
                int[] frequ = new int[suits.Length];
                for (int i = 0; i < aiHand.Count; i++)
                {
                    for (int j = 0; j < suits.Length; j++)
                    {
                        if (cardSuits[allCards.IndexOf(aiHand[i])] == suits[j])
                        {
                            frequ[j]++;
                        }
                    }
                }
                bool alDaSame = true;
                int next = pInd;
                next++;
                if (next >= aiHand.Count)
                {
                    next -= aiHand.Count;
                }
                for (int i = 0; i < aiHand.Count; i++)
                {
                    if (i != pInd)
                    {
                        if (cardValues[allCards.IndexOf(aiHand[i])] != cardValues[allCards.IndexOf(aiHand[next])])
                        {
                            alDaSame = false;
                            break;
                        }
                    }
                }
                if (frequ.Max() == 1 && aiHand.Count > 2 && !alDaSame)
                {
                    if (canBePlayed.Count <= 1)
                    {
                        playList.Clear();
                        GoMarket();
                        return;
                    }
                    else
                    {
                        playList.Clear();
                        int ni = canBePlayed.IndexOf(aiHand[pInd]);
                        ni++;
                        if (ni >= canBePlayed.Count)
                        {
                            ni -= canBePlayed.Count;
                        }
                        playList.Add(aiHand.IndexOf(canBePlayed[ni]));
                    }
                }
                bool hasOrdCard = false;
                for (int i = 0; i < aiHand.Count; i++)
                {
                    if (i != pInd && !cardRules.specCards.Contains(cardValues[allCards.IndexOf(aiHand[i])]))
                    {
                        hasOrdCard = true;
                    }
                }
                if (!hasOrdCard)
                {
                    playList.Clear();
                    GoMarket();
                    return;
                }
            }
            if (cardRules.gTM && mp.Contains(cardValues[allCards.IndexOf(aiHand[playList[0]])]))
            {
                if (diff == AiDifficulty.easy)
                {
                    playList.Clear();
                    GoMarket();
                    return;
                }
                else if (diff == AiDifficulty.medium)
                {
                    int go = UnityEngine.Random.Range(0, 11);
                    if (go != 3)
                    {
                        playList.Clear();
                        GoMarket();
                        return;
                    }
                }
            }
        }
        StartCoroutine(cardsMan.PlayCard(inDex, playList));
    }
    public int PlInd()
    {
        int pInddd = 0;
        if (aiHand.Count > 2)
        {
            int ran = UnityEngine.Random.Range(0, canBePlayed.Count);
            pInddd = aiHand.IndexOf(canBePlayed[ran]);
            if (cardValues[allCards.IndexOf(aiHand[pInddd])] == 20 && canBePlayed.Count > 1)
            {
                if (ran == 0)
                {
                    pInddd = aiHand.IndexOf(canBePlayed[ran + 1]);
                }
                else
                {
                    pInddd = aiHand.IndexOf(canBePlayed[ran - 1]);
                }
            }
        }
        else
        {
            int ran = UnityEngine.Random.Range(0, canBePlayed.Count);
            pInddd = aiHand.IndexOf(canBePlayed[ran]);
            for (int i = 0; i < canBePlayed.Count; i++)
            {
                if (cardRules.specCards.Contains(cardValues[allCards.IndexOf(canBePlayed[i])]))
                {
                    pInddd = aiHand.IndexOf(canBePlayed[i]);
                    break;
                }
                else if (cardValues[allCards.IndexOf(canBePlayed[i])] == 20)
                {
                    pInddd = aiHand.IndexOf(canBePlayed[i]);
                }
            }
        }
        if (!cardRules.specCards.Contains(cardValues[allCards.IndexOf(aiHand[pInddd])]))
        {
            for (int i = 0; i < canBePlayed.Count; i++)
            {
                if (rp.Contains(cardValues[allCards.IndexOf(canBePlayed[i])]))
                {
                    pInddd = aiHand.IndexOf(canBePlayed[i]);
                    break;
                }
            }
        }
        if (tender)
        {
            int bigest = 0;
            for (int i = 0; i < canBePlayed.Count; i++)
            {
                int vall = cardValues[allCards.IndexOf(canBePlayed[i])];
                if (cardSuits[allCards.IndexOf(canBePlayed[i])] == "Star")
                    vall *= 2;
                if (vall > bigest)
                {
                    bigest = vall;
                    pInddd = aiHand.IndexOf(canBePlayed[i]);
                }
            }
        }
        else if (comStreak)
        {
            pInddd = StreakPlay();
        }
        pInd = pInddd;
        return pInddd;
    }
    public string MySuit()
    {
        string[] suits = new string[] { "Circle", "Square", "Triangle", "Cross", "Star" };
        int[] freq = new int[suits.Length];
        int[] valNu = new int[suits.Length];
        for (int i = 0; i < aiHand.Count; i++)
        {
            for (int j = 0; j < suits.Length; j++)
            {
                if (cardSuits[allCards.IndexOf(aiHand[i])] == suits[j])
                {
                    freq[j]++;
                    int vv = cardValues[allCards.IndexOf(aiHand[i])];
                    if (cardSuits[allCards.IndexOf(aiHand[i])] == "Star")
                        vv *= 2;
                    valNu[j] += vv;
                }
            }
        }
        int[] usin = new int[aiHand.Count];
        if (!tender)
        {
            usin = freq;
        }
        else
        {
            usin = valNu;
        }
        return suits[Array.IndexOf(usin, usin.Max())];
    }
    void GoMarket()
    {
        if (!cardRules.gTM)
            StartCoroutine(cardsMan.GoToMarket(inDex, 1));
        else
        {
            StartCoroutine(cardsMan.GoToMarket(inDex, cardRules.gTMVal));
        }
    }
    void HarrassNextHand()
    {
        if (nextHand.Count <= 2)
        {
            List<int> marCards = new List<int> { 5, 2, 14, 8, 12, 1 };
            for (int i = 0; i < canBePlayed.Count; i++)
            {
                for (int j = 0; j < marCards.Count; j++)
                {
                    if (cardValues[allCards.IndexOf(canBePlayed[i])] == marCards[j])
                    {
                        playList.Clear();
                        pInd = aiHand.IndexOf(canBePlayed[i]);
                        playList.Add(pInd);
                        i = 60;
                        break;
                    }
                }
            }
        }
    }
    void LeftWithDoubles()
    {
        if (aiHand.Count - playList.Count == 1 && canBePlayed.Count > 1)
        {
            for (int i = 0; i < canBePlayed.Count; i++)
            {
                if (cardValues[allCards.IndexOf(canBePlayed[i])] != cardValues[allCards.IndexOf(aiHand[playList[0]])])
                {
                    playList.Clear();
                    pInd = aiHand.IndexOf(canBePlayed[i]);
                    playList.Add(pInd);
                    break;
                }
            }
        }
    }
    List<int> TenderSp()
    {
        int pileCo = cardsMan.pile.Count;
        if (pileCo > 30)
        {
            sp.Remove(1);
            sp.Remove(8);
            sp.Remove(12);
            sp.Remove(20);
        }
        else if (pileCo <= 30 && pileCo > 15)
        {
            sp.Remove(1);
            sp.Remove(2);
            sp.Remove(5);
            sp.Remove(8);
            sp.Remove(12);
            sp.Remove(20);
        }
        else if (pileCo <= 15)
        {
            sp.Clear();
        }
        return sp;
    }
    int StreakPlay()
    {
        int pinnd = 0;
        bool wentForward = false;
        bool play1or14 = false;
        string[] sh = new string[2];
        int[] ind = new int[] { 100, 100 };
        for (int i = 0; i < canBePlayed.Count; i++)
        {
            if (cardValues[allCards.IndexOf(canBePlayed[i])] == 1)
            {
                ind[0] = aiHand.IndexOf(canBePlayed[i]);
                sh[0] = cardSuits[allCards.IndexOf(canBePlayed[i])];
            }
            if (cardValues[allCards.IndexOf(canBePlayed[i])] == 14)
            {
                ind[1] = aiHand.IndexOf(canBePlayed[i]);
                sh[1] = cardSuits[allCards.IndexOf(canBePlayed[i])];
            }
        }
        for (int i = 0; i < aiHand.Count; i++)
        {
            if (!ind.Contains(i) && sh.Contains(cardSuits[allCards.IndexOf(aiHand[i])]))
            {
                play1or14 = true;
                pinnd = cardSuits[allCards.IndexOf(aiHand[i])] == sh[0] ? ind[0] : ind[1];
                break;
            }
        }
        if (!play1or14)
        {

            int ran = UnityEngine.Random.Range(0, canBePlayed.Count);
            pinnd = aiHand.IndexOf(canBePlayed[ran]);
            if (rp.Contains(cardValues[allCards.IndexOf(aiHand[pinnd])])/* && canBePlayed.Count > 1*/)
            {
                if (ran == 0)
                {
                    pinnd = aiHand.IndexOf(canBePlayed[ran + 1]);
                    wentForward = true;
                }
                else
                {
                    pinnd = aiHand.IndexOf(canBePlayed[ran - 1]);
                }
            }
            if (rp.Contains(cardValues[allCards.IndexOf(aiHand[pinnd])])/* && canBePlayed.Count > 1*/)
            {
                if (wentForward)
                {
                    pinnd = aiHand.IndexOf(canBePlayed[ran + 2]);
                    wentForward = true;
                }
                else
                {
                    pinnd = aiHand.IndexOf(canBePlayed[ran - 2]);
                }
            }
            if (rp.Contains(cardValues[allCards.IndexOf(aiHand[pinnd])])/* && canBePlayed.Count > 1*/)
            {
                if (wentForward)
                {
                    pinnd = aiHand.IndexOf(canBePlayed[ran + 3]);
                    wentForward = true;
                }
                else
                {
                    pinnd = aiHand.IndexOf(canBePlayed[ran - 3]);
                }
            }
        }
        return pinnd;
    }
    bool AnotherPair(int[] frq)
    {
        bool re = false;
        int n = 0;
        for (int i = 0; i < frq.Length; i++)
        {
            if (frq[i] == frq.Max())
            {
                n++;
                if (n > 1)
                {
                    re = true;
                    break;
                }
            }
        }
        return re;
    }
    bool Links()
    {
        bool nco = false;
        int ind = cardValues[allCards.IndexOf(aiHand[playList[0]])];
        List<string> sh = new List<string>();
        for (int i = 0; i < aiHand.Count; i++)
        {
            if (i != playList[0] && cardValues[allCards.IndexOf(aiHand[i])] == ind)
            {
                sh.Add(cardSuits[allCards.IndexOf(aiHand[i])]);
            }
        }
        for (int i = 0; i < aiHand.Count; i++)
        {
            if (cardValues[allCards.IndexOf(aiHand[i])] != ind)
            {
                if (sh.Contains(cardSuits[allCards.IndexOf(aiHand[i])]))
                {
                    nco = true;
                    break;
                }
            }
        }
        return nco;
    }
    bool All14N1()
    {
        //canBePlayed.Count == 1 && (new int[]{1,14}.Contains(cardValues[allCards.IndexOf(canBePlayed[0])])
        bool yes = true;
        foreach (GameObject item in canBePlayed)
        {
            if (!rp.Contains(cardValues[allCards.IndexOf(item)]))
            {
                yes = false;
                break;
            }
        }
        return yes;
    }
    void CalcNextHand()
    {
        int t = cardsMan.turn;
        if (!cardRules.reverse)
            t++;
        else
            t--;
        if (t >= cardsMan.playHands.Count)
        {
            t -= cardsMan.playHands.Count;
        }
        else if (t < 0)
        {
            t = cardsMan.playHands.Count + t;
        }
        List<int> outt = cardsMan.checkedOut;
        if (!cardRules.reverse)
        {
            for (int i = 0; i < outt.Count; i++)
            {
                if (cardsMan.turn == outt[i])
                {
                    t++;
                    if (t >= cardsMan.playHands.Count)
                    {
                        t -= cardsMan.playHands.Count;
                    }
                    else if (t < 0)
                    {
                        t = cardsMan.playHands.Count + t;
                    }
                }
            }
        }
        else
        {
            for (int i = (outt.Count - 1); i >= 0; i--)
            {
                if (cardsMan.turn == outt[i])
                {
                    t--;
                    if (t >= cardsMan.playHands.Count)
                    {
                        t -= cardsMan.playHands.Count;
                    }
                    else if (t < 0)
                    {
                        t = cardsMan.playHands.Count + t;
                    }
                }
            }
        }
        nextHand = cardsMan.playHands[t];
    }
}
enum AiDifficulty
{
    easy,
    medium,
    hard
}

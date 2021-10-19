using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Game        
{
    public List<Card> EnemyDeck, PlayerDeck;

    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();

        
    }
    List<Card> GiveDeckCard()
    {
        List<Card> list =  new List<Card>();

        for (int i = 0; i < 10; i++)
            list.Add(CardMngr.AllCards[Random.Range(0, CardMngr.AllCards.Count)]);
        return list;
    } 
}

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr Instance; 

    public Game CurrentGame;
    public Transform EnemyHand, PlayerHand, PlayerField, EnemyField;
    public GameObject Cardprf;
    int Turn, TurnTime = 30;
    public TextMeshProUGUI TurnTimeTxt;
    public Button EndTurnBtn;

    public int PlayerMana = 10, EnemyMana = 10;

    public TextMeshProUGUI PlayerManaTxt, EnemyManaTxt;

    public int PlayerHP, EnemyHP;
    public TextMeshProUGUI PlayerHPTxt, EnemyHPTxt;

    public GameObject ResultGO;
    public TextMeshProUGUI ResultTxt;

    public AttackedHero EnemyHero,PlayerHero;

    public List<CardControllerScr> PlayerHandCards = new List<CardControllerScr>(),
                            PlayerFieldCards = new List<CardControllerScr>(),
                            EnemyHandCards = new List<CardControllerScr>(),
                            EnemyFieldCards = new List<CardControllerScr>();

    public bool IsPlayerTurn
    {
        get
        {
            return Turn % 2 == 0;
        }
    }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        StartGame();
    }

    public void RestartGame()
    {
        StopAllCoroutines();
        foreach (var card in PlayerHandCards)
            Destroy(card.gameObject);
        foreach (var card in PlayerFieldCards)
            Destroy(card.gameObject);

        foreach (var card in EnemyHandCards)
            Destroy(card.gameObject);
        foreach (var card in EnemyFieldCards)
            Destroy(card.gameObject);

        PlayerHandCards.Clear();
        PlayerFieldCards.Clear();
        EnemyHandCards.Clear();
        EnemyFieldCards.Clear();

        StartGame();
    }

    public void StartGame()
    {
        Turn = 0;
        EndTurnBtn.interactable = true;

        CurrentGame = new Game();
        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand);
        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand);

        PlayerMana = EnemyMana = 10;
        PlayerHP = EnemyHP = 30;

        ShowHP();
        ShowMana();

        ResultGO.SetActive(false);

        StartCoroutine(TurnFunc());
    }

    void GiveHandCards(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 4)
            GiveCardToHand(deck, hand);
    }

    void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;

        CreatCardPref(deck[0], hand);
        
        deck.RemoveAt(0);

    }

    void CreatCardPref(Card card, Transform hand)
    {
        GameObject cardGO = Instantiate(Cardprf, hand, false);
        CardControllerScr cardC = cardGO.GetComponent<CardControllerScr>();
        cardC.Init(card, hand == PlayerHand);
        if (cardC.IsPlayerCard)
            PlayerHandCards.Add(cardC);
        else
            EnemyHandCards.Add(cardC);
    }        
        
    IEnumerator TurnFunc()
    {
        TurnTime = 30;
        TurnTimeTxt.text = TurnTime.ToString();

        foreach (var card in PlayerFieldCards)

            card.Info.HighlightCard(false);

        CheckCardsForManaAvailability();


        if (IsPlayerTurn)
        {

            foreach (var card in PlayerFieldCards)
            {
                card.Card.CanAttack =true;
                card.Info.HighlightCard(true);
            }
            while (TurnTime-- > 0)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
            ChangeTurn();
        }
        else
        {

            foreach (var card in EnemyFieldCards)
                card.Card.CanAttack=true;
                  
            
                StartCoroutine(EnemyTurn(EnemyHandCards));
            
        }
    }

    IEnumerator EnemyTurn(List<CardControllerScr> cards)
    {

        yield return new WaitForSeconds(1);
        int count = cards.Count == 1 ? 1 :
            Random.Range(0, cards.Count);

        for (int i = 0; i < count; i++)
        {

            if (EnemyFieldCards.Count > 5 ||
                EnemyMana == 0 || 
                EnemyHandCards.Count == 0)
                break;

            List<CardControllerScr> cardsList = cards.FindAll(x => EnemyMana >= x.Card.Manacost);

            if (cardsList.Count == 0)
                break;

            cardsList[0].GetComponent<CardMovementScr>().MoveToFields(EnemyField);
            ReduceMana(false, cardsList[0].Card.Manacost);

            yield return new WaitForSeconds(.51f);

            cardsList[0].Info.ShowCardInfo();
            cardsList[0].transform.SetParent(EnemyField);

            cardsList[0].OnCast();
        }

        yield return new WaitForSeconds(1);

        foreach (var activeCard in EnemyFieldCards.FindAll(x => x.Card.CanAttack))
        {
            if (Random.Range(0, 2) == 0 &&
                PlayerFieldCards.Count > 0)
            {

                var enemy = PlayerFieldCards[Random.Range(0, PlayerFieldCards.Count)];

                Debug.Log(activeCard.Card.Name + "(" + activeCard.Card.Attack + ";" + activeCard.Card.Defence + ")" + "--->" +
                    enemy.Card.Name + "(" + enemy.Card.Attack + ";" + enemy.Card.Defence + ")");
               
                activeCard.Card.CanAttack =false ;

                activeCard.GetComponent<CardMovementScr>().MoveToTarget(enemy.transform);
                yield return new WaitForSeconds(.75f);

                CradsFight(enemy, activeCard);
            }
            else
            {
                Debug.Log(activeCard.Card.Name + "(" + activeCard.Card.Attack + ") Attacked hero");
                activeCard.Card.CanAttack=false;

                activeCard.GetComponent<CardMovementScr>().MoveToTarget(PlayerHero.transform);
                yield return new WaitForSeconds(.75f);

                DamageHero(activeCard, false);
            }

            yield return new WaitForSeconds(.2f);
        }
        yield return new WaitForSeconds(1);
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        StopAllCoroutines();
        Turn++;
        EndTurnBtn.interactable = IsPlayerTurn;
        if (IsPlayerTurn)
        {
            GiveNewCards();

            PlayerMana = EnemyMana = 10;
            ShowMana();
        }

        StartCoroutine(TurnFunc());


    }

    void GiveNewCards()
    {
        GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
        GiveCardToHand(CurrentGame.PlayerDeck, PlayerHand);
    }

    public void CradsFight(CardControllerScr attacker, CardControllerScr defender)
    {
        attacker.Card.GetDamage(defender.Card.Attack);
        attacker.OnDamageDeal();
        defender.OnTakeDamage(attacker);
        defender.Card.GetDamage(attacker.Card.Attack);
        attacker.OnTakeDamage();
        attacker.CheckForalive();
        defender.CheckForalive();
    }

   

    void ShowMana()
    {
        PlayerManaTxt.text = PlayerMana.ToString();
        EnemyManaTxt.text = EnemyMana.ToString();

    }

    void ShowHP()
    {
        PlayerHPTxt.text = PlayerHP.ToString();
        EnemyHPTxt.text = EnemyHP.ToString();
    }

    public void ReduceMana(bool playerMana, int manacost)
    {
        if (playerMana)
            PlayerMana = Mathf.Clamp(PlayerMana - manacost, 0, int.MaxValue);
        else
            EnemyMana = Mathf.Clamp(EnemyMana - manacost, 0, int.MaxValue);

        ShowMana();
    }

    public void DamageHero(CardControllerScr card, bool isEnemyAttacked)
    {
        if (isEnemyAttacked)
            EnemyHP = Mathf.Clamp(EnemyHP - card.Card.Attack, 0, int.MaxValue);
        else
            PlayerHP = Mathf.Clamp(PlayerHP - card.Card.Attack, 0, int.MaxValue);
        ShowHP();
        card.OnDamageDeal();
        CheckForResult();
    }

    void CheckForResult()
    {
        if (EnemyHP == 0 || PlayerHP == 0)
        {
            ResultGO.SetActive(true);
            StopAllCoroutines();

            if (EnemyHP == 0)
                ResultTxt.text = "You have won!";
            else
                ResultTxt.text = "You have lost!";
        }

    }

    public void CheckCardsForManaAvailability()
    {
        foreach (var card in PlayerHandCards)

            card.Info.HighlightManaAvailability(PlayerMana);

    }

    public void HighlightTargets (bool highlight)
        {
        foreach (var card in EnemyFieldCards)
            card.Info.HighlightAsTarget(highlight);

        EnemyHero.HighlightAsTarget(highlight);
        }
}

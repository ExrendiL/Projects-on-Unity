using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public string Name;
    public Sprite Logo;
    public int Attack, Defence, Manacost;
    public bool CanAttack;
    public bool IsPlaced;

    public bool IsAlive
    {
        get
        {
            return Defence > 0;
        }
    }

    public Card(string name, string logoPath, int attack, int defence, int manacost)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defence = defence;
        CanAttack = false;
        Manacost = manacost;
        IsPlaced = false;
    }

    public void ChangeAttackState(bool can)
    {
        CanAttack = can; 
    }

    public void GetDamage(int dmg)
    {
        Defence -= dmg;
    }
}

public static class CardMngr
{
    public static List<Card> AllCards = new List<Card>();
}

public class CardMangr : MonoBehaviour
{
    public void Awake()
    {
        CardMngr.AllCards.Add(new Card("Rogue", "Sprites/Cards/wr", 5, 5, 6));
        CardMngr.AllCards.Add(new Card("Sorcerer", "Sprites/Cards/wr1", 7, 5, 10));
        CardMngr.AllCards.Add(new Card("Warrior", "Sprites/Cards/wr2", 5, 9, 5));
        CardMngr.AllCards.Add(new Card("Monster", "Sprites/Cards/wr3", 2, 8, 2));

    }

}

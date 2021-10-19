using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public enum AbilityType
    { 
    NO_ABILIITY,
    INSTANT_ACTIVE,
    DOUBLE_ATTACK,
    SHIELD,
    PROVOCATION,
    REGENERATION_EACH_TURN,
    COUNTER_ATTACK
    }

    public string Name;
    public Sprite Logo;
    public int Attack, Defence, Manacost;
    public bool CanAttack;
    public bool IsPlaced;

    public List<AbilityType> Abilities;

    public bool IsAlive
    {
        get
        {
            return Defence > 0;
        }
    }

    public bool HasAbility
    {
        get
        {
            return Abilities.Count > 0;
        }
    }

    public bool IsProvocation
    {
        get
        {
            return Abilities.Exists(x => x == AbilityType.PROVOCATION);
        }
    }

    public int TimesTookDamage;
    public int TimeDealDamage;

    public Card(string name, string logoPath, int attack, int defence, int manacost,
        AbilityType abilityType = 0)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defence = defence;
        CanAttack = false;
        Manacost = manacost;
        IsPlaced = false;

        Abilities = new List<AbilityType>();

        if (abilityType != 0)
            Abilities.Add(abilityType);

        TimesTookDamage = TimeDealDamage = 0;
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

        CardMngr.AllCards.Add(new Card("Provocation", "Sprites/Cards/pr", 5, 5, 6, Card.AbilityType.PROVOCATION));
        CardMngr.AllCards.Add(new Card("Regeneration", "Sprites/Cards/wr1", 7, 5, 8, Card.AbilityType.REGENERATION_EACH_TURN));
        CardMngr.AllCards.Add(new Card("DoubleAttack", "Sprites/Cards/wr2", 5, 9, 8, Card.AbilityType.DOUBLE_ATTACK));
        CardMngr.AllCards.Add(new Card("InstatnActive", "Sprites/Cards/wr3", 2, 8, 5, Card.AbilityType.INSTANT_ACTIVE));
        CardMngr.AllCards.Add(new Card("Shield", "Sprites/Cards/sh", 2, 8, 6, Card.AbilityType.SHIELD));
        CardMngr.AllCards.Add(new Card("CounterAttack", "Sprites/Cards/wr3", 2, 8, 7, Card.AbilityType.COUNTER_ATTACK));

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class CardData : ScriptableObject
{
    public enum TypeOfCard
    {
        Key,
        Note,
        Book,
        Image,
        Door
    }
}

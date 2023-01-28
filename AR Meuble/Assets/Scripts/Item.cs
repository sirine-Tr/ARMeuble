// data of a furnuture
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//permet d'ajouter un ongle dans asset qui permet l'ajout d'un item
[CreateAssetMenu(fileName = "Item1" , menuName = "AddItem/Item")]
public class Item : ScriptableObject
{
    public float price;
    public GameObject itemPrefab;
    public Sprite itemImage;
}

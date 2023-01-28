using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public GameObject furniture;
    //get information from button 
    [SerializeField] private ButtonManager buttonManager;
    // the content of the button
    [SerializeField] private GameObject buttonContainter;
    //save all the items
    [SerializeField] private List <Item> items;
    [SerializeField] private ButtonManager buttonPrefab;
    private int current_id = 0;
    private static DataHandler instance;
    //methode to create an instance
    public static DataHandler Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }
private void Start()
{
    LoadItems();
    CreateButtons();
}
    void LoadItems()
    {
        var items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach (var item in items_obj)
        {
            items.Add((Item)item);
        }
    }
    //responsable to render the button dynamique
    void CreateButtons()
    {
        foreach (Item i in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainter.transform);
            b.ItemId = current_id;
            b.ButtonTexture = i.itemImage;
            current_id ++;

        }
        

    }
    public void SetFurniture (int id)
        {
            furniture = items[id].itemPrefab;


        }
}

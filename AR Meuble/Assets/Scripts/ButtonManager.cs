// manage the buttons
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    private Button btn;
    public GameObject furniture;
    
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        //appel of the action
      btn.onClick.AddListener(SelectObject);  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectObject()
    {
        DataHandler.Instance.furniture = furniture;
    }
}

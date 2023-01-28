// manage the buttons
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//using UnityEditorInternal;
public class ButtonManager : MonoBehaviour
{
    private Button btn;
    private RawImage buttonImage;
    public GameObject furniture;
    
    private int _itemId;
    public int ItemId
    {
        set
         { 
             _itemId = value;
         }

    }

    private Sprite _buttonTexture;
    public Sprite ButtonTexture
    {
        set 
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }
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
        if (UIManager.Instance.OnEntered(gameObject))
        {
            //how match you want to sceel
            transform.DOScale(Vector3.one * 2, 0.2f);
            //transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.2f);
            //transform.localScale = Vector3.one;
        }
    }
    void SelectObject()
    {
        DataHandler.Instance.SetFurniture(_itemId);
    }
}

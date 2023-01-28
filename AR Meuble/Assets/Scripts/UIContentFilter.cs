//pour permettre au 1er button de s'agrendir
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIContentFilter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HorizontalLayoutGroup hg = GetComponent<HorizontalLayoutGroup>();
        //cobient de child
        int childCount = transform.childCount -1;
        // the width of every button  
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        //with of the line with child + spaces
        float width = hg.spacing * childCount + childCount * childWidth + hg.padding.left;
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 268); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

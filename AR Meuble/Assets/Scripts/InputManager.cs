using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
//using UnityEditorInternal;
public class InputManager : MonoBehaviour
{
    //referance to the object (sofa)
    //[SerializeField] private GameObject arObj;
    //camera
    //[SerializeField] could change the value from editeur
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    private List <ARRaycastHit> _hits = new List <ARRaycastHit>();
    //get the tache of the user in the screen
    private Touch touch;
    private Pose pose;
    //to cross the space 
    [SerializeField] private GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairCalculation();
        // when the user click on the screen the object apear
        touch = Input.GetTouch(0);
        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
             return;

        if (IsPointerOverUI (touch)) return;     
        Instantiate (DataHandler.Instance.furniture, pose.position, pose.rotation);
            

        
    }

    bool IsPointerOverUI (Touch touch)
    {
        PointerEventData eventData = new PointerEventData (EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List <RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    //calculating the space 
    void CrosshairCalculation()
    {
        //point in the center of the screen
        Vector3 origin = arCam.ViewportToScreenPoint( new Vector3(0.5f, 0.5f, 0));
        //when the user tab the camera read the location of mouseposition
       
            Ray ray = arCam.ScreenPointToRay(origin);
            if(_raycastManager.Raycast(ray, _hits))
            {
                //pose give the position and the rotation of arObj
                 pose = _hits[0].pose;
                crosshair.transform.position = pose.position;
                crosshair.transform.eulerAngles = new Vector3(90,0,0);
            }

    }
}

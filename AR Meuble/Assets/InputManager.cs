using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class InputManager : MonoBehaviour
{
    //referance to the object (sofa)
    [SerializeField] private GameObject arObj;
    //camera
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _raycastManager;
    private List <ARRaycastHit> _hits = new List <ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when the user tab the camera read the location of mouseposition
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCam.ScreenPointToRay(Input.mousePosition);
            if(_raycastManager.Raycast(ray, _hits))
            {
                //pose give the position and the rotation of arObj
                Pose pose = _hits[0].pose;
                Instantiate (arObj, pose.position, pose.rotation);
            }
            

        }
    }
}

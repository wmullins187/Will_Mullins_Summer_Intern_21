using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twins : MonoBehaviour
{
    private GameObject num1;
    private UnityEngine.Component MTB1;
    private UnityEngine.Component DTEH;
    private UnityEngine.Component T;
    private Quaternion twinco;
    private Quaternion prevtwinco;
    private Quaternion camco;
    private Quaternion delta;
    private Quaternion prevcamco;
    private Vector3 offset;
    private Vector3 offsetcam;
    private GameObject upclone;
    private GameObject cam;
    private Quaternion prevco;
    // Start is called before the first frame update
    void Start()
    {
        
        num1 = GameObject.Find("Clone");

        
        if(num1 == null)
        {
        MTB1 = GetComponent("MultiTargetBehaviour");
        DTEH = GetComponent("DefaultTrackableEventHandler");
        

        transform.position = new Vector3(0,-0.05f,0.3f);
       // transform.localscale = new Vector3(3,3,3);
        //gameObject.GetComponent("MultiTargetBehaviour").enabled = false;
         GameObject twin = Instantiate(gameObject);
          twin.name = "Clone";
         T = twin.GetComponent("Twins");
         Behaviour bhvr2 = (Behaviour)T;
         bhvr2.enabled = false;
        
         

         prevco = Quaternion.identity;
         prevtwinco = Quaternion.identity;
         prevcamco = Quaternion.identity;
         //camco = Quaternion.identity;

         
         //MTB1.enabled = false;

         Behaviour bhvr = (Behaviour)MTB1;
         bhvr.enabled = false;
         Behaviour bhvr1 = (Behaviour)DTEH;
         bhvr1.enabled = false;

         //transform.localScale = new Vector3(20,20,20);

       if(gameObject.name == "Cube2")
       {
        //gameObject.transform.localScale = new Vector3(20,20,20);
       }

       

        }
        

    }
   


    void Update()
    {

       //Debug.Log(gameObject.GetComponent("MultiTargetBehaviour"));
      // Debug.Log(0);

        if(gameObject.name == "Cube2")
       {
        gameObject.transform.localScale = new Vector3(3,3,3);
       }
       

       
       if(gameObject.name == "Cube2")
       {
        upclone = GameObject.Find("Clone");
        cam = GameObject.Find("ARCamera");
        twinco = upclone.transform.localRotation;
        camco = cam.transform.localRotation;
        //Debug.Log(1);


        //offset = twinco.eulerAngles - prevtwinco.eulerAngles; //+ camco.eulerAngles;
        //offsetcam = camco.eulerAngles - prevcamco.eulerAngles;

        //Try keeping camera fixed
      // cam.transform.localRotation = Quaternion.identity;
      // cam.transform.position = new Vector3(0,0,0);

         //most basic
        //gameObject.transform.localRotation = twinco;
        
       
       // gameObject.transform.Rotate(offset.x - offsetcam.x, offset.y-offsetcam.y, offset.z+offsetcam.z);
        
        gameObject.transform.localRotation = Quaternion.Euler( twinco.eulerAngles - new Vector3(camco.eulerAngles.x,camco.eulerAngles.y,-camco.eulerAngles.z));

        /*
         //use previous positions, almost but likely still needs camera to work
        gameObject.transform.localRotation = Quaternion.Euler(prevco.eulerAngles + offset);

        prevco = gameObject.transform.localRotation;
        prevtwinco = twinco;
        */
        
        /*
         //use previous positions, iteration includes camera, doesn't work'
        gameObject.transform.localRotation = Quaternion.Euler(prevco.eulerAngles + offset - new Vector3(offsetcam.x,offsetcam.y,-offsetcam.z));
        */
       // prevco = gameObject.transform.localRotation;
        //prevtwinco = twinco;
        //prevcamco = camco;
        

        /* //when reset take last position, won't work
        if(gameObject.transform.localRotation.eulerAngles = new Vector3(0,180,0))
        {
            gameObject.transform.localRotation = prevco;
        }
        else
        {
        gameObject.transform.localRotation = Quaternion.Euler(offset);
        }
        prevco = gameObject.transform.localRotation;
        */
       }
       else
       {
             // Debug.Log(0);
       }
       
       
       //If tracker activated 
       // Find Clone change in position and rotation this frame
       //Apply changes to Cube2

       //Debug.Log(twinco);
       //prevco = gameObject.transform.localRotation;
    }


}
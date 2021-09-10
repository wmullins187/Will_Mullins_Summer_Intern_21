using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinTracker : MonoBehaviour
{

        private Vector3 LeftTop, LeftBottom, RightTop, RightBottom;
        private Vector3 LTcal, LBcal, RTcal, RBcal, Initialcal;
        private Vector3 delta1, delta2, delta3 , delta4, Delta, RDelta;
        private float Movex,Movey,Movez;
        private float Rotx,Roty,Rotz;
        private GameObject Tracker, Twin, Drill;
        private GameObject Loop2;
        private int track;
        private float L1,L2,L3;
        private Material C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14;
        private List<Material> C;
        
      
        public Vector3 DistanceToTracker;
        public float Height;
        //private Vector3 RotationCalibration;

     
        private Vector2 calsize;


    // Start is called before the first frame update
    void Start()
    {
        
         Tracker = GameObject.Find("VRTestCube");
         Twin = gameObject;
         Loop2 = GameObject.Find("looper");  
         track = 0;
         Drill = GameObject.Find("Drill");
         var nochild = Drill.transform.childCount;
         //Get dimensions of drill (3 parts stacked)
         L1 = Drill.transform.GetChild(0).GetComponentInChildren<Renderer>().bounds.size.y;
         L2 = Drill.transform.GetChild(1).GetComponentInChildren<Renderer>().bounds.size.y;
         L3 = Drill.transform.GetChild(2).GetComponentInChildren<Renderer>().bounds.size.y;

        //Save materials list of 3 parts
        Material[] myMaterials1 = Drill.transform.GetChild(0).GetComponent<Renderer>().materials;
        Material[] myMaterials2 = Drill.transform.GetChild(1).GetComponent<Renderer>().materials;
        Material[] myMaterials3 = Drill.transform.GetChild(2).GetComponent<Renderer>().materials;
        
        //Get colours in all material lists
        C1 = myMaterials1[0];
        C2 = myMaterials1[1];
        C3 = myMaterials2[0];
        C4 = myMaterials2[1];
        C5 = myMaterials2[2];
        C6 = myMaterials2[3];
        C7 = myMaterials3[0];
        C8 = myMaterials3[1];
        C9 = myMaterials3[2];
        C10 = myMaterials3[3];
        C11 = myMaterials3[4];
        C12 = myMaterials3[5];
        C13 = myMaterials3[6];
        C14 = myMaterials3[7];

        //Set scale depending on height of real-world prototype
       gameObject.transform.localScale = gameObject.transform.localScale * (Height / (L1 + L2 + L3) );

    }

    // Update is called once per frame
    void Update()
    {
          
            //Calibration routine, DistanceToTracker is permanent 
            if(Input.GetKey(KeyCode.Alpha1) && (Loop2 != null))
            {
                track = 1;

                

                Delta = DistanceToTracker - Tracker.transform.position;
                RDelta = Tracker.transform.eulerAngles;

                Loop2 = null;  
            }

            //Randomly change set colours
            if(Input.GetKey(KeyCode.C))
            {   
               
                Color randomColor = RandomColor();

                C1.SetColor("_Color", randomColor);
                C5.SetColor("_Color", randomColor);
                C14.SetColor("_Color", randomColor);
                C13.SetColor("_Color", randomColor);
                C9.SetColor("_Color", randomColor);
            }

            if(Input.GetKey(KeyCode.V))
            {   
                

                Color randomColor = RandomColor();

                C2.SetColor("_Color", randomColor);
                C4.SetColor("_Color", randomColor);
                C11.SetColor("_Color", randomColor);
            }

             if(Input.GetKey(KeyCode.B))
            {   
                

                Color randomColor = RandomColor();

                C3.SetColor("_Color", randomColor);
                C6.SetColor("_Color", randomColor);
               // C7.SetColor("_Color", randomColor);
                //C8.SetColor("_Color", randomColor);
                C12.SetColor("_Color", randomColor);
            }
            
            
            //Transforms to convert movement to mirror
            if(track == 1)
            {
                
                 Movex = Delta.x + Tracker.transform.position.x;
               
                Movey = Delta.y + Tracker.transform.position.y; //- 0.048f;
                
                Movez = Delta.z + Tracker.transform.position.z;
                
                Twin.transform.position = new Vector3(Movex, Movey, -Movez);

                 Rotx = -RDelta.x + Tracker.transform.eulerAngles.x;
               
                Roty = - RDelta.y + Tracker.transform.eulerAngles.y; //- 0.048f;
                
                Rotz = -RDelta.z + Tracker.transform.eulerAngles.z;

                Twin.transform.eulerAngles = new Vector3(Rotx,-Roty,-Rotz);
            }
    }

    //Method for generating random colours
     Color RandomColor()
    {
        // A different random value is used for each color component (if
        // the same is used for R, G and B, a shade of grey is produced).
        return new Color(Random.value, Random.value, Random.value);
    }

}

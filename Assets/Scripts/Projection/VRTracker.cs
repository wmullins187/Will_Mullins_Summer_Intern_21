using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apt.Unity.Projection
{
    public class VRTracker : TrackerBase
    {
        /*
        [Min(0.001f)]
        //public float BoundsSize = 2;
        [Tooltip("How much of the bounds size to move each second")]
        [Range(0, 1)]
        public float MoveAmountPerSecond = 0.2f;

        //private Bounds bounds;
        */

        private Vector3 LeftTop, LeftBottom, RightTop, RightBottom;
        private Vector3 LTcal, LBcal, RTcal, RBcal, Initialcal;
        private Vector3 delta1, delta2, delta3 , delta4, Delta;
        private GameObject Tracker;
        private GameObject Loop1;

        public GameObject projcalib;
        private ProjectionPlane scripter;
        private Vector2 calsize;
        
        
        

        void Start()
        {
            //bounds = new Bounds(Vector3.zero, new Vector3(BoundsSize, BoundsSize, BoundsSize));
            Tracker = GameObject.Find("VRTestCube");
            Loop1 = GameObject.Find("looper");
            
           


            scripter = projcalib.GetComponent<ProjectionPlane>();
            
            //ProjP = GameObject.Find("Projection Plane");

            calsize = scripter.Size;
           // Debug.Log(calsize.);
           LTcal = new Vector3(- calsize.x / 2, calsize.y /2 , 0);
           LBcal = new Vector3(- calsize.x / 2, - calsize.y /2 , 0);
           RTcal = new Vector3( calsize.x / 2, calsize.y /2 , 0);
           RBcal = new Vector3( calsize.x / 2, -calsize.y /2 , 0);

           //Debug.Log(LTcal);
           
           
        }

        void Update()
        {
           
            //Debug.Log(Tracker.transform.position);

            if( Time.frameCount == 10)
            {
            Initialcal = Tracker.transform.localEulerAngles;
            // This is  0 0 0 
           // Debug.Log(Initialcal);
            }

            if(Input.GetKey(KeyCode.Alpha1))
            {
                LeftTop = Tracker.transform.position;
                delta1 = LTcal - LeftTop;
                //Vector3 delta1 = new Vector3 
                //Debug.Log(1);
            }

            if(Input.GetKey(KeyCode.Alpha2))
            {
                RightTop = Tracker.transform.position;
                delta2 = RTcal- RightTop;
            }

            if(Input.GetKey(KeyCode.Alpha3))
            {
                RightBottom = Tracker.transform.position;
                delta3 = RBcal - RightBottom;
            }

            if(Input.GetKey(KeyCode.Alpha4))
            {
                LeftBottom = Tracker.transform.position;
                delta4 = LBcal - LeftBottom;

            }

            if((LeftTop != Vector3.zero) && (LeftBottom != Vector3.zero) && (RightBottom != Vector3.zero) && (RightTop != Vector3.zero) && (Loop1 != null))
            {
                IsTracking = !IsTracking;

                /*
               float theta12 = Mathf.Acos( calsize.x / Vector3.Distance(LeftTop,RightTop) ) * Mathf.Rad2Deg;
               float theta34 = Mathf.Acos( calsize.x / Vector3.Distance(LeftBottom,RightBottom) ) * Mathf.Rad2Deg;

               float thetaA = (theta12 + theta34) /2;
              Debug.Log( Vector3.Distance(LeftTop,RightTop));


               Debug.Log(theta12);
               Debug.Log(theta34);
               Debug.Log(thetaA);

               
               float theta14 = Mathf.Cos( calsize.y / Mathf.Abs(Vector3.Distance(LeftTop,LeftBottom)) ) * Mathf.Rad2Deg;
               float theta23 = Mathf.Cos( calsize.y / Mathf.Abs(Vector3.Distance(RightTop,RightBottom)) ) * Mathf.Rad2Deg;

               float thetaB = (theta14 + theta23) /2;

               Debug.Log(theta14);
               Debug.Log(theta23);
               Debug.Log(thetaB);
               */

                Delta = (delta1 + delta2 + delta3 + delta4 )/4;
               // Debug.Log(1);
               // Debug.Log(Delta);
                Loop1 = null;
            }

            if(IsTracking)
            {
                
                translation.x = Delta.x + Tracker.transform.position.x;

                translation.y = Delta.y + Tracker.transform.position.y - 0.048f;

                translation.z = Delta.z + Tracker.transform.position.z;
               // translation.y = 

               // translation.z = 
            }

            /*
            if(Input.GetKeyUp(KeyCode.Space))
            {
                IsTracking = !IsTracking;
                SecondsHasBeenTracked = 0;
            }

            

            if(IsTracking)
            {
                SecondsHasBeenTracked += Time.deltaTime;

                float MovedThisFrame = MoveAmountPerSecond * BoundsSize * Time.deltaTime;
                if (Input.GetKey(KeyCode.A))
                {
                    translation.x = Mathf.Max(bounds.min.x, translation.x - MovedThisFrame);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    translation.x = Mathf.Min(bounds.max.x, translation.x + MovedThisFrame);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    translation.y = Mathf.Min(bounds.max.y, translation.y + MovedThisFrame);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    translation.y = Mathf.Max(bounds.min.y, translation.y - MovedThisFrame);
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    translation.z = Mathf.Max(bounds.min.z, translation.z - MovedThisFrame);
                }
                if (Input.GetKey(KeyCode.E))
                {
                    translation.z = Mathf.Min(bounds.max.z, translation.z + MovedThisFrame);
                }

                if (Input.GetKey(KeyCode.R))
                {
                    translation.Set(0, 0, 0);
                }

                if(Input.GetKey(KeyCode.N))
                {
                    TrackedId++;
                }
               
            }
            */
        }
    }
}

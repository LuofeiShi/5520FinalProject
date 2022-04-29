using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class FinalPoints : MonoBehaviour
 {
     public static FinalPoints instance = null;

     private int finalPoints = 0;
     void Start()
     {
         //PauseMenu point = GetComponent<PauseMenu>();
         // if (instance == null) {
         //     instance = this;
         // }
         instance = this;
         UImanager.instance.UpdatePoints(finalPoints);
     }

     public void SetFinalPoints(int finalPoint)
     {
         finalPoints = finalPoint;
         Debug.Log("pointtttttttt");
     }
 }

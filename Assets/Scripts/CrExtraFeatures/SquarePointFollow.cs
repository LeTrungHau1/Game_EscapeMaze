using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePointFollow : MonoBehaviour
{
    [SerializeField] public float MovingSpeed;//tốc độ
    [SerializeField] private GameObject[] Waypoints; //điểm duy chuyển
    [SerializeField]private int curWayPointIndex=0;



    void Update()
    {
        wayPointPlatform();
    }


    private void wayPointPlatform()
    {
        if (Vector3.Distance(Waypoints[curWayPointIndex].transform.position,transform.position) < 0.1f)// khoản cách từ điểm  tới vị trí của tansform>0.1
        {
            curWayPointIndex++;
            if(curWayPointIndex>=Waypoints.Length)
            {
                curWayPointIndex = 0;
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[curWayPointIndex].transform.position,MovingSpeed*Time.deltaTime);//duy chuyen từ transform tới điểm với tốc độ
    }


}

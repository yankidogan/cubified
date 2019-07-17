using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject TargetPoint;
    Vector3 TargetPos;
    Vector3 StartPos;
    Quaternion TargetRot;
    Quaternion StartRot;
    float LerpT;
    float TimeToArrive;
    public bool isMoveToTarget;
    public bool isMoveToStart;

    void Start()
    {
        LerpT = 0;
        TimeToArrive = 1;
        isMoveToTarget = false;
        isMoveToStart = false;
    }

    void Update()
    {

        if (isMoveToTarget)
        {
            MoveToTarget();
        }

       else if (isMoveToStart)
        {
            MoveToStart();
        }

    }

    void MoveToTarget()
    {
        StartPos = StartPoint.gameObject.transform.position;
        TargetPos = TargetPoint.gameObject.transform.position;
        StartRot = StartPoint.gameObject.transform.rotation;
        TargetRot = TargetPoint.gameObject.transform.rotation;
        LerpT = LerpT + Time.deltaTime / TimeToArrive;
        transform.position = Vector3.Lerp(StartPos, TargetPos, LerpT);
        transform.rotation = Quaternion.Lerp(StartRot, TargetRot, LerpT);
        if (LerpT > 1)
        {
            isMoveToTarget = false;
            LerpT = 0;
        }
    }

    void MoveToStart()
    {
        StartPos = StartPoint.gameObject.transform.position;
        TargetPos = TargetPoint.gameObject.transform.position;
        StartRot = StartPoint.gameObject.transform.rotation;
        TargetRot = TargetPoint.gameObject.transform.rotation;
        LerpT = LerpT + Time.deltaTime / TimeToArrive;
        transform.position = Vector3.Lerp(TargetPos, StartPos, LerpT);
        transform.rotation = Quaternion.Lerp(TargetRot, StartRot, LerpT);
        if (LerpT > 1)
        {
            isMoveToStart = false;
            LerpT = 0;
        }
    }
}

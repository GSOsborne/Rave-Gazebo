﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTracking : MonoBehaviour
{
    public bool thisisLH;

    public float triggerSpeed;
    public float cooldownTime;

    RaycastHit hit;

    bool lhResetting;
    bool rhResetting;

    // Start is called before the first frame update
    void Start()
    {
        lhResetting = false;
        rhResetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisisLH)
        {
            Vector3 controllerVelocityVector = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
            if(controllerVelocityVector.magnitude > triggerSpeed)
            {
                SpeedCheckPassed(OVRInput.Controller.LTouch, controllerVelocityVector);
            }
        }
        else
        {
            Vector3 controllerVelocityVector = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            if (OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude > triggerSpeed)
            {
                SpeedCheckPassed(OVRInput.Controller.RTouch, controllerVelocityVector);
            }
        }
    }

    void SpeedCheckPassed(OVRInput.Controller controller, Vector3 velocityVector)
    {
        if (controller == OVRInput.Controller.LTouch && !lhResetting)
        {
            RevealWalls(controller, velocityVector);
        }
        else if (controller == OVRInput.Controller.RTouch && !rhResetting)
        {
            RevealWalls(controller, velocityVector);
        }
    }

    void RevealWalls(OVRInput.Controller controller, Vector3 velocityVector)
    {
        Ray checkForWall = new Ray(OVRInput.GetLocalControllerPosition(controller), velocityVector);
        if (Physics.Raycast(checkForWall, out hit, 30f))
        {
            if (hit.transform.gameObject.CompareTag("GestureWall"))
            {
                hit.transform.gameObject.GetComponent<WallTrigger>().WallTriggered();
                if (controller == OVRInput.Controller.LTouch)
                {
                    StartCoroutine(LHResetting());
                }
                else
                {
                    StartCoroutine(RHResetting());
                }
            }
            else
            {
                Debug.Log("Instead of a wall, I hit: " + hit.transform.gameObject);
            }
        }
        else
        {
            Debug.Log("the raycast didn't hit anything.");

        }
        Debug.DrawRay(OVRInput.GetLocalControllerPosition(controller), velocityVector, Color.green, 2f);

    }


    IEnumerator LHResetting()
    {
        lhResetting = true;
        yield return new WaitForSeconds(cooldownTime);
        lhResetting = false;
    }

    IEnumerator RHResetting()
    {
        rhResetting = true;
        yield return new WaitForSeconds(cooldownTime);
        rhResetting = false;
    }
}

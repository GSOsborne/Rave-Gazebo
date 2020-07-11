using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLifter : MonoBehaviour
{
    public Transform cameraHeadObject;
    Transform thisTransform;
    public float frameTime;
    public bool panelRaised;
    float startingTransformY;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        panelRaised = false;
        startingTransformY = thisTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaisePanels()
    {
        Debug.Log("Someone is trying to raise the panels!");
        if (!panelRaised)
        {
            Debug.Log("So we're raising the panels now.");
            StopAllCoroutines();
            StartCoroutine(ChangeHeight(cameraHeadObject.position.y / .7f));
            panelRaised = true;
        }
        else
        {
            Debug.Log("But they were already raised, dummy");
        }
    }

    public void LowerPanels()
    {
        Debug.Log("Someone is trying to lower the panels!");
        if (panelRaised)
        {
            Debug.Log("So we're lowering the panels now.");
            StopAllCoroutines();
            StartCoroutine(ChangeHeight(startingTransformY));
            panelRaised = false;
        }
        else
        {
            Debug.Log("But they were already down, lmao");
        }
    }

    IEnumerator ChangeHeight(float desiredY)
    {
        float startingY = thisTransform.position.y;
        for (float i = 0; i <=100; i++)
        {
            thisTransform.position = new Vector3(thisTransform.position.x, Mathf.SmoothStep(startingY, desiredY, i / 100));
            //Debug.Log(Mathf.SmoothStep(startingY, desiredY, i / 100));
            yield return new WaitForSeconds(frameTime);
        }
        Debug.Log("Should be done moving the panels now.");
    }

}

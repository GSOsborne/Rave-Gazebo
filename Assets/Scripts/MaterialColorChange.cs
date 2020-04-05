using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class MaterialColorChange : MonoBehaviour
{
    public Color duringPurple, duringRed, duringOrange, duringYellow, duringGreen, duringBlue;
    Renderer colorRenderer;

    // Start is called before the first frame update
    void Start()
    {
        colorRenderer = GetComponent<Renderer>();
        //Debug.Log("Material is " + colorRenderer.material);
        DavisDnB_AudioManager.WallTriggerEvent += ChangeMatColorOnDrop;
        ChangeMatColorOnStart(MusicLayer.OGProd);
    }

    private void OnDestroy()
    {
        DavisDnB_AudioManager.WallTriggerEvent -= ChangeMatColorOnDrop;
    }

    void ChangeMatColorOnStart(MusicLayer givenLayer)
    {
        
        Color newColor = Color.black;
        switch (givenLayer)
        {
            case MusicLayer.Charleston:
                newColor = duringPurple;
                break;
            case MusicLayer.Dholak:
                newColor = duringRed;
                break;
            case MusicLayer.Funk:
                newColor = duringOrange;
                break;
            case MusicLayer.OGProd:
                newColor = duringYellow;
                break;
            case MusicLayer.Sniper:
                newColor = duringGreen;
                break;
            case MusicLayer.Squeaker:
                newColor = duringBlue;
                break;
        }
        colorRenderer.material.SetColor("_Color", newColor);
        //Debug.Log("Set Color to " + newColor);
    }

    void ChangeMatColorOnDrop(MusicLayer givenLayer)
    {
        Color newColor = Color.black;
        switch (givenLayer)
        {
            case MusicLayer.Charleston:
                newColor = duringPurple;
                break;
            case MusicLayer.Dholak:
                newColor = duringRed;
                break;
            case MusicLayer.Funk:
                newColor = duringOrange;
                break;
            case MusicLayer.OGProd:
                newColor = duringYellow;
                break;
            case MusicLayer.Sniper:
                newColor = duringGreen;
                break;
            case MusicLayer.Squeaker:
                newColor = duringBlue;
                break;
        }
        colorRenderer.material.SetColor("_Color", newColor);
        //Debug.Log("Set Color to " + newColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

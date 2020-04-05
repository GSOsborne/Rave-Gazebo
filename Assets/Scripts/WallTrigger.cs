using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DavisDnB_AudioManager;

public class WallTrigger : MonoBehaviour
{

    public MusicLayer layer;
    public ParticleSystem pSystem;

    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WallTriggered()
    {
        if (DavisDnB_AudioManager.Instance.songPlaying)
        {
            DavisDnB_AudioManager.Instance.TriggerWallEvent(layer);
            Debug.Log("Wall sent " + layer + " trigger!");
        }
        else
        {
            Debug.Log("Wall sent nothing cus the song isn't playing.");
        }
    }

    public void WallHitParticles(Vector3 wallHitPos)
    {
        pSystem.Play();
    }
}

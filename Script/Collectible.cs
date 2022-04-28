using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    
    //public ParticleSystem collectEffect;
    public AudioClip collectClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check collision
    void OnTriggerEnter2D(Collider2D other) {
        Player pc = other.GetComponent<Player>();
        if(pc != null){
            if(pc.MyCurrentHealth < pc.MyMaxHealth)
            {
                pc.ChangeHealth(1);
                pc.ChangeAppleCount(1);
                
                AudioManager.instance.AudioPlayer(collectClip);

                Destroy(this.gameObject);
            }
        }
    }
}

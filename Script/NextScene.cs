using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    //public AudioClip nextClip;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("yes", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player pc = other.GetComponent<Player>();
        if(pc != null)
        {
            Debug.Log("debug scene loader");
            // send current status to GameManager
            pc.UpdateScene();
            anim.SetBool("yes", true);
            //AudioManager.instance.AudioPlayer(nextClip);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            // pc.LoadScene();
            Destroy(this.gameObject);
        }
    }
}

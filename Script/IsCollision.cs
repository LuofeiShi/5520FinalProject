using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollision : MonoBehaviour
{
    private BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //TreeSpawner pc = other.gameObject.GetComponent<TreeSpawner>();
        if(collision.collider.tag == "Environment")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReport : MonoBehaviour
{
    public bool hasCollided;
    //  AudioSource sound;
    


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Weight>() && !hasCollided)
        {
            GameManager.Instance.starsEarned++;
            //gameObject.GetComponent<AudioSource>().Play();
            // sound = gameObject.GetComponent<AudioSource>();
            //Collect= gameObject.GetComponent<AudioClip>(); 
            //AudioSource.PlayClipAtPoint(Collect, transform.position);
            

            hasCollided = true;
            
            Destroy(this.gameObject);
            
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public float damage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    /*
    OnCollisionEnter(Collision entity){

        //Names killable, killableEntity, .takeDamage(), interactable, interactableEntity, .attacked() should be changed
        if (entity.gameObject.tag == "killable"){
            entity.gameObject.GetComponent<killableEntity>().takeDamage(damage);
        }

        //interactable entities like a painting on a wall that falls when you hit it will be last on priority list
        else if (entity.gameObject.tag == "interactable"){
            entity.gameObject.GetComponent<interactableEntity>().attacked();
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersArrow : Combat
{
    void OnEnable() 
    {
        myStats = GetComponent<CharacterStats>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyStats>() != null)
            Attack(collision.gameObject.GetComponent<EnemyStats>());
        

        //if (collision.gameObject.TryGetComponent(out MeshRenderer meshRenderer))
            //Stick();
    }

    /*private void Stick()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    */
}

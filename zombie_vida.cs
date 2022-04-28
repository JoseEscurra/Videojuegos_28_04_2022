using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_vida : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifeZombie;


    void Update()
    {
        CheckLife();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.gameObject.tag;
        if(tag == "bala")
        {
            lifeZombie--;
        }

        if(tag == "balaMediana")
        {
            lifeZombie -= 2;
        }

        if(tag == "balaGrande")
        {
            lifeZombie = 0;
        }
    }

    private void CheckLife()
    {
        if(lifeZombie <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

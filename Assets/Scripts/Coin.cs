using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Coin : LevelManager
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            CoinPickedUp();
        }        
    }
}

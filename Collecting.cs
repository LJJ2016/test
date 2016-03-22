using UnityEngine;
using System.Collections;

public class Collecting : MonoBehaviour {

   


   



	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Collectibles"))
        {
            Destroy(col.gameObject);

           

        }


    }
        
	
	// Update is called once per frame
	void Update () {
	
	}
}

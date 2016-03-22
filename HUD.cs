using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HealthbarSprites;

    public Image HealthbarUI;

    private movement player;

  


	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();



	}
	
	// Update is called once per frame
	void Update () {


        HealthbarUI.sprite = HealthbarSprites[player.curHealth]; 

	}
}

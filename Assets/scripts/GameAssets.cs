using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance { get; private set; }
    public Sprite snakeHeadSprite;
    public Sprite foodSprite;

    private void Awake() {
    	if (instance == null) {
    		instance = this;
     	} else {
     		Destroy(gameObject);
     	}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("BANANA hit");
    }

}

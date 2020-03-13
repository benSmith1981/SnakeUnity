using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance { get; private set; }

    private void Awake() {
    	if (instance == null) {
    		instance = this;
     	} else {
     		Destroy(gameObject);
     	}
    }

    public Sprite snakeHeadSprite;
    public Sprite foodSprite;


}

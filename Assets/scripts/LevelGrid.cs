using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid: ScriptableObject
{
    private Vector2Int foodGridPosition;
	public GameObject foodSprite;

	private int width;
	private int height;

	public LevelGrid(int width, int height) {
		this.width = width;
		this.height = height;
	} 

    public void SpawnFood() {
    	Vector2Int foodGridPosition = new Vector2Int(Random.Range(0,20), Random.Range(0, 20));
    	// GameObject foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
    	// foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite as Sprite;
    	// foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y,0);


    	GameObject foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
    	foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite as Sprite;
    	foodGameObject.transform.localScale = new Vector3(4 ,4 ,4);
    	foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("BANANA hit detected");
	}
}

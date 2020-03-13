using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid
{
    private Vector2Int foodGridPosition;
	public GameObject foodSprite;

	private int width;
	private int height;
	private Snake snake;

	public LevelGrid(int width, int height, Snake snake) {
		this.width = width;
		this.height = height;
		this.snake = snake;
	} 

    public void SpawnFood() {
    	Vector2Int foodGridPosition = new Vector2Int(Random.Range(-50,50), Random.Range(-50,50));
    	// GameObject foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
    	// foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite as Sprite;
    	// foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y,0);


    	GameObject foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
    	foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite as Sprite;
    	foodGameObject.transform.localScale = new Vector3(4 ,4 ,4);
    	foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    	//foodGameObject.Tag = "food";
    	//Rigidbody gameObjectsRigidBody = foodGameObject.AddComponent<Rigidbody>();
    	//BoxCollider boxCollider = (BoxCollider)foodGameObject.AddComponent(typeof(BoxCollider));
    	foodGameObject.AddComponent<BoxCollider2D>();
 		// boxCollider.offset = new Vector2 (0, -0.5f);
 		Rigidbody2D rb = foodGameObject.AddComponent<Rigidbody2D>();
 		//rb.tag = "food";
        rb.bodyType = RigidbodyType2D.Kinematic;
        //boxCollider.size = new Vector3 (0.5f, 1f);
 		// boxCollider.isTrigger = true;

	}
}

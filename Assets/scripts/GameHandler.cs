using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	private LevelGrid levelGrid;
	public GameObject foodSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("GameHandler Start");
        levelGrid = new LevelGrid(20,20);
        levelGrid.SpawnFood();
    	//levelGrid.SpawnFood();


    }

    public void SpawnFood() {
			Vector2Int foodGridPosition = new Vector2Int(Random.Range(-100,100), Random.Range(-100, 100));
    		GameObject foodGameObject = Instantiate(foodSprite) as GameObject;
    		foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y,0);

    }

    // Update is called once per frame
    void Update()
    {
    	// levelGrid.SpawnFood();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("BANANA hit detected");
	}
}

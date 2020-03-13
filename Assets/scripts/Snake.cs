using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum controlDirection
{
	up = 0,
	down = 1,
	left = 2,
	right = 3
}
public class Snake : MonoBehaviour
{
	float snakeSpeed = 0.1f; //lower value faster the snake
	int pixelsToMove = 5; //lower value faster the snake

	private Vector2Int gridPosition;
	private float gridMoveTimer;
	private float gridMoveTimerMax;
	private Vector2Int gridMoveDirection;
	private controlDirection moveDirection;

	private void Awake() {
		gridPosition = new Vector2Int(10,10);
		gridMoveTimerMax = snakeSpeed;
		gridMoveTimer = gridMoveTimerMax; 
		gridMoveDirection = new Vector2Int(0, pixelsToMove);
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	handleInputs();
    	handleGridMovements();
	}

	void handleGridMovements() {
		// Debug.Log("gridMoveTimerMax" + gridMoveTimerMax);
		// Debug.Log("gridMoveTimer" + gridMoveTimer);
		// Debug.Log("Time.deltaTime;" + Time.deltaTime);

		//Time.deltaTime is a fragment of time passed since the last frame
		//keep adding it to grid move timer until you get to max, then update the position
		gridMoveTimer += Time.deltaTime;

		//when all the delta times reach max update position
		if(gridMoveTimer > gridMoveTimerMax) { 
		    // Debug.Log("gridMoveTimer > gridMoveTimerMax***********");
			gridPosition += gridMoveDirection; //add on the vector
			gridMoveTimer -= gridMoveTimerMax; //reset to zero

		}
	}

	void handleInputs() {
		if (Input.GetKey(KeyCode.UpArrow))
		{
			if(this.moveDirection != controlDirection.down) {
				moveShip(controlDirection.up);
			}
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			if(this.moveDirection != controlDirection.up) {
				moveShip(controlDirection.down);
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if(this.moveDirection != controlDirection.right) {
				moveShip(controlDirection.left);
			}
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			if(this.moveDirection != controlDirection.left) {
				moveShip(controlDirection.right);
			}
		}
		//now transform our game object to new position
		this.transform.position = new Vector3(gridPosition.x, gridPosition.y);
		transform.eulerAngles = new Vector3(0, 0, getAngleFromVector(gridMoveDirection)-90);

	}

	bool moveShip(controlDirection moveDirection)
	{
		// float degrees = 90;
		// Vector2 to = new Vector3(degrees, 0, 0);
		// transform.eulerAngles = Vector2.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
		switch (moveDirection)
		{
			
			case controlDirection.up:
				this.moveDirection = controlDirection.up;
				gridMoveDirection = new Vector2Int(0, pixelsToMove); //* snakeSpeed * Time.deltaTime;

				return true;
			case controlDirection.down:
				this.moveDirection = controlDirection.down;
				gridMoveDirection = new Vector2Int(0, -pixelsToMove);

				return true;
			case controlDirection.left:
				this.moveDirection = controlDirection.left;
				gridMoveDirection = new Vector2Int(-pixelsToMove, 0);

				return true;
			case controlDirection.right:
				this.moveDirection = controlDirection.right;	
				gridMoveDirection = new Vector2Int(pixelsToMove, 0);

				return true;
		}

		return false;
	}

	private float getAngleFromVector(Vector2Int dir) {
		float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		if(n<0) n += 360;
		return n;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("hit detected");
		// GameObject e = Instantiate(snakeGameobject) as GameObject;
		// e.transform.position = transform.position;
		//snakeGameobject.gameObject.SetActive(false);
		// Destroy(other.gameObject);
		this.gameObject.SetActive(false);

	}
}

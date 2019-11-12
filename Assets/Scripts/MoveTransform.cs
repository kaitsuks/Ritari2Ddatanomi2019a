using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Kaitsu/Movement/Move Transform With Arrows")]

public class MoveTransform : MonoBehaviour {

    //public GameObject go;

    [Header("Input keys")]
    //public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.WASD;

    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 5f;
    public Enums.MovementType movementType = Enums.MovementType.AllDirections;

    [Header("Orientation")]
    public bool orientToDirection = false;
    // The direction that will face the player
    public Enums.Directions lookAxis = Enums.Directions.Up;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;

    // Use this for initialization
    void Start () {

    }

    // Update gets called every frame
    void Update()
    {
        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.WASD)

        {
            moveHorizontal = Input.GetAxis("Horizontal2");
            //Debug.Log("Horisontaali " + moveHorizontal);
            moveVertical = Input.GetAxis("Vertical2");
        }

        else
                {
                    moveHorizontal = Input.GetAxis("Horizontal");
                    moveVertical = Input.GetAxis("Vertical");
                }
        

		//zero-out the axes that are not needed, if the movement is constrained
		switch(movementType)
		{
			case Enums.MovementType.OnlyHorizontal:
				moveVertical = 0f;
				break;
			case Enums.MovementType.OnlyVertical:
				moveHorizontal = 0f;
				break;
		}
			
		movement = new Vector2(moveHorizontal, moveVertical);


		//rotate the gameObject towards the direction of movement
		//the axis to look can be decided with the "axis" variable
		if(orientToDirection)
		{
			if(movement.sqrMagnitude >= 0.01f)
			{
				cachedDirection = movement;
			}
			Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
		}

        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(movement * speed * Time.deltaTime);
    }

}

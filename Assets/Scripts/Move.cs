using UnityEngine;
using System.Collections;

[AddComponentMenu("Kaitsu/Movement/Move With Arrows Orig")]
[RequireComponent(typeof(Rigidbody2D))]
public class Move : Physics2DObject
{
	[Header("Input keys")]
	public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

	[Header("Movement")]
	[Tooltip("Speed of movement")]
	public float speed = 5f;
	public Enums.MovementType movementType = Enums.MovementType.AllDirections;

	[Header("Orientation")]
	public bool orientToDirection = false;
	// The direction that will face the player
	public Enums.Directions lookAxis = Enums.Directions.Up;

    [HideInInspector]
    public Vector2 movement;

    private Vector2 cachedDirection;
	private float moveHorizontal;
	private float moveVertical;

    Animator animator;

    void Start()
    {
       animator = GetComponentInChildren<Animator>();
    }
        // Update gets called every frame
        void Update ()
	{	
		// Moving with the arrow keys
		if(typeOfControl == Enums.KeyGroups.ArrowKeys)
		{
			moveHorizontal = Input.GetAxis("Horizontal");
			moveVertical = Input.GetAxis("Vertical");
		}
		else
		{
			moveHorizontal = Input.GetAxis("Horizontal2");
			moveVertical = Input.GetAxis("Vertical2");
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
	}



	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate ()
	{
		// Apply the force to the Rigidbody2d
		rigidbody2D.AddForce(movement * speed * 1.5f); 
        //SlowDown(0f);
	}

    public void SlowDown(float slow)
    {
        //Debug.Log("Vedess‰ ollaan, jarrutetaan" + speed);
        //speed -= slow;
        //deltaspeed = 0.01f;
        speed = 0.1f;
        //Debug.Log("Vedess‰ ollaan, jarrutetaan" + speed);
        //speedCoefficient = 1f;
        //rigidbody2D.velocity = new Vector3(0.0f, -0.1f, 0);
        animator.SetTrigger("Robo2trigger");
        rigidbody2D.velocity = new Vector2(movement.x, movement.y);
    }
    public void RunFaster(float fast)
    {
        //Debug.Log("Ja taas menn‰‰n!");
        speed = 5f;
        //Debug.Log("Maalla, lis‰t‰‰n" + speed);
        //deltaspeed = 0.05f;
        //maxspeed = 1f;
        //speedCoefficient = 3;
        animator.SetTrigger("Robo1trigger");
    }
}
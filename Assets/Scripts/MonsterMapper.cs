using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[AddComponentMenu("Kaitsu/Movement/MonsterMapper Follower")]
[RequireComponent(typeof(Rigidbody2D))]
public class MonsterMapper : Physics2DObject
{
	//public const string k_Key = "exploded";

	//public TileBase m_Border;
	//public TileBase m_ExplodedFloor;
    //public TileBase tieTiili;
    public TileBase vesiTiili;
    //public TileBase stub;
    //public GameObject m_Explosion;
	
	private Grid m_Grid;
	//public Tilemap m_Foreground;
	//private Tilemap m_BackGround;
    public Tilemap m_TreeGround;
    //private GridInformation m_Info;
    private Vector3 monsterPosition;
    private Vector3 killDistance;

    //FOLLOW
    // This is the target the object is going to move towards
    public Transform target;
    [Header("Movement")]
    // Speed used to move towards the target
    public float speed = 1f;
    // Used to decide if the object will look at the target while pursuing it
    public bool lookAtTarget = false;
    // The direction that will face the target
    public Enums.Directions useSide = Enums.Directions.Up;

    //WANDER
    [Header("Movement")]
    //public float speed = 1f;
    public float directionChangeInterval = 3f;
    public bool keepNearStartingPoint = true;

    [Header("Orientation")]
    public bool orientToDirection = false;
    // The direction that the GameObject will be oriented to
    public Enums.Directions lookAxis = Enums.Directions.Up;


    private Vector2 direction;
    private Vector3 startingPoint;

    // Use this for initialization
    void Start ()
	{
        killDistance = new Vector3(300f, 300f, 0f);
        m_Grid = GameObject.Find("Grid").GetComponent<Grid>();
        //m_Info = m_Grid.GetComponent<GridInformation>();
        //m_Foreground = GameObject.Find("Tiet").GetComponent<Tilemap>();
        //m_BackGround = GameObject.Find("Ruoho").GetComponent<Tilemap>();
        //      m_TreeGround = GameObject.Find("Puut").GetComponent<Tilemap>();

        //we don't want directionChangeInterval to be 0, so we force it to a minimum value ;)
        if (directionChangeInterval < 0.1f)
        {
            directionChangeInterval = 0.1f;
        }

        // we note down the initial position of the GameObject in case it has to hover around that (see keepNearStartingPoint)
        startingPoint = transform.position;

        StartCoroutine(ChangeDirection());
    }
	
	// Update is called once per frame
	void Update ()
	{
        monsterPosition = this.transform.position;
        Vector3Int gridPos = m_Grid.WorldToCell(monsterPosition);
        //if(m_TreeGround.GetTile(gridPos) != null && m_TreeGround.GetTile(gridPos) != stub)
        if (m_TreeGround.GetTile(gridPos) == vesiTiili )
        {
            //Debug.Log("Monster on VEDESSÄ! " + gridPos);
            //gameObject.SendMessage("SlowDown", 0.2f);
        }
        else
            gameObject.SendMessage("RunFaster", 0.2f);

        //Debug.Log(transform.position);
        //Debug.Log(monsterPosition);
        if (m_Grid && (Input.GetKeyDown("k") || Input.GetKeyDown("l")))
		{
            //monsterPosition = this.transform.position;
            Debug.Log("k- tai l-kirjainta painettu");
			//Vector3 world = Camera.main.ScreenToWorldPoint(monsterPosition);
			//Vector3Int gridPos = m_Grid.WorldToCell(world);
            //Vector3Int gridPos = m_Grid.WorldToCell(monsterPosition);
            gridPos = m_Grid.WorldToCell(monsterPosition);
            Debug.Log("Monster ruudussa " + gridPos);
            

            //ExplodeCell(gridPos);
			//ExplodeCell(gridPos + new Vector3Int(-1, 0, 0));
			//ExplodeCell(gridPos + new Vector3Int(-2, 0, 0));
			//ExplodeCell(gridPos + new Vector3Int(1, 0, 0));
			//ExplodeCell(gridPos + new Vector3Int(2, 0, 0));
			//ExplodeCell(gridPos + new Vector3Int(0, -1, 0));
			//ExplodeCell(gridPos + new Vector3Int(0, -2, 0));
			//ExplodeCell(gridPos + new Vector3Int(0, 1, 0));
			//ExplodeCell(gridPos + new Vector3Int(0, 2, 0));
		}
	}

	private void ExplodeCell(Vector3Int position)
	{
		//if (m_Foreground.GetTile(position) == m_Border)
			return;

        //if(m_Foreground.GetTile(position) == tieTiili)
        //{
        //    m_Foreground.SetTile(position, null);
        //}
        // if (m_TreeGround.GetTile(position) != null)
        //{
        //    m_TreeGround.SetTile(position, stub);
        //}

        //m_Info.ErasePositionProperty(position, k_Key);
        //m_Info.SetPositionProperty(position, k_Key, 1);
        //foreach (var pos in new BoundsInt(position.x - 1, position.y - 1, position.z, 3, 3, 1).allPositionsWithin)
        //{
        //	if (m_Foreground.GetTile(pos) != null)
        //	{
        //		m_BackGround.SetTile(pos, m_ExplodedFloor);
        //	}
        //}
        //m_Foreground.SetTile(position, null);

        //GameObject.Instantiate(m_Explosion, m_Grid.CellToLocalInterpolated(position + new Vector3(0.5f, 0.5f)), Quaternion.identity);
    }

    // Calculates a new direction
    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            direction = Random.insideUnitCircle; //change the direction the player is going

            // if we need to keep near the starting point...
            if (keepNearStartingPoint)
            {
                // we measure the distance from it...
                float distanceFromStart = Vector2.Distance(startingPoint, transform.position);
                if (distanceFromStart > 1f + (speed * 0.1f)) // and if it's too much...
                {
                    //... we get a direction that points back to the starting point
                    direction = (startingPoint - transform.position).normalized;
                }
            }


            //if the object has to look in the direction of movement
            if (orientToDirection)
            {
                Utils.SetAxisTowards(lookAxis, transform, direction);
            }


            // this will make Unity wait for some time before continuing the execution of the code
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //do nothing if the target hasn't been assigned or it was detroyed for some reason
        if (target == null)
            return;

        //look towards the target
        if (lookAtTarget)
        {
            Utils.SetAxisTowards(useSide, transform, target.position - transform.position);
        }
        killDistance = target.position - transform.position;
        //Move towards the target
        if (Mathf.Abs(killDistance.x) < 2f || Mathf.Abs(killDistance.y) < 2f)
        {
            //Debug.Log("Lähellä... " + killDistance);
            rigidbody2D.MovePosition(Vector2.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed));
        }
        rigidbody2D.AddForce(direction * speed);
    }

    public void SlowDown(float slow)
    {
        //Debug.Log("Puussa ollaan, jarrutetaan");
        //speed -= slow;
        //deltaspeed = 0.01f;
        speed = 0.0f;
        //speedCoefficient = 1f;
        //rigidbody2D.velocity = new Vector3(0.0f, -0.1f, 0);
    }
    public void RunFaster(float fast)
    {
        //Debug.Log("Ja taas mennään!");
        speed = 0.5f;
        //deltaspeed = 0.05f;
        //maxspeed = 1f;
        //speedCoefficient = 3;
    }
}


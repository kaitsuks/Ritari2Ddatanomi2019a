using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroMapper : MonoBehaviour
{
	public TileBase vesiTiili;
	public TileBase hiekkaTiili;
    public TileBase suoTiili;
    public TileBase muuriTiili;
	private Grid m_Grid;
	public Tilemap m_Foreground;
	public Tilemap m_BackGround;
    private Vector3 characterPosition;
    private Vector3Int gridPos;
    private Vector3Int nextPos;
    private Move move;
    private bool dirNorth;
    private bool  dirEast;
    private bool dirSouth;
    private bool  dirWest;
    private int dirx;
    private int diry;
    private int n; //laskuri

    // Use this for initialization
    void Start ()
	{
		m_Grid = GameObject.Find("Grid").GetComponent<Grid>();
        move = gameObject.GetComponent<Move>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        characterPosition = this.transform.position;
        gridPos = m_Grid.WorldToCell(characterPosition);
        if(m_BackGround.GetTile(gridPos) == vesiTiili ) {
            //Debug.Log("HAHMO ON VEDESSƒ! " + gridPos);
            gameObject.SendMessage("SlowDown", 0.2f);
        }
        else
            gameObject.SendMessage("RunFaster", 0.2f);

        
        if (m_Grid && (Input.GetKeyDown("k") || Input.GetKeyDown("l")))
		{
            
            Debug.Log("k- tai l-kirjainta painettu");
            gridPos = m_Grid.WorldToCell(characterPosition);
            Debug.Log("Hahmo ruudussa " + gridPos);
            Debug.Log("Tiili on " + m_BackGround.GetTile(gridPos));
           
		}

        // LookAround();

        //n++;
        //if (n > 30)
        //{
        // if (move.movement != Vector2.zero)
        //{
            //Debug.Log("Luetaan uusi suunta ");
            //LookForward();
        //}
        //    n = 0;
        //}

    }

    public void LookAround()
    {
        //Debug.Log("Tarkistetaan maastoa ");

        if (dirWest)
            {
                nextPos = gridPos + new Vector3Int(-1, 0, 0);
            if (m_BackGround.GetTile(nextPos) == vesiTiili)
            {
                gameObject.SendMessage("SlowDown", 0.2f);
                Debug.Log("VETTƒ LƒNNESSƒ"); }
            }
            if (dirEast)
            {
                nextPos = gridPos + new Vector3Int(1, 0, 0);
            if (m_BackGround.GetTile(nextPos) == vesiTiili)
            {
                gameObject.SendMessage("SlowDown", 0.2f);
                Debug.Log("VETTƒ IDƒSSƒ");
            }
            }
            if (dirSouth)
            { 
                nextPos = gridPos + new Vector3Int(0, -1, 0);
            if (m_BackGround.GetTile(nextPos) == vesiTiili)
            {
                gameObject.SendMessage("SlowDown", 0.2f);
                Debug.Log("VETTƒ ETELƒSSƒ");
            }
            }

            if (dirNorth)
            {
                nextPos = gridPos + new Vector3Int(0, 1, 0);
            if (m_BackGround.GetTile(nextPos) == vesiTiili)
            {
                gameObject.SendMessage("SlowDown", 0.2f);
                Debug.Log("VETTƒ POHJOISESSA ");
            }
            }
        
    }

    public void LookForward()
    {
        dirNorth = false;
        dirEast = false;
        dirSouth = false;
        dirWest = false;

        if(Input.GetKeyDown("down")) dirSouth = true;
        if (Input.GetKeyDown("up")) dirNorth = true;
        if (Input.GetKeyDown("right")) dirEast = true;
        if (Input.GetKeyDown("left")) dirWest = true;

        //Debug.Log("Suunta " + move.movement);
        //dirx = (int) move.movement.x;
        //diry = (int) move.movement.y;

        ////y>0 etel‰‰n
        //if (diry < 0) dirSouth = true;
        ////y<0 pohjoiseen
        //if (diry > 0) dirNorth = true;
        ////x>0 it‰‰n
        //if (dirx > 0) dirEast = true;
        ////x<0 l‰nteen
        //if (dirx < 0) dirWest = true;

        // LookAround();
    }

    void FixedUpdate()
    {

        //n++;
        //if (n > 30)
        //{
            
                //Debug.Log("Luetaan uusi suunta ");
                LookForward();
                LookAround();
            
        //    n = 0;
        //}
    }
}


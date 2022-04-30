using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public List<GameObject> resources = new List<GameObject>();//树木
    public List<GameObject> items = new List<GameObject>();//食物等
    public List<GameObject> enemys = new List<GameObject>();//敌人等
    private List<Vector3> grassTileWorldPos = new List<Vector3>();
    private bool[] grassTileHasEmptySlot;

    public GameObject nextChest;
    private int grassTileCount;
    private int resourcesCount;
    private int itemsCount;
    private int enemysCount;
    //timmer
    public float spawDelay = 5f;
    private float spawnTimer = 0f;

    public int treeNumLimitation = 6;//max tree number
    private int numTree = 0;//树木计数

    public int itemsNumLimitation = 10;//max food
    private int numitems = 0;

    public int enemysNumLimitation = 3;//max enemy
    private int numenemeys;
    
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        

        Vector3Int tmOrg = tilemap.origin;
        Vector3Int tmSz = tilemap.size;

        //init grassTileWorldPos
        for(int x = tmOrg.x + 3 ; x < tmSz.x ; x++)
        {
            for(int y = tmOrg.y +1  ; y < tmSz.y ; y++)
            {
                if(tilemap.GetTile(new Vector3Int(x,y,0)) != null)
                {
                    int tempy = y;
                    int tempx = x;
                    if (tempy - 3 > 0)
                        tempy = tempy - 3;
                        if(tempx - 3 > 0){
                            tempx = tempx - 3;
                        }                      
                    Vector3 cellToWorldPos = tilemap.GetCellCenterWorld(new Vector3Int(tempx,tempy,0)); //cell postion转换 world postion
                    grassTileWorldPos.Add(cellToWorldPos);

                }
            }
        }
        grassTileCount = grassTileWorldPos.Count;
        resourcesCount = resources.Count;

        enemysCount = enemys.Count;

        itemsCount = items.Count;

        //init grassTileHasEmptySlo
        grassTileHasEmptySlot = new bool[grassTileCount];
        for(int i = 0; i < grassTileCount; i++)
        {
            grassTileHasEmptySlot[i] = true;
        }
        int aRandomTile = Random.Range(0, grassTileCount);
        Vector3 chestPos = grassTileWorldPos[aRandomTile];
        Instantiate(nextChest, chestPos , Quaternion.identity);
        treeSetup();
        enemysSetup();
    }

    private void treeSetup()
    {
        while (numTree <= treeNumLimitation) {
            //randomly chose an element
            int aRandomTile = Random.Range(0, grassTileCount);
            if(grassTileHasEmptySlot[aRandomTile] && numTree <= treeNumLimitation)
            {
                 Vector3 spawnPos = grassTileWorldPos[aRandomTile];
                int aRandomRes = Random.Range(0, resourcesCount);
                GameObject spawRes = resources[aRandomRes];

                Instantiate(spawRes, spawnPos , Quaternion.identity);

                grassTileHasEmptySlot[aRandomTile] = false;

                numTree++;
            }
        }

    }

        private void enemysSetup()
    {
        while (numenemeys <= enemysNumLimitation) {
            int aRandomTile = Random.Range(0, grassTileCount);
            if(grassTileHasEmptySlot[aRandomTile] && numenemeys <= enemysNumLimitation)
            {
                 Vector3 spawnPos = grassTileWorldPos[aRandomTile];
                int aRandomEne = Random.Range(0, enemysCount);
                GameObject spawEne = enemys[aRandomEne];
                Instantiate(spawEne, spawnPos , Quaternion.identity);

                grassTileHasEmptySlot[aRandomTile] = false;

                numenemeys++;
            }
        }
    }


}

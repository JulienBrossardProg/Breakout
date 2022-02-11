using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public int level = 1;
    public static WavesManager instance;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CreateLevel(BricksManager.instance.bricksObject);
    }

    public void CreateLevel(List<GameObject> gos)
    {
        for (int i = 0; i < level; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                gos.Add(Pooler.instance.Pop("Red Brick"));
                gos[gos.Count-1].transform.position = new Vector3(0,10-i-0.2f, j-8f);
            }
        }

        BricksManager.instance.AssociateBrick(level,level/2,level/3,level/4,level,level );
    }
}

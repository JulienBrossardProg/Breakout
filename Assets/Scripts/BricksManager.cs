using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BricksManager : MonoBehaviour
{
    public static BricksManager instance;
    public List<GameObject> bricksObject;
    private List<Brick> bricks;
    private int result;
    private GameObject currentBrick;



    private void Awake()
    {
        instance = this;
    }

    public void SetLife(GameObject go)
    {
        int iteration = FindGameObjectIteration(go, bricksObject);
        if (bricks[iteration].lifeCount == 5)
        {
            bricks[iteration] = new GreenBrick();
            bricksObject[iteration] = Pooler.instance.Pop("Green Brick");
            bricksObject[iteration].transform.position = go.transform.position;
            Pooler.instance.DePop("Blue Brick",go);
        }
        else if (bricks[iteration].lifeCount == 4)
        {
            bricks[iteration] = new YellowBrick();
            bricksObject[iteration] = Pooler.instance.Pop("Yellow Brick");
            bricksObject[iteration].transform.position = go.transform.position;
            Pooler.instance.DePop("Green Brick",go);
        }
        else if (bricks[iteration].lifeCount == 3)
        {
            bricks[iteration] = new OrangeBrick();
            bricksObject[iteration] = Pooler.instance.Pop("Orange Brick");
            bricksObject[iteration].transform.position = go.transform.position;
            Pooler.instance.DePop("Yellow Brick",go);
        }
        else if (bricks[iteration].lifeCount == 2)
        {
            bricks[iteration] = new RedBrick();
            bricksObject[iteration] = Pooler.instance.Pop("Red Brick");
            bricksObject[iteration].transform.position = go.transform.position;
            Pooler.instance.DePop("Orange Brick",go);
        }
        else
        {
            if (go.gameObject.GetComponent<IHasBonus>()!=null)
            {
                go.gameObject.GetComponent<IHasBonus>().SpawnBonus();
                bricks.Remove(bricks[iteration]);
                bricksObject.Remove(go);
                if (go.gameObject.GetComponent<BlackBrick>()!=null)
                {
                    Pooler.instance.DePop("Black Brick",go);
                }
                else
                {
                    Pooler.instance.DePop("White Brick",go); 
                }
            }
            else
            {
                bricks.Remove(bricks[iteration]);
                bricksObject.Remove(go);
                Pooler.instance.DePop("Red Brick",go);
            }
        }
    }

    public void AssociateBrick(int orangeNb, int yellowNb, int greenNb, int blueNb, int blackNb, int whiteNb)
    {
        int redNb = bricksObject.Count - orangeNb - yellowNb - greenNb - blueNb - blackNb - whiteNb;
        bricks = new List<Brick>();
        for (int i = 0; i < redNb; i++)
        {
            bricks.Add(new RedBrick());
        }
        
        for (int i = 0; i < orangeNb; i++)
        {
            bricks.Add(new OrangeBrick());
            result = Random.Range(0, bricksObject.Count-i);
            currentBrick = Pooler.instance.Pop("Orange Brick");
            currentBrick.transform.position = bricksObject[result].transform.position;
            Pooler.instance.DePop("Red Brick",bricksObject[result]);
            bricksObject.Remove(bricksObject[result]);
            bricksObject.Add(currentBrick);
        }
        
        for (int i = 0; i < yellowNb; i++)
        {
            bricks.Add(new YellowBrick());
            result = Random.Range(0, bricksObject.Count-i-orangeNb);
            currentBrick = Pooler.instance.Pop("Yellow Brick");
            currentBrick.transform.position = bricksObject[result].transform.position;
            Pooler.instance.DePop("Red Brick",bricksObject[result]);
            bricksObject.Remove(bricksObject[result]);
            bricksObject.Add(currentBrick);
        }
        
        for (int i = 0; i < greenNb; i++)
        {
            bricks.Add(new GreenBrick());
            result = Random.Range(0, bricksObject.Count-i-orangeNb-yellowNb);
            currentBrick = Pooler.instance.Pop("Green Brick");
            currentBrick.transform.position = bricksObject[result].transform.position;
            Pooler.instance.DePop("Red Brick",bricksObject[result]);
            bricksObject.Remove(bricksObject[result]);
            bricksObject.Add(currentBrick);
        }
        
        for (int i = 0; i < blueNb; i++)
        {
            bricks.Add(new BlueBrick());
            result = Random.Range(0, bricksObject.Count-i-orangeNb-yellowNb-greenNb);
            currentBrick = Pooler.instance.Pop("Blue Brick");
            currentBrick.transform.position = bricksObject[result].transform.position;
            Pooler.instance.DePop("Red Brick",bricksObject[result]);
            bricksObject.Remove(bricksObject[result]);
            bricksObject.Add(currentBrick);
        }
        
        for (int i = 0; i < blackNb; i++)
        {
            bricks.Add(new BlackBrick());
            result = Random.Range(0, bricksObject.Count-i-orangeNb-yellowNb-greenNb- blueNb);
            currentBrick = Pooler.instance.Pop("Black Brick");
            currentBrick.transform.position = bricksObject[result].transform.position;
            Pooler.instance.DePop("Red Brick",bricksObject[result]);
            bricksObject.Remove(bricksObject[result]);
            bricksObject.Add(currentBrick);
        }
        
        for (int i = 0; i < whiteNb; i++)
        {
            bricks.Add(new WhiteBrick());
            result = Random.Range(0, bricksObject.Count-i-orangeNb-yellowNb-greenNb- blueNb - blackNb);
            currentBrick = Pooler.instance.Pop("White Brick");
            currentBrick.transform.position = bricksObject[result].transform.position;
            Pooler.instance.DePop("Red Brick",bricksObject[result]);
            bricksObject.Remove(bricksObject[result]);
            bricksObject.Add(currentBrick);
        }
    }

    private int FindGameObjectIteration(GameObject go,List<GameObject> gos)
    {
        for (int i = 0; i < gos.Count; i++)
        {
            if (gos[i]==go)
            {
                return i;
            }
        }

        return 0;
    }
}

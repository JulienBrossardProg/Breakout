using System.Runtime.Remoting.Channels;
using UnityEngine;

public class WhiteBrick : Brick, IHasBonus
{
    public WhiteBrick()
    {
        lifeCount = 1;
    }
    
    public void SpawnBonus()
    {
        Pooler.instance.Pop("Bonus").transform.position = transform.position;
    }
}

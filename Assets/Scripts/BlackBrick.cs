using UnityEngine;

public class BlackBrick : Brick, IHasBonus
{
    public BlackBrick()
    {
        lifeCount = 1;
    }

    public void SpawnBonus()
    {
        Pooler.instance.Pop("Malus").transform.position = transform.position;
    }
}

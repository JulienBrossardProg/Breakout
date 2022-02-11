using UnityEngine;

public class BallManager : MonoBehaviour
{
    public int ballCount = 1;
    public static BallManager instance;

    private void Awake()
    {
        instance = this;
    }
}

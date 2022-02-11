using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public int score;
    public int scoreBrick;
    public TMP_Text text;

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int point)
    {
        score += point;
        text.text = "Score : " + score;
    }
    
    
}

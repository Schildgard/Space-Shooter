using TMPro;
using UnityEngine;

public class HUDHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text KillCountText;

    private float score = 0;
    public int KillCount = 0;

    public void SetScore(float _value)
    {
        score += _value;
        ScoreText.text = score.ToString();
    }

    public void AddKillScore()
    {
        if (KillCountText != null)
        {
            KillCount += 1;
            KillCountText.text = "Targets Destroyed:\n " + KillCount.ToString();
        }
    }
}

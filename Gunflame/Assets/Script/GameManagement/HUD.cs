using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image lifeBar;
    public void ChangeLife(float _lifepercent)
    {
        lifeBar.fillAmount = _lifepercent / 100;
    }
}

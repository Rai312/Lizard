using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _mainCanvas;

    public void EnableMainCanvas()
    {
        _mainCanvas.gameObject.SetActive(true);
    }

    public void DisableMainCanvas()
    {
        _mainCanvas.gameObject.SetActive(false);
    }
}

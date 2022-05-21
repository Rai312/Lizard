using UnityEngine;

public class FinishCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _finishCanvas;
    
    public void EnableFinishCanvas()
    {
        _finishCanvas.gameObject.SetActive(true);
    }

    public void DisableFinishCanvas()
    {
        _finishCanvas.gameObject.SetActive(false);
    }
}

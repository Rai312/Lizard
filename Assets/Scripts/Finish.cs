using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private MainCanvas _mainCanvas;
    [SerializeField] private FinishCanvas _finishCanvas;
    [SerializeField] private FinishTrigger _finishTrigger;

    private void OnEnable()
    {
        _finishTrigger.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _finishTrigger.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        _mainCanvas.DisableMainCanvas();
        _finishCanvas.EnableFinishCanvas();
    }
}

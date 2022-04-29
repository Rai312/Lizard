using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _finishPositionZ;

    private void Start()
    {
        _slider.minValue = _player.transform.position.z;
        _slider.maxValue = _finishPositionZ;
    }

    private void Update()
    {
        _slider.value = _player.transform.position.z;
    }
}

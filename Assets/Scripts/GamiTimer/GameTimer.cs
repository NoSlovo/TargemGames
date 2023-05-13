using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Text _timer;
    [SerializeField] private string _text = "Времени прошло:";
    [SerializeField] private Button _buttonReset;
    
    private int _timeValue = 0;
    private int _timeStartDefaultValue = 0;
    private float _oneSecondDuration = 1f;
    private float _oneSecondValue = 1f;

    private void Awake() => _buttonReset.onClick.AddListener(Reset);
    
    private void Start() => _timer.text = _text + _timeValue;
    
    private void FixedUpdate()
    {
        _oneSecondDuration -= Time.fixedDeltaTime;

        if (_oneSecondDuration <= 0)
        {
            _oneSecondDuration = _oneSecondValue;
            _timeValue++;
        }

        _timer.text = _text + _timeValue;
    }

    private void Reset() => _timeValue = _timeStartDefaultValue;
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionCounter : MonoBehaviour
{
    [SerializeField] private Text _textCounter;
    [SerializeField] private Button _buttonReset;
    [SerializeField] private List<ShapeElement> _shapeElements;

    private const string _text = "Количество столкновений:";
    private int _counterKick;
    private float _delay = 1f;
    private float _maxDelayValue = 1f;

    private void OnEnable() => Listen();

    private void Awake() => _buttonReset.onClick.AddListener(Reset);

    private void Start() => Show();

    private void Update() => _delay -= Time.fixedDeltaTime;

    private void Handler()
    {
        if (_delay <= 0)
        {
            _counterKick++;
            Show();
            _delay = _maxDelayValue;
        }
    }

    private void Listen()
    {
        foreach (var datactionColaided in _shapeElements)
            datactionColaided.ObjectsTouched += Handler;
    }

    private void DisableListen()
    {
        foreach (var datactionColaided in _shapeElements)
            datactionColaided.ObjectsTouched -= Handler;
    }

    private void Show() => _textCounter.text = _text + _counterKick;

    private void Reset()
    {
        _counterKick = 0;
        Show();
    }

    private void OnDisable() => DisableListen();
}
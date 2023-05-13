using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionCounter : MonoBehaviour
{
    [SerializeField] private Text _textCounter;
    [SerializeField] private string _text = "Количество столкновений:";
    [SerializeField] private Button _buttonReset;
    [SerializeField] private List<ShapeElement> _shapeElements;
    
    private int _counterKick;

    private void OnEnable()=> Listen();
    
    private void Awake() => _buttonReset.onClick.AddListener(Reset);

    private void Start() => _textCounter.text = _text;

    private void Update() => _textCounter.text = _text + _counterKick;

    private void Handler()=> _counterKick++;

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

    private void Reset() => _counterKick = 0;
    
    private void OnDisable() => DisableListen();
}
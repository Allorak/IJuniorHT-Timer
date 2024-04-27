using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    
    private float _counter = 0;
    private Coroutine _increaseCounterRepeatedlyCoroutine;
    private bool _isActive = false;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) 
            return;

        if (_isActive == false)
            _increaseCounterRepeatedlyCoroutine = StartCoroutine(nameof(IncreaseCounterRepeatedly));
        else
            StopCoroutine(_increaseCounterRepeatedlyCoroutine);

        _isActive = !_isActive;
    }

    private IEnumerator IncreaseCounterRepeatedly()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            yield return wait;
            _counter++;
            Debug.Log(_counter);
        }
    }
}

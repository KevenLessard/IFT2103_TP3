using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GoldenSnitch : MonoBehaviour
{
    [SerializeField] private GameObject rails;

    [SerializeField] private float speed;

    private List<Transform> _railList;

    private int _currentRailIndex;

    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _railList = rails.GetComponentsInChildren<Transform>().ToList();
        _railList.RemoveAt(0);
        _transform = transform;
        _transform.position = _railList[0].position;
        _currentRailIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position =
            Vector2.MoveTowards(_transform.position,
                _railList[_currentRailIndex].position,
                speed * Time.deltaTime);
        
        if (Vector2.Distance(_transform.position, _railList[_currentRailIndex].position) < 0.01f)
        {
            _currentRailIndex = (_currentRailIndex + 1) % _railList.Count;
        }
    }
}
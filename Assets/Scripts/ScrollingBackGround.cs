using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    [Header("Scrolling Settings")]
    [SerializeField] private float _backGroundSize = default;
    [SerializeField] private Transform _cameraTransform = default;
    [SerializeField] private Transform[] _layers = default;
    [SerializeField] private float _vievZone = default;

    [Header("Parallax Settings")]
    [SerializeField] private float _parallaxSpeed = default;
    [SerializeField] private float _yOffset = 1;

    private int _leftIndex;
    private int _rightIndex;
    private float _lastCameraX;

    private Vector3 _vectorRight = Vector3.right;
    private Vector3 _tempPosition = Vector3.zero;

    private void Start()
    {
        _lastCameraX = _cameraTransform.position.x;

        _leftIndex = 0;
        _rightIndex = _layers.Length - 1;
    }

    private void LateUpdate()
    {
        float _deltaX = _cameraTransform.position.x - _lastCameraX;
        //transform.position += _vectorRight * (_deltaX * _parallaxSpeed);

        _tempPosition.Set(transform.position.x + (_deltaX * _parallaxSpeed),
                                _cameraTransform.position.y - _yOffset,
                                transform.position.z);

        transform.position = _tempPosition;

        _lastCameraX = _cameraTransform.position.x;

        if (_cameraTransform.position.x < _layers[_leftIndex].position.x + _vievZone)
            ScrollLeft();
        if (_cameraTransform.position.x > _layers[_rightIndex].position.x - _vievZone)
            ScrollRight();
    }

    private void ScrollLeft()
    {
        //int lastRight = _rightIndex;
        //_layers[_rightIndex].position = _vectorRight * (_layers[_leftIndex].position.x - _backGroundSize);
        _layers[_rightIndex].position = new Vector3(_layers[_leftIndex].position.x - _backGroundSize,
                                                    transform.position.y,
                                                    transform.position.z);
        _leftIndex = _rightIndex;
        _rightIndex--;
        if (_rightIndex < 0)
            _rightIndex = _layers.Length - 1;
    }

    private void ScrollRight()
    {
        //int lastLeft = _leftIndex;
        //_layers[_leftIndex].position = _vectorRight * (_layers[_rightIndex].position.x + _backGroundSize);
        _layers[_leftIndex].position = new Vector3(_layers[_rightIndex].position.x + _backGroundSize,
                                                    transform.position.y,
                                                    transform.position.z);
        _rightIndex = _leftIndex;
        _leftIndex++;
        if (_leftIndex == _layers.Length)
            _leftIndex = 0;
    }
}

using UnityEngine;

public sealed class ClampPosition : MonoBehaviour
{
    [SerializeField] private Vector2 _positionX = Vector2.zero;
    [SerializeField] private Vector2 _positionY = Vector2.zero;
    [SerializeField] private Vector2 _positionZ = Vector2.zero;

    [SerializeField] private Transform _target = null;

    private void Update()
    {
        float x = Mathf.Clamp(_target.position.x, _positionX.x, _positionX.y);
        float y = Mathf.Clamp(_target.position.y, _positionY.x, _positionY.y);
        float z = Mathf.Clamp(_target.position.z, _positionZ.x, _positionZ.y);

        _target.position = new Vector3(x,y,z);
    }
}
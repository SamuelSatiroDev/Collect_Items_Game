using UnityEngine;

public sealed class TransformGroup : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms = new Transform[] { };

    public Transform[] Transforms => _transforms;
}
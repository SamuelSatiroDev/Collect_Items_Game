using System.Collections.Generic;
using UnityEngine;

public sealed class AIFieldOfVisionManager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> fielOfVision = new List<GameObject>();
    [HideInInspector] public List<NavegationFollowTarget> navegationFollowTarget = new List<NavegationFollowTarget>();

    private void Awake()
    {
        GameManagerData.Instance.AIFieldOfVisionManager = this; 
    }
}
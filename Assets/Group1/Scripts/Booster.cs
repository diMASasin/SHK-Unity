using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private float _duration = 2;
    [SerializeField] private float _speedIncreaseMultiplier = 2;

    public float Duration => _duration;
    public float SpeedIncreaseMultiplier => _speedIncreaseMultiplier;
}

using System;
using UnityEngine;

public class Bonus : MonoBehaviour, IBonus
{
    [SerializeField] private Transform padel;

    private void Awake()
    {
        padel = GameObject.FindWithTag("Padel").transform;
    }

    public void Use()
    {
        padel.localScale = new Vector3(padel.localScale.x, padel.localScale.y+0.1f, padel.localScale.z);
        Pooler.instance.DePop("Bonus", gameObject);
    }
}

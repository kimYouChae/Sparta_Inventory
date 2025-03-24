using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    [SerializeField] private float attack;
    [SerializeField] private float defence;
    [SerializeField] private float hp;
    [SerializeField] private float criticalHit;

    public float Attack { get => attack; set => attack = value; }
    public float Defence { get => defence; set => defence = value; }
    public float Hp { get => hp; set => hp = value; }
    public float CriticalHit { get => criticalHit; set => criticalHit = value; }

    public Character(float a, float d, float h, float c)
    {
        this.attack = a;
        this.defence = d;
        this.hp = h;
        this.criticalHit = c;
    }
}

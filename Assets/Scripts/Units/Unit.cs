using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Unit : MonoBehaviour 
{
    public bool IsSelected { get; set; }
    public GameObject Target { get; set; }
    public Vector3 Destination { get; set; }

    public Slider HealtBar;
    public GameObject SelectionIndicator;
    public int Team;
    public string Name;
    public int MaxHealth;
    public int CurrHealth;
    public float Speed = 10f;
    public float Acceleration = 10f;
    public float RotationSpeed = 1240f;
    public int Damage;
    public float Range;
    public float AtackSpeed;
    public bool IsDead;

    public abstract void ReceveDamage(int dmg);
    public abstract void SetTarget(GameObject target);
    public abstract void SetDestination(Vector3 destination);
    public abstract void Die();
}

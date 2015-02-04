using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Unit : MonoBehaviour
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

    private UnitManager _unitManager;
    private Animation _animation;
    private NavMeshAgent _agent;
    private bool _isDead;
    private bool _isAtacking;

    void Awake()
    {
        _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
        _animation = GetComponent<Animation>();
        _agent = GetComponent<NavMeshAgent>();
    }
	void Start ()
	{
	    GameObjectInfo.GetObjectInfoById(gameObject.GetInstanceID()).Team = Team;
        _unitManager.RegisterUnit(gameObject.GetInstanceID(), this);
	    CurrHealth = MaxHealth;
	    HealtBar.maxValue = MaxHealth;
	    HealtBar.value = CurrHealth;
	}

    void Update()
    {
        if (_isDead)
            return;
        if(CurrHealth <= 0)
            Die();

        if (Target != null && _agent.remainingDistance > Range && !_isAtacking)
        {
            StartCoroutine(Atack(Target));
        }
    }

    public IEnumerator Atack(GameObject other)
    {
        _isAtacking = true;
        _animation.CrossFade("attack");
        var target = _unitManager.GetUnitByObjectId(other.GetInstanceID());
        target.ReceveDamage(Damage);
        if (target.CurrHealth <= 0)
            Target = null;

        yield return new WaitForSeconds(AtackSpeed);
        _isAtacking = false;
    }

    public bool ReceveDamage(int dmg)
    {
        CurrHealth = Mathf.Clamp(CurrHealth - dmg, 0, MaxHealth);
        HealtBar.value = CurrHealth;
        if(!_isDead)
            _animation.CrossFade("gethit");
        if (CurrHealth == 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        _isDead = true;

        if(IsSelected)
            _unitManager.DeselectSingleUnit(this);

        _animation.CrossFade("die");

        Invoke("DesableComponentsOnDeath", 3f);
    }

    private void DesableComponentsOnDeath()
    {
        _animation.enabled = false;
        _agent.enabled = false;
        collider.enabled = false;
    }
}

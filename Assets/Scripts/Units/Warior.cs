using UnityEngine;
using System.Collections;

public class Warior : Unit 
{
    private UnitManager _unitManager;
    private Animation _animation;
    private NavMeshAgent _agent;
    private bool _isAtacking;

    void Awake()
    {
        _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
        _animation = GetComponent<Animation>();
        _agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        GameObjectInfo.GetObjectInfoById(gameObject.GetInstanceID()).Team = Team;
        _unitManager.RegisterUnit(gameObject.GetInstanceID(), this);
        CurrHealth = MaxHealth;
        HealtBar.maxValue = MaxHealth;
        HealtBar.value = CurrHealth;
    }
	
	void Update () 
    {
        if (IsDead)
            return;
        if (CurrHealth <= 0)
            Die();

        if (Target != null && Vector3.Distance(Target.transform.position, transform.position) <= Range && !_isAtacking)
        {
            Destination = transform.position;
            StartCoroutine(Attack(Target));
        }

        if (Target != null)
        {
            transform.LookAt(Target.transform);
            Destination = Target.transform.position;
        }

        _agent.SetDestination(Destination);

        // Run appropriat animations
        if (_agent.velocity.z != 0 || _agent.velocity.x != 0 && !_isAtacking && !_animation.IsPlaying("gethit"))
        {
            _animation.CrossFade("run");
        }
        else if (_agent.velocity.z == 0 && _agent.velocity.x == 0 && !_isAtacking && !_animation.IsPlaying("gethit"))
        {
            _animation.CrossFade("idle");
        }
	}

    private IEnumerator Attack(GameObject other)
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

    private void DesableComponentsOnDeath()
    {
        _animation.enabled = false;
        _agent.enabled = false;
        collider.enabled = false;

    }

    public override void ReceveDamage(int dmg)
    {
        CurrHealth = Mathf.Clamp(CurrHealth - dmg, 0, MaxHealth);
        HealtBar.value = CurrHealth;
        _animation.CrossFade("gethit");
        
        if (CurrHealth == 0)
            Die();
    }

    public override void SetTarget(GameObject target)
    {
        Target = target;
    }

    public override void SetDestination(Vector3 destination)
    {
        Target = null;
        Destination = destination;
    }

    public override void Die()
    {
        IsDead = true;

        if(IsSelected)
            _unitManager.DeselectSingleUnit(this);

        _animation.CrossFade("die");

        Invoke("DesableComponentsOnDeath", 3f);
    }
}

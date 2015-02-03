using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public bool IsSelected { get; set; }
    public GameObject SelectionIndicator { get; private set; }
    
    public int Team;
    public string Name;
    public int MaxHealth;
    public int CurrHealth;
    public int Damage;
    public float Range;
    public float AttackSpeed;

    private UnitManager _unitManager;
    private NavMeshAgent _agent;
    private bool _isDead;
    private float _lastAtack;

	void Start ()
	{
	    _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
	    _agent = GetComponent<NavMeshAgent>();
	    SelectionIndicator = transform.Find("SelectionIndicator").gameObject;
	    CurrHealth = MaxHealth;
	}

    void Update()
    {
      
    }

    public void Select()
    {
        
    }

    public bool ReceveDamage(int dmg)
    {
        CurrHealth = Mathf.Clamp(CurrHealth - dmg, 0, MaxHealth);

        if (CurrHealth == 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        //_isDead = true;

        //if (_sel.IsSelected)
        //{
        //    for (int i = 0; i < Selectable.Selections.Length; i++)
        //    {
        //        if (Selectable.Selections[i] != null && Selectable.Selections[i].ID == _sel.ID)
        //        {
        //            Selectable.Selections[i] = null;
        //        } 
        //    }
        //    _sel.SelectionIndicator.SetActive(false);
        //}
        //_sel.enabled = false;

        //transform.Rotate(90f, 0, 0);

        //Destroy(gameObject, 5f);
    }
}

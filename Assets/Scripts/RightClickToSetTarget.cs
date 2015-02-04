using UnityEngine;
using System.Collections;

public class RightClickToSetTarget : MonoBehaviour
{

    private Unit _unit;
    private Animation _animation;
    private UnitManager _unitManager;

    void Awake()
    {
        _unit = GetComponent<Unit>();
        _animation = GetComponent<Animation>();
        _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            var selectedUnits = _unitManager.GetSelectedUnits();
            if (selectedUnits.Count > 0)
            {
                var hit = GetHit();
                if (!hit.transform.gameObject.CompareTag("Walkable"))
                {
                    foreach (var unit in selectedUnits)
                    {
                        unit.Target = hit.transform.gameObject;
                    }
                }
            }

            //if (_unit.IsSelected && Input.GetMouseButtonUp(1))
            //{
            //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    RaycastHit hit;

            //    Physics.Raycast(ray, out hit, Mathf.Infinity);

            //    if (IsObjectAttacable(hit.transform.gameObject))
            //    {
            //        _unit.Target = hit.transform.gameObject;
            //    }
            //}
        }
    }

    private RaycastHit GetHit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, Mathf.Infinity);

        return hit;
    }
}

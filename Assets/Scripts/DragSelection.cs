using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

[AddComponentMenu("Controlls/Drag Selection")]
public class DragSelection : MonoBehaviour
{
    public Texture2D SelectionBoxTexture;
    public static Rect SelectionBox;
    
    private Vector3 _startClick;
    private UnitManager _unitManager;

    void Awake ()
    {
        _unitManager = GameObject.Find("PlayerUnitManager").GetComponent<UnitManager>();
    }
	
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SelectionBox = new Rect(0, 0, 0, 0);
            _startClick = -Vector3.one;
        }

        if (Input.GetMouseButton(0))
        {
            SelectionBox = new Rect(
                _startClick.x,
                InvertMouseY(_startClick.y),
                Input.mousePosition.x - _startClick.x,
                InvertMouseY(Input.mousePosition.y) - InvertMouseY(_startClick.y));

            if (SelectionBox.width < 0)
            {
                SelectionBox.x += SelectionBox.width;
                SelectionBox.width = -SelectionBox.width;
            }
            if (SelectionBox.height < 0)
            {
                SelectionBox.y += SelectionBox.height;
                SelectionBox.height = -SelectionBox.height;
            }
        }
	}

    public static float InvertMouseY(float y)
    {
        return Screen.height - y;
    }

    private void OnGUI()
    {
        if (_startClick != -Vector3.one)
        {
            GUI.color = new Color(1, 1, 1, 0.5f);
            GUI.DrawTexture(SelectionBox, SelectionBoxTexture);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldController : MonoBehaviour
{
    [SerializeField] int index;
    
    public void OnValueChanged()
    {
        Controller.Instance.OnValueChanged(index);
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }
}

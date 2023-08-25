using UnityEngine;

[CreateAssetMenu()]
public class IntVariable : ScriptableObject
{
    [SerializeField]
    private int _value;

    public int Value
    {
        get { return _value; }
        set
        {
            if (_value != value)
            {
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }

    public delegate void ValueChanged(int newValue);
    public event ValueChanged OnValueChanged;
}
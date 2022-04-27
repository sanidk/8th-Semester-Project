using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierSyncTest : MonoBehaviour
{
    public int _modifier = default;
    public int _previousModifier = default;
    public ModifierSync _modifierSync;

    // Start is called before the first frame update
    void Start()
    {
        _modifierSync = GetComponent<ModifierSync>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_modifier != _previousModifier)
        {
            //_modifierSync.SetColor(_modifier);
            _previousModifier = _modifier;
        }
    }
}

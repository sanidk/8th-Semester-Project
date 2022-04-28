using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ModifierSync : RealtimeComponent<ModifierSyncModel>
{

    public BallBehaviour _ballBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        _ballBehaviour = GetComponent<BallBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnRealtimeModelReplaced(ModifierSyncModel previousModel, ModifierSyncModel currentModel)
    {
        //base.OnRealtimeModelReplaced(previousModel, currentModel);
        //UpdateMeshRendererColor();
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.modifierDidChange -= ModifierDidChange;
        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
                currentModel.modifier = _ballBehaviour.modifier;

            // Update the mesh render to match the new model
            UpdateModifier();

            // Register for events so we'll know if the color changes later
            currentModel.modifierDidChange += ModifierDidChange;
        }
    }

    private void UpdateModifier()
    {
        _ballBehaviour.modifier = model.modifier;
    }

    private void ModifierDidChange(ModifierSyncModel model, int value)
    {
       UpdateModifier();
    }

    public void SetModifier(int val)
    {
        model.modifier = val;
    }

    public int GetModifier()
    {
        return model.modifier;
    }
}

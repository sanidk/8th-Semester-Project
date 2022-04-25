using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ColorSync : RealtimeComponent<ColorSyncModel>
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void OnRealtimeModelReplaced(ColorSyncModel previousModel, ColorSyncModel currentModel)
    {
        //base.OnRealtimeModelReplaced(previousModel, currentModel);
        //UpdateMeshRendererColor();
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.colorDidChange -= ColorDidChange;
        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
                currentModel.color = _meshRenderer.material.color;

            // Update the mesh render to match the new model
            UpdateMeshRendererColor();

            // Register for events so we'll know if the color changes later
            currentModel.colorDidChange += ColorDidChange;
        }
    }

    private void UpdateMeshRendererColor()
    {
        _meshRenderer.material.color = model.color;
    }

    private void ColorDidChange(ColorSyncModel model, Color value)
    {
        UpdateMeshRendererColor();
    }

    public void SetColor(Color color)
    {
        model.color = color;
    }

    public Color GetColor()
    {
        return model.color;
    }


}

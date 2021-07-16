using UnityEngine;

public class MaterialRenderer : MonoBehaviour

{
    [SerializeField] private Renderer _renderer;

    public virtual void SetMaterial(Material material)
    {
        _renderer.sharedMaterial = material;
    }
}
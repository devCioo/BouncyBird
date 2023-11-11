using UnityEngine;

public class MeshScroller : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField] private float scrollSpeed = 1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
    }
}

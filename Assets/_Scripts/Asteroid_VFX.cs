using DG.Tweening;
using UnityEngine;

public class Asteroid_VFX : MonoBehaviour
{
    public GameObject vfx;
    public float time;
    public float delay;

    public Ease enEase;

    public Vector3 scale;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void InstanceVFX(Sprite sprite)
    {
        Instantiate(vfx, transform.position, Quaternion.identity);
        transform.localScale = Vector3.zero;
        transform.DOScale(scale, time).SetEase(enEase).SetDelay(delay).SetUpdate(true);
        spriteRenderer.sprite = sprite;
    }
}

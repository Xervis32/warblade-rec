using System.Collections;
using UnityEngine;

public class Entity_FVX : MonoBehaviour
{
    private Material originalMat;
    private SpriteRenderer sr;

    [SerializeField] private Material onDamageVfxMat;
    private float onDamageVfxDuration = 0.07f;
    private Coroutine onDamageVfxCo;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalMat = sr.material;
    }

    public void PlayOnDamageVfx()
    {
        if (onDamageVfxCo != null)
        {
            StopCoroutine(onDamageVfxCo);
        }
        onDamageVfxCo = StartCoroutine(OnDamageVfxCo());
    }

    private IEnumerator OnDamageVfxCo()
    {
        sr.material = onDamageVfxMat;
        yield return new WaitForSeconds(onDamageVfxDuration);
        sr.material = originalMat;
    }
}

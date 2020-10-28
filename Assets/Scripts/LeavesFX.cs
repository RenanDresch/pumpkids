using System.Collections;
using UnityEngine;

public class LeavesFX : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer smr = default;
    [SerializeField]
    private float blendSpeed = default;
    [SerializeField]
    private ParticleSystem ps = default;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            activated = true;
            ps.Play();
            StartCoroutine(AnimateLeaves());
        }
    }

    private IEnumerator AnimateLeaves()
    {
        var bs = smr.GetBlendShapeWeight(0);
        while (bs < 75f)
        {
            smr.SetBlendShapeWeight(0, bs + (Time.deltaTime * blendSpeed));
            bs = smr.GetBlendShapeWeight(0);
            yield return null;
        }
    }
}

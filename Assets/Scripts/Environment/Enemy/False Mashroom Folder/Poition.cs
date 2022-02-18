using System.Collections;
using UnityEngine;

public class Poition : MonoBehaviour
{
    [SerializeField] private float flyTime;
    [SerializeField] private float height; 
    [SerializeField] private GameObject breakingPoitionVFX; 
    [SerializeField] private AnimationCurve yAnimation;

    public void PlayAnimation(Transform jumper, float duration)
    {
        StartCoroutine(ThrowPoition_y(jumper, duration));
    }


    private IEnumerator ThrowPoition_y(Transform jumper, float duration)
    {
        float expiredSeconds = 0;
        float progress = 0;
        Vector3 startPosition = jumper.position;

        while(progress < 0)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            jumper.position = startPosition + new Vector3(0, yAnimation.Evaluate(progress), 0);
        }

        return null;
    }

    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out PlayerController playerController) || collision.gameObject.tag == "Ground")
        {
            Instantiate(breakingPoitionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

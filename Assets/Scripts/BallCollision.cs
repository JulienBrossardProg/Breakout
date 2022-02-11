using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallCollision : MonoBehaviour
{
    private bool canDamage = true;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            StartCoroutine(WaitDamage(other.gameObject));
        }
    }

    IEnumerator WaitDamage(GameObject go)
    {
        canDamage = false;
        yield return new WaitForSeconds(0.05f);
        canDamage = true;
        BricksManager.instance.SetLife(go);
        ScoreManager.instance.AddScore(10);
        StopAllCoroutines();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IBonus>()!=null)
        {
            Debug.Log("ok");
            other.gameObject.GetComponent<IBonus>().Use();
        }
    }
}

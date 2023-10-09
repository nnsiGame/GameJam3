using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] float m_DestroyTime = 0.3f;
    [SerializeField] float m_EnlargeSpeed = 5;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Destroy(gameObject,m_DestroyTime);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float colorMinus = spriteRenderer.color.a / m_DestroyTime;

        while (true)
        {
            transform.localScale = new Vector3(transform.localScale.x + m_EnlargeSpeed * Time.deltaTime, transform.localScale.y + m_EnlargeSpeed * Time.deltaTime, transform.localScale.z);

            spriteRenderer.color -= new Color(0, 0, 0, 4 * Time.deltaTime);
            yield return null;
        }
    }
}

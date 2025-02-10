using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class AppearEffect : MonoBehaviour
{
    [Header("Properties")]
    [Tooltip("����Ʈ ��� �ð� ")] public float effectDuration = 1.0f;
    [ReadOnly][Tooltip("����Ʈ ��� �ð�")] public float effectTimer = 0.0f;
    private GameObject target = null;
    private float lifeTimer = 0.0f;
    [Tooltip("����Ʈ ���� �ð�")] public float startTime = 0.0f;

    void Start()
    {
        target = gameObject;
        if (null == target)
        {
            Debug.Log("Effect Target is not setting.");
            return;
        }

        target.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;

        if(lifeTimer >= startTime)
        {
            effectTimer += Time.deltaTime;

            if (effectTimer <= effectDuration)
            {
                // alpha controller
                float alpha = (effectTimer / effectDuration);
                target.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
            }
            else
            {
                effectTimer = 0.0f;
                this.enabled = false;
            }
        }
    }
}

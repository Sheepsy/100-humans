using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeInstructions : MonoBehaviour
{
    [SerializeField] private GameObject instructionsObject;
    private TextMeshProUGUI instructions;

    // Start is called before the first frame update
    void Start()
    {
        instructions = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            instructionsObject.SetActive(false);
        }
    }

    private IEnumerator FadeOut()
    {
        float duration = 1.5f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            instructions.color = new Color(instructions.color.r, instructions.color.g, instructions.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float duration = 1.5f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            instructions.color = new Color(instructions.color.r, instructions.color.g, instructions.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(FadeOut());
    }
}

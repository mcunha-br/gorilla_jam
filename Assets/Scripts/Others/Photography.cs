using UnityEngine;
using System.Collections;

public class Photography : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("TakePhoto");
    }

    private IEnumerator TakePhoto() {
        var timer = Random.Range(1f, 2f);
        var photo = Random.Range(1, 4);
        spriteRenderer.color = new Color(GetRandomColor(), GetRandomColor(), GetRandomColor(), 1);
        yield return new WaitForSeconds(timer);

        for (int i = 0; i < photo; i++) {
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
        }

        spriteRenderer.enabled = false;
        StartCoroutine("TakePhoto");

    }

    private float GetRandomColor() {
        return Random.Range(0f, 1f);
    }
}

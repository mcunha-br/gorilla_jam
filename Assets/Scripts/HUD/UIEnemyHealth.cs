using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIEnemyHealth : MonoBehaviour {
    public Slider sliderHealth;
    public Image borderPhoto;
    public Image photography;

    public Sprite[] sprites;

   private void OnEnable() {
       EnemyAI.OnUpdateHealth += UpdateHealth;
   }

   private void OnDisable() {
       EnemyAI.OnUpdateHealth -= UpdateHealth;
   }

   private IEnumerator UpdateHealth(float health) {
       borderPhoto.color = Color.red;
       sliderHealth.value = health;
       photography.sprite = sprites[1];
       yield return new WaitForSeconds(0.2f);
       photography.sprite = sprites[0];
       borderPhoto.color = Color.white;
   }
}

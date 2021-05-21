using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIEnemyHealth : MonoBehaviour {
    public Slider sliderHealth;
    public Image borderPhoto;

   private void OnEnable() {
       EnemyAI.OnUpdateHealth += UpdateHealth;
   }

   private void OnDisable() {
       EnemyAI.OnUpdateHealth -= UpdateHealth;
   }

   private IEnumerator UpdateHealth(float health) {
       borderPhoto.color = Color.red;
       sliderHealth.value = health;
       yield return new WaitForSeconds(0.1f);
       borderPhoto.color = Color.white;
   }
}

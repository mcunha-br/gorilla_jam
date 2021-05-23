using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameObject credtits;

    public void SetButtons(string value) {
        switch (value) {
            case "START":
                SceneManager.LoadScene("GamePlay");
            break;

            case "CREDITS":
                credtits.SetActive(true);
            break;

            case "MENU":
                credtits.SetActive(false);                
            break;            
        }
    }
}

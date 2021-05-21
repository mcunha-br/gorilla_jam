using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void SetButtons(string value) {
        switch (value) {
            case "START":
                SceneManager.LoadScene("GamePlay");
            break;

            case "CREDITS":
                //TODO: Abrir um menu com o nome dos desenvolvedores
            break;

            case "MENU":
                //TODO: Voltar ao menu depois que entrar na tela de 'CREDITS'
            break;            
        }
    }
}

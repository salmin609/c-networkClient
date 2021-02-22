using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject startMenu;
    public InputField usernameField;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Instance already exist");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        startMenu.SetActive(false);
        usernameField.interactable = false;
        Client.instance.ConnectToServer();
    }
}

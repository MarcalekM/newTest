using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DataTransfer : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI inputField;

    public void LoadNextScene(int scene)
    {
        int myIntData;
        if (int.TryParse(inputField.text, out myIntData))
        {
            DataManager.SetMyIntData(myIntData);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scene);
        }
        else
        {
            Debug.LogError("Hiba");
        }
    }

    void Start()
    {
        int myIntData = DataManager.GetMyIntData();

        inputField.text = myIntData.ToString();
    }
}
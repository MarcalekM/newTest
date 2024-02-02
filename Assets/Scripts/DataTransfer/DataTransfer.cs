using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DataTransfer : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI inputField;

    // Function to load the next scene
    public void LoadNextScene(int scene)
    {
        // Get the int data from the TextMeshPro input field
        int myIntData;
        if (int.TryParse(inputField.text, out myIntData))
        {
            // Save the int data in the DataManager class
            DataManager.SetMyIntData(myIntData);

            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scene);
        }
        else
        {
            Debug.LogError("Hiba");
        }
    }

    void Start()
    {
        // Retrieve the int data from the DataManager class
        int myIntData = DataManager.GetMyIntData();

        // Display the int data in a TextMeshPro text component
        inputField.text = myIntData.ToString();
    }
}
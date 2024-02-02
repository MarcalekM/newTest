using TMPro;
using UnityEngine;

public class DeleteTrash : MonoBehaviour
{
    [SerializeField] private GameObject trash1Image;
    [SerializeField] private GameObject trash1Button;
    [SerializeField] private TextMeshProUGUI trash1Text;

    [SerializeField] private GameObject trash2Image;
    [SerializeField] private GameObject trash2Button;
    [SerializeField] private TextMeshProUGUI trash2Text;

    [SerializeField] private GameObject trash3Image;
    [SerializeField] private GameObject trash3Button;
    [SerializeField] private TextMeshProUGUI trash3Text;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentPoints;

    private void Start()
    {
        CheckAndDestroy(trash1Image, trash1Button, trash1Text, "Trash1Destroyed");
        CheckAndDestroy(trash2Image, trash2Button, trash2Text, "Trash2Destroyed");
        CheckAndDestroy(trash3Image, trash3Button, trash3Text, "Trash3Destroyed");

        currentPoints = int.Parse(scoreText.text);
    }

    private void Update()
    {
        currentPoints = int.Parse(scoreText.text);
    }

    private void CheckAndDestroy(GameObject image, GameObject button, TextMeshProUGUI text, string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            Destroy(image);
            Destroy(button);
            Destroy(text);
        }
    }

    private void RemoveTrash(GameObject image, GameObject button, TextMeshProUGUI text, int pointsNeeded, string key)
    {
        if (currentPoints >= pointsNeeded)
        {
            Destroy(image);
            Destroy(button);
            Destroy(text);

            PlayerPrefs.SetInt(key, 1);
            PlayerPrefs.Save();
        }
    }

    public void RemoveTrash1()
    {
        RemoveTrash(trash1Image, trash1Button, trash1Text, 10, "Trash1Destroyed");
    }

    public void RemoveTrash2()
    {
        RemoveTrash(trash2Image, trash2Button, trash2Text, 20, "Trash2Destroyed");
    }

    public void RemoveTrash3()
    {
        RemoveTrash(trash3Image, trash3Button, trash3Text, 30, "Trash3Destroyed");

    }
}

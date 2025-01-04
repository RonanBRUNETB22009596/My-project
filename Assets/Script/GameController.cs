using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        string selectedLevel = PlayerPrefs.GetString("SelectedLevel", "DefaultLevel");
        Debug.Log($"Current level: {selectedLevel}");
    }
}

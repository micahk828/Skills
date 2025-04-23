using UnityEngine;
using TMPro;

public class MemoryFragment : MonoBehaviour
{
    public string memoryID; 
    [TextArea(3, 6)] public string memoryText;

    public GameObject memoryPanel;
    public TextMeshProUGUI memoryTextUI;

    private bool showingMemory = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !PlayerPrefs.HasKey(memoryID))
        {
            ShowMemory();
        }
    }

    void Update()
    {
        if (showingMemory && Input.GetKeyDown(KeyCode.X))
        {
            HideMemory();
        }
    }

    void ShowMemory()
    {
        memoryTextUI.text = memoryText;
        memoryPanel.SetActive(true);
        Time.timeScale = 0f; 
        showingMemory = true;

        PlayerPrefs.SetInt(memoryID, 1); 
    }

    void HideMemory()
    {
        memoryPanel.SetActive(false);
        Time.timeScale = 1f;
        showingMemory = false;
        Destroy(gameObject); 
    }
}

using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField] private TMP_Text experienceText;
    public GameObject pausePanel;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateExperience(float value)
    {
        
    }
}

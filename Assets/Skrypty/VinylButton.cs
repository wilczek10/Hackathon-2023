using UnityEngine;
using UnityEngine.UI;

public class VinylButton : MonoBehaviour
{
    public string vinylName; // Nazwa winyla
    public AudioClip vinylClip; // Plik audio przypisany do winyla
    public InventoryManager inventoryManager;
    public AudioSource audioSource;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // Dodaj kod obsługi wybierania winyla
        Debug.Log("Wybrano winyl: " + vinylName);
        
        audioSource.Stop();

        audioSource.clip = vinylClip;
        // Odtwórz plik audio przypisany do winyla
        audioSource.Play();

        // Zamknij ekwipunek po wyborze
        inventoryManager.ToggleInventory();
    }
}

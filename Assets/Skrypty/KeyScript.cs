using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Podnieś klucz
            Destroy(gameObject);

            // Przejdź do drugiej sceny
            SceneManager.LoadScene("Poziom 2"); // Zastąp "NazwaDrugiejSceny" nazwą drugiej sceny
        }
    }
}

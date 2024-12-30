using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool GameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public static float Score;
    public Text coinsText;
    public Text scoreText;

    // Vitesse d'incrémentation du score
    public float scoreMultiplier = 10f;

    // Gestion du bouclier
    public GameObject shieldEffectPrefab;
    private GameObject activeShieldEffect;
    private bool isShieldActive;

    public Text shieldText;


    private bool isDoubleScoreActive = false;
    private float originalScoreMultiplier;
    public Text doubleScoreText; // Référence au texte UI


    void Start()
    {
        GameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
        Score = 0;
        ActivateShield(5f);

    }

    void Update()
    {
        if (GameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        else if (isGameStarted)
        {
            Score += Time.deltaTime * scoreMultiplier;
        }

        coinsText.text = "Coins : " + numberOfCoins.ToString();
        scoreText.text = "Score : " + Mathf.FloorToInt(Score).ToString();

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }

    public void ActivateShield(float duration)
    {
        if (isShieldActive) return;

        isShieldActive = true;

        if (shieldText)
        {
            Debug.Log("Texte du bouclier détecté, activation.");
            shieldText.enabled = true;
        }

        if (shieldEffectPrefab != null)
        {
            activeShieldEffect = Instantiate(shieldEffectPrefab, transform.position, Quaternion.identity, transform);
        }

        StartCoroutine(DisableShieldAfterTime(duration));
    }

    private IEnumerator DisableShieldAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (activeShieldEffect)
        {
            Destroy(activeShieldEffect);
        }

        if (shieldText)
        {
            shieldText.enabled = false;
        }

        isShieldActive = false;
    }

    // Gérer les collisions avec le bouclier
    private void OnCollisionEnter(Collision collision)
    {
        if (isShieldActive && collision.gameObject.CompareTag("Obstacle"))
        {
            // Annuler les effets de l'obstacle
            Destroy(collision.gameObject); // Exemple : détruire l'obstacle
            return;
        }

        // Logique existante pour les collisions
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
        }
    }

    public void HandleCollision(Transform hitObject)
    {
        if (hitObject.CompareTag("Obstacle"))
        {
            if (isShieldActive)
            {
                Debug.Log("Bouclier actif - Obstacle détruit.");
                Destroy(hitObject.gameObject); // Détruire l'obstacle
                return;
            }

            Debug.Log("Bouclier inactif - Game Over.");
            GameOver = true;
        }
    }

    public void ActivateDoubleScore(float duration)
    {
        if (isDoubleScoreActive) return; // Empêcher l'activation multiple

        Debug.Log("Doublement du score activé pour " + duration + " secondes.");

        isDoubleScoreActive = true;
        originalScoreMultiplier = scoreMultiplier;
        scoreMultiplier *= 2; // Multiplie le score par 2

        // Afficher le texte
        if (doubleScoreText != null)
        {
            doubleScoreText.text = "X2";
            doubleScoreText.enabled = true; // Activer le texte
        }

        StartCoroutine(DisableDoubleScoreAfterTime(duration));
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator DisableDoubleScoreAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);

        Debug.Log("Doublement du score désactivé.");

        scoreMultiplier = originalScoreMultiplier; // Restaure le multiplicateur initial
        isDoubleScoreActive = false;

        // Masquer le texte
        if (doubleScoreText)
        {
            doubleScoreText.text = "";
            doubleScoreText.enabled = false; // Désactiver le texte
        }
    }
}

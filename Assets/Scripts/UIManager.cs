using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] lives;
    [SerializeField]
    private Image _livesUI;
    [SerializeField]
    private Text _GameOver;
    private bool _GameOverBool;
    [SerializeField]
    private Text _reload;
    [SerializeField]
    private GameManager GameManager;
    void Start()
    {
        _GameOverBool = false;
        _scoreText.text = "Score: " + 0;
        _GameOver.transform.gameObject.SetActive(false);
        _reload.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void livesUI(int currentlives)
    {
        _livesUI.sprite = lives[currentlives];
        if (currentlives == 0 )
        {
            GameOverSequence();
        }
    }
    IEnumerator GameOverFlicker()
    {     
        while (_GameOverBool == true)
        {
            yield return new WaitForSeconds(0.5f);
            _GameOver.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _GameOver.transform.gameObject.SetActive(false);
        }
        
    }
    void GameOverSequence()
    {
         _GameOverBool = true;
         GameManager.GameOverman();
        _reload.transform.gameObject.SetActive(true);
        StartCoroutine(GameOverFlicker());
    }

}


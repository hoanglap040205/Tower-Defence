using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coin;
    [SerializeField] private Animator animator;
    private bool isOpened = true;
    public void MenuToggle()
    {
        isOpened = !isOpened;
        animator.SetBool("isOpened", isOpened);
    }
    private void OnGUI()
    {
        coin.text = SconeManager.instance.coin.ToString();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MENU");
    }
}

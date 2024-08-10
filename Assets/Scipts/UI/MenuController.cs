using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Canvas menucanvas;
    public GameObject level;
    public Button playbutton;
    public Button backbutton;
    

    void Start()
    {
        playbutton.onClick.AddListener(OnPlayButtonClicked);
        backbutton.onClick.AddListener(OnBackButtonClicked);
    }
    private void OnPlayButtonClicked()
    {
        menucanvas.gameObject.SetActive(false);

        StartCoroutine(MoveLevel());
    }
    private void OnBackButtonClicked()
    {
      

        StartCoroutine(MoveLevelAndShowMenur());
    }
    private IEnumerator MoveLevel()
    {
        Vector3 startPos = new Vector3(level.transform.position.x, 1423, level.transform.position.z);
        Vector3 endPos = new Vector3(level.transform.position.x, 461, level.transform.position.z);

        float duration = 2.0f;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            level.transform.position = Vector3.Lerp(startPos,endPos,(elapsedTime/duration));

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        level.transform.position = endPos;
    }
    private IEnumerator MoveLevel2()
    {
        Vector3 startPos = new Vector3(level.transform.position.x, 461, level.transform.position.z);
        Vector3 endPos = new Vector3(level.transform.position.x, 1528, level.transform.position.z);

        float duration = 2.0f;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            level.transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / duration));

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        level.transform.position = endPos;
    }

    private IEnumerator MoveLevelAndShowMenur()
    {

        yield return MoveLevel2();

        yield return new WaitForSeconds(0.2f);

        menucanvas.gameObject.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Regis : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField User;
    public TMP_InputField Pass;
    public TextMeshProUGUI Thongbao;

    public void Dangkybutton()
    {
        StartCoroutine(Dangky());
    }
    IEnumerator Dangky()
    {
        WWWForm from = new WWWForm();
        from.AddField("user", User.text);
        from.AddField("passwd", Pass.text);

        UnityWebRequest wwwconect = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", from);

        yield return wwwconect.SendWebRequest();

        if (!wwwconect.isDone)
        {
            Thongbao.text = "ket noi khong thanh cong";
        }

        else
        {
            string x = wwwconect.downloadHandler.text;
            switch (x)
            {
                case "exist":
                    Thongbao.text = "tai khoan da ton tai";
                    break;
                case "OK":
                    Thongbao.text = "dang ky thanh cong";
                    break;
                case "ERROR":
                    Thongbao.text = "dang ky khong thanh cong";
                    break;
                default:
                    Thongbao.text = "khong ket noi dc server";
                    break;
            }
        }
    }
}

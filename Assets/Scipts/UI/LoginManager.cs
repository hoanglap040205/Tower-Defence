using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class LoginManager : MonoBehaviour
{
    public TMP_InputField User;
    public TMP_InputField Pass;
    public TextMeshProUGUI Thongbao;
    public GameObject loginCanvas; // Tham chiếu tới canvas đăng nhập
    public RectTransform levelCanvas; // Tham chiếu tới RectTransform của canvas cấp độ
    public GameObject menuCanvas; // Tham chiếu tới canvas menu
    public Button backButton; // Tham chiếu tới nút quay lại

    private void Start()
    {
        // Đăng ký sự kiện cho nút quay lại
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public void DangNhapButton()
    {
        StartCoroutine(DangNhap());
    }

    IEnumerator DangNhap()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", User.text);
        form.AddField("passwd", Pass.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangnhap.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            Thongbao.text = "kết nối không thành công";
        }
        else
        {
            string get = www.downloadHandler.text;
            if (get == "empty")
            {
                Thongbao.text = "các trường dữ liệu không thể để trống";
            }
            else if (string.IsNullOrEmpty(get))
            {
                Thongbao.text = "tài khoản hoặc mật khẩu không chính xác";
            }
            else if (get.Contains("Lỗi"))
            {
                Thongbao.text = "không thể kết nối tới server";
            }
            else
            {
                Thongbao.text = "đăng nhập thành công";
                PlayerPrefs.SetString("token", get);
               // Debug.Log(get);

                // Ẩn canvas đăng nhập và di chuyển canvas cấp độ
                loginCanvas.SetActive(false);
                menuCanvas.SetActive(false); // Ẩn canvas menu khi đăng nhập thành công
                StartCoroutine(MoveLevelCanvas(1423, 70)); // Di chuyển canvas cấp độ
            }
        }
    }

    IEnumerator MoveLevelCanvas(float startY, float endY)
    {
        Vector3 startPosition = new Vector3(levelCanvas.localPosition.x, startY, levelCanvas.localPosition.z);
        Vector3 endPosition = new Vector3(levelCanvas.localPosition.x, endY, levelCanvas.localPosition.z);

        // Đặt vị trí ban đầu
        levelCanvas.localPosition = startPosition;

        while (Vector3.Distance(levelCanvas.localPosition, endPosition) > 0.1f)
        {
            levelCanvas.localPosition = Vector3.Lerp(levelCanvas.localPosition, endPosition, Time.deltaTime * 5);
            yield return null;
        }
        levelCanvas.localPosition = endPosition;
    }

    void OnBackButtonClicked()
    {
        // Hiển thị lại canvas menu và di chuyển canvas cấp độ về y = 1828
        menuCanvas.SetActive(true);
        StartCoroutine(MoveLevelCanvas(700, 1928));
    }

    public string GetToken()
    {
        return PlayerPrefs.GetString("token", ""); // Lấy token dưới dạng chuỗi, mặc định là chuỗi rỗng nếu không tìm thấy
    }


}

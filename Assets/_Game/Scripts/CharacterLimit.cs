using TMPro; 
using UnityEngine;

public class CharacterLimit : MonoBehaviour
{
    public TMP_InputField inputField;
    public int maxCharacterLimit = 10;  // Số ký tự tối đa

    private void Start()
    {
        if (inputField != null)
        {
            // Đăng ký sự kiện để lắng nghe thay đổi trong InputField
            inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }
    }

    private void OnInputFieldValueChanged(string newValue)
    {
        // Kiểm tra số ký tự và giữ lại số ký tự dưới giới hạn
        if (newValue.Length > maxCharacterLimit)
        {
            inputField.text = newValue.Substring(0, maxCharacterLimit);
        }
    }
}

using UnityEngine;
using TMPro;
using System.Collections;

public class FadeInText : MonoBehaviour
{
    [SerializeField] private TMP_Text text; // �\������e�L�X�g�R���|�[�l���g
    [SerializeField] private float fadeSpeed = 0.1f; // �t�F�[�h�C�����x

    void Start()
    {
        // �R���[�`�������s����O�� 'text' �� null ���ǂ������m�F
        if (text == null)
        {
            Debug.LogError("FadeInText: 'text' �ϐ������蓖�Ă��Ă��܂���I �C���X�y�N�^�[�� TextMeshPro UI �G�������g�����蓖�ĂĂ��������B");
            return; // 'text' �����蓖�Ă��Ă��Ȃ��ꍇ�� Start �֐����I��
        }

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // ���̃t���[���܂őҋ@
        yield return new WaitForEndOfFrame();

        // �e�L�X�g�̐F���擾
        Color currentColor = text.color;

        // �t�F�[�h�C������
        for (float alpha = 0.0f; alpha <= 1.0f; alpha += fadeSpeed)
        {
            // �V�����F�𐶐�
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);

            // �e�L�X�g�̐F��ݒ�
            text.color = newColor;

            // ���̃t���[���܂őҋ@
            yield return new WaitForSeconds(fadeSpeed);
        }
    }
}

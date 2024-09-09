using UnityEngine;
using TMPro;
using System.Collections;

public class FadeInText : MonoBehaviour
{
    [SerializeField] private TMP_Text text; // 表示するテキストコンポーネント
    [SerializeField] private float fadeSpeed = 0.1f; // フェードイン速度

    void Start()
    {
        // コルーチンを実行する前に 'text' が null かどうかを確認
        if (text == null)
        {
            Debug.LogError("FadeInText: 'text' 変数が割り当てられていません！ インスペクターで TextMeshPro UI エレメントを割り当ててください。");
            return; // 'text' が割り当てられていない場合は Start 関数を終了
        }

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // 次のフレームまで待機
        yield return new WaitForEndOfFrame();

        // テキストの色を取得
        Color currentColor = text.color;

        // フェードイン処理
        for (float alpha = 0.0f; alpha <= 1.0f; alpha += fadeSpeed)
        {
            // 新しい色を生成
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);

            // テキストの色を設定
            text.color = newColor;

            // 次のフレームまで待機
            yield return new WaitForSeconds(fadeSpeed);
        }
    }
}

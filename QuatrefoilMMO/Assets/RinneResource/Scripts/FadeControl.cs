using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace RinneResource
{
    public class FadeControl : MonoBehaviour
    {
        public static FadeControl Instance;     // シングルトンインスタンス
        private Image fadeImage;                // フェード用のImageコンポーネント
        private Coroutine currentFadeCoroutine; // 現在実行中のフェードコルーチン

        private void Awake()
        {
            // シングルトンの設定
            if (Instance == null)
            {
                Instance = this;                // インスタンスに自身を設定
                DontDestroyOnLoad(gameObject);  // シーンをまたいでオブジェクトを保持
            }
            else
            {
                Destroy(gameObject);            // すでにインスタンスが存在する場合は破棄
                return;
            }

            // 子オブジェクトからImageコンポーネントを取得
            fadeImage = GetComponentInChildren<Image>();
            if (fadeImage == null)
            {
                Debug.LogError("FadeImageが見つかりません。"); // エラーメッセージ
            }
        }

        // フェードイン処理
        // duration: フェードにかかる時間
        // onComplete: フェード完了時に実行されるコールバック
        public void FadeIn(float duration, System.Action onComplete = null)
        {
            // 現在のフェードコルーチンを停止
            if (currentFadeCoroutine != null)
            {
                StopCoroutine(currentFadeCoroutine);
            }
            // フェードコルーチンを開始
            currentFadeCoroutine = StartCoroutine(Fade(1, 0, duration, onComplete));
        }

        // フェードアウト処理
        // duration: フェードにかかる時間
        // onComplete: フェード完了時に実行されるコールバック
        public void FadeOut(float duration, System.Action onComplete = null)
        {
            // 現在のフェードコルーチンを停止
            if (currentFadeCoroutine != null)
            {
                StopCoroutine(currentFadeCoroutine);
            }
            // フェードコルーチンを開始
            currentFadeCoroutine = StartCoroutine(Fade(0, 1, duration, onComplete));
        }

        // フェード処理本体
        // startAlpha: フェード開始時のアルファ値
        // endAlpha: フェード終了時のアルファ値
        // duration: フェードにかかる時間
        // onComplete: フェード完了時に実行されるコールバック
        private IEnumerator Fade(float startAlpha, float endAlpha, float duration, System.Action onComplete)
        {
            float elapsedtime = 0f;         // 経過時間を初期化
            Color color = fadeImage.color;  // 現在のImageの色を取得

            while (elapsedtime < duration)
            {
                elapsedtime += Time.deltaTime; // 時間を更新
                                               // アルファ値を線形補間で計算
                color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedtime / duration);
                fadeImage.color = color; // アルファ値を更新
                yield return null; // 次のフレームまで待機
            }

            // 最終的なアルファ値を設定
            color.a = endAlpha;
            fadeImage.color = color;

            // フェード完了時のコールバックを実行
            onComplete?.Invoke();
        }
    }
}


using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class Candle : MonoBehaviour
    {
        [SerializeField] Sprite originalCandleImage;
        [SerializeField] Sprite answerImage;

        Image image;

        RectTransform rectTransform;

        public void SetCandleImage(Sprite updatedImage)
        {

            image = gameObject.GetComponent<Image>();

            image.sprite = updatedImage;
        }

        public Sprite GetCandleImage()
        {
            return gameObject.GetComponent<Image>().sprite;
        }

        public Vector3 GetRectTransformLocalPosition()
        {
            rectTransform = gameObject.GetComponent<RectTransform>();

            return rectTransform.localPosition;
        }

        public void ResetCandleImage()
        {
            image = gameObject.GetComponent<Image>();

            image.sprite = originalCandleImage;
        }

        public bool IsSolved()
        {
            if(GetCandleImage() == answerImage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
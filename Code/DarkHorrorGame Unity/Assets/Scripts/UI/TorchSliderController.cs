using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class TorchSliderController : MonoBehaviour
    {
        public Slider slider;
        public TorchController torch;

        private void Start()
        {
            slider.highValue = torch.maxIntensity;
        }

        private void Update()
        {
            slider.value = torch.Intensity;
        }
    }
}
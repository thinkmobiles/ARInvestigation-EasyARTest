using UnityEngine;
using UnityEngine.UI;
public class FPS : MonoBehaviour
{
    private const float SMOOTHING_COEF = 0.1f;
    private Text _text;
    private float _deltaTime;
    private float _fps;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _deltaTime += (Time.deltaTime - _deltaTime) * SMOOTHING_COEF;
        _fps = 1.0f / _deltaTime;
    }

    void OnGUI()
    {
        _text.text = string.Format("{0:0.0} ms ({1:0.} FPS)", _deltaTime * 1000.0f, _fps);

        _text.color = _fps > 60
            ? Color.green
            : _fps > 50
                ? Color.yellow
                : Color.red;
    }
}
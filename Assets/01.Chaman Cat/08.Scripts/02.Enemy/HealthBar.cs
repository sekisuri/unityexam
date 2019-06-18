using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    RectTransform  hpBar;   // HP의 RectTransform
    Rect rect;              // HP의 Rect

    // Use this for initialization
    void Start () {
        var back = transform.Find("Background").GetComponent<RectTransform>();
        rect = back.rect;

        hpBar = transform.Find("HP").GetComponent<RectTransform>();
        hpBar.sizeDelta = new Vector2(rect.width, rect.height);
	}
    

    // Update is called once per frame
    void Update() {
        if (transform.parent == null) return;

        // 체력바 뒤집기
        int dir = (transform.parent.localScale.x > 0) ? 1 : -1;
        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;
    }

    // 체력 표시 <- Monster
    void SetHP (float hp) {
        hpBar.sizeDelta = new Vector2(rect.width * hp, rect.height);
    }
}

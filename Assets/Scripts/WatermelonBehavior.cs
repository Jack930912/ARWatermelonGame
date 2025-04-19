
using UnityEngine;

public class WatermelonBehavior : MonoBehaviour {
    private bool isEaten = false;

    void OnMouseDown() {
        if (isEaten) return;
        isEaten = true;

        FindObjectOfType<WatermelonManager>().OnEaten();
        Destroy(gameObject);
    }
}

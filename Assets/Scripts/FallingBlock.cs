using UnityEngine;

public class FallingBlock : MonoBehaviour {
    float speed;
    float visibleHeightThreshold;
    public Vector2 speedMinMax;

    void Start() {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.getDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y; 
    }
    
    // Update is called once per frame
    void Update() {   
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        ifCubeOutOfCamera();
    }

    void ifCubeOutOfCamera() {
        if (transform.position.y < visibleHeightThreshold){
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class SpawningScript : MonoBehaviour {
    public GameObject fallingBlockPrefab;
    public Vector2 spawnSizeMinMax;
    public Vector2 spawnTimeDelayMinMax;
    public float spawnAngleMax;

    float nextSpawnTime;
    float spawnTimeDelay;
    Vector2 screenHalfWidthWorldUnits;
    
    // Start is called before the first frame update
    void Start() {
        screenHalfWidthWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update() {
        spawningBlock();
    }

    void spawningBlock() {
        if (Time.time > nextSpawnTime) {   
            spawnTimeDelay        = Mathf.Lerp(spawnTimeDelayMinMax.x, spawnTimeDelayMinMax.y, Difficulty.getDifficultyPercent());
            nextSpawnTime         = Time.time + spawnTimeDelay;
            
            float spawnSize       = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle      = Random.Range(-spawnAngleMax, spawnAngleMax);

            Vector2 spawnPosition = new Vector2(
                Random.Range(-screenHalfWidthWorldUnits.x, screenHalfWidthWorldUnits.x), transform.position.y + spawnSize);

            GameObject newBlock   = 
                (GameObject) Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;

            if (spawnTimeDelay >= 0.1) {
                spawnTimeDelay -= 0.01f;
            }
        }
    }
}

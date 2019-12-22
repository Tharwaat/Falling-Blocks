using UnityEngine;

enum BlockTags {
        //FallingBlock = "Falling Block";
}

public class PlayerMovement : MonoBehaviour {   
    
    public float speed = 7f;
    float screenHalfWidthInWorldUnits;

    void Start() {   
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    void Update() {
        playerMovement();
        movementRestrictions();
    }

    void playerMovement() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

    void movementRestrictions() {
        if (transform.position.x < -screenHalfWidthInWorldUnits) {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        else if (transform.position.x > screenHalfWidthInWorldUnits) {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D objectCollider) {
        if (objectCollider.tag == "Falling Block") {
            Destroy(gameObject);
            FindObjectOfType<GameOver> ().onGameOver();
        }        
    }
}

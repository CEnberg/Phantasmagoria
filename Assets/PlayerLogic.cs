using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [Header("Scrap Metal")]
    public int ScrapMetalCount;
    public int MaxScrapCount;
    public int ScrapThreshold;

    private int localStageCount = 0;
    private playerDrive drive;

    void Awake()
    {
        drive = GetComponent<playerDrive>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkScrapMetal();
    }

    private void checkScrapMetal()
    {
        if (ScrapMetalCount == 1 && localStageCount == 0)
        {
            print("yay!"); //Do Something
            drive.changeStage(1);
            localStageCount = 1;
        }
        else if (ScrapMetalCount == 4 && localStageCount == 1)
        {
            print("second tier"); //change into proper parts as needed
            drive.changeStage(2);
            localStageCount = 2;
        }
        else if (ScrapMetalCount == 9 && localStageCount == 2)
        {
            print("last tier reached!");
            // drive.changeStage(3);
            // localStageCount = 3;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectible"))
        {
            ScrapMetalCount += 1;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
            print("game over!!! :( ");      // Change as needed
        else if (other.CompareTag("EndOfLevel"))
        {
            print("You did it!!!");
        }
    }
}

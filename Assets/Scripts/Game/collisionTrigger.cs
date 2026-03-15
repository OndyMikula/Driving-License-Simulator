using UnityEngine;

public class collisionTrigger : MonoBehaviour
{
    public gameController gameC;

    void Start()
    {
        gameC = FindAnyObjectByType<gameController>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        string hitTag = collision.gameObject.tag;
        string message = "";

        if (hitTag == "DrivingLine")
        {
            gameC.Uncompleted();
            gameC.Canvas_UncompletedText.text = "Vjel jsi do protisměru!\nMáš -1 bod";
            Debug.Log("Collided with " + collision.gameObject.name + " (Tag: DrivingLine)");
            gameC.score -= 1;
            gameC.rulesFail++;
        }

        if (gameObject.CompareTag("Player"))
        {
            switch (hitTag)
            {
                case "Pedestrian":
                    message = "Narazil jsi do chodce a tím ohrozil jeho život!\nZačni znovu a tentokrát lépe :)";
                    break;

                case "Car":
                    message = "Narazil jsi do auta a tím ohrozil život mnoha řidičů!\nZačni znovu a tentokrát lépe :)";
                    break;

                case "Building":
                    message = "Narazil jsi do budovy!\nTakhle ten řidičák neuděláš, poškodil jsi majetek.\nZačni znovu a tentokrát lépe :)";
                    break;

                case "Prop":
                    message = "Narazil jsi do věci, do které bys obvykle neměl narážet.\nZačni znovu a tentokrát lépe :)";
                    break;

                default: return;
            }

            gameC.score = 0;
            gameC.Fail();
            gameC.Canvas_FailText.text = message;
            Debug.Log("Collided with " + collision.gameObject.name + " (Tag: " + hitTag + ")");
        }
    }
}

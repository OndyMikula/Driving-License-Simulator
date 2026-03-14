using UnityEngine;

public class controll : MonoBehaviour
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

        gameC.Fail();
        gameC.Canvas_FailText.text = message;
        Debug.Log("Collided with " + collision.gameObject.name + " (Tag: " + hitTag + ")");
    }
}

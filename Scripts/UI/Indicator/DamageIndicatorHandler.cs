using TD.Game;
using TMPro;
using UnityEngine;

public class DamageIndicatorHandler : MonoBehaviour
{


    private float disappearCooldown;
    private Color textColor;

    public static GameObject Create(GameObject targetObject, float damage)
    {
        try
        {
            GameObject damageIndicator = TD.Game.GameManager.Instance.damageIndicator; // calls the GameObject saved in the singleton ObjectsHandler to a local variable called damaageIndicator.



            GameObject damageText = InstantiateObject(targetObject, damageIndicator, targetObject.transform.position);

            DamageIndicatorHandler damageIndicatorHandler = damageText.GetComponent<DamageIndicatorHandler>(); // get the damageText Gameobject that we insantiated just now and get the DamageIndicatorHandler component (this instance of the script essentially) then, save it to a variable.
            damageIndicatorHandler.SetText(damage); // now, we can set that specific damageText's text because we have the instance of the DamageIndicatorHandler.

            return damageText;
        }
        catch (MissingReferenceException) { return null; } // if the player tries to hit a monster when it's in the process of dying, catch it and do nothing

    }

    public static GameObject Create(GameObject targetObject, string text, Color color, int size)
    {
        try
        {
            GameObject damageIndicator = TD.Game.GameManager.Instance.tooCloseIndicator; // calls the GameObject saved in the singleton ObjectsHandler to a local variable called damaageIndicator.



            GameObject damageText = InstantiateObject(targetObject, damageIndicator, targetObject.transform.position + 
                
                new Vector3(0, 0.2f));

            DamageIndicatorHandler damageIndicatorHandler = damageText.transform
                .GetChild(0).GetComponent<DamageIndicatorHandler>(); // get the damageText Gameobject that we insantiated just now and get the DamageIndicatorHandler component (this instance of the script essentially) then, save it to a variable.
            
            damageIndicatorHandler.SetText(text).SetFontSize(size).SetTextColor(color);


            return damageText;
        }
        catch (MissingReferenceException) { return null; } // if the player tries to hit a monster when it's in the process of dying, catch it and do nothing

    }



    private static GameObject InstantiateObject(GameObject targetObject, GameObject indicatorObject, Vector3 spawnPosition)
    {
        Vector3 position = spawnPosition; // get the position, by taking the targetObject's position minusing the targetObject's forward position (1, 0, 0)

        GameObject indicatorText = Instantiate(indicatorObject, // instantiate the damageText into a GameObject variable at position that we calculated just now.. 
             position

            + new Vector3(0f, 1f, -0.3f), Quaternion.identity);  // with an adjusted vector so its at the correct height (Y) and (Z). Quaternion.identity is for no rotations.


        return indicatorText;



    }



    private TextMeshPro text;

    private void Awake() // using awake because it calls earlier than start, needs to call before it starts so it can create properly.
    {
        text = GetComponent<TextMeshPro>();
        disappearCooldown = 1f; // when awake, set the disappear cooldown to 1f so it can slowly go down to 0 later.
        textColor = text.color; // get the color of the text mesh.

    }


    private void SetText(float damage) // set the damage of the text mesh.
    {
        text.SetText(damage.ToString()); // using the parameter of the function, set the textmesh.




    }

    private DamageIndicatorHandler SetText(string newText) // set the damage of the text mesh.
    {
        text.SetText(newText); // using the parameter of the function, set the textmesh.


        return this;
    }


    private DamageIndicatorHandler SetTextColor(Color color)
    {
        text.color = color;
        textColor = text.color;

        return this;
    }

    private DamageIndicatorHandler SetFontSize(int size)
    {
        text.fontSize = size;

        return this;
    }




    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1f) * Time.deltaTime; // it'll move at a y speed of 1f up for the damage text game object.

        disappearCooldown -= Time.deltaTime; // same like the attack cooldown system, we slowly minus it using Time.deltaTime from 1f.

        if (disappearCooldown < 0) // after minusing, check if it's below 0, meaning cool down is over.
        {
            textColor.a -= 2f * Time.deltaTime; // set the alpha of the text color to go down at a speed of 2f * Time.deltaTime.

            text.color = textColor; // set the color to the above changed alpha color.

            if (textColor.a < 0) //  if the alpha is under 0, meaning it's not visible already
            {
                Destroy(gameObject); // we destroy the game object to clear up memory.

                if(gameObject.transform.parent != null)
                    Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}

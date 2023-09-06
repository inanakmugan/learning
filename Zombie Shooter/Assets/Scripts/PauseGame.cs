using UnityEngine;

public class PauseGame : MonoBehaviour
{
    GameObject player;
    StarterAssets.StarterAssetsInputs starterAssetsInputs;
    public bool gamePaused = false;

    void Start()
    {

        starterAssetsInputs = GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ProcessPause();
            }
            else
            {
                UnPause();
            }
        }
    }

    private void UnPause()
    {
        // setting cursor bool, in the starterAssetsInputs Script
        starterAssetsInputs.cursorLocked = false;
        starterAssetsInputs.cursorInputForLook = false;

        starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
    }

    private void ProcessPause()
    {
        starterAssetsInputs.cursorLocked = true;
        starterAssetsInputs.cursorInputForLook = true;

        starterAssetsInputs.SetCursorState(starterAssetsInputs.cursorLocked);
    }
}
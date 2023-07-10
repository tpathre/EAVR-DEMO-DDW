using UnityEngine;

public class SceneIndexToName : MonoBehaviour
{

    public static string GetSceneIndex(int buildIndex)
    {

        string scenarioName = "";

        switch (buildIndex)
        {
            case 1:
                scenarioName = "Sports Hall";
                break;
            case 2:
                scenarioName = "Reverberation Room";
                break;

        }

        return scenarioName;
    }
}


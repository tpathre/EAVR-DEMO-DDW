using UnityEngine;

public class PlayerInputs : MonoBehaviour
{

    float RotateY;

    // Use this for initialization
    public void Start()
    {

    }

    void Rotate(float RotateY)
    {
        Vector3 RotationVector = new Vector3(0.0f, RotateY, 0.0f);
        transform.Rotate(RotationVector);
    }

    // Update is called once per frame
    public void Update()
    {
        RotateY = Input.GetAxis("RotateY"); //Corresponds to the Input Manager in Unity. If the correct key is pressed to activate RotateY.
        Rotate(RotateY * 0.4f); //Calls the Rotate function, which actually rotate funtion
    }
}

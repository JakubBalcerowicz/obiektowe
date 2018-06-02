public class AroundYaxis : MonoBehaviour
{
    float rotationNumber = 10;
    private float nextActionTime = 0.0f;
    private float period = 0.1f;
    void Update()
    {
        //timeSinceLevelLoad time for scene started to move obcjekt axe Z
        if (Time.timeSinceLevelLoad >= nextActionTime)
        {
            nextActionTime += period;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y = rotationVector.y + rotationNumber;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
}

using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] float destroyObjectDelay = 5;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject); //destoy projectile

        gameObject.GetComponent<MoveForward>().enabled = false; //stop animal from moving forward
        Destroy(gameObject, destroyObjectDelay); //destroys animal after delay
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,2,5), ForceMode.Impulse);//add force to animal up and backwards

        float torque = Random.Range(1,100);
        gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0,2,5) * torque); //adds random torque to flying animal
        gameObject.GetComponent<Collider>().enabled = false; //disable collider
    }
}

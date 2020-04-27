using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class charcontroller : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f;

    Vector3 foward, right;
    public Text text_warn;
    private bool pressed_e = false;
    Animator anim;
    GameObject dialoguer;

    public GameObject firstdialogue;

    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponentInChildren<Animator>();

        foward = Camera.main.transform.forward;
        foward.y = 0;
        foward = Vector3.Normalize(foward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * foward;
        firstdialogue.GetComponent<dialoguetrigger>().TriggerDialogue();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
            move();
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isidle", true);
        }


        if (Input.GetKey("e"))
        {
            pressed_e = true;
            if (check_forInfo("info", 3))
            {
                
                dialoguer.GetComponent<dialoguetrigger>().TriggerDialogue();
            }
           
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            //Debug.Log("test");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (check_forInfo("info", 3)){
            text_warn.text = "Press E to Read";
        }
        else
        {
            text_warn.text = " ";
        }
    }

    void move()
    {

        anim.SetBool("isWalking", true);
        anim.SetBool("isidle", false);
        Vector3 direction = new Vector3(Input.GetAxis("honrizontalKey"), 0, Input.GetAxis("verticalkey"));

        Vector3 roghtmovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("honrizontalKey");
        Vector3 upmovemetn = foward * moveSpeed * Time.deltaTime * Input.GetAxis("verticalkey");

        Vector3 heading = Vector3.Normalize(roghtmovement + upmovemetn);

        transform.forward = heading;
        transform.position += roghtmovement;
        transform.position += upmovemetn;
    }


    bool check_forInfo(string tag, float minimumDistance){

        GameObject[] taginfo = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < taginfo.Length; ++i)
        {
            if (Vector3.Distance(transform.position, taginfo[i].transform.position) <= minimumDistance)
            {//Debug.Log(" close");
                if (pressed_e) dialoguer = taginfo[i];
                pressed_e = false;
                return true;
                
            }
        }

       // Debug.Log("not close");

        return false;
    }
}


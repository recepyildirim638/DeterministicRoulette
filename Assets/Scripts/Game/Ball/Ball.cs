using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform mainParent;
    [SerializeField] Transform centerArea;
    public float radius = 5f; 
    public float speed = 1f; 

    private float angle = 0f;

    GameObject target;
    bool isDump = false;
    public float friction = 0.8f;

    [SerializeField] Vector3 startLocalPos;
    [SerializeField] RouletteWhell rouletteWhell;

    private void OnEnable()
    {
        isDump = true;
    }

    public void StartWheel()
    {
        transform.parent = mainParent;
        speed = Random.Range(2.8f, 3.1f);
        transform.localPosition = startLocalPos;
        target = rouletteWhell.GetNumberTransform(GameManager.BET_RESULT_NUMBER).gameObject;
        isDump = false;
    }

    void Update()
    {
        if (isDump)
            return;

        speed -= 0.1f * Time.deltaTime;
        angle += speed * Time.deltaTime * -1f;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        float y = 0.445f;

        transform.localPosition = new Vector3(x, y, z);


        // The ball falls onto the table after dropping below a certain speed.
        if (speed < 1.3f)
        {
            Vector2 center = centerArea.position.ToVector2();
            Vector2 ball = transform.position.ToVector2();
            Vector2 t = target.transform.position.ToVector2();
            
            if (GetCenterDirection(center, ball,t))
            {

                float dumpDistance = Vector3.Distance(transform.position, target.transform.position);
                if (dumpDistance < 2.0f)
                {
                    isDump = true;
                    StartCoroutine(JumpToGo(target.transform.position, 1f, 8f));
                }
            }
        }
    }

    // Is the ball aligned with the target number?  
    bool GetCenterDirection(Vector2 center, Vector2 A, Vector2 B)
    {
        Vector2 dirA = A - center;
        Vector2 dirB = B - center;


        float angleA = Mathf.Atan2(dirA.y, dirA.x) * Mathf.Rad2Deg;
        float angleB = Mathf.Atan2(dirB.y, dirB.x) * Mathf.Rad2Deg;


        if (angleA < 0) angleA += 360;
        if (angleB < 0) angleB += 360;


        float angleDiff = Mathf.DeltaAngle(angleA, angleB);


        if (angleDiff >= 0)
            return false;
        else
            return true;
    }

    bool GetRelativePosition(Vector2 A, Vector2 B, Vector2 reference)
    {
        float cross = (B.x - reference.x) * (A.y - reference.y) - (B.y - reference.y) * (A.x - reference.x);

        if (cross > 0)
            return false;
        else if (cross < 0)
            return true;
        else
            return false;
    }

    // The process of the ball landing on the designated number on the table.
    IEnumerator JumpToGo(Vector3 targetPos, float height, float moveSpeed)
    {

        // The ball bounces three times while moving towards the area it will land in.
        for (int i = 0; i < 3; i++)
        {
            Vector3 startPos = transform.position;

            targetPos = Vector3.Lerp(transform.position, target.transform.position, 0.5f);
            Vector3 grounPos = GroundPos(targetPos);

            if (grounPos != Vector3.zero)
                targetPos = grounPos;


            float distance = Vector3.Distance(startPos, targetPos);
            float time = distance / moveSpeed;
            height = height / 3f;

            float elapsedTime = 0f;

            while (elapsedTime < time)
            {

                elapsedTime += Time.deltaTime;
                float t = elapsedTime / time;

                Vector3 newPos = Vector3.Lerp(startPos, targetPos, t);

                newPos.y += Mathf.Sin(t * Mathf.PI) * height;

                transform.position = newPos;

                yield return null;
            }
        }

         float endDistance = Vector3.Distance(transform.position, target.transform.position);
         float endTime = endDistance / moveSpeed;
         float endElapsedTime = 0f;



        while (endElapsedTime < endTime)
        {

            endElapsedTime += Time.deltaTime;
            float t = endElapsedTime / endTime;

            Vector3 newPos = Vector3.Lerp(transform.position, targetPos, t);

            newPos.y += Mathf.Sin(t * Mathf.PI) * height;

            transform.position = newPos;

            yield return null;
        }




        transform.position = target.transform.position;
        transform.parent = target.transform;

        yield return new WaitForSeconds(2f);
        ActionManager.WheelEnd?.Invoke();
    }

    public Vector3 GroundPos(Vector3 startPos)
    {

        RaycastHit hit;
        Debug.DrawRay(startPos.With(y: 10f), Vector3.down * 100f, Color.red);
        if (Physics.Raycast(startPos.With(y: 10f), Vector3.down, out hit, 100f))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

   

}

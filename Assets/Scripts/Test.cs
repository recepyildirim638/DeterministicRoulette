using System.Collections;
using UnityEngine;


public class Test : MonoBehaviour
{
    public Transform target;
    public GameObject tempTemp;
    public GameObject temp;
    public Transform center;

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(center.position, 3f);
        float angle = GetCircularRegion(center.position, transform.position);
        temp.transform.position = GetPointOnCircle(center.position, 3f, angle);

        float angleTarget = GetCircularRegion(center.position, target.transform.position);
        tempTemp.transform.position = GetPointOnCircle(center.position, 3f, angleTarget);

        Vector2 p = temp.transform.position.ToVector2();


        Vector2 p2 = tempTemp.transform.position.ToVector2();

        string a = GetRelativePosition(center.transform.position.ToVector2(), p, p2);

        Debug.Log(a);

    }

    string GetRelativePosition2(Vector2 center,Vector2 A, Vector2 B)
    {
        // A ve B noktalarýnýn merkeze göre yön vektörünü bul
        Vector2 dirA = A - center;
        Vector2 dirB = B - center;

        // A ve B noktalarýnýn açýsýný hesapla (merkezden itibaren)
        float angleA = Mathf.Atan2(dirA.y, dirA.x) * Mathf.Rad2Deg;
        float angleB = Mathf.Atan2(dirB.y, dirB.x) * Mathf.Rad2Deg;

        // Açýlar negatifse 0-360 arasýna getir
        if (angleA < 0) angleA += 360;
        if (angleB < 0) angleB += 360;

        // **Doðrudan farký hesapla** (-180 ile +180 arasýnda olsun)
        float angleDiff = Mathf.DeltaAngle(angleA, angleB);

        // Eðer fark pozitifse, B noktasý A'nýn saat yönünde (Saðýnda)
        if (angleDiff > 0)
            return "Saðýnda";
        else
            return "Solunda";
    }
    bool GetRelativePositionBoolen(Vector2 A, Vector2 B, Vector2 reference)
    {
        float cross = (B.x - reference.x) * (A.y - reference.y) - (B.y - reference.y) * (A.x - reference.x);

        if (cross > 0)
            return false;
        else if (cross < 0)
            return true;
        else
            return false;
    }
    string GetRelativePosition(Vector2 A, Vector2 B, Vector2 reference)
    {
        // Çapraz çarpýmý hesapla
        float cross = (B.x - reference.x) * (A.y - reference.y) - (B.y - reference.y) * (A.x - reference.x);

        if (cross > 0)
            return "Solunda";
        else if (cross < 0)
            return "Saðýnda";
        else
            return "Ayný hizadayýz";
    }

    float GetAngleBetweenPoints(Vector2 A, Vector2 B)
    {
        // Dot Product hesapla
        float dot = A.x * B.x + A.y * B.y;

        // Açýyý hesapla (radyan cinsinden)
        float angleRad = Mathf.Acos(dot);

        // Dereceye çevir
        float angleDeg = angleRad * Mathf.Rad2Deg;

        return angleDeg;
    }

    float GetCircularDistance2(float radius, float angle1, float angle2)
    {
        angle1 = Mathf.Rad2Deg * angle1;
        angle2 = Mathf.Rad2Deg * angle2;

        if (angle1 < 0)
        {
            angle1 = 360f + angle1;
        }

       

        float angleDiff = Mathf.Abs(angle2 - angle1);


       // if (angleDiff > 180) angleDiff = 360 - angleDiff;


        float circumference = 2 * Mathf.PI * radius;
        float arcLength = (angleDiff / 360f) * circumference;

  
        return arcLength;
    }

    float GetCircularDistance(float radius, float angle1, float angle2)
    {
         angle1 = Mathf.Rad2Deg * angle1;
         angle2 = Mathf.Rad2Deg * angle2;

        if (angle1 < angle2)
        {
            Debug.Log("0");
            return 0f;
        }


        float angleDiff = Mathf.Abs(angle2 - angle1);


        if (angleDiff > 180) angleDiff = 360 - angleDiff;


        float circumference = 2 * Mathf.PI * radius;
        float arcLength = (angleDiff / 360f) * circumference;

        Debug.Log(arcLength);
        return arcLength;
    }


    void Update()
    {
        
    }


    float GetCircularRegion(Vector3 center, Vector3 objectPosition)
    {

        float angleRad = Mathf.Atan2(objectPosition.z - center.z, objectPosition.x - center.x);

       // float angleDeg = Mathf.Rad2Deg * angleRad;
        return angleRad;
    }

    Vector3 GetPointOnCircle(Vector3 center, float radius, float angleInRadians)
    {

        float x = center.x + radius * Mathf.Cos(angleInRadians); 
        float z = center.z + radius * Mathf.Sin(angleInRadians); 

        return new Vector3(x, center.y, z); 
    }




    IEnumerator JumpToGo(Vector3 targetPos, float height, float moveSpeed)
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 startPos = transform.position;

            targetPos = Vector3.Lerp(transform.position, target.position, 0.5f);
            Vector3 grounPos = GroundPos(targetPos);

            if(grounPos != Vector3.zero)
                targetPos = grounPos;
            Debug.Log(grounPos);

            temp.transform.position = grounPos;
            
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

      

        while(Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            transform.position += dir * Time.deltaTime * moveSpeed;
            yield return null;
        }
       

        transform.position = target.position;
        transform.parent = target;
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

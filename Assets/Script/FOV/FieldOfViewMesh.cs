using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FieldOfViewMesh : MonoBehaviour
{
    FieldOfView fov;
    [SerializeField] private Mesh mesh;
    RaycastHit2D raycastHit;
    [SerializeField] float meshRes = 4;
    [HideInInspector] public Vector3[] vertices;
    [HideInInspector] public int[] triangle;
    [HideInInspector] public int stepCount;
    // Start is called before the first frame update
    void Start()
    {
        mesh=GetComponent<MeshFilter>().mesh;
        //Material material = mesh.GetComponent<Material>();
       // material.SetColor("Albedo",new Color(224f,49f,49f,85f));
        fov =GetComponentInParent<FieldOfView>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        makeMesh();
    }
    void makeMesh()
    {
        stepCount=Mathf.RoundToInt(fov.Angle*meshRes);
        float stepAngle=fov.Angle/stepCount ;
        List<Vector3> viewVertex=new List<Vector3>();
        for(int i=0;i<stepCount;i++)
        {
            float angle=fov.transform.eulerAngles.y-fov.Angle/2+stepAngle*i;
            Vector3 dir = fov.DirFromAngle(angle, false);
            raycastHit=Physics2D.Raycast(fov.transform.position,dir,fov.Radius,fov.obstacleMask);
            if(raycastHit.collider== null )
            {
                viewVertex.Add(transform.position+ dir.normalized * fov.Radius);
                raycastHit=Physics2D.Raycast(fov.transform.position,dir,fov.Radius,fov.playerMask);
                if (raycastHit.collider != null)
                {
                    findPlayer();
                }
            }
            else
            {
                viewVertex.Add(transform.position+ dir.normalized *raycastHit.distance);
                raycastHit = Physics2D.Raycast(fov.transform.position, dir, raycastHit.distance, fov.playerMask);
                if (raycastHit.collider != null)
                {
                    findPlayer();
                }
            }
            

        }
        int vertexCount = viewVertex.Count + 1;
        vertices=new Vector3[vertexCount];
        triangle=new int[(vertexCount-2)*3];
        vertices[0]=Vector3.zero;
        for(int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewVertex[i]);
            if(i<vertexCount - 2)
            {
                triangle[i * 3 + 2] = 0;  
                triangle[i * 3 + 1] = i + 1;
                triangle[i * 3 ] = i + 2;
            }
        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangle;
        mesh.RecalculateBounds();
    }
    public void findPlayer()
    {
        GameManager.Instance.playerCtrl.state = PlayerState.DisAppear;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float velocity;
    private Vector3 Movement;
    
    [SerializeField]private List<Material> materials = new List<Material>();
    private Renderer rend;
    public int currentMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }
    private void OnEnable()
    {
        InputRader.OnMove += Movimiento;
        InputRader.ChangeColor += changecolor;
    }
    private void OnDisable()
    {
        InputRader.OnMove -= Movimiento;
        InputRader.ChangeColor -= changecolor;
    }
    private void Start()
    {
        rend.material = materials[currentMaterial];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocity=new Vector3(Movement.x*velocity,rb.linearVelocity.y,Movement.y*velocity);
    }
    public void Movimiento(Vector2 move)
    {
        Movement = move;
    }
    public void changecolor()
    {
        currentMaterial++;
        if (currentMaterial >= materials.Count)
        {
            currentMaterial = 0;
        }
        rend.material= materials[currentMaterial];
    }
}

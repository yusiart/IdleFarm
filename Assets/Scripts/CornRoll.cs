using UnityEngine;
using UnityEngine.Events;

public class CornRoll : MonoBehaviour
{
   [SerializeField] private float height = 1.5f;
   [SerializeField] private float duration = 1f;     // Duration of the movement

   private Vector3 _startPoint;
   private Vector3 _endPoint;
   private float elapsedTime = 0f;
   private bool _isMove;
   private Rigidbody _rigidbody;
   private Collider _collider;
   private ContainerBag _containerBag;
   private bool _isSelling;

   [HideInInspector]
   public Vector3 TargetHeight;
   
   private void Start()
   {
      _startPoint = transform.position;
      _collider = GetComponent<Collider>();
      _rigidbody = GetComponent<Rigidbody>();
   }

   void Update()
   {
      if (!_isMove)
       return;
      
      elapsedTime += Time.deltaTime;
      float t = elapsedTime / duration;

      if (!_isSelling)
      {
         _endPoint = new Vector3(_containerBag.transform.position.x, TargetHeight.y, _containerBag.transform.position.z);
      }

      Vector3 currentPos = Vector3.Lerp(_startPoint, _endPoint, t);
      currentPos.y += height * Mathf.Sin(t * Mathf.PI);
      
      transform.position = currentPos;
      
      if (t >= 1f)
      {
         transform.position = _endPoint;
         _isMove = false;
         elapsedTime = 0f;
      }
   }
   
   private void OnCollisionEnter(Collision collision)
   {
      if (_isMove)
         return;
      
      if (collision.gameObject.TryGetComponent(out Player player))
      {
         _containerBag = player.GetComponentInChildren<ContainerBag>();
         
         if (_containerBag.AddCornBag(this))
         {
            _collider.isTrigger = true;
            _isMove = true;
            _rigidbody.isKinematic = true;
            transform.parent = _containerBag.transform;
            transform.rotation = _containerBag.transform.rotation;
         }
      }
   }

   public void Drop(Vector3 target)
   {
      _isSelling = true;
      _endPoint = target;
      _startPoint = transform.position;
      transform.parent = null;
      _isMove = true;
   }
}

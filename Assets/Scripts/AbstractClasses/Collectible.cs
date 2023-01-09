using System;
using DG.Tweening;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class Collectible : MonoBehaviour
    {
        [SerializeField] private Color _color;
        [SerializeField] private Light _light;
        [SerializeField] private MeshRenderer _meshRenderer;

        private Material _mat;

        private void Awake()
        {
            _mat = _meshRenderer.material;
            _mat.color = _color;
            _meshRenderer.material = _mat;
            _light.color = _color;
        }

        private void Start()
        {
            
            Swing();
        }
        

        public abstract void Interact(Collider collider);

        public virtual void Swing()
        {
            transform.gameObject.SetActive(true);
            transform.DOMoveY(2, 2).OnComplete(() => { transform.DOMoveY(1, 2).SetLoops(-1, LoopType.Yoyo); });
            transform.DORotate(Vector3.one * 360,1 ).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
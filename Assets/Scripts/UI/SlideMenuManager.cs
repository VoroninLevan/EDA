using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = panel.GetComponent<Animator>();
    }

    public void OpenCloseTopMenu()
    {
        if (panel != null)
        {
            if (_animator != null)
            {
                bool isOpen = _animator.GetBool("open");
                _animator.SetBool("open", !isOpen);
            }
        }
    }
}

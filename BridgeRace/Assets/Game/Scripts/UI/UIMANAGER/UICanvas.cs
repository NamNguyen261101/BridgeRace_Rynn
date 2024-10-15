using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    public bool IsDestroyOnClose = false;

    protected RectTransform m_RectTransform;
    private Animator m_Animator;
    private float m_OffsetY = 0;


    private void Start()
    {
        OnInit();
    }
    /// <summary>
    /// Init default Canvas - khoi tao gia tri canvas
    /// </summary>
    protected void OnInit()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Animator = GetComponent<Animator>();

        // xu ly tai tho
        float ratio = (float)Screen.height / (float)Screen.width;
        if (ratio > 2.1f)
        {
            Vector2 leftBottom = m_RectTransform.offsetMin;
            Vector2 rightTop = m_RectTransform.offsetMax;
            rightTop.y = -100f;
            m_RectTransform.offsetMax = rightTop;
            leftBottom.y = 0f;
            m_RectTransform.offsetMin = leftBottom;
            m_OffsetY = 100f;
        }
    }

    /// <summary>
    /// Setup canvas to avoid flash UI - set up mac dinh cho UI de tranh truong hop bi nhay' hinh
    /// </summary>
    public virtual void Setup()
    {
        UIManager.Instance.AddBackUI(this);
        UIManager.Instance.PushBackAction(this, BackKey);
    }

    /// <summary>
    /// back key in android device 
    /// </summary>
    public virtual void BackKey()
    {

    }

    /// <summary>
    /// Open Canvas - Mo Canvas
    /// </summary>
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Close canvas directly -- dong truc tiep, ngay lap tuc
    /// </summary>
    public virtual void CloseDirectly()
    {
        UIManager.Instance.RemoveBackUI(this);
        gameObject.SetActive(false);
        if (IsDestroyOnClose)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// close canvas with delay time, used to anim UI action - dong canvas sau mot khoang thoi gian delay
    /// </summary>
    /// <param name="delayTime"></param>
    public virtual void Close(float delayTime)
    {
        Invoke(nameof(CloseDirectly), delayTime);
    }
}

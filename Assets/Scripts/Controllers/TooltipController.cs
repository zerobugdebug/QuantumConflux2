using UnityEngine;
using UnityEngine.EventSystems;
public class TooltipController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler

{
    private TooltipModel tooltipModel;
    private TooltipView tooltipView;
    private GameObject tooltipObject;
    [SerializeField] private GameObject tooltipPrefab;

    private void Awake()
    {
        tooltipModel = new TooltipModel("test");
    }

    public void Initialize(TooltipModel tooltipModel)
    {
        this.tooltipModel = tooltipModel;
    }

    public void ShowTooltip(Vector2 position)
    {
        if (tooltipObject != null)
        {
            Destroy(tooltipObject);
        }

        tooltipObject = Instantiate(tooltipPrefab, transform);
        //tooltipView.GetComponentInChildren<Text>().text = text;
        //        RectTransform tooltipRectTransform = currentTooltip.GetComponent<RectTransform>();
        //      tooltipRectTransform.position = position;

        //  GameObject cardObject = Instantiate(cardPrefab, parent);

        if (tooltipObject.TryGetComponent(out tooltipView))
        {
            tooltipView.UpdateView(tooltipModel, position);
            //tooltipView.SetTooltipController(this);
        }
        else
        {
            Debug.LogError("View is not assigned to tooltipPrefab");
            return;
        }
    }

    public void HideTooltip()
    {
        if (tooltipObject != null)
        {
            Destroy(tooltipObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip(eventData.position);
        Debug.Log("OnPointerEnter(PointerEventData eventData");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTooltip();
        Debug.Log("OnPointerExit(PointerEventData eventData");

    }

    public void OnPointerMove(PointerEventData eventData)
    {
        tooltipView.UpdateView(tooltipModel, eventData.position);
        Debug.Log("OnPointerMove(PointerEventData eventData");

    }
}

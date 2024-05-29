using TMPro;
using UnityEngine;

public class TooltipView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private TooltipModel tooltipModel;
    //private TooltipController tooltipController;

    public void UpdateView(TooltipModel tooltipModel, Vector2 position)
    {
        if (tooltipModel == null)
        {
            Debug.LogError("tooltipModel is null");
            return;
        }

        this.tooltipModel = tooltipModel;

        text.text = this.tooltipModel.GetText();
        transform.position = position;
    }

    /*    public void SetTooltipController(TooltipController tooltipController)
        {
            this.tooltipController = tooltipController;
        }*/
}

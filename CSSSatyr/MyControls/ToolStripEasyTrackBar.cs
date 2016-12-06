using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CSSSatyr.MyControls
{
    /// <summary>
    /// 加入到 StripItem 中不理想
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripEasyTrackBar : ToolStripControlHost
    {
        public ToolStripEasyTrackBar() : base (new EasyTrackBar()) { }

        public EasyTrackBar EasyTrackBarControl
        {
            get
            {
                return Control as EasyTrackBar;
            }
        }


        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
        }
    }
}

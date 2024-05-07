using CommonComponentLibrary;
using WaferMapLibrary;
using MotionLibrary;
namespace MainForm
{
    public partial class PadControl : UserControl
    {
        public PadControl()
        {
            InitializeComponent();
        }
        private void btnRefPad_Click(object sender, EventArgs e)
        {
            PadData.CurrentIndex = -1;
            //求带offset的坐标
            CommonFunctions.IndexUserPosAfterAlign(WaferMap.Entity.RefDieX, WaferMap.Entity.RefDieY, out double X, out double Y);
            Motion.UserPosMoveAbs(Compensation.Area.Align, X + PadData.Entity.DieOrg2RefPadX, Y + PadData.Entity.DieOrg2RefPadY);
        }

        private void btnRefDie_Click(object sender, EventArgs e)
        {
            //已好精定位，直接IndexMove
            CommonFunctions.IndexMove(Compensation.Area.Align, WaferMap.Entity.RefDieX, WaferMap.Entity.RefDieY);
        }

        private void btnPrevPad_Click(object sender, EventArgs e)
        {
            if (PadData.Entity.Pads == null) return;
            int Index = (PadData.CurrentIndex <= 0) ? PadData.Entity.Pads.Count - 1 : PadData.CurrentIndex - 1;
            PadMoveFromRefPad(Index);
        }

        private void btnNextPad_Click(object sender, EventArgs e)
        {
            if (PadData.Entity.Pads == null) return;
            int Index = (PadData.CurrentIndex >= PadData.Entity.Pads.Count - 1) ? 0 : PadData.CurrentIndex + 1;
            PadMoveFromRefPad(Index);
        }

        private void PadMoveFromRefPad(int Index)
        {
            if (PadData.Entity.Pads == null) return;
            //先获得当前Die Org的用户坐标
            CommonFunctions.IndexUserPosAfterAlign(WaferMap.CurrentIndexX, WaferMap.CurrentIndexY, out double X,out double Y);
            //获得Pad的坐标
            X += PadData.Entity.DieOrg2RefPadX + PadData.Entity.Pads[Index].PosX;
            Y += PadData.Entity.DieOrg2RefPadY + PadData.Entity.Pads[Index].PosY;
            //运动到Pad
            Motion.UserPosMoveAbs(Compensation.Area.Align, X, Y);
            PadData.CurrentIndex = Index;//改Index
        }
        private void btnMoveToPad_Click(object sender, EventArgs e)
        {

        }
    }
}

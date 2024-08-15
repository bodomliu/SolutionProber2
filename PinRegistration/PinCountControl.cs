using System.Data;
using WaferMapLibrary;

namespace PinRegistration
{
    public partial class PinCountControl : UserControl
    {
        private static PinCountControl entity = new();
        public static PinCountControl Entity = entity;
        private PinCountControl()
        {
            InitializeComponent();
            Total_PinCount.Text = PinData.Entity.Pins.Count.ToString();
            Passed_PinCount.Text = PinData.Entity.Pins.Where(x => x.AlignResult == 1).Count().ToString();
        }

        public void UpdateUI()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateUI));
            }
            else
            {
                Total_PinCount.Text = PinData.Entity.Pins.Count.ToString();
                Passed_PinCount.Text = PinData.Entity.Pins.Where(x => x.AlignResult == 1).Count().ToString();
            }
        }
    }
}

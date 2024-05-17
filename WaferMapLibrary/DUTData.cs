using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferMapLibrary
{
    public class DUT
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Boolean Enable { get; set; } = true;
    }

    public class DUTClass
    {
        public List<DUT> DUTs { get; set; }

        public string CardId { get; set; }

        public string Location { get; set; }

        public DUTClass()
        {
            DUTs = new List<DUT>();
            DUTs.Add(new DUT() { X = 0, Y = 0, Enable = true });
            CardId = "1-0";
            Location = "FF";
        }
    }

    public class DUTData
    {
        public static DUTClass Entity = new DUTClass();

        private static int currentIndex = 0;
        public static int CurrentIndexX
        {
            get
            {
                return currentIndex;
            }
            set
            {
                currentIndex = value;
                if (OnIndexChange != null) OnIndexChange();
            }
        }

        private static int currentIndexY = 0;
        public static int CurrentIndexY
        {
            get
            {
                return currentIndexY;
            }

            set
            {
                currentIndexY = value;
                OnIndexChange?.Invoke();
            }
        }

        public static void setCurrentIndex(int x, int y)
        {
            CurrentIndexX = x;
            CurrentIndexY = y;
            OnIndexChange?.Invoke();
        }

        public delegate void OnIndexChangeHander();

        public static event OnIndexChangeHander? OnIndexChange;


    }
}

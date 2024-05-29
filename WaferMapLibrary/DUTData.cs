using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            DUTs = new List<DUT>
            {
                new DUT() { X = 0, Y = 0, Enable = true }
            };
            CardId = "1-0";
            Location = "FF";
        }
    }

    public class DUTData
    {
        public static DUTClass Entity = new();

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
                OnIndexChange?.Invoke();
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

        public static void Save(string filePath)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(Entity, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static void Load(string filePath)
        {
            try
            { 
                string jsonString = File.ReadAllText(filePath);
                var item = JsonSerializer.Deserialize<DUTClass>(jsonString);
                if (item != null)
                {
                    Entity = item;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

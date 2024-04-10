﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection;

namespace WaferMapLibrary
{
    /// <summary>
    /// 每一个Mapping点（Die）的信息，包括坐标和Bin状态
    /// </summary>
    public class MappingPoint
    {
        public double UserPosX { get; set; }
        public double UserPosY { get; set; }
        public double EncodeX { get; set; }
        public double EncodeY { get; set; }
        public int IndexX { get; set; }
        public int IndexY { get; set; }

        /// <summary>
        /// 0 = Not Exist;
        /// 1 = Test Die;
        /// 2 = Skip Die;
        /// 3 = Mark Die;
        /// 4 = Pass Die;
        /// 5 = Fail Die;
        /// 6 = Cur Die;
        /// 7 = Teach Die;
        /// 8 = Sample Die.
        /// </summary>
        public int BIN { get; set; } 
        public int Coordinates { get; set; }//0 = 不是坐标点，1 = 有效坐标点，2 = 需要进行标定的点
    }

    /// <summary>
    /// 代表注册的WaferMap信息
    /// </summary>
    public class WaferMapClass
    {
        public int WaferSize { get; set; } = 12;//This is wafer size of current device. Value = 6/8/12
        public double DieSizeX { get; set; } = 0;//this is die size of current device; Also named Index size
        public double DieSizeY { get; set; } = 0;//this is die size of current device; Also named Index size
        public int DieNumX { get; set; } = 21;
        public int DieNumY { get; set; } = 21;
        public int OriginDieX { get; set; } = 10;
        public int OriginDieY { get; set; } = 10;
        public string DirectionX { get; set; } = "RIGHT";
        public string DirectionY { get; set; } = "DOWN";
        public double Center2OriginDieCornerX { get; set; } = 0;//OriginDie的Left Lower Crorner X - CenterX
        public double Center2OriginDieCornerY { get; set; } = 0;//OriginDie的Left Lower Crorner Y - CenterY
        public double Corner2PatternX { get; set; } = 0;//DiePattern - Lower Left Corner
        public double Corner2PatternY { get; set; } = 0;//DiePattern - Lower Left Corner
        public List<MappingPoint>? MappingPoints { get; set; }
    }

    /// <summary>
    /// 当前测试的这张Wafer信息
    /// </summary>
    public static class WaferMap
    {
        public static WaferMapClass Entity = new WaferMapClass();//定义WaferMap的实体
        public delegate void OnIndexChangeHander(int x,int y); //定义一个委托
        public static event OnIndexChangeHander? OnIndexChange;
        private static int currentIndexX = 0;
        public static int CurrentIndexX//当前index
        {
            get
            {
                return currentIndexX;
            }
            set
            {
                currentIndexX = value;
                if (OnIndexChange != null) OnIndexChange(currentIndexX, currentIndexY);
            }
        }
        private static int currentIndexY = 0;
        public static int CurrentIndexY//当前index
        {
            get
            {
                return currentIndexY;
            }
            set
            {
                currentIndexY = value;
                if (OnIndexChange != null) OnIndexChange(currentIndexX, currentIndexY);
            }

        }


        public delegate void OnAlignChangeHander(bool WaferCenter,bool LowAlign,bool HighAlign); //定义一个委托
        public static event OnAlignChangeHander? OnAlignChange;
        private static bool isWaferCenterCompleted = false;//晶圆圆心未寻找
        public static bool IsWaferCenterCompleted//WaferCenter未寻找
        {
            get
            {
                return isWaferCenterCompleted;
            }
            set
            {
                isWaferCenterCompleted = value;
                if (OnAlignChange != null) OnAlignChange(isWaferCenterCompleted, isLowAlignCompleted, isHighAlignCompleted);
            }
        }
        private static bool isLowAlignCompleted = false;//粗定位未完成
        public static bool IsLowAlignCompleted//精定位未完成
        {
            get
            {
                return isLowAlignCompleted;
            }
            set
            {
                isLowAlignCompleted = value;
                if (OnAlignChange != null) OnAlignChange(isWaferCenterCompleted, isLowAlignCompleted, isHighAlignCompleted);
            }
        }
        private static bool isHighAlignCompleted = false;//精定位未完成
        public static bool IsHighAlignCompleted//精定位未完成
        {
            get
            {
                return isHighAlignCompleted;
            }
            set
            {
                isHighAlignCompleted = value;
                if (OnAlignChange != null) OnAlignChange(isWaferCenterCompleted, isLowAlignCompleted, isHighAlignCompleted);
            }
        }

        public static double WaferCenterX;//LowMag下的值 + XWAFERLOW2HIGHT：转UserPos
        public static double WaferCenterY;//LowMag下的值 + YWAFERLOW2HIGHT：转UserPos
        public static double WaferOffsetX;//HighMag下的值：实际RefDie - 注册RefDie：转UserPos
        public static double WaferOffsetY;//HighMag下的值：实际RefDie - 注册RefDie：转UserPos

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
            string jsonString = File.ReadAllText(filePath);
            var item = JsonSerializer.Deserialize<WaferMapClass>(jsonString);
            if (item != null) Entity = item;
        }
    }
}

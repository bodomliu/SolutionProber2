using MathNet.Numerics.Statistics.Mcmc;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaferMapLibrary;

namespace CommonComponentLibrary
{
    public static class CommonFunctions
    {
        /// <summary>
        /// 根据index值，获得用户坐标系坐标
        /// </summary>
        /// <param name="indexX"></param>
        /// <param name="intexY"></param>
        /// <param name="userPosX"></param>
        /// <param name="userPosY"></param>
        /// <returns></returns>
        public static int GetMapUserPos(int indexX, int intexY, out double userPosX, out double userPosY)
        {
            userPosX = double.NaN; userPosY = double.NaN;
            if (WaferMap.Entity.MappingPoints == null) return 1;

            var point = WaferMap.Entity.MappingPoints.Find(p => p.IndexX == indexX && p.IndexY == intexY);
            if (point == null) return 2;

            userPosX = point.UserPosX;
            userPosY = point.UserPosY;
            return 0;
        }

        public static void IndexMove(int indexX, int intexY)
        { 
            //TODO：需要知道是粗定位还是精定位下的坐标
        }

        /// <summary>
        /// 根据index值，获得轴坐标系坐标
        /// </summary>
        /// <param name="indexX"></param>
        /// <param name="indexY"></param>
        /// <param name="encodeX"></param>
        /// <param name="encodeY"></param>
        /// <returns></returns>
        public static int GetMapEncode(int indexX, int indexY, out double encodeX, out double encodeY)
        {
            encodeX = double.NaN; encodeY = double.NaN;
            if (WaferMap.Entity.MappingPoints == null) return 1;

            var point = WaferMap.Entity.MappingPoints.Find(p => p.IndexX == indexX && p.IndexY == indexY);
            if (point == null) return 2;

            encodeX = point.EncodeX;
            encodeY = point.EncodeY;
            return 0;
        }
    }
}

using System;
using UnityEngine;

namespace ChuongLibrary.GameDev
{
    public class UnixTime : MonoBehaviour
    {
        public static DateTimeOffset UnixEpoch = new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);


        //Hiện thời điểm hiện tại tính bằng giây
        public static int GetUnixTime()
        {
            return (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        //Hiện thời điểm hiện tại tính bằng micro giây
        public static long GetUnixTimeMicro()
        {
            var now = DateTimeOffset.UtcNow;
            return ToUnixTimeMicrosecond(now);

            static long ToUnixTimeMicrosecond(DateTimeOffset timeStamp)
            {
                var Duration = timeStamp - UnixEpoch;
                return Duration.Ticks / 10;
            }
        }

        // hàm này trả về khoảng thời gian chạy từ lúc bắt đầu cho tới thời điểm hiện tại
        public static float GetTimeDiffToNow(long startTime)
        {
            long nowTime = GetUnixTimeMicro();
            return (float)(nowTime - startTime) / 1000000;
        }
    }
}

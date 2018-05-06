//using UnityEngine;

namespace Common
{
    /// <summary>
    /// 禁止非战斗逻辑模块使用此随机数
    /// </summary>
    public static class Random
    {
        static System.Random s_random = null;
        static int s_seed = 0;
        public static int s_index = 0;

        public static void SetSeed(int seed)
        {
            s_seed = seed;
            s_random = new System.Random(s_seed);
        }

        /// <summary>
        /// 左闭右开区间 与unity一致
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static int Range(int minInclusive, int maxExclusive)
        {
            s_index++;
            if (s_random == null)
            {
                s_random = new System.Random(s_seed);
            }

            int ret = s_random.Next(minInclusive, maxExclusive);
            return ret;
        }

        /// <summary>
        /// 左闭右闭区间 与unity一致
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static float Range(float minInclusive, float maxInclusive)
        {
            s_index++;
            if (s_random == null)
            {
                s_random = new System.Random(s_seed);
            }

            int randomInteger = s_random.Next(0, int.MaxValue);
            float randomFloat = (float)randomInteger / (float)int.MaxValue;
            float range = maxInclusive - minInclusive;
            float ret = minInclusive + randomFloat * range;
            return ret;
        }
    }
}

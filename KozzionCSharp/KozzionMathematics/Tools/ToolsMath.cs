﻿using KozzionMathematics.Algebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace KozzionMathematics.Tools
{
    public class ToolsMath
    {
        private static IAlgebraInteger<int> algebra_int32 = new AlgebraSymbolInt32();
        private static IAlgebraInteger<BigInteger> algebra_big_integer = new AlgebraSymbolBigInteger();

        public static Tuple<IntegerType, IntegerType, IntegerType> ExtendedEuclideanAlgorithm<IntegerType>(IAlgebraInteger<IntegerType> algebra, IntegerType a, IntegerType b)
        {
            if (algebra.Compare(algebra.Abs(a), algebra.Abs(b)) == -1)
            {
                Tuple<IntegerType, IntegerType, IntegerType> xyd = ExtendedEuclideanAlgorithm(algebra, b, a);
                return new Tuple<IntegerType, IntegerType, IntegerType>(xyd.Item2, xyd.Item1, xyd.Item3);
            }

            if (algebra.Abs(b).Equals(algebra.AddIdentity))
            {
                return new Tuple<IntegerType, IntegerType, IntegerType>(algebra.MultiplyIdentity, algebra.AddIdentity, a);
            }

            IntegerType x1 = algebra.AddIdentity;
            IntegerType x2 = algebra.MultiplyIdentity;
            IntegerType y1 = algebra.MultiplyIdentity;
            IntegerType y2 = algebra.AddIdentity;
            while (algebra.Compare(algebra.AddIdentity, algebra.Abs(b)) == -1)
            {
                IntegerType q = algebra.Divide(a,b);
                IntegerType r = algebra.Modulo(a,b);
                IntegerType x = algebra.Subtract(x2, algebra.Multiply(q,x1));
                IntegerType y = algebra.Subtract(y2, algebra.Multiply(q,y1));
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            return new Tuple<IntegerType, IntegerType, IntegerType>(x2, y2, a);
        }

        public static Tuple<BigInteger, BigInteger, BigInteger> ExtendedEuclideanAlgorithm(BigInteger a, BigInteger b)
        {
            return ExtendedEuclideanAlgorithm(algebra_big_integer, a, b);
        }

        public static Tuple<int, int, int> ExtendedEuclideanAlgorithm(int a, int b)
        {
            return ExtendedEuclideanAlgorithm(algebra_int32, a, b);
        }

        //Minmax operation
        public static int Clamp(int value, int min, int max)
        {
            if (max < min)
            {
                throw new Exception("min should be smaller than or equal to max");
            }

            return Math.Max(Math.Min(value, max), min);
        }

        public static long Clamp(long value, long min, long max)
        {
            if (max < min)
            {
                throw new Exception("min should be smaller than or equal to max");
            }

            return Math.Max(Math.Min(value, max), min);
        }

        public static float Clamp(float value, float min, float max)
        {
            if (max < min)
            {
                throw new Exception("min should be smaller than or equal to max");
            }

            return Math.Max(Math.Min(value, max), min);
        }

        public static double Clamp(double value, double min, double max)
        {
            if (max < min)
            {
                throw new Exception("min should be smaller than or equal to max");
            }

            return Math.Max(Math.Min(value, max), min);
        }

        //Modulo like operation but also shifted and negative 
        public static int Wrap(int value, int min, int max)
        {
            if (max < min)
            {
                throw new Exception("min should be smaller than or equal to max");
            }

            if (value < min)
            {
                return min + (max - (-(value - min) % (max - min)));
            }
            else
            {
                return min + ((value - min) % (max - min));
            }
        }

        //Modulo like operation but also shifted and negative 
        public static long Wrap(long value, long min, long max)
        {
            if (max < min)
            {
                throw new Exception("min should be smaller than or equal to max");
            }

            if (value < min)
            {
                return min + (max - (-(value - min) % (max - min)));
            }
            else
            {
                return min + ((value - min) % (max - min));
            }
        }

        public static float Floor(float value)
        {
            return (float)Math.Floor(value);
        }

        internal static int Sqrt(BigInteger bigInteger)
        {
            throw new NotImplementedException();
        }


        //Modulo like operation but also shifted and 
        public static float Wrap(float value, float min, float max)
        {
            if (max < min)
            {
                throw new Exception("min should be smaller than or equal to max");
            }

            if (value < min)
            {
                return min + (max - (-(value - min) % (max - min)));
            }
            else
            {
                return min + ((value - min) % (max - min));
            }
        }

        public static float Sin(float value_0)
        {
            throw new NotImplementedException();
        }

        public static float Cos(float value_0)
        {
            throw new NotImplementedException();
        }

        public static float Cos(float value_0, float value_1)
        {
            throw new NotImplementedException();
        }

        //Modulo like operation but also shifted and 
        public static double Wrap(double value, double min, double max)
        {
            if (max < min)
            {
                throw new Exception("min should be smaller than or equal to max");
            }

            if (value < min)
            {
                return min + (max - (-(value - min) % (max - min)));
            }
            else
            {
                return min + ((value - min) % (max - min));
            }
        }

        //Modulo like operation but also shifted and 
        public static int Wrap(int value, int max)
        {

            if (value < 0)
            {
                return max - (-value % max);
            }
            else
            {
                return value % max;
            }
        }

        //Modulo like operation but also shifted and 
        public static long Wrap(long value, long max)
        {

            if (value < 0)
            {
                return max - (-value % max);
            }
            else
            {
                return value % max;
            }
        }

        public static float Log(float value)
        {
            return (float)Math.Log(value);
        }

        //Modulo like operation but also shifted and 
        public static float Wrap(float value, float max)
        {

            if (value < 0)
            {
                return max - (-value % max);
            }
            else
            {
                return value % max;
            }
        }

        public static RangeType Min<RangeType>(RangeType value_0, RangeType value_1) 
            where RangeType : IComparable<RangeType>
        {
            if (value_0.CompareTo(value_1) == 1)
            {
                return value_1;
            }
            else
            {
                return value_0;
            }
        }


        public static RangeType Max<RangeType>(RangeType value_0, RangeType value_1)
            where RangeType : IComparable<RangeType>
        {
            if (value_0.CompareTo(value_1) == 1)
            {
                return value_0;
            }
            else
            {
                return value_1;
            }
        }

        public static float Sqr(float value)
        {
            return value * value;
        }

        public static int Sqr(int value)
        {
            return value * value;
        }

        public static double Sqr(double value)
        {
            return value * value;
        }

        //Modulo like operation but also shifted and 
        public static double Wrap(double value, double max)
        {

            if (value < 0)
            {
                return max - (-value % max);
            }
            else
            {
                return value % max;
            }
        }


        static double[] ExpAdjustmentDouble = new double[256] {
            1.040389835,
            1.039159306,
            1.037945888,
            1.036749401,
            1.035569671,
            1.034406528,
            1.033259801,
            1.032129324,
            1.031014933,
            1.029916467,
            1.028833767,
            1.027766676,
            1.02671504,
            1.025678708,
            1.02465753,
            1.023651359,
            1.022660049,
            1.021683458,
            1.020721446,
            1.019773873,
            1.018840604,
            1.017921503,
            1.017016438,
            1.016125279,
            1.015247897,
            1.014384165,
            1.013533958,
            1.012697153,
            1.011873629,
            1.011063266,
            1.010265947,
            1.009481555,
            1.008709975,
            1.007951096,
            1.007204805,
            1.006470993,
            1.005749552,
            1.005040376,
            1.004343358,
            1.003658397,
            1.002985389,
            1.002324233,
            1.001674831,
            1.001037085,
            1.000410897,
            0.999796173,
            0.999192819,
            0.998600742,
            0.998019851,
            0.997450055,
            0.996891266,
            0.996343396,
            0.995806358,
            0.995280068,
            0.99476444,
            0.994259393,
            0.993764844,
            0.993280711,
            0.992806917,
            0.992343381,
            0.991890026,
            0.991446776,
            0.991013555,
            0.990590289,
            0.990176903,
            0.989773325,
            0.989379484,
            0.988995309,
            0.988620729,
            0.988255677,
            0.987900083,
            0.987553882,
            0.987217006,
            0.98688939,
            0.98657097,
            0.986261682,
            0.985961463,
            0.985670251,
            0.985387985,
            0.985114604,
            0.984850048,
            0.984594259,
            0.984347178,
            0.984108748,
            0.983878911,
            0.983657613,
            0.983444797,
            0.983240409,
            0.983044394,
            0.982856701,
            0.982677276,
            0.982506066,
            0.982343022,
            0.982188091,
            0.982041225,
            0.981902373,
            0.981771487,
            0.981648519,
            0.981533421,
            0.981426146,
            0.981326648,
            0.98123488,
            0.981150798,
            0.981074356,
            0.981005511,
            0.980944219,
            0.980890437,
            0.980844122,
            0.980805232,
            0.980773726,
            0.980749562,
            0.9807327,
            0.9807231,
            0.980720722,
            0.980725528,
            0.980737478,
            0.980756534,
            0.98078266,
            0.980815817,
            0.980855968,
            0.980903079,
            0.980955475,
            0.981017942,
            0.981085714,
            0.981160303,
            0.981241675,
            0.981329796,
            0.981424634,
            0.981526154,
            0.981634325,
            0.981749114,
            0.981870489,
            0.981998419,
            0.982132873,
            0.98227382,
            0.982421229,
            0.982575072,
            0.982735318,
            0.982901937,
            0.983074902,
            0.983254183,
            0.983439752,
            0.983631582,
            0.983829644,
            0.984033912,
            0.984244358,
            0.984460956,
            0.984683681,
            0.984912505,
            0.985147403,
            0.985388349,
            0.98563532,
            0.98588829,
            0.986147234,
            0.986412128,
            0.986682949,
            0.986959673,
            0.987242277,
            0.987530737,
            0.987825031,
            0.988125136,
            0.98843103,
            0.988742691,
            0.989060098,
            0.989383229,
            0.989712063,
            0.990046579,
            0.990386756,
            0.990732574,
            0.991084012,
            0.991441052,
            0.991803672,
            0.992171854,
            0.992545578,
            0.992924825,
            0.993309578,
            0.993699816,
            0.994095522,
            0.994496677,
            0.994903265,
            0.995315266,
            0.995732665,
            0.996155442,
            0.996583582,
            0.997017068,
            0.997455883,
            0.99790001,
            0.998349434,
            0.998804138,
            0.999264107,
            0.999729325,
            1.000199776,
            1.000675446,
            1.001156319,
            1.001642381,
            1.002133617,
            1.002630011,
            1.003131551,
            1.003638222,
            1.00415001,
            1.004666901,
            1.005188881,
            1.005715938,
            1.006248058,
            1.006785227,
            1.007327434,
            1.007874665,
            1.008426907,
            1.008984149,
            1.009546377,
            1.010113581,
            1.010685747,
            1.011262865,
            1.011844922,
            1.012431907,
            1.013023808,
            1.013620615,
            1.014222317,
            1.014828902,
            1.01544036,
            1.016056681,
            1.016677853,
            1.017303866,
            1.017934711,
            1.018570378,
            1.019210855,
            1.019856135,
            1.020506206,
            1.02116106,
            1.021820687,
            1.022485078,
            1.023154224,
            1.023828116,
            1.024506745,
            1.025190103,
            1.02587818,
            1.026570969,
            1.027268461,
            1.027970647,
            1.02867752,
            1.029389072,
            1.030114973,
            1.030826088,
            1.03155163,
            1.032281819,
            1.03301665,
            1.033756114,
            1.034500204,
            1.035248913,
            1.036002235,
            1.036760162,
            1.037522688,
            1.038289806,
            1.039061509,
            1.039837792,
            1.040618648
        };

        public static float Sqrt(float d)
        {
            return (float)Math.Sqrt(d);
        }


        public static double FastExp(double x)
        {
            var tmp = (long)(1512775 * x + 1072632447);
            int index = (int)(tmp >> 12) & 0xFF;
            return BitConverter.Int64BitsToDouble(tmp << 32) * ExpAdjustmentDouble[index];
        }

        public static float FastExp(float x)
        {
            //Would be nice to have some more optimized double and float functions here
            return (float)FastExp((double)x);
        }

        public static int FloorToInt32(float value)
        {
            return (int)value;
        }

        public static int SignToInt32(float value)
        {
            return value.CompareTo(0);
        }

        public static float Erf(float v)
        {
            throw new NotImplementedException();
        }

        public static float Exp(float value_0)
        {
            return (float)Math.Exp(value_0);
        }

        public static float Pow(int value_0, int value_1)
        {
            return (float)Math.Pow(value_0, value_1);
        }

        public static float Log2(float value_0)
        {
            throw new NotImplementedException();
        }
    }
}

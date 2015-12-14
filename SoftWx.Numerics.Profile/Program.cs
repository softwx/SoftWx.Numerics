using SoftWx.Diagnostics;
using System;

namespace SoftWx.Numerics.Profile {
    class Program {
        static void Main(string[] args) {
            ((byte)1).LowBit(); // gets the assembly going
            sbyte sr, s1; s1 = -1;
            sr = s1.BitCount();
            sr = s1.HighBit();
            sr = s1.HighBitPosition();
            sr = s1.LeadingZeroBits();
            sr = s1.LowBit();
            sr = s1.LowBitPosition();
            sr = s1.TrailingZeroBits();
            ProfileBitMath();
            //int val = -10;
            //sbyte s = sbyte.MinValue;
            //Console.WriteLine(ToBinString(10));
            //Console.WriteLine(ToBinString(-10));
            //Console.WriteLine(ToBinString(10u));
            //Console.WriteLine(ToBinString((uint)val));
            //Console.WriteLine(ToBinString(val.HighBit()));
            //var bench = new Bench();
            //int ur; int u1 = 123;
            //bench.Time("old", () => { ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); ur = u1.LowBitPosition(); }, 10);
            //bench.Time("2", () => { ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); ur = u1.LowBitPosition2(); }, 10);
            //byte b = byte.MinValue;
            //while (true) {
            //    if (b.LeadingZeroBits() != b.LeadingZeroBits2()) throw new Exception();
            //    sbyte br = b.LowBit();
            //    Console.WriteLine(ToBinString(b)+" " + b);
            //    Console.WriteLine(ToBinString(br));
            //    Console.ReadKey();
            //    Console.WriteLine();
            //    //if (b.TrailingZeroBits() != br.TrailingZeroBits()) throw new Exception();
            //    if (b == byte.MaxValue) break;
            //    b++;
            //}
            Console.Write("press any key to exit...");
            Console.ReadKey();
        }
        static void ProfileBitMath() {
            byte b1, br; b1 = 123;
            sbyte sb1, sbr; sb1 = 123;
            ushort us1, usr; us1 = 123;
            short s1, sr; s1 = 123;
            uint ui1, uir; ui1 = 123;
            int i1, ir; i1 = 123;
            ulong ul1, ulr; ul1 = 123;
            long l1, lr; l1 = 123;
            var bench = new Bench();
            bench.Time("byte.LowBit", () => { br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); }, 5);
            bench.Time("sbyte.LowBit", () => { sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); }, 5);
            bench.Time("ushort.LowBit", () => { usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); }, 5);
            bench.Time("short.LowBit", () => { sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); }, 5);
            bench.Time("uint.LowBit", () => { uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); }, 5);
            bench.Time("int.LowBit", () => { ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); }, 5);
            bench.Time("ulong.LowBit", () => { ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); }, 5);
            bench.Time("long.LowBit", () => { lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); }, 5);
            bench.Time("byte.HighBit", () => { br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); }, 5);
            bench.Time("sbyte.HighBit", () => { sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); }, 5);
            bench.Time("ushort.HighBit", () => { usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); }, 5);
            bench.Time("short.HighBit", () => { sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); }, 5);
            bench.Time("uint.HighBit", () => { uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); }, 5);
            bench.Time("int.HighBit", () => { ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); }, 5);
            bench.Time("ulong.HighBit", () => { ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); }, 5);
            bench.Time("long.HighBit", () => { lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); }, 5);
            bench.Time("byte.LowBitPosition", () => { br = b1.LowBitPosition(); br = b1.LowBitPosition(); br = b1.LowBitPosition(); br = b1.LowBitPosition(); br = b1.LowBitPosition(); }, 5);
            bench.Time("sbyte.LowBitPosition", () => { sbr = sb1.LowBitPosition(); sbr = sb1.LowBitPosition(); sbr = sb1.LowBitPosition(); sbr = sb1.LowBitPosition(); sbr = sb1.LowBitPosition(); }, 5);
            bench.Time("ushort.LowBitPosition", () => { usr = us1.LowBitPosition(); usr = us1.LowBitPosition(); usr = us1.LowBitPosition(); usr = us1.LowBitPosition(); usr = us1.LowBitPosition(); }, 5);
            bench.Time("short.LowBitPosition", () => { sr = s1.LowBitPosition(); sr = s1.LowBitPosition(); sr = s1.LowBitPosition(); sr = s1.LowBitPosition(); sr = s1.LowBitPosition(); }, 5);
            bench.Time("uint.LowBitPosition", () => { uir = ui1.LowBitPosition(); uir = ui1.LowBitPosition(); uir = ui1.LowBitPosition(); uir = ui1.LowBitPosition(); uir = ui1.LowBitPosition(); }, 5);
            bench.Time("int.LowBitPosition", () => { ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); }, 5);
            bench.Time("ulong.LowBitPosition", () => { ulr = ul1.LowBitPosition(); ulr = ul1.LowBitPosition(); ulr = ul1.LowBitPosition(); ulr = ul1.LowBitPosition(); ulr = ul1.LowBitPosition(); }, 5);
            bench.Time("long.LowBitPosition", () => { lr = l1.LowBitPosition(); lr = l1.LowBitPosition(); lr = l1.LowBitPosition(); lr = l1.LowBitPosition(); lr = l1.LowBitPosition(); }, 5);
            bench.Time("byte.HighBitPosition", () => { br = b1.HighBitPosition(); br = b1.HighBitPosition(); br = b1.HighBitPosition(); br = b1.HighBitPosition(); br = b1.HighBitPosition(); }, 5);
            bench.Time("sbyte.HighBitPosition", () => { sbr = sb1.HighBitPosition(); sbr = sb1.HighBitPosition(); sbr = sb1.HighBitPosition(); sbr = sb1.HighBitPosition(); sbr = sb1.HighBitPosition(); }, 5);
            bench.Time("ushort.HighBitPosition", () => { usr = us1.HighBitPosition(); usr = us1.HighBitPosition(); usr = us1.HighBitPosition(); usr = us1.HighBitPosition(); usr = us1.HighBitPosition(); }, 5);
            bench.Time("short.HighBitPosition", () => { sr = s1.HighBitPosition(); sr = s1.HighBitPosition(); sr = s1.HighBitPosition(); sr = s1.HighBitPosition(); sr = s1.HighBitPosition(); }, 5);
            bench.Time("uint.HighBitPosition", () => { uir = ui1.HighBitPosition(); uir = ui1.HighBitPosition(); uir = ui1.HighBitPosition(); uir = ui1.HighBitPosition(); uir = ui1.HighBitPosition(); }, 5);
            bench.Time("int.HighBitPosition", () => { ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); }, 5);
            bench.Time("ulong.HighBitPosition", () => { ulr = ul1.HighBitPosition(); ulr = ul1.HighBitPosition(); ulr = ul1.HighBitPosition(); ulr = ul1.HighBitPosition(); ulr = ul1.HighBitPosition(); }, 5);
            bench.Time("long.HighBitPosition", () => { lr = l1.HighBitPosition(); lr = l1.HighBitPosition(); lr = l1.HighBitPosition(); lr = l1.HighBitPosition(); lr = l1.HighBitPosition(); }, 5);
            bench.Time("byte.LeadingZeroBits", () => { br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); }, 5);
            bench.Time("sbyte.LeadingZeroBits", () => { br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); br = b1.LeadingZeroBits(); }, 5);
            bench.Time("ushort.LeadingZeroBits", () => { usr = us1.LeadingZeroBits(); usr = us1.LeadingZeroBits(); usr = us1.LeadingZeroBits(); usr = us1.LeadingZeroBits(); usr = us1.LeadingZeroBits(); }, 5);
            bench.Time("short.LeadingZeroBits", () => { sr = s1.LeadingZeroBits(); sr = s1.LeadingZeroBits(); sr = s1.LeadingZeroBits(); sr = s1.LeadingZeroBits(); sr = s1.LeadingZeroBits(); }, 5);
            bench.Time("uint.LeadingZeroBits", () => { uir = ui1.LeadingZeroBits(); uir = ui1.LeadingZeroBits(); uir = ui1.LeadingZeroBits(); uir = ui1.LeadingZeroBits(); uir = ui1.LeadingZeroBits(); }, 5);
            bench.Time("int.LeadingZeroBits", () => { ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); }, 5);
            bench.Time("ulong.LeadingZeroBits", () => { ulr = ul1.LeadingZeroBits(); ulr = ul1.LeadingZeroBits(); ulr = ul1.LeadingZeroBits(); ulr = ul1.LeadingZeroBits(); ulr = ul1.LeadingZeroBits(); }, 5);
            bench.Time("long.LeadingZeroBits", () => { lr = l1.LeadingZeroBits(); lr = l1.LeadingZeroBits(); lr = l1.LeadingZeroBits(); lr = l1.LeadingZeroBits(); lr = l1.LeadingZeroBits(); }, 5);
            bench.Time("byte.BitCount", () => { br = b1.BitCount(); br = b1.BitCount(); br = b1.BitCount(); br = b1.BitCount(); br = b1.BitCount(); }, 5);
            bench.Time("sbyte.BitCount", () => { sbr = sb1.BitCount(); sbr = sb1.BitCount(); sbr = sb1.BitCount(); sbr = sb1.BitCount(); sbr = sb1.BitCount(); }, 5);
            bench.Time("ushort.BitCount", () => { usr = us1.BitCount(); usr = us1.BitCount(); usr = us1.BitCount(); usr = us1.BitCount(); usr = us1.BitCount(); }, 5);
            bench.Time("short.BitCount", () => { sr = s1.BitCount(); sr = s1.BitCount(); sr = s1.BitCount(); sr = s1.BitCount(); sr = s1.BitCount(); }, 5);
            bench.Time("uint.BitCount", () => { uir = ui1.BitCount(); uir = ui1.BitCount(); uir = ui1.BitCount(); uir = ui1.BitCount(); uir = ui1.BitCount(); }, 5);
            bench.Time("int.BitCount", () => { ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); }, 5);
            bench.Time("ulong.BitCount", () => { ulr = ul1.BitCount(); ulr = ul1.BitCount(); ulr = ul1.BitCount(); ulr = ul1.BitCount(); ulr = ul1.BitCount(); }, 5);
            bench.Time("long.BitCount", () => { lr = l1.BitCount(); lr = l1.BitCount(); lr = l1.BitCount(); lr = l1.BitCount(); lr = l1.BitCount(); }, 5);
            bench.Time("byte.ReverseBits", () => { br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); }, 5);
            bench.Time("sbyte.ReverseBits", () => { sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); }, 5);
            bench.Time("ushort.ReverseBits", () => { usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); }, 5);
            bench.Time("short.ReverseBits", () => { sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); }, 5);
            bench.Time("uint.ReverseBits", () => { uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); }, 5);
            bench.Time("int.ReverseBits", () => { ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); }, 5);
            bench.Time("ulong.ReverseBits", () => { ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); }, 5);
            bench.Time("long.ReverseBits", () => { lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); }, 5);
        }
        public static String ToBinString(byte value) {
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }
        public static String ToBinString(sbyte value) {
            return Convert.ToString((byte)value, 2).PadLeft(8, '0');
        }
        public static String ToBinString(uint value) {
            return Convert.ToString(value, 2).PadLeft(32, '0');
        }
        public static String ToBinString(int value) {
            return Convert.ToString(value, 2).PadLeft(32, '0');
        }
    }
}

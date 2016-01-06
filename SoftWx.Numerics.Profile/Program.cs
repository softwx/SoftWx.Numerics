// Copyright ©2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
using SoftWx.Diagnostics;
using System;

namespace SoftWx.Numerics.Profile {
    class Program {
        static void Main(string[] args) {
            ((byte)1).LowBit(); // gets the assembly and class going
            ((byte)1).Log2(); // get the class going
            ((sbyte)1).AbsU(); // get the class going
            ((int)10).Gcd((int)10); // get the class going
            (UInt128.Zero).LowBit();

            ProfileBitMath();
            ProfileLog2Math();
            ProfileMath();
            ProfilePrimeMath();

            Console.Write("press any key to exit...");
            Console.ReadKey();
        }
        static void ProfilePrimeMath() {
            bool bo;
            byte b1, br, b2; b1 = 123; b2 = 127;
            sbyte sb1, sbr, sb2; sb1 = 123; sb2 = 127;
            ushort us1, usr, us2; us1 = 123; us2 = 127;
            short s1, sr, s2; s1 = 123; s2 = 127;
            uint ui1, uir, ui2; ui1 = 123; ui2 = 127;
            int i1, ir, i2; i1 = 123; i2 = 127;
            ulong ul1, ulr, ul2; ul1 = 123; ul2 = 127;
            long l1, lr, l2; l1 = 123; l2 = 127;
            var bench = new Bench();
            bench.Time("uint.Gcd", () => { uir = ui1.Gcd(ui2); uir = ui1.Gcd(ui2); uir = ui1.Gcd(ui2); uir = ui1.Gcd(ui2); uir = ui1.Gcd(ui2); }, 5);
            bench.Time("int.Gcd", () => { ir = i1.Gcd(i2); ir = i1.Gcd(i2); ir = i1.Gcd(i2); ir = i1.Gcd(i2); ir = i1.Gcd(i2); }, 5);
            bench.Time("ulong.Gcd", () => { ulr = ul1.Gcd(ul2); ulr = ul1.Gcd(ul2); ulr = ul1.Gcd(ul2); ulr = ul1.Gcd(ul2); ulr = ul1.Gcd(ul2); }, 5);
            bench.Time("long.Gcd", () => { lr = l1.Gcd(l2); lr = l1.Gcd(l2); lr = l1.Gcd(l2); lr = l1.Gcd(l2); lr = l1.Gcd(l2); }, 5);
            bench.Time("uint.IsCoprime", () => { bo = ui1.IsCoprime(ui2); bo = ui1.IsCoprime(ui2); bo = ui1.IsCoprime(ui2); bo = ui1.IsCoprime(ui2); bo = ui1.IsCoprime(ui2); }, 5);
            bench.Time("int.IsCoprime", () => { bo = i1.IsCoprime(i2); bo = i1.IsCoprime(i2); bo = i1.IsCoprime(i2); bo = i1.IsCoprime(i2); bo = i1.IsCoprime(i2); }, 5);
            bench.Time("ulong.IsCoprime", () => { bo = ul1.IsCoprime(ul2); bo = ul1.IsCoprime(ul2); bo = ul1.IsCoprime(ul2); bo = ul1.IsCoprime(ul2); bo = ul1.IsCoprime(ul2); }, 5);
            bench.Time("long.IsCoprime", () => { bo = l1.IsCoprime(l2); bo = l1.IsCoprime(l2); bo = l1.IsCoprime(l2); bo = l1.IsCoprime(l2); bo = l1.IsCoprime(l2); }, 5);
            bench.Time("uint.NearestCoprimeFloor", () => { uir = ui1.NearestCoprimeFloor(ui2); uir = ui1.NearestCoprimeFloor(ui2); uir = ui1.NearestCoprimeFloor(ui2); uir = ui1.NearestCoprimeFloor(ui2); uir = ui1.NearestCoprimeFloor(ui2); }, 5);
            bench.Time("int.NearestCoprimeFloor", () => { ir = i1.NearestCoprimeFloor(i2); ir = i1.NearestCoprimeFloor(i2); ir = i1.NearestCoprimeFloor(i2); ir = i1.NearestCoprimeFloor(i2); ir = i1.NearestCoprimeFloor(i2); }, 5);
            bench.Time("ulong.NearestCoprimeFloor", () => { ulr = ul1.NearestCoprimeFloor(ul2); ulr = ul1.NearestCoprimeFloor(ul2); ulr = ul1.NearestCoprimeFloor(ul2); ulr = ul1.NearestCoprimeFloor(ul2); ulr = ul1.NearestCoprimeFloor(ul2); }, 5);
            bench.Time("long.NearestCoprimeFloor", () => { lr = l1.NearestCoprimeFloor(l2); lr = l1.NearestCoprimeFloor(l2); lr = l1.NearestCoprimeFloor(l2); lr = l1.NearestCoprimeFloor(l2); lr = l1.NearestCoprimeFloor(l2); }, 5);
            bench.Time("uint.NearestCoprimeCeiling", () => { uir = ui1.NearestCoprimeCeiling(ui2); uir = ui1.NearestCoprimeCeiling(ui2); uir = ui1.NearestCoprimeCeiling(ui2); uir = ui1.NearestCoprimeCeiling(ui2); uir = ui1.NearestCoprimeCeiling(ui2); }, 5);
            bench.Time("int.NearestCoprimeCeiling", () => { ir = i1.NearestCoprimeCeiling(i2); ir = i1.NearestCoprimeCeiling(i2); ir = i1.NearestCoprimeCeiling(i2); ir = i1.NearestCoprimeCeiling(i2); ir = i1.NearestCoprimeCeiling(i2); }, 5);
            bench.Time("ulong.NearestCoprimeCeiling", () => { ulr = ul1.NearestCoprimeCeiling(ul2); ulr = ul1.NearestCoprimeCeiling(ul2); ulr = ul1.NearestCoprimeCeiling(ul2); ulr = ul1.NearestCoprimeCeiling(ul2); ulr = ul1.NearestCoprimeCeiling(ul2); }, 5);
            bench.Time("long.NearestCoprimeCeiling", () => { lr = l1.NearestCoprimeCeiling(l2); lr = l1.NearestCoprimeCeiling(l2); lr = l1.NearestCoprimeCeiling(l2); lr = l1.NearestCoprimeCeiling(l2); lr = l1.NearestCoprimeCeiling(l2); }, 5);
        }
        static void ProfileMath() {
            bool bo;
            //byte b1, br, b2; b1 = 123; b2 = 127;
            //sbyte sb1, sbr, sb2; sb1 = 123; sb2 = 127;
            //ushort us1, usr, us2; us1 = 123; us2 = 127;
            //short s1, sr, s2; s1 = 123; s2 = 127;
            //uint ui1, uir, ui2; ui1 = 123; ui2 = 127;
            //int i1, ir, i2; i1 = 123; i2 = 127;
            //ulong ul1, ulr, ul2; ul1 = 123; ul2 = 127;
            //long l1, lr, l2; l1 = 123; l2 = 127;
            byte b1, br, b2; b1 = sbyte.MaxValue-7; b2 = sbyte.MaxValue-13;
            sbyte sb1, sbr, sb2; sb1 = (sbyte)b1; sb2 = (sbyte)b2;
            ushort us1, usr, us2; us1 = short.MaxValue-7; us2 = short.MaxValue-13;
            short s1, sr, s2; s1 = (short)us1; s2 = (short)us2;
            uint ui1, uir, ui2; ui1 = int.MaxValue-7; ui2 = int.MaxValue-13;
            int i1, ir, i2; i1 = (int)ui1; i2 = (int)ui2;
            ulong ul1, ulr, ul2; ul1 = long.MaxValue-7; ul2 = long.MaxValue-13;
            long l1, lr, l2; l1 = (long)ul1; l2 = (long)ul2;
            br = 0; ulr = 0;
            const byte mod = 121;
            var bench = new Bench();
            bench.Time("sbyte.AbsU", () => { br = sb1.AbsU(); br = sb1.AbsU(); br = sb1.AbsU(); br = sb1.AbsU(); br = sb1.AbsU(); }, 5);
            bench.Time("short.AbsU", () => { usr = s1.AbsU(); usr = s1.AbsU(); usr = s1.AbsU(); usr = s1.AbsU(); usr = s1.AbsU(); }, 5);
            bench.Time("int.AbsU", () => { uir = i1.AbsU(); uir = i1.AbsU(); uir = i1.AbsU(); uir = i1.AbsU(); uir = i1.AbsU(); }, 5);
            bench.Time("long.AbsU", () => { ulr = l1.AbsU(); ulr = l1.AbsU(); ulr = l1.AbsU(); ulr = l1.AbsU(); ulr = l1.AbsU(); }, 5);
            bench.Time("byte.MulMod", () => { br = b1.MulMod(b2, 143); br = b1.MulMod(b2, 143); br = b1.MulMod(b2, 143); br = b1.MulMod(b2, 143); br = b1.MulMod(b2, 143); }, 5);
            bench.Time("sbyte.MulMod", () => { sbr = sb1.MulMod(sb2, (sbyte)mod); sbr = sb1.MulMod(sb2, (sbyte)mod); sbr = sb1.MulMod(sb2, (sbyte)mod); sbr = sb1.MulMod(sb2, (sbyte)mod); sbr = sb1.MulMod(sb2, (sbyte)mod); }, 5);
            bench.Time("ushort.MulMod", () => { usr = us1.MulMod(us2, mod); usr = us1.MulMod(us2, mod); usr = us1.MulMod(us2, mod); usr = us1.MulMod(us2, mod); usr = us1.MulMod(us2, mod); }, 5);
            bench.Time("short.MulMod", () => { sr = s1.MulMod(s2, mod); sr = s1.MulMod(s2, mod); sr = s1.MulMod(s2, mod); sr = s1.MulMod(s2, mod); sr = s1.MulMod(s2, mod); }, 5);
            bench.Time("uint.MulMod", () => { uir = ui1.MulMod(ui2, mod); uir = ui1.MulMod(ui2, mod); uir = ui1.MulMod(ui2, mod); uir = ui1.MulMod(ui2, mod); uir = ui1.MulMod(ui2, mod); }, 5);
            bench.Time("int.MulMod", () => { ir = i1.MulMod(i2, mod); ir = i1.MulMod(i2, mod); ir = i1.MulMod(i2, mod); ir = i1.MulMod(i2, mod); ir = i1.MulMod(i2, mod); }, 5);
            bench.Time("ulong.MulMod", () => { ulr = ul1.MulMod(ul2, mod); ulr = ul1.MulMod(ul2, mod); ulr = ul1.MulMod(ul2, mod); ulr = ul1.MulMod(ul2, mod); ulr = ul1.MulMod(ul2, mod); }, 5);
            bench.Time("long.MulMod", () => { lr = l1.MulMod(l2, mod); lr = l1.MulMod(l2, mod); lr = l1.MulMod(l2, mod); lr = l1.MulMod(l2, mod); lr = l1.MulMod(l2, mod); }, 5);
            bench.Time("uint.ModPow", () => { uir = ui1.ModPow(ui2, mod); uir = ui1.ModPow(ui2, mod); uir = ui1.ModPow(ui2, mod); uir = ui1.ModPow(ui2, mod); uir = ui1.ModPow(ui2, mod); }, 5);
            bench.Time("ulong.ModPow", () => { ulr = ul1.ModPow(ul2, mod); ulr = ul1.ModPow(ul2, mod); ulr = ul1.ModPow(ul2, mod); ulr = ul1.ModPow(ul2, mod); ulr = ul1.ModPow(ul2, mod); }, 5);
        }
        static void ProfileLog2Math() {
            bool bo;
            byte b1; int br; b1 = 123;
            sbyte sb1, sbr; sb1 = 123;
            ushort us1, usr; us1 = 123;
            short s1, sr; s1 = 123;
            uint ui1, uir; ui1 = 123;
            int i1, ir; i1 = 123;
            ulong ul1, ulr; ul1 = 123;
            long l1, lr; l1 = 123;
            var bench = new Bench();
            bench.Time("byte.Log2", () => { br = b1.Log2(); br = b1.Log2(); br = b1.Log2(); br = b1.Log2(); br = b1.Log2(); }, 5);
            bench.Time("sbyte.Log2", () => { sbr = sb1.Log2(); sbr = sb1.Log2(); sbr = sb1.Log2(); sbr = sb1.Log2(); sbr = sb1.Log2(); }, 5);
            bench.Time("ushort.Log2", () => { usr = us1.Log2(); usr = us1.Log2(); usr = us1.Log2(); usr = us1.Log2(); usr = us1.Log2(); }, 5);
            bench.Time("short.Log2", () => { sr = s1.Log2(); sr = s1.Log2(); sr = s1.Log2(); sr = s1.Log2(); sr = s1.Log2(); }, 5);
            bench.Time("uint.Log2", () => { uir = ui1.Log2(); uir = ui1.Log2(); uir = ui1.Log2(); uir = ui1.Log2(); uir = ui1.Log2(); }, 5);
            bench.Time("int.Log2", () => { ir = i1.Log2(); ir = i1.Log2(); ir = i1.Log2(); ir = i1.Log2(); ir = i1.Log2(); }, 5);
            bench.Time("ulong.Log2", () => { ulr = ul1.Log2(); ulr = ul1.Log2(); ulr = ul1.Log2(); ulr = ul1.Log2(); ulr = ul1.Log2(); }, 5);
            bench.Time("long.Log2", () => { lr = l1.Log2(); lr = l1.Log2(); lr = l1.Log2(); lr = l1.Log2(); lr = l1.Log2(); }, 5);
            bench.Time("byte.IsPowerOf2", () => { bo = b1.IsPowerOf2(); bo = b1.IsPowerOf2(); bo = b1.IsPowerOf2(); bo = b1.IsPowerOf2(); bo = b1.IsPowerOf2(); }, 5);
            bench.Time("sbyte.IsPowerOf2", () => { bo = sb1.IsPowerOf2(); bo = sb1.IsPowerOf2(); bo = sb1.IsPowerOf2(); bo = sb1.IsPowerOf2(); bo = sb1.IsPowerOf2(); }, 5);
            bench.Time("ushort.IsPowerOf2", () => { bo = us1.IsPowerOf2(); bo = us1.IsPowerOf2(); bo = us1.IsPowerOf2(); bo = us1.IsPowerOf2(); bo = us1.IsPowerOf2(); }, 5);
            bench.Time("short.IsPowerOf2", () => { bo = s1.IsPowerOf2(); bo = s1.IsPowerOf2(); bo = s1.IsPowerOf2(); bo = s1.IsPowerOf2(); bo = s1.IsPowerOf2(); }, 5);
            bench.Time("uint.IsPowerOf2", () => { bo = ui1.IsPowerOf2(); bo = ui1.IsPowerOf2(); bo = ui1.IsPowerOf2(); bo = ui1.IsPowerOf2(); bo = ui1.IsPowerOf2(); }, 5);
            bench.Time("int.IsPowerOf2", () => { bo = i1.IsPowerOf2(); bo = i1.IsPowerOf2(); bo = i1.IsPowerOf2(); bo = i1.IsPowerOf2(); bo = i1.IsPowerOf2(); }, 5);
            bench.Time("ulong.IsPowerOf2", () => { bo = ul1.IsPowerOf2(); bo = ul1.IsPowerOf2(); bo = ul1.IsPowerOf2(); bo = ul1.IsPowerOf2(); bo = ul1.IsPowerOf2(); }, 5);
            bench.Time("long.IsPowerOf2", () => { bo = l1.IsPowerOf2(); bo = l1.IsPowerOf2(); bo = l1.IsPowerOf2(); bo = l1.IsPowerOf2(); bo = l1.IsPowerOf2(); }, 5);
            bench.Time("byte.PowerOf2Floor", () => { br = b1.PowerOf2Floor(); br = b1.PowerOf2Floor(); br = b1.PowerOf2Floor(); br = b1.PowerOf2Floor(); br = b1.PowerOf2Floor(); }, 5);
            bench.Time("sbyte.PowerOf2Floor", () => { sbr = sb1.PowerOf2Floor(); sbr = sb1.PowerOf2Floor(); sbr = sb1.PowerOf2Floor(); sbr = sb1.PowerOf2Floor(); sbr = sb1.PowerOf2Floor(); }, 5);
            bench.Time("ushort.PowerOf2Floor", () => { usr = us1.PowerOf2Floor(); usr = us1.PowerOf2Floor(); usr = us1.PowerOf2Floor(); usr = us1.PowerOf2Floor(); usr = us1.PowerOf2Floor(); }, 5);
            bench.Time("short.PowerOf2Floor", () => { sr = s1.PowerOf2Floor(); sr = s1.PowerOf2Floor(); sr = s1.PowerOf2Floor(); sr = s1.PowerOf2Floor(); sr = s1.PowerOf2Floor(); }, 5);
            bench.Time("uint.PowerOf2Floor", () => { uir = ui1.PowerOf2Floor(); uir = ui1.PowerOf2Floor(); uir = ui1.PowerOf2Floor(); uir = ui1.PowerOf2Floor(); uir = ui1.PowerOf2Floor(); }, 5);
            bench.Time("int.PowerOf2Floor", () => { ir = i1.PowerOf2Floor(); ir = i1.PowerOf2Floor(); ir = i1.PowerOf2Floor(); ir = i1.PowerOf2Floor(); ir = i1.PowerOf2Floor(); }, 5);
            bench.Time("ulong.PowerOf2Floor", () => { ulr = ul1.PowerOf2Floor(); ulr = ul1.PowerOf2Floor(); ulr = ul1.PowerOf2Floor(); ulr = ul1.PowerOf2Floor(); ulr = ul1.PowerOf2Floor(); }, 5);
            bench.Time("long.PowerOf2Floor", () => { lr = l1.PowerOf2Floor(); lr = l1.PowerOf2Floor(); lr = l1.PowerOf2Floor(); lr = l1.PowerOf2Floor(); lr = l1.PowerOf2Floor(); }, 5);
            bench.Time("byte.PowerOf2Ceiling", () => { br = b1.PowerOf2Ceiling(); br = b1.PowerOf2Ceiling(); br = b1.PowerOf2Ceiling(); br = b1.PowerOf2Ceiling(); br = b1.PowerOf2Ceiling(); }, 5);
            bench.Time("sbyte.PowerOf2Ceiling", () => { sbr = sb1.PowerOf2Ceiling(); sbr = sb1.PowerOf2Ceiling(); sbr = sb1.PowerOf2Ceiling(); sbr = sb1.PowerOf2Ceiling(); sbr = sb1.PowerOf2Ceiling(); }, 5);
            bench.Time("ushort.PowerOf2Ceiling", () => { usr = us1.PowerOf2Ceiling(); usr = us1.PowerOf2Ceiling(); usr = us1.PowerOf2Ceiling(); usr = us1.PowerOf2Ceiling(); usr = us1.PowerOf2Ceiling(); }, 5);
            bench.Time("short.PowerOf2Ceiling", () => { sr = s1.PowerOf2Ceiling(); sr = s1.PowerOf2Ceiling(); sr = s1.PowerOf2Ceiling(); sr = s1.PowerOf2Ceiling(); sr = s1.PowerOf2Ceiling(); }, 5);
            bench.Time("uint.PowerOf2Ceiling", () => { uir = ui1.PowerOf2Ceiling(); uir = ui1.PowerOf2Ceiling(); uir = ui1.PowerOf2Ceiling(); uir = ui1.PowerOf2Ceiling(); uir = ui1.PowerOf2Ceiling(); }, 5);
            bench.Time("int.PowerOf2Ceiling", () => { ir = i1.PowerOf2Ceiling(); ir = i1.PowerOf2Ceiling(); ir = i1.PowerOf2Ceiling(); ir = i1.PowerOf2Ceiling(); ir = i1.PowerOf2Ceiling(); }, 5);
            bench.Time("ulong.PowerOf2Ceiling", () => { ulr = ul1.PowerOf2Ceiling(); ulr = ul1.PowerOf2Ceiling(); ulr = ul1.PowerOf2Ceiling(); ulr = ul1.PowerOf2Ceiling(); ulr = ul1.PowerOf2Ceiling(); }, 5);
            bench.Time("long.PowerOf2Ceiling", () => { lr = l1.PowerOf2Ceiling(); lr = l1.PowerOf2Ceiling(); lr = l1.PowerOf2Ceiling(); lr = l1.PowerOf2Ceiling(); lr = l1.PowerOf2Ceiling(); }, 5);
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
            UInt128 ull1, ullr; ull1 = new UInt128(0, 123);
            var bench = new Bench();
            bench.Time("byte.LowBit", () => { br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); br = b1.LowBit(); }, 5);
            bench.Time("sbyte.LowBit", () => { sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); sbr = sb1.LowBit(); }, 5);
            bench.Time("ushort.LowBit", () => { usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); usr = us1.LowBit(); }, 5);
            bench.Time("short.LowBit", () => { sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); sr = s1.LowBit(); }, 5);
            bench.Time("uint.LowBit", () => { uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); uir = ui1.LowBit(); }, 5);
            bench.Time("int.LowBit", () => { ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); ir = i1.LowBit(); }, 5);
            bench.Time("ulong.LowBit", () => { ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); ulr = ul1.LowBit(); }, 5);
            bench.Time("long.LowBit", () => { lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); lr = l1.LowBit(); }, 5);
            bench.Time("UInt128.LowBit", () => { ullr = ull1.LowBit(); ullr = ull1.LowBit(); ullr = ull1.LowBit(); ullr = ull1.LowBit(); ullr = ull1.LowBit(); }, 5);
            bench.Time("byte.HighBit", () => { br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); br = b1.HighBit(); }, 5);
            bench.Time("sbyte.HighBit", () => { sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); sbr = sb1.HighBit(); }, 5);
            bench.Time("ushort.HighBit", () => { usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); usr = us1.HighBit(); }, 5);
            bench.Time("short.HighBit", () => { sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); sr = s1.HighBit(); }, 5);
            bench.Time("uint.HighBit", () => { uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); uir = ui1.HighBit(); }, 5);
            bench.Time("int.HighBit", () => { ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); ir = i1.HighBit(); }, 5);
            bench.Time("ulong.HighBit", () => { ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); ulr = ul1.HighBit(); }, 5);
            bench.Time("long.HighBit", () => { lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); lr = l1.HighBit(); }, 5);
            bench.Time("UInt128.HighBit", () => { ullr = ull1.HighBit(); ullr = ull1.HighBit(); ullr = ull1.HighBit(); ullr = ull1.HighBit(); ullr = ull1.HighBit(); }, 5);
            bench.Time("byte.LowBitPosition", () => { ir = b1.LowBitPosition(); ir = b1.LowBitPosition(); ir = b1.LowBitPosition(); ir = b1.LowBitPosition(); ir = b1.LowBitPosition(); }, 5);
            bench.Time("sbyte.LowBitPosition", () => { ir = sb1.LowBitPosition(); ir = sb1.LowBitPosition(); ir = sb1.LowBitPosition(); ir = sb1.LowBitPosition(); ir = sb1.LowBitPosition(); }, 5);
            bench.Time("ushort.LowBitPosition", () => { ir = us1.LowBitPosition(); ir = us1.LowBitPosition(); ir = us1.LowBitPosition(); ir = us1.LowBitPosition(); ir = us1.LowBitPosition(); }, 5);
            bench.Time("short.LowBitPosition", () => { ir = s1.LowBitPosition(); ir = s1.LowBitPosition(); ir = s1.LowBitPosition(); ir = s1.LowBitPosition(); ir = s1.LowBitPosition(); }, 5);
            bench.Time("uint.LowBitPosition", () => { ir = ui1.LowBitPosition(); ir = ui1.LowBitPosition(); ir = ui1.LowBitPosition(); ir = ui1.LowBitPosition(); ir = ui1.LowBitPosition(); }, 5);
            bench.Time("int.LowBitPosition", () => { ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); ir = i1.LowBitPosition(); }, 5);
            bench.Time("ulong.LowBitPosition", () => { ir = ul1.LowBitPosition(); ir = ul1.LowBitPosition(); ir = ul1.LowBitPosition(); ir = ul1.LowBitPosition(); ir = ul1.LowBitPosition(); }, 5);
            bench.Time("long.LowBitPosition", () => { ir = l1.LowBitPosition(); ir = l1.LowBitPosition(); ir = l1.LowBitPosition(); ir = l1.LowBitPosition(); ir = l1.LowBitPosition(); }, 5);
            bench.Time("UInt128.LowBitPosition", () => { ir = ull1.LowBitPosition(); ir = ull1.LowBitPosition(); ir = ull1.LowBitPosition(); ir = ull1.LowBitPosition(); ir = ull1.LowBitPosition(); }, 5);
            bench.Time("byte.HighBitPosition", () => { ir = b1.HighBitPosition(); ir = b1.HighBitPosition(); ir = b1.HighBitPosition(); ir = b1.HighBitPosition(); ir = b1.HighBitPosition(); }, 5);
            bench.Time("sbyte.HighBitPosition", () => { ir = sb1.HighBitPosition(); ir = sb1.HighBitPosition(); ir = sb1.HighBitPosition(); ir = sb1.HighBitPosition(); ir = sb1.HighBitPosition(); }, 5);
            bench.Time("ushort.HighBitPosition", () => { ir = us1.HighBitPosition(); ir = us1.HighBitPosition(); ir = us1.HighBitPosition(); ir = us1.HighBitPosition(); ir = us1.HighBitPosition(); }, 5);
            bench.Time("short.HighBitPosition", () => { ir = s1.HighBitPosition(); ir = s1.HighBitPosition(); ir = s1.HighBitPosition(); ir = s1.HighBitPosition(); ir = s1.HighBitPosition(); }, 5);
            bench.Time("uint.HighBitPosition", () => { ir = ui1.HighBitPosition(); ir = ui1.HighBitPosition(); ir = ui1.HighBitPosition(); ir = ui1.HighBitPosition(); ir = ui1.HighBitPosition(); }, 5);
            bench.Time("int.HighBitPosition", () => { ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); ir = i1.HighBitPosition(); }, 5);
            bench.Time("ulong.HighBitPosition", () => { ir = ul1.HighBitPosition(); ir = ul1.HighBitPosition(); ir = ul1.HighBitPosition(); ir = ul1.HighBitPosition(); ir = ul1.HighBitPosition(); }, 5);
            bench.Time("long.HighBitPosition", () => { ir = l1.HighBitPosition(); ir = l1.HighBitPosition(); ir = l1.HighBitPosition(); ir = l1.HighBitPosition(); ir = l1.HighBitPosition(); }, 5);
            bench.Time("UInt128.HighBitPosition", () => { ir = ull1.HighBitPosition(); ir = ull1.HighBitPosition(); ir = ull1.HighBitPosition(); ir = ull1.HighBitPosition(); ir = ull1.HighBitPosition(); }, 5);
            bench.Time("byte.TrailingZeroBits", () => { ir = b1.TrailingZeroBits(); ir = b1.TrailingZeroBits(); ir = b1.TrailingZeroBits(); ir = b1.TrailingZeroBits(); ir = b1.TrailingZeroBits(); }, 5);
            bench.Time("sbyte.TrailingZeroBits", () => { ir = sb1.TrailingZeroBits(); ir = sb1.TrailingZeroBits(); ir = sb1.TrailingZeroBits(); ir = sb1.TrailingZeroBits(); ir = sb1.TrailingZeroBits(); }, 5);
            bench.Time("ushort.TrailingZeroBits", () => { ir = us1.TrailingZeroBits(); ir = us1.TrailingZeroBits(); ir = us1.TrailingZeroBits(); ir = us1.TrailingZeroBits(); ir = us1.TrailingZeroBits(); }, 5);
            bench.Time("short.TrailingZeroBits", () => { ir = s1.TrailingZeroBits(); ir = s1.TrailingZeroBits(); ir = s1.TrailingZeroBits(); ir = s1.TrailingZeroBits(); ir = s1.TrailingZeroBits(); }, 5);
            bench.Time("uint.TrailingZeroBits", () => { ir = ui1.TrailingZeroBits(); ir = ui1.TrailingZeroBits(); ir = ui1.TrailingZeroBits(); ir = ui1.TrailingZeroBits(); ir = ui1.TrailingZeroBits(); }, 5);
            bench.Time("int.TrailingZeroBits", () => { ir = i1.TrailingZeroBits(); ir = i1.TrailingZeroBits(); ir = i1.TrailingZeroBits(); ir = i1.TrailingZeroBits(); ir = i1.TrailingZeroBits(); }, 5);
            bench.Time("ulong.TrailingZeroBits", () => { ir = ul1.TrailingZeroBits(); ir = ul1.TrailingZeroBits(); ir = ul1.TrailingZeroBits(); ir = ul1.TrailingZeroBits(); ir = ul1.TrailingZeroBits(); }, 5);
            bench.Time("long.TrailingZeroBits", () => { ir = l1.TrailingZeroBits(); ir = l1.TrailingZeroBits(); ir = l1.TrailingZeroBits(); ir = l1.TrailingZeroBits(); ir = l1.TrailingZeroBits(); }, 5);
            bench.Time("UInt128.TrailingZeroBits", () => { ir = ull1.TrailingZeroBits(); ir = ull1.TrailingZeroBits(); ir = ull1.TrailingZeroBits(); ir = ull1.TrailingZeroBits(); ir = ull1.TrailingZeroBits(); }, 5);
            bench.Time("byte.LeadingZeroBits", () => { ir = b1.LeadingZeroBits(); ir = b1.LeadingZeroBits(); ir = b1.LeadingZeroBits(); ir = b1.LeadingZeroBits(); ir = b1.LeadingZeroBits(); }, 5);
            bench.Time("sbyte.LeadingZeroBits", () => { ir = sb1.LeadingZeroBits(); ir = sb1.LeadingZeroBits(); ir = sb1.LeadingZeroBits(); ir = sb1.LeadingZeroBits(); ir = sb1.LeadingZeroBits(); }, 5);
            bench.Time("ushort.LeadingZeroBits", () => { ir = us1.LeadingZeroBits(); ir = us1.LeadingZeroBits(); ir = us1.LeadingZeroBits(); ir = us1.LeadingZeroBits(); ir = us1.LeadingZeroBits(); }, 5);
            bench.Time("short.LeadingZeroBits", () => { ir = s1.LeadingZeroBits(); ir = s1.LeadingZeroBits(); ir = s1.LeadingZeroBits(); ir = s1.LeadingZeroBits(); ir = s1.LeadingZeroBits(); }, 5);
            bench.Time("uint.LeadingZeroBits", () => { ir = ui1.LeadingZeroBits(); ir = ui1.LeadingZeroBits(); ir = ui1.LeadingZeroBits(); ir = ui1.LeadingZeroBits(); ir = ui1.LeadingZeroBits(); }, 5);
            bench.Time("int.LeadingZeroBits", () => { ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); ir = i1.LeadingZeroBits(); }, 5);
            bench.Time("ulong.LeadingZeroBits", () => { ir = ul1.LeadingZeroBits(); ir = ul1.LeadingZeroBits(); ir = ul1.LeadingZeroBits(); ir = ul1.LeadingZeroBits(); ir = ul1.LeadingZeroBits(); }, 5);
            bench.Time("long.LeadingZeroBits", () => { ir = l1.LeadingZeroBits(); ir = l1.LeadingZeroBits(); ir = l1.LeadingZeroBits(); ir = l1.LeadingZeroBits(); ir = l1.LeadingZeroBits(); }, 5);
            bench.Time("UInt128.LeadingZeroBits", () => { ir = ull1.LeadingZeroBits(); ir = ull1.LeadingZeroBits(); ir = ull1.LeadingZeroBits(); ir = ull1.LeadingZeroBits(); ir = ull1.LeadingZeroBits(); }, 5);
            bench.Time("byte.BitCount", () => { ir = b1.BitCount(); ir = b1.BitCount(); ir = b1.BitCount(); ir = b1.BitCount(); ir = b1.BitCount(); }, 5);
            bench.Time("sbyte.BitCount", () => { ir = sb1.BitCount(); ir = sb1.BitCount(); ir = sb1.BitCount(); ir = sb1.BitCount(); ir = sb1.BitCount(); }, 5);
            bench.Time("ushort.BitCount", () => { ir = us1.BitCount(); ir = us1.BitCount(); ir = us1.BitCount(); ir = us1.BitCount(); ir = us1.BitCount(); }, 5);
            bench.Time("short.BitCount", () => { ir = s1.BitCount(); ir = s1.BitCount(); ir = s1.BitCount(); ir = s1.BitCount(); ir = s1.BitCount(); }, 5);
            bench.Time("uint.BitCount", () => { ir = ui1.BitCount(); ir = ui1.BitCount(); ir = ui1.BitCount(); ir = ui1.BitCount(); ir = ui1.BitCount(); }, 5);
            bench.Time("int.BitCount", () => { ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); ir = i1.BitCount(); }, 5);
            bench.Time("ulong.BitCount", () => { ir = ul1.BitCount(); ir = ul1.BitCount(); ir = ul1.BitCount(); ir = ul1.BitCount(); ir = ul1.BitCount(); }, 5);
            bench.Time("long.BitCount", () => { ir = l1.BitCount(); ir = l1.BitCount(); ir = l1.BitCount(); ir = l1.BitCount(); ir = l1.BitCount(); }, 5);
            bench.Time("UInt128.BitCount", () => { ir = ull1.BitCount(); ir = ull1.BitCount(); ir = ull1.BitCount(); ir = ull1.BitCount(); ir = ull1.BitCount(); }, 5);
            bench.Time("byte.ReverseBits", () => { br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); br = b1.ReverseBits(); }, 5);
            bench.Time("sbyte.ReverseBits", () => { sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); sbr = sb1.ReverseBits(); }, 5);
            bench.Time("ushort.ReverseBits", () => { usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); usr = us1.ReverseBits(); }, 5);
            bench.Time("short.ReverseBits", () => { sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); sr = s1.ReverseBits(); }, 5);
            bench.Time("uint.ReverseBits", () => { uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); uir = ui1.ReverseBits(); }, 5);
            bench.Time("int.ReverseBits", () => { ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); ir = i1.ReverseBits(); }, 5);
            bench.Time("ulong.ReverseBits", () => { ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); ulr = ul1.ReverseBits(); }, 5);
            bench.Time("long.ReverseBits", () => { lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); lr = l1.ReverseBits(); }, 5);
            bench.Time("UInt128.ReverseBits", () => { ullr = ull1.ReverseBits(); ullr = ull1.ReverseBits(); ullr = ull1.ReverseBits(); ullr = ull1.ReverseBits(); ullr = ull1.ReverseBits(); }, 5);
        }
    }
}

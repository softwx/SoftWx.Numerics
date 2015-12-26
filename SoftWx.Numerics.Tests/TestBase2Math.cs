// Copyright ©2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
using NUnit.Framework;

namespace SoftWx.Numerics.Tests {
    /// <summary></summary>
    [TestFixture]
    public class TestBase2Math {

        [Test]
        public void Log2UnsignedOf0ShouldReturnMaxValue() {
            Assert.AreEqual(byte.MaxValue, Base2Math.Log2((byte)0), "byte");
            Assert.AreEqual(ushort.MaxValue, Base2Math.Log2((ushort)0), "ushort");
            Assert.AreEqual(uint.MaxValue, Base2Math.Log2((uint)0), "uint");
            Assert.AreEqual(ulong.MaxValue, Base2Math.Log2((ulong)0), "ulong");
        }

        [Test]
        public void Log2SignedOf0ShouldReturnNeg1() {
            Assert.AreEqual(-1, Base2Math.Log2((sbyte)0), "sbyte");
            Assert.AreEqual(-1, Base2Math.Log2((short)0), "short");
            Assert.AreEqual(-1, Base2Math.Log2((int)0), "int");
            Assert.AreEqual(-1, Base2Math.Log2((long)0), "long");
        }

        [Test]
        public void Log2SignedOfNegativeShouldReturnNeg1() {
            Assert.AreEqual(-1, Base2Math.Log2((sbyte)-10), "sbyte");
            Assert.AreEqual(-1, Base2Math.Log2((short)-10), "short");
            Assert.AreEqual(-1, Base2Math.Log2((int)-10), "int");
            Assert.AreEqual(-1, Base2Math.Log2((long)-10), "long");
        }

        [Test]
        public void Log2Of1ShouldReturn0() {
            Assert.AreEqual(0, Base2Math.Log2((byte)1), "byte");
            Assert.AreEqual(0, Base2Math.Log2((sbyte)1), "sbyte");
            Assert.AreEqual(0, Base2Math.Log2((ushort)1), "ushort");
            Assert.AreEqual(0, Base2Math.Log2((short)1), "short");
            Assert.AreEqual(0, Base2Math.Log2((uint)1), "uint");
            Assert.AreEqual(0, Base2Math.Log2((int)1), "int");
            Assert.AreEqual(0, Base2Math.Log2((ulong)1), "ulong");
            Assert.AreEqual(0, Base2Math.Log2((long)1), "long");
        }

        [Test]
        public void Log2Of2ShouldReturn1() {
            Assert.AreEqual(1, Base2Math.Log2((byte)2), "byte");
            Assert.AreEqual(1, Base2Math.Log2((sbyte)2), "sbyte");
            Assert.AreEqual(1, Base2Math.Log2((ushort)2), "ushort");
            Assert.AreEqual(1, Base2Math.Log2((short)2), "short");
            Assert.AreEqual(1, Base2Math.Log2((uint)2), "uint");
            Assert.AreEqual(1, Base2Math.Log2((int)2), "int");
            Assert.AreEqual(1, Base2Math.Log2((ulong)2), "ulong");
            Assert.AreEqual(1, Base2Math.Log2((long)2), "long");
        }

        [Test]
        public void Log2Of10ShouldReturn3() {
            Assert.AreEqual(3, Base2Math.Log2((byte)10), "byte");
            Assert.AreEqual(3, Base2Math.Log2((sbyte)10), "sbyte");
            Assert.AreEqual(3, Base2Math.Log2((ushort)10), "ushort");
            Assert.AreEqual(3, Base2Math.Log2((short)10), "short");
            Assert.AreEqual(3, Base2Math.Log2((uint)10), "uint");
            Assert.AreEqual(3, Base2Math.Log2((int)10), "int");
            Assert.AreEqual(3, Base2Math.Log2((ulong)10), "ulong");
            Assert.AreEqual(3, Base2Math.Log2((long)10), "long");
        }

        [Test]
        public void Log2UnsignedByteShouldMatchWider() {
            byte v = 1;
            while (true) {
                byte expected = Base2Math.Log2(v);
                Assert.AreEqual((ushort)expected, Base2Math.Log2((ushort)v), "ushort=>" + v);
                Assert.AreEqual((short)expected, Base2Math.Log2((short)v), "short=>" + v);
                Assert.AreEqual((uint)expected, Base2Math.Log2((uint)v), "uint=>" + v);
                Assert.AreEqual((int)expected, Base2Math.Log2((int)v), "int=>" + v);
                Assert.AreEqual((ulong)expected, Base2Math.Log2((ulong)v), "ulong=>" + v);
                Assert.AreEqual((long)expected, Base2Math.Log2((long)v), "long=>" + v);
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void Log2SignedByteShouldMatchWider() {
            sbyte v = sbyte.MinValue;
            while (true) {
                sbyte expected = Base2Math.Log2(v);
                Assert.AreEqual((short)expected, Base2Math.Log2((short)v), "short");
                Assert.AreEqual((int)expected, Base2Math.Log2((int)v), "int");
                Assert.AreEqual((long)expected, Base2Math.Log2((long)v), "long");
                if (v == sbyte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void IsPowerOf2SignedOfNegativeShouldReturnFalse() {
            Assert.AreEqual(false, Base2Math.IsPowerOf2((sbyte)-10), "sbyte");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((short)-10), "short");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((int)-10), "int");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((long)-10), "long");
        }

        [Test]
        public void IsPowerOf2Of0ShouldReturnFalse() {
            Assert.AreEqual(false, Base2Math.IsPowerOf2((byte)0), "byte");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((sbyte)0), "sbyte");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((ushort)0), "ushort");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((short)0), "short");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((uint)0), "uint");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((int)0), "int");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((ulong)0), "ulong");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((long)0), "long");
        }

        [Test]
        public void IsPowerOf2Of1ShouldReturnTrue() {
            Assert.AreEqual(true, Base2Math.IsPowerOf2((byte)1), "byte");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((sbyte)1), "sbyte");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((ushort)1), "ushort");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((short)1), "short");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((uint)1), "uint");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((int)1), "int");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((ulong)1), "ulong");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((long)1), "long");
        }

        [Test]
        public void IsPowerOf2Of2ShouldReturnTrue() {
            Assert.AreEqual(true, Base2Math.IsPowerOf2((byte)2), "byte");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((sbyte)2), "sbyte");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((ushort)2), "ushort");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((short)2), "short");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((uint)2), "uint");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((int)2), "int");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((ulong)2), "ulong");
            Assert.AreEqual(true, Base2Math.IsPowerOf2((long)2), "long");
        }

        [Test]
        public void IsPowerOf2Of3ShouldReturnFalse() {
            Assert.AreEqual(false, Base2Math.IsPowerOf2((byte)3), "byte");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((sbyte)3), "sbyte");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((ushort)3), "ushort");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((short)3), "short");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((uint)3), "uint");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((int)3), "int");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((ulong)3), "ulong");
            Assert.AreEqual(false, Base2Math.IsPowerOf2((long)3), "long");
        }

        [Test]
        public void IsPowerOf2UnsignedByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                bool expected = Base2Math.IsPowerOf2(v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((ushort)v), "ushort=>" + v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((short)v), "short=>" + v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((uint)v), "uint=>" + v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((int)v), "int=>" + v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((ulong)v), "ulong=>" + v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((long)v), "long=>" + v);
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void IsPowerOf2SignedByteShouldMatchWider() {
            sbyte v = sbyte.MinValue;
            while (true) {
                bool expected = Base2Math.IsPowerOf2(v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((short)v), "short=>" + v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((int)v), "int=>" + v);
                Assert.AreEqual(expected, Base2Math.IsPowerOf2((long)v), "long=>" + v);
                if (v == sbyte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void PowerOf2FloorOf0ShouldReturn0() {
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((byte)0), "byte");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((sbyte)0), "sbyte");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((ushort)0), "ushort");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((short)0), "short");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((uint)0), "uint");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((int)0), "int");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((ulong)0), "ulong");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((long)0), "long");
        }

        [Test]
        public void PowerOf2FloorOfNegativeShouldReturn0() {
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((sbyte)-10), "sbyte");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((short)-10), "short");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((int)-10), "int");
            Assert.AreEqual(0, Base2Math.PowerOf2Floor((long)-10), "long");
        }

        [Test]
        public void PowerOf2FloorOf1ShouldReturn1() {
            Assert.AreEqual(1, Base2Math.PowerOf2Floor((byte)1), "byte");
            Assert.AreEqual(1, Base2Math.PowerOf2Floor((sbyte)1), "sbyte");
            Assert.AreEqual(1, Base2Math.PowerOf2Floor((ushort)1), "ushort");
            Assert.AreEqual(1, Base2Math.PowerOf2Floor((short)1), "short");
            Assert.AreEqual(1, Base2Math.PowerOf2Floor((uint)1), "uint");
            Assert.AreEqual(1, Base2Math.PowerOf2Floor((int)1), "int");
            Assert.AreEqual(1, Base2Math.PowerOf2Floor((ulong)1), "ulong");
            Assert.AreEqual(1, Base2Math.PowerOf2Floor((long)1), "long");
        }

        [Test]
        public void PowerOf2FloorOf3ShouldReturn2() { 
            Assert.AreEqual(2, Base2Math.PowerOf2Floor((byte)3), "byte");
            Assert.AreEqual(2, Base2Math.PowerOf2Floor((sbyte)3), "sbyte");
            Assert.AreEqual(2, Base2Math.PowerOf2Floor((ushort)3), "ushort");
            Assert.AreEqual(2, Base2Math.PowerOf2Floor((short)3), "short");
            Assert.AreEqual(2, Base2Math.PowerOf2Floor((uint)3), "uint");
            Assert.AreEqual(2, Base2Math.PowerOf2Floor((int)3), "int");
            Assert.AreEqual(2, Base2Math.PowerOf2Floor((ulong)3), "ulong");
            Assert.AreEqual(2, Base2Math.PowerOf2Floor((long)3), "long");
        }

        [Test]
        public void PowerOf2FloorUnsignedByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                byte expected = Base2Math.PowerOf2Floor(v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((ushort)v), "ushort=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((short)v), "short=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((uint)v), "uint=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((int)v), "int=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((ulong)v), "ulong=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((long)v), "long=>" + v);
                if (v == byte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void PowerOf2FloorSignedByteShouldMatchWider() {
            sbyte v = sbyte.MinValue;
            while (true) {
                sbyte expected = Base2Math.PowerOf2Floor(v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((short)v), "short=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((int)v), "int=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Floor((long)v), "long=>" + v);
                if (v == sbyte.MaxValue) break;
                v++;
            }
        }

        [Test]
        public void PowerOf2CeilingOf0ShouldReturn1() {
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((byte)0), "byte");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((sbyte)0), "sbyte");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((ushort)0), "ushort");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((short)0), "short");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((uint)0), "uint");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((int)0), "int");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((ulong)0), "ulong");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((long)0), "long");
        }

        [Test]
        public void PowerOf2CeilingOfNegativeShouldReturn1() {
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((sbyte)-10), "sbyte");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((short)-10), "short");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((int)-10), "int");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((long)-10), "long");
        }

        [Test]
        public void PowerOf2CeilingOf1ShouldReturn1() {
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((byte)1), "byte");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((sbyte)1), "sbyte");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((ushort)1), "ushort");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((short)1), "short");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((uint)1), "uint");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((int)1), "int");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((ulong)1), "ulong");
            Assert.AreEqual(1, Base2Math.PowerOf2Ceiling((long)1), "long");
        }

        [Test]
        public void PowerOf2CeilingOf3ShouldReturn4() {
            Assert.AreEqual(4, Base2Math.PowerOf2Ceiling((byte)3), "byte");
            Assert.AreEqual(4, Base2Math.PowerOf2Ceiling((sbyte)3), "sbyte");
            Assert.AreEqual(4, Base2Math.PowerOf2Ceiling((ushort)3), "ushort");
            Assert.AreEqual(4, Base2Math.PowerOf2Ceiling((short)3), "short");
            Assert.AreEqual(4, Base2Math.PowerOf2Ceiling((uint)3), "uint");
            Assert.AreEqual(4, Base2Math.PowerOf2Ceiling((int)3), "int");
            Assert.AreEqual(4, Base2Math.PowerOf2Ceiling((ulong)3), "ulong");
            Assert.AreEqual(4, Base2Math.PowerOf2Ceiling((long)3), "long");
        }

        [Test]
        public void PowerOf2CeilingOfMaxValueShouldReturn0() {
            Assert.AreEqual(0, Base2Math.PowerOf2Ceiling(byte.MaxValue), "byte");
            Assert.AreEqual(0, Base2Math.PowerOf2Ceiling(sbyte.MaxValue), "sbyte");
            Assert.AreEqual(0, Base2Math.PowerOf2Ceiling(ushort.MaxValue), "ushort");
            Assert.AreEqual(0, Base2Math.PowerOf2Ceiling(short.MaxValue), "short");
            Assert.AreEqual(0, Base2Math.PowerOf2Ceiling(uint.MaxValue), "uint");
            Assert.AreEqual(0, Base2Math.PowerOf2Ceiling(int.MaxValue), "int");
            Assert.AreEqual(0, Base2Math.PowerOf2Ceiling(ulong.MaxValue), "ulong");
            Assert.AreEqual(0, Base2Math.PowerOf2Ceiling(long.MaxValue), "long");
        }

        [Test]
        public void PowerOf2CeilingUnsignedByteShouldMatchWider() {
            byte v = byte.MinValue;
            while (true) {
                byte expected = Base2Math.PowerOf2Ceiling(v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((ushort)v), "ushort=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((short)v), "short=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((uint)v), "uint=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((int)v), "int=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((ulong)v), "ulong=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((long)v), "long=>" + v);
                if (v == byte.MaxValue >> 1) break;
                v++;
            }
        }

        [Test]
        public void PowerOf2CeilingSignedByteShouldMatchWider() {
            sbyte v = sbyte.MinValue;
            while (true) {
                sbyte expected = Base2Math.PowerOf2Ceiling(v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((short)v), "short=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((int)v), "int=>" + v);
                Assert.AreEqual(expected, Base2Math.PowerOf2Ceiling((long)v), "long=>" + v);
                if (v == sbyte.MaxValue >> 1) break;
                v++;
            }
        }
    }
}

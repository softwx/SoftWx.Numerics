// Copyright ©2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
using NUnit.Framework;

namespace SoftWx.Numerics.Tests {
    /// <summary></summary>
    [TestFixture]
    public class TestMath {
        [Test]
        public void AbsU0ShouldReturn0() {
            Assert.AreEqual(0, Math.AbsU((sbyte)0), "sbyte");
            Assert.AreEqual(0, Math.AbsU((short)0), "short");
            Assert.AreEqual(0, Math.AbsU((int)0), "int");
            Assert.AreEqual(0, Math.AbsU((long)0), "long");
        }

        [Test]
        public void AbsU1ShouldReturn1() {
            Assert.AreEqual(1, Math.AbsU((sbyte)1), "sbyte");
            Assert.AreEqual(1, Math.AbsU((short)1), "short");
            Assert.AreEqual(1, Math.AbsU((int)1), "int");
            Assert.AreEqual(1, Math.AbsU((long)1), "long");
        }

        [Test]
        public void AbsUNegative1ShouldReturn1() {
            Assert.AreEqual(1, Math.AbsU((sbyte)-1), "sbyte");
            Assert.AreEqual(1, Math.AbsU((short)-1), "short");
            Assert.AreEqual(1, Math.AbsU((int)-1), "int");
            Assert.AreEqual(1, Math.AbsU((long)-1), "long");
        }

        [Test]
        public void AbsUMaxValueShouldReturnMaxValue() {
            Assert.AreEqual(sbyte.MaxValue, Math.AbsU(sbyte.MaxValue), "sbyte");
            Assert.AreEqual(short.MaxValue, Math.AbsU(short.MaxValue), "short");
            Assert.AreEqual(int.MaxValue, Math.AbsU(int.MaxValue), "int");
            Assert.AreEqual(long.MaxValue, Math.AbsU(long.MaxValue), "long");
        }

        [Test]
        public void AbsUMinValueShouldReturnNegMinValue() {
            Assert.AreEqual(-(sbyte.MinValue+1), Math.AbsU(sbyte.MinValue)-1, "sbyte");
            Assert.AreEqual(-(short.MinValue+1), Math.AbsU(short.MinValue)-1, "short");
            Assert.AreEqual(-(int.MinValue+1), Math.AbsU(int.MinValue)-1, "int");
            Assert.AreEqual(-(long.MinValue+1), Math.AbsU(long.MinValue)-1, "long");
        }

        [Test]
        public void AbsUSByteShouldMatchWider() {
            sbyte v = sbyte.MinValue;
            while (true) {
                byte expected = Math.AbsU(v);
                Assert.AreEqual((ushort)expected, Math.AbsU((short)v), "short=>" + v);
                Assert.AreEqual((uint)expected, Math.AbsU((int)v), "int=>" + v);
                Assert.AreEqual((ulong)expected, Math.AbsU((long)v), "long=>" + v);
                if (v == sbyte.MaxValue) break;
                v++;
            }
        }
    }
}
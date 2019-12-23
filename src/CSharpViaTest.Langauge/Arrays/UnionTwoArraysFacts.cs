﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSharpViaTest.Langauge.Arrays
{
    public class UnionTwoArraysFacts
    {
        static T[] UnionArray<T>(T[] left, T[] right)
        {
            #region Please implement the method

            // You cannot use Union method provided by LINQ. You should write
            // your own implementation.
            // Note: A List<T> can be used to dynamically add/remove items.

            #endregion

            if (left == null || right == null)
                throw new ArgumentNullException(left == null ? nameof(left) : nameof(right));

            var unionSet = new HashSet<T>();
            foreach (var t in left)
            {
                unionSet.Add(t);
            }

            foreach (var t in right)
            {
                unionSet.Add(t);
            }

            var unionLength = unionSet.Count;
            var unionArray = new T[unionLength];
            unionSet.CopyTo(unionArray);
            return unionArray;
        }

        [Fact]
        public void should_combine_left_and_right()
        {
            var left = new[] {1, 2};
            var right = new[] {3, 4};

            int[] union = UnionArray(left, right);

            Assert.Equal(4, union.Length);
            Assert.Empty(new [] {1,2,3,4}.Except(union));
        }

        [Fact]
        public void should_merge_duplicates()
        {
            var left = new[] { 1, 2 };
            var right = new[] { 3, 2 };

            int[] union = UnionArray(left, right);

            Assert.Equal(3, union.Length);
            Assert.Empty(new[] { 1, 2, 3 }.Except(union));
        }

        [Fact]
        public void should_support_empty_array()
        {
            var left = Array.Empty<int>();
            var right = new[] { 3, 2 };

            int[] union = UnionArray(left, right);

            Assert.Equal(2, union.Length);
            Assert.Empty(new[] { 2, 3 }.Except(union));
        }

        [Fact]
        public void should_support_empty_arrays()
        {
            var left = Array.Empty<int>();
            var right = Array.Empty<int>();

            int[] union = UnionArray(left, right);

            Assert.Empty(union);
        }

        [Fact]
        public void should_throw_if_null()
        {
            var right = new[] {1, 2};
            Assert.Throws<ArgumentNullException>("left", () => UnionArray(null, right));
        }

        [Fact]
        public void should_throw_if_both_null()
        {
            Assert.Throws<ArgumentNullException>("left", () => UnionArray<int>(null, null));
        }
    }
}
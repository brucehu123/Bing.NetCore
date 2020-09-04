﻿using Bing.Datas.Queries;
using Bing.Datas.Queries.Criterias;
using Bing.Tests.Samples;
using Xunit;

namespace Bing.Tests.Datas.Queries.Criterias
{
    /// <summary>
    /// 测试double范围过滤条件
    /// </summary>
    public class DecimalSegmentCriteriaTest
    {
        /// <summary>
        /// 测试 - 获取查询条件
        /// </summary>
        [Fact]
        public void Test_GetPredicate()
        {
            DecimalSegmentCriteria<AggregateRootSample, decimal> criteria = new DecimalSegmentCriteria<AggregateRootSample, decimal>(t => t.DecimalValue, 1.1M, 10.1M);
            Assert.Equal("t => ((t.DecimalValue >= 1.1) AndAlso (t.DecimalValue <= 10.1))", criteria.GetPredicate().ToString());

            DecimalSegmentCriteria<AggregateRootSample, decimal?> criteria2 = new DecimalSegmentCriteria<AggregateRootSample, decimal?>(t => t.NullableDecimalValue, 1.1M, 10.1M);
            Assert.Equal("t => ((t.NullableDecimalValue >= 1.1) AndAlso (t.NullableDecimalValue <= 10.1))", criteria2.GetPredicate().ToString());
        }

        /// <summary>
        /// 测试 - 获取查询条件 - 设置边界
        /// </summary>
        [Fact]
        public void Test_GetPredicate_Boundary()
        {
            DecimalSegmentCriteria<AggregateRootSample, decimal> criteria = new DecimalSegmentCriteria<AggregateRootSample, decimal>(t => t.DecimalValue, 1.1M, 10.1M, Boundary.Neither);
            Assert.Equal("t => ((t.DecimalValue > 1.1) AndAlso (t.DecimalValue < 10.1))", criteria.GetPredicate().ToString());

            criteria = new DecimalSegmentCriteria<AggregateRootSample, decimal>(t => t.DecimalValue, 1.1M, 10.1M, Boundary.Left);
            Assert.Equal("t => ((t.DecimalValue >= 1.1) AndAlso (t.DecimalValue < 10.1))", criteria.GetPredicate().ToString());

            DecimalSegmentCriteria<AggregateRootSample, decimal?> criteria2 = new DecimalSegmentCriteria<AggregateRootSample, decimal?>(t => t.NullableDecimalValue, 1.1M, 10.1M, Boundary.Right);
            Assert.Equal("t => ((t.NullableDecimalValue > 1.1) AndAlso (t.NullableDecimalValue <= 10.1))", criteria2.GetPredicate().ToString());

            criteria2 = new DecimalSegmentCriteria<AggregateRootSample, decimal?>(t => t.NullableDecimalValue, 1.1M, 10.1M, Boundary.Both);
            Assert.Equal("t => ((t.NullableDecimalValue >= 1.1) AndAlso (t.NullableDecimalValue <= 10.1))", criteria2.GetPredicate().ToString());
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace GameEngine.Tests
{
    public class HealthDemageDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0, 100 };
            yield return new object[] { 10, 90 };
            yield return new object[] { 50, 50 };
            yield return new object[] { 101, 1 };
        }
    }
}

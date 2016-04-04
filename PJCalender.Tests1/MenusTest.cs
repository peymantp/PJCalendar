// <copyright file="MenusTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using PJCalender;

namespace PJCalender.Tests
{
    /// <summary>This class contains parameterized unit tests for Menus</summary>
    [PexClass(typeof(Menus))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class MenusTest
    {

    }
}

using NUnit.Framework;
using Tests.Tools;
using UnityEngine;

namespace Tests.EditMode
{
    public class TestHelperTests
    {
        [Test]
        public void ClearScene_ShouldClearAllGameObjectsExceptCameras()
        {
            // Arrange
            GameObject testObject1 = new GameObject("TestObject1");
            GameObject testObject2 = new GameObject("TestObject2");
            Camera testCamera = new GameObject("TestCamera").AddComponent<Camera>();

            // Act
            TestHelper.ClearScene();

            // Assert
            Assert.IsFalse(GameObject.Find("TestObject1"));
            Assert.IsFalse(GameObject.Find("TestObject2"));
            Assert.IsNotNull(GameObject.Find("TestCamera"));
        }

        [Test]
        public void GetTestReference_ShouldReturnValidTestReferenceInstance()
        {
            // Act
            TestReference result = TestHelper.GetTestReference();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<TestReference>(result);
        }
    }
}
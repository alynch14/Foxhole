using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerMovement
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerJump()
        {
            var player = new GameObject();
            var fox = player.AddComponent<FoxMovement>();
            Assert.AreEqual();
            yield return null;
        }
    }
}

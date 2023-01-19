using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

namespace UnityTestExtensions {
    public static class TestMenuItems {
        /// <summary>
        /// Runs all edit mode tests.
        /// </summary>
        [MenuItem("Tests/Test Extensions/Run Edit Mode Tests")]
        public static void RunEditModeTests() {
            RunTests(TestMode.EditMode);
        }

        /// <summary>
        /// Runs all play mode tests.
        /// </summary>
        [MenuItem("Tests/Test Extensions/Run Play Mode Tests")]
        public static void RunPlayModeTests() {
            RunTests(TestMode.PlayMode);
        }

        private static void RunTests(TestMode testModeToRun) {
            var testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
            var filter = new Filter() {
                testMode = testModeToRun
            };

            testRunnerApi.Execute(new ExecutionSettings(filter));
        }
    }
}

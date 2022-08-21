using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CrabStuff {
    public class Pointer
    {

        public static Vector3 GetPointerWorldPosition2D()
        {
            return GetPointerWorldPosition2D(Camera.main);
        }

        public static Vector3 GetPointerWorldPosition2D(Camera camera)
        {
            Vector3 v3 = GetPointerWorldPosition3D(Input.mousePosition, camera);
            v3.z = 0f;
            return v3;
        }

        public static Vector3 GetPointerWorldPosition3D()
        {
            return GetPointerWorldPosition3D(Input.mousePosition, Camera.main);
        }

        public static Vector3 GetPointerWorldPosition3D(Camera camera)
        {
            return GetPointerWorldPosition3D(Input.mousePosition, camera);
        }

        public static Vector3 GetPointerWorldPosition3D(Vector3 screenPos, Camera camera)
        {
            Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
            return worldPos;
        }
    }

    public class Loader
    {
        public static void Load(int scene) => SceneManager.LoadScene(scene);

        public static void Load(string scene) => SceneManager.LoadScene(scene);

        public static void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public static void NextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public class Angle
    {
        public static float GetFromVector(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }
    }

    public class PopUp
    {
        public static void PointerText(string text)
        {
            Vector3 position = Pointer.GetPointerWorldPosition2D();
        }
    }
}


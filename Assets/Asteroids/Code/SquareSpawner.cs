using System;
using UnityEngine;
using System.Collections.Generic;

namespace Asteroids.Code
{
    public sealed class SquareSpawner : MonoBehaviour
    {
        [SerializeField] public GameObject Object;
        [SerializeField] public Vector3 Position;
        [SerializeField] public float Lenght;

        public void Awake()
        {
            var square = new Square(Lenght, Position);

            foreach (var item in square.GetPOsitions())
            {
                var spawnedSquare = Instantiate(Object);
                spawnedSquare.transform.position = item;
            }
        }
    }

    public sealed class Square
    {
        public float SideLength;
        public float LineFreequency;
        public List<Vector3> Coordinates;
        public Vector3 SquareCenter;

        public Square(float lenght, Vector3 position, float freequency = 1.0f)
        {
            SideLength = lenght;
            LineFreequency = freequency;
            int points = (int)(SideLength / LineFreequency);
            CalculateValues(SideLength, points, SquareCenter);
        }

        public void CalculateValues(float length, int points, Vector3 center)
        {
            Coordinates = new List<Vector3>();

            var step = length / points;
            var xValue = length;
            var yValue = length;

            var xValues = new float[points * 2 + 1];
            var yValues = new float[points * 2 + 1];

            for (int i = 0; i < xValues.Length; i++)
            {
                xValues[i] = xValue;
                xValue -= step;

                yValues[i] = yValue;
                yValue -= step;
            }

            for (var i = 0; i < xValues.Length; i++)
            {
                for (var i2 = 0; i2 < yValues.Length; i2++)
                {
                    Console.Write("x={0}|", xValues[i]);
                    Console.Write("y={0}|", yValues[i2]);
                    var sum = Math.Abs(xValues[i]) + Math.Abs(yValues[i2]);
                    if (sum == length) Coordinates.Add(new Vector3(xValues[i], yValues[i2]));
                    Console.WriteLine("sum={0}", sum);
                }
            }
        }

        public List<Vector3> GetPOsitions()
        {
            return Coordinates;
        }
    }
}
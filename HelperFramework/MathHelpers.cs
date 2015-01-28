using System;
using System.Windows;

namespace HelperFramework
{
	public static class MathHelpers
	{
		public static Double DegreesToRadians(Double degrees)
		{
			return ((degrees / 360) * 2 * Math.PI);
		}
		public static Double RadiansToDegrees(Double radians)
		{
			return radians * ((360 / 2) / Math.PI);
		}

		public static Vector CreateVectorFromAngle(Double angleInDegrees, Double length)
		{
			Double x = Math.Sin(DegreesToRadians(angleInDegrees)) * length;
			Double y = Math.Cos(DegreesToRadians(angleInDegrees)) * length;
			return new Vector(x, y);
		}
		public static Vector CreateVectorFromAngle(Double angleInDegrees, Vector vector)
		{
			angleInDegrees = GetAngleFromVector(vector) + DegreesToRadians(angleInDegrees);
			Double length = GetLengthFromVector(vector);
			Double x = Math.Sin((angleInDegrees)) * length;
			Double y = Math.Cos((angleInDegrees)) * length;
			return new Vector(x, y);
		}
		public static Vector CreateVectorFromAngle(Double angleInDegrees, Vector vector, Double length)
		{
			angleInDegrees = GetAngleFromVector(vector) + DegreesToRadians(angleInDegrees);
			Double x = Math.Sin((angleInDegrees)) * length;
			Double y = Math.Cos((angleInDegrees)) * length;
			return new Vector(x, y);
		}

		public static Double GetLengthFromVector(Vector vector)
		{
			Double x = vector.X * vector.X;
			Double y = vector.Y * vector.Y;
			return Math.Sqrt(x + y);
		}

		public static Double GetAngleFromVector(Vector vector)
		{
			return Math.Atan(vector.X / vector.Y);
		}

		public static Boolean ContainsPoint(Point centre, Double radius, Point hitTest)
		{
			Double x = hitTest.X - centre.X;
			Double y = hitTest.Y - centre.Y;
			return radius * radius >= (x * x + y * y);
		}
	}
}

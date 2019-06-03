
using System;

namespace Orion.Analytics.LinearAlgebra.Sparse
{
	/// <summary> An index/data pairing with integer indices and double-precision data.
	/// Note that the length of the indices and the data need not be equal.
	/// Furthermore, the indices must be kept sorted in most cases.</summary>
	public class IntDoubleVectorPair
	{
		/// <summary> Integer indices</summary>
		public int[] Indices;

		/// <summary> Double-precision data</summary>
		public double[] Data;

		/// <summary> Constructor for IntDoubleVectorPair.</summary>
		/// <param name="indices">Indices</param>
		/// <param name="data">Data</param>
		public IntDoubleVectorPair(int[] indices, double[] data)
		{
			Indices = indices;
			Data = data;
		}

		/// <summary> Deep copy of the object</summary>
		public virtual IntDoubleVectorPair Clone()
		{
			int[] newIndex = new int[Indices.Length];
			double[] newData = new double[Data.Length];
			Array.Copy(Indices, 0, newIndex, 0, Indices.Length);
			Array.Copy(Data, 0, newData, 0, Data.Length);
			return new IntDoubleVectorPair(newIndex, newData);
		}

		/// <summary> Copy of the data between index[i] and index[i+1]</summary>
		public virtual double[] Copy(int i)
		{
			double[] copy = new double[Indices[i + 1] - Indices[i]];
			Array.Copy(Data, Indices[i], copy, 0, copy.Length);
			return copy;
		}
	}
}
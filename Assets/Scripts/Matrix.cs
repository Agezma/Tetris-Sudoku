using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Matrix<T> : IEnumerable<T>
{
    T[] matrix;

    public int Width { get; private set; }

    public int Height { get; private set; }

    public int Capacity { get; private set; }

    public void Initialize( int width, int height)
    {
        Width = width;
        Height = height;
        Capacity = width * height;
        matrix = new T[Capacity];
    }

    public Matrix(int width, int height)
    {
        Initialize(width, height);
    }

	public Matrix(T[,] copyFrom)
    {
        Initialize(copyFrom.GetLength(0), copyFrom.GetLength(1));

        for (int i = 0; i < Capacity; i++)
        {
            matrix[i] = copyFrom[i % Width, i / Width];
        }
    }

	public Matrix<T> Clone() {
        Matrix<T> aux = new Matrix<T>(Width, Height);      
      
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                aux[i, j] = this[i, j];
            }

        }
        return aux;
    }

	public void SetRangeTo(int x0, int y0, int x1, int y1, T item) 
    {
        int initPos = x0 + y0 * Width;
        int endPos = x1 + y1 * Width;

        for (int i = initPos; i < endPos; i++)
        {
            matrix[i] = item;
        }
    }

    public List<T> GetRange(int x0, int y0, int x1, int y1) {
        List<T> aux = new List<T>();

        int initPos = x0 + y0 * Width;
        int endPos = x1 + y1 * Width;

        for (int i = x0; i < x1; i++)
        {
            for (int j = y0; j < y1; j++)
            {
                aux.Add( matrix[i + j * Width]);
            }
        }
        return aux;
	}

    public T this[int x, int y] {
		get
        {
            Debug.Log(Width);
            var index = x + y * Width;     
            return matrix[index];
		}
		set 
        {
            var index = x + y * Width;
            matrix[index] = value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Capacity; i++)
        {
            yield return matrix[i];
        }
    }

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}
}

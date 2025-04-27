// Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Tetris.Block
using System.Collections.Generic;
using Tetris;

public abstract class Block
{
	private int rotationState;

	private Position offset;

	protected abstract Position[][] Tiles { get; }

	protected abstract Position StartOffset { get; }

	public abstract int Id { get; }

	public Block()
	{
		offset = new Position(StartOffset.Row, StartOffset.Column);
	}

	public IEnumerable<Position> TilePositions()
	{
		Position[] array = Tiles[rotationState];
		foreach (Position p in array)
		{
			yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
		}
	}

	public void RotateCW()
	{
		rotationState = (rotationState + 1) % Tiles.Length;
	}

	public void RotateCCW()
	{
		if (rotationState == 0)
		{
			rotationState = Tiles.Length - 1;
		}
		else
		{
			rotationState--;
		}
	}

	public void Move(int rows, int columns)
	{
		offset.Row += rows;
		offset.Column += columns;
	}

	public void Reset()
	{
		rotationState = 0;
		offset.Row = StartOffset.Row;
		offset.Column = StartOffset.Column;
	}
}

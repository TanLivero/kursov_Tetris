// Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Tetris.Gamesetka
public class Gamesetka
{
	private readonly int[,] setka;

	public int Rows { get; }

	public int Columns { get; }

	public int this[int r, int c]
	{
		get
		{
			return setka[r, c];
		}
		set
		{
			setka[r, c] = value;
		}
	}

	public Gamesetka(int rows, int columns)
	{
		Rows = rows;
		Columns = columns;
		setka = new int[rows, columns];
	}

	public bool IsInside(int r, int c)
	{
		return r >= 0 && r < Rows && c >= 0 && c < Columns;
	}

	public bool IsEmpty(int r, int c)
	{
		return IsInside(r, c) && setka[r, c] == 0;
	}

	public bool IsRowFull(int r)
	{
		for (int c = 0; c < Columns; c++)
		{
			if (setka[r, c] == 0)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsRowEmpty(int r)
	{
		for (int c = 0; c < Columns; c++)
		{
			if (setka[r, c] != 0)
			{
				return false;
			}
		}
		return true;
	}

	private void ClearRow(int r)
	{
		for (int c = 0; c < Columns; c++)
		{
			setka[r, c] = 0;
		}
	}

	private void MoveRowDown(int r, int numRows)
	{
		for (int c = 0; c < Columns; c++)
		{
			setka[r + numRows, c] = setka[r, c];
			setka[r, c] = 0;
		}
	}

	public int ClearFullRows()
	{
		int cleared = 0;
		for (int r = Rows - 1; r >= 0; r--)
		{
			if (IsRowFull(r))
			{
				ClearRow(r);
				cleared++;
			}
			else if (cleared > 0)
			{
				MoveRowDown(r, cleared);
			}
		}
		return cleared;
	}
}

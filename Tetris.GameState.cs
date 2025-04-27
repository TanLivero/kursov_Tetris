// Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Tetris.GameState
using System;
using Tetris;

public class GameState
{
	private Block currentBlock;

	public Block CurrentBlock
	{
		get
		{
			return currentBlock;
		}
		private set
		{
			currentBlock = value;
			currentBlock.Reset();
			for (int i = 0; i < 2; i++)
			{
				currentBlock.Move(1, 0);
				if (!BlockFits())
				{
					currentBlock.Move(-1, 0);
				}
			}
		}
	}

	public Gamesetka Gamesetka { get; }

	public BlockQueue BlockQueue { get; }

	public bool GameOver { get; private set; }

	public int Score { get; private set; }

	public Block HeldBlock { get; private set; }

	public bool CanHold { get; private set; }

	public GameState()
	{
		Gamesetka = new Gamesetka(22, 10);
		BlockQueue = new BlockQueue();
		CurrentBlock = BlockQueue.GetAndUpdate();
		CanHold = true;
	}

	private bool BlockFits()
	{
		foreach (Position p in CurrentBlock.TilePositions())
		{
			if (!Gamesetka.IsEmpty(p.Row, p.Column))
			{
				return false;
			}
		}
		return true;
	}

	public void HoldBlock()
	{
		if (CanHold)
		{
			if (HeldBlock == null)
			{
				HeldBlock = CurrentBlock;
				CurrentBlock = BlockQueue.GetAndUpdate();
			}
			else
			{
				Block tmp = CurrentBlock;
				CurrentBlock = HeldBlock;
				HeldBlock = tmp;
			}
			CanHold = false;
		}
	}

	public void RotateBlockCW()
	{
		CurrentBlock.RotateCW();
		if (!BlockFits())
		{
			CurrentBlock.RotateCCW();
		}
	}

	public void RotateBlockCCW()
	{
		CurrentBlock.RotateCCW();
		if (!BlockFits())
		{
			CurrentBlock.RotateCW();
		}
	}

	public void MoveBlockLeft()
	{
		CurrentBlock.Move(0, -1);
		if (!BlockFits())
		{
			CurrentBlock.Move(0, 1);
		}
	}

	public void MoveBlockRight()
	{
		CurrentBlock.Move(0, 1);
		if (!BlockFits())
		{
			CurrentBlock.Move(0, -1);
		}
	}

	private bool IsGameOver()
	{
		return !Gamesetka.IsRowEmpty(0) || !Gamesetka.IsRowEmpty(1);
	}

	private void PlaceBlock()
	{
		foreach (Position p in CurrentBlock.TilePositions())
		{
			Gamesetka[p.Row, p.Column] = CurrentBlock.Id;
		}
		Score += Gamesetka.ClearFullRows();
		if (IsGameOver())
		{
			GameOver = true;
			return;
		}
		CurrentBlock = BlockQueue.GetAndUpdate();
		CanHold = true;
	}

	public void MoveBlockDown()
	{
		CurrentBlock.Move(1, 0);
		if (!BlockFits())
		{
			CurrentBlock.Move(-1, 0);
			PlaceBlock();
		}
	}

	private int TileDropDistance(Position p)
	{
		int drop;
		for (drop = 0; Gamesetka.IsEmpty(p.Row + drop + 1, p.Column); drop++)
		{
		}
		return drop;
	}

	public int BlockDropDistance()
	{
		int drop = Gamesetka.Rows;
		foreach (Position p in CurrentBlock.TilePositions())
		{
			drop = Math.Min(drop, TileDropDistance(p));
		}
		return drop;
	}

	public void DropBlock()
	{
		CurrentBlock.Move(BlockDropDistance(), 0);
		PlaceBlock();
	}
}

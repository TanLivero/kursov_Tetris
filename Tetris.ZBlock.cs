// Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Tetris.ZBlock
using Tetris;

public class ZBlock : Block
{
	private readonly Position[][] tiles = new Position[4][]
	{
		new Position[4]
		{
			new Position(0, 0),
			new Position(0, 1),
			new Position(1, 1),
			new Position(1, 2)
		},
		new Position[4]
		{
			new Position(0, 2),
			new Position(1, 1),
			new Position(1, 2),
			new Position(2, 1)
		},
		new Position[4]
		{
			new Position(1, 0),
			new Position(1, 1),
			new Position(2, 1),
			new Position(2, 2)
		},
		new Position[4]
		{
			new Position(0, 1),
			new Position(1, 0),
			new Position(1, 1),
			new Position(2, 0)
		}
	};

	public override int Id => 7;

	protected override Position StartOffset => new Position(0, 3);

	protected override Position[][] Tiles => tiles;
}

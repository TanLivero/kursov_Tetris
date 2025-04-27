// Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Tetris.OBlock
using Tetris;

public class OBlock : Block
{
	private readonly Position[][] tiles = new Position[1][] { new Position[4]
	{
		new Position(0, 0),
		new Position(0, 1),
		new Position(1, 0),
		new Position(1, 1)
	} };

	public override int Id => 4;

	protected override Position StartOffset => new Position(0, 4);

	protected override Position[][] Tiles => tiles;
}

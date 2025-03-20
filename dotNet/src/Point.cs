class Point
{
	public int X { get; set; }
	public int Y { get; set; }

	public Point(int x, int y)
	{
		X = x;
		Y = y;
	}

	public override string ToString()
	{
		return $"({X}, {Y})";
	}
}
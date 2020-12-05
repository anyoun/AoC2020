<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main() {
	int valid = 0; int invalid = 0;
	foreach(var line in  File.ReadLines(@"c:\Users\willt\My Dropbox\Programming\AoC2020\Day 2\input_full.txt")){
		var m = Regex.Match(line, @"^(\d+)-(\d+) (.): (.+)$");
		if(!m.Success)
			throw new Exception("oh no");
		var min = Int32.Parse(m.Groups[1].Value);
		var max = Int32.Parse(m.Groups[2].Value);
		var ch = m.Groups[3].Value[0];
		var pw = m.Groups[4].Value;
		
		if( pw[min-1] ==ch  ^ pw[max-1] == ch)
			valid++;
		else
			invalid++;
	}
	String.Format("Found {0} valid, {1} invalid.", valid, invalid).Dump();
}

